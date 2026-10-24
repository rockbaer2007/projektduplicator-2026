using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Threading;

namespace Projektduplicator.Update
{
    [DataContract]
    internal sealed class UpdateJob
    {
        [DataMember] public string InstallDirectory { get; set; }
        [DataMember] public string ZipPath { get; set; }
        [DataMember] public string Sha256 { get; set; }
        [DataMember] public string Version { get; set; }
        [DataMember] public string BackupDirectory { get; set; }
        [DataMember] public int ProcessId { get; set; }
        [DataMember] public long ProcessStartTicks { get; set; }
        [DataMember] public string Language { get; set; }
    }

    internal static class UpdateCore
    {
        internal const string MainExe = "Projektduplicator_2017.exe";
        internal static string Hash(string path)
        {
            using (var file = File.OpenRead(path))
            using (var sha = SHA256.Create())
                return BitConverter.ToString(sha.ComputeHash(file)).Replace("-", "").ToLowerInvariant();
        }

        internal static void WriteJob(string path, UpdateJob job)
        {
            using (var file = File.Create(path)) new DataContractJsonSerializer(typeof(UpdateJob)).WriteObject(file, job);
        }

        internal static UpdateJob ReadJob(string path)
        {
            using (var file = File.OpenRead(path)) return (UpdateJob)new DataContractJsonSerializer(typeof(UpdateJob)).ReadObject(file);
        }

        internal static string RelativePath(string path)
        {
            string normalized = path.Replace('\\', '/');
            if (normalized.Length == 0 || normalized.StartsWith("/") || normalized.Contains(":") ||
                normalized.Any(character => char.IsControl(character)) ||
                normalized.Split('/').Any(part => part == "." || part == ".." || part.EndsWith(".") || part.EndsWith(" ")))
                throw new InvalidDataException("Invalid package path.");
            return normalized;
        }

        internal static string Target(string root, string relative)
        {
            string directory = Path.GetFullPath(root).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            string full = Path.GetFullPath(Path.Combine(directory, RelativePath(relative).Replace('/', Path.DirectorySeparatorChar)));
            if (!full.StartsWith(directory, StringComparison.OrdinalIgnoreCase)) throw new InvalidDataException("Path outside installation.");
            for (string current = Path.GetDirectoryName(full); current != null; current = Path.GetDirectoryName(current))
            {
                if (Directory.Exists(current) && (File.GetAttributes(current) & FileAttributes.ReparsePoint) != 0)
                    throw new InvalidDataException("Linked installation directory.");
            }
            if (File.Exists(full) && (File.GetAttributes(full) & FileAttributes.ReparsePoint) != 0)
                throw new InvalidDataException("Linked installation file.");
            return full;
        }

        internal static readonly string[] ProgramFiles = { MainExe, MainExe + ".config", "Projektduplicator.Updater.exe", "IniFile.dll", "Newtonsoft.Json.dll", "rbtools.dll", "RichTextBoxPrintCtrl.dll", "info.txt" };
        internal static bool Allowed(string relative)
        {
            if (ProgramFiles.Contains(relative, StringComparer.OrdinalIgnoreCase)) return true;
            return new[] { "de", "en", "fr", "nl" }.Any(locale => string.Equals(relative,
                locale + "/Projektduplicator_2017.resources.dll", StringComparison.OrdinalIgnoreCase));
        }

        // Personal configuration and project files are never accepted from an update ZIP.
        internal static bool Preserve(string relative) { return string.Equals(relative, "info.txt", StringComparison.OrdinalIgnoreCase); }

        internal static List<string> Extract(UpdateJob job, string staging, CancellationToken cancel = default(CancellationToken))
        {
            cancel.ThrowIfCancellationRequested();
            if (Hash(job.ZipPath) != job.Sha256) throw new InvalidDataException("Checksum differs.");
            var files = new List<string>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            long total = 0;
            using (var archive = ZipFile.OpenRead(job.ZipPath))
            {
                if (archive.Entries.Count > 2000) throw new InvalidDataException("Too many files.");
                foreach (var entry in archive.Entries)
                {
                    cancel.ThrowIfCancellationRequested();
                    string relative = RelativePath(entry.FullName.TrimEnd('/', '\\'));
                    if (!seen.Add(relative)) throw new InvalidDataException("Duplicate package path.");
                    int kind = (entry.ExternalAttributes >> 16) & 0xf000;
                    if (kind != 0 && kind != 0x8000 && kind != 0x4000) throw new InvalidDataException("Linked archive entry.");
                    if (entry.FullName.EndsWith("/") || entry.FullName.EndsWith("\\")) continue;
                    if (!Allowed(relative)) throw new InvalidDataException("Unexpected package file: " + relative);
                    total = checked(total + entry.Length);
                    if (entry.Length > 128L * 1024 * 1024 || total > 512L * 1024 * 1024)
                        throw new InvalidDataException("Package is too large.");
                    string destination = Target(staging, relative);
                    Directory.CreateDirectory(Path.GetDirectoryName(destination));
                    using (var input = entry.Open())
                    using (var output = new FileStream(destination, FileMode.CreateNew))
                    {
                        var buffer = new byte[81920];
                        long written = 0;
                        int count;
                        while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            cancel.ThrowIfCancellationRequested();
                            written += count;
                            if (written > entry.Length) throw new InvalidDataException("Invalid file size.");
                            output.Write(buffer, 0, count);
                        }
                        if (written != entry.Length) throw new InvalidDataException("Truncated package.");
                    }
                    files.Add(relative);
                }
            }
            foreach (string required in ProgramFiles.Concat(new[] { "de", "en", "fr", "nl" }
                .Select(locale => locale + "/Projektduplicator_2017.resources.dll")))
                if (!files.Contains(required, StringComparer.OrdinalIgnoreCase)) throw new InvalidDataException("Required file missing.");
            Version expected;
            if (!System.Version.TryParse(job.Version, out expected) ||
                Normalize(FileVersionInfo.GetVersionInfo(Target(staging, MainExe)).FileVersion) != Normalize(job.Version))
                throw new InvalidDataException("Executable version differs from release.");
            return files;
        }

        internal static string Normalize(string value)
        {
            var version = new Version(value);
            return new Version(version.Major, version.Minor, Math.Max(0, version.Build), Math.Max(0, version.Revision)).ToString();
        }

        private static void Replace(string source, string destination)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destination));
            string temporary = destination + ".pdup-update-" + Guid.NewGuid().ToString("N");
            File.Copy(source, temporary);
            try
            {
                if (File.Exists(destination)) File.Replace(temporary, destination, null);
                else File.Move(temporary, destination);
            }
            finally { if (File.Exists(temporary)) File.Delete(temporary); }
        }

        // Tests can interrupt a specific write to verify restoration after partial installation.
        internal static void Install(UpdateJob job, Action<int> beforeWrite = null)
        {
            string staging = Path.Combine(Path.GetDirectoryName(job.ZipPath), "extract-" + Guid.NewGuid().ToString("N"));
            var files = Extract(job, staging);
            if (!File.Exists(Target(job.InstallDirectory, MainExe))) throw new InvalidDataException("Installation not found.");
            if (Directory.Exists(job.BackupDirectory)) throw new InvalidDataException("Backup directory already exists.");
            Directory.CreateDirectory(job.BackupDirectory);
            foreach (string personal in new[] { "pdup_settings.xml", "Path.txt", "SplineID.txt", "HN_splineID.txt" })
            {
                string source = Target(job.InstallDirectory, personal);
                if (File.Exists(source)) File.Copy(source, Target(job.BackupDirectory, personal));
            }
            var existing = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var changed = new List<string>();
            var selected = files.Where(file => !(Preserve(file) && File.Exists(Target(job.InstallDirectory, file)))).ToList();
            foreach (string relative in files.Where(file => Preserve(file) && File.Exists(Target(job.InstallDirectory, file))))
            {
                string backup = Target(job.BackupDirectory, relative);
                Directory.CreateDirectory(Path.GetDirectoryName(backup));
                using (var source = new FileStream(Target(job.InstallDirectory, relative), FileMode.Open, FileAccess.Read, FileShare.None))
                using (var destination = File.Create(backup)) source.CopyTo(destination);
            }
            // Complete the backup and verify writable destinations before replacing the first file.
            foreach (string relative in selected)
            {
                string destination = Target(job.InstallDirectory, relative);
                if (File.Exists(destination))
                {
                    using (var probe = new FileStream(destination, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { }
                    string backup = Target(job.BackupDirectory, relative);
                    Directory.CreateDirectory(Path.GetDirectoryName(backup));
                    File.Copy(destination, backup);
                    existing.Add(relative);
                }
            }
            File.WriteAllLines(Path.Combine(job.BackupDirectory, "files.txt"), selected);
            try
            {
                foreach (string relative in selected)
                {
                    beforeWrite?.Invoke(changed.Count);
                    changed.Add(relative);
                    Replace(Target(staging, relative), Target(job.InstallDirectory, relative));
                }
                File.WriteAllText(Path.Combine(job.BackupDirectory, "result.txt"), "Installed " + job.Version);
            }
            catch (Exception failure)
            {
                var errors = new List<string>();
                foreach (string relative in changed.AsEnumerable().Reverse())
                {
                    try
                    {
                        string destination = Target(job.InstallDirectory, relative);
                        if (existing.Contains(relative)) Replace(Target(job.BackupDirectory, relative), destination);
                        else if (File.Exists(destination)) File.Delete(destination);
                    }
                    catch { errors.Add(relative); }
                }
                File.WriteAllText(Path.Combine(job.BackupDirectory, "result.txt"),
                    errors.Count == 0 ? "Installation failed; previous files restored." : "Restoration incomplete: " + string.Join(", ", errors));
                if (errors.Count != 0) throw new IOException("Restoration incomplete; see backup.", failure);
                throw new IOException("Installation failed; previous files restored.", failure);
            }
        }
    }
}

