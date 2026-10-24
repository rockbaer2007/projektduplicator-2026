using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Projektduplicator.Update;
using Projektduplicator_2017;

internal static class Tests
{
    // Render real controls without startup handlers that read projects or ping Google.
    private sealed class RenderEditor : editor
    {
        internal RenderEditor() : base((text, from, to) => text) { }
        protected override void OnLoad(EventArgs args) { }
    }
    private sealed class RenderMain : Form1
    {
        protected override void OnLoad(EventArgs args) { }
    }
    private sealed class FixtureSettings : PortableSettingsProvider
    {
        internal string DirectoryPath;
        public override string GetAppPath() { return DirectoryPath; }
    }
    private static string root, runtime;
    private static int passed;
    private static void Assert(bool value) { if (!value) throw new Exception("Assertion failed"); }
    private static void Test(string name, Action test) { test(); passed++; Console.WriteLine("PASS " + name); }
    private static void Fails(Action action) { bool failed = false; try { action(); } catch { failed = true; } Assert(failed); }
    private static string Folder() { string path = Path.Combine(root, Guid.NewGuid().ToString("N")); Directory.CreateDirectory(path); return path; }
    private sealed class Handler : HttpMessageHandler
    {
        internal Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> Reply;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token) { return Reply(request, token); }
    }
    private static string Metadata()
    {
        string prefix = "https://github.com/" + GithubUpdateClient.Repository + "/releases/download/v4.6.6.60/";
        return new JObject { ["tag_name"] = "v4.6.6.60", ["draft"] = false, ["prerelease"] = false, ["body"] = "Test release",
            ["assets"] = new JArray(
                new JObject { ["name"] = "Projektduplicator-2026-v4.6.6.60-windows.zip", ["browser_download_url"] = prefix + "Projektduplicator-2026-v4.6.6.60-windows.zip" },
                new JObject { ["name"] = "SHA256SUMS.txt", ["browser_download_url"] = prefix + "SHA256SUMS.txt" }) }.ToString();
    }
    private static GithubUpdateClient Client(string data, HttpStatusCode status = HttpStatusCode.OK)
    {
        return new GithubUpdateClient(new Handler { Reply = (request, token) => Task.FromResult(
            new HttpResponseMessage(status) { Content = new StringContent(data) }) });
    }
    private static UpdateJob Package(string extra = null, string omit = null)
    {
        string directory = Folder(), zip = Path.Combine(directory, "package.zip"), target = Path.Combine(directory, "installation");
        Directory.CreateDirectory(target);
        using (var archive = ZipFile.Open(zip, ZipArchiveMode.Create))
        {
            foreach (string name in UpdateCore.ProgramFiles.Concat(new[] { "de", "en", "fr", "nl" }.Select(locale => locale + "/Projektduplicator_2017.resources.dll")))
                if (name != omit) archive.CreateEntryFromFile(Path.Combine(runtime, name), name);
            if (extra != null) using (var writer = new StreamWriter(archive.CreateEntry(extra).Open())) writer.Write("UNEXPECTED");
        }
        File.WriteAllText(Path.Combine(target, UpdateCore.MainExe), "OLD MAIN");
        File.WriteAllText(Path.Combine(target, "IniFile.dll"), "OLD LIBRARY");
        File.WriteAllText(Path.Combine(target, "pdup_settings.xml"), "PERSONAL SETTINGS");
        File.WriteAllText(Path.Combine(target, "Path.txt"), "PERSONAL PATHS");
        Directory.CreateDirectory(Path.Combine(target, "projects", "model"));
        File.WriteAllText(Path.Combine(target, "projects", "model", "System.ini"), "PERSONAL MODEL");
        return new UpdateJob { ZipPath = zip, Sha256 = UpdateCore.Hash(zip), InstallDirectory = target,
            BackupDirectory = Path.Combine(directory, "backup"), Version = FileVersionInfo.GetVersionInfo(Path.Combine(runtime, UpdateCore.MainExe)).FileVersion };
    }
    private static object Field(object instance, string name) { return instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(instance); }
    private static TextBox Box(object instance, string name) { return (TextBox)Field(instance, name); }
    private static void Render(Form form, string name, bool show = false)
    {
        using (form)
        {
            form.StartPosition = FormStartPosition.Manual; form.Location = new Point(-20000, -20000); form.ShowInTaskbar = false;
            if (show) { form.Show(); Application.DoEvents(); }
            using (var image = new Bitmap(form.Width, form.Height)) { form.DrawToBitmap(image, new Rectangle(Point.Empty, form.Size)); image.Save(Path.Combine(root, name + ".png")); }
            form.Close();
        }
    }
    [STAThread]
    private static int Main(string[] args)
    {
        root = Path.Combine(Path.GetTempPath(), "projektduplicator-tests-" + Guid.NewGuid().ToString("N")); Directory.CreateDirectory(root);
        runtime = Path.GetFullPath(args[0]);
        try
        {
            Application.EnableVisualStyles();
            var settings = Projektduplicator_2017.Properties.Settings.Default;
            settings.pathNos = settings.pathNosDup = settings.pathNosDup_alt = root;
            settings.backup = Path.Combine(root, "backups"); settings.user_backup = Path.Combine(root, "snapshots");
            settings.id_code = "TEST"; settings.set_b = true;
            foreach (string locale in new[] { "de", "en", "fr", "nl" })
            {
                settings.country2 = locale;
                Test("complete resource keys " + locale, () => {
                    int count = 0;
                    foreach (string family in new[] { "langres", "iconres", "optionres" })
                    {
                        var resources = new ResourceManager("Projektduplicator_2017." + family, typeof(Form1).Assembly);
                        var baseline = resources.GetResourceSet(new CultureInfo("de"), true, false);
                        var translated = resources.GetResourceSet(new CultureInfo(locale), true, false);
                        foreach (System.Collections.DictionaryEntry entry in baseline) { Assert(translated.GetObject((string)entry.Key) != null); count++; }
                    }
                    Assert(count == 365);
                });
                Test("actual model-name and description button routing " + locale, () => {
                    var calls = new List<string>();
                    using (var form = new editor((text, from, to) => { calls.Add(text + ":" + from + ":" + to); return to + "=" + text; }))
                    {
                        Box(form, "tb2").Text = "EN NAME"; Box(form, "tb3").Text = "DE NAME";
                        Box(form, "tb6").Text = "EN DESCRIPTION"; Box(form, "tb7").Text = "DE DESCRIPTION";
                        string source = locale == "de" ? "DE NAME" : "EN NAME", language = locale == "de" ? "de" : "en";
                        typeof(editor).GetMethod("button11_Click", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(form, new object[] { null, EventArgs.Empty });
                        Assert(calls.Count == 3 && calls.All(call => call.StartsWith(source + ":" + language + ":")));
                        Assert(Box(form, locale == "de" ? "tb3" : "tb2").Text == source);
                        Assert(Box(form, "tb4").Text == "fr=" + source && Box(form, "tb5").Text == "pl=" + source);
                        calls.Clear(); source = locale == "de" ? "DE DESCRIPTION" : "EN DESCRIPTION";
                        typeof(editor).GetMethod("button3_Click", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(form, new object[] { null, EventArgs.Empty });
                        Assert(calls.Count == 3 && calls.All(call => call.StartsWith(source + ":" + language + ":")));
                        Assert(Box(form, "tb8").Text == "fr=" + source && Box(form, "tb9").Text == "pl=" + source);
                        var resources = new ResourceManager("Projektduplicator_2017.langres", typeof(Form1).Assembly);
                        Assert((string)Field(form, "o1") == resources.GetString("o1.Text", new CultureInfo(locale)));
                        Assert((string)Field(form, "b1") == resources.GetString("b1.Text", new CultureInfo(locale)));
                        Assert(((Label)Field(form, "label11")).Text == resources.GetString("o1.Text", new CultureInfo(locale)));
                        Assert(((Label)Field(form, "label12")).Text == resources.GetString("b1.Text", new CultureInfo(locale)));
                    }
                });
                Test("editor and main window render " + locale, () => {
                    Render(new RenderEditor(), "editor-" + locale, true);
                    using (var form = new options()) {
                        var resources = new ResourceManager("Projektduplicator_2017.optionres", typeof(Form1).Assembly);
                        Assert(((Button)Field(form, "button4")).Text == resources.GetString("opt_9", new CultureInfo(locale)));
                        Render(form, "options-" + locale, true);
                    }
                    using (var form = new RenderMain()) { Assert(form.Text.Contains("Projektduplicator 2026")); Render(form, "main-" + locale, true); }
                });
                Test("GitHub update dialog and no published release " + locale, () => {
                    using (var form = new GithubUpdateForm(Client(Metadata()))) { Render(form, "update-" + locale, true); }
                    using (var form = new GithubUpdateForm(Client("", HttpStatusCode.NotFound)))
                    {
                        form.StartPosition = FormStartPosition.Manual; form.Location = new Point(-20000, -20000); form.ShowInTaskbar = false;
                        form.Show(); Application.DoEvents();
                        var label = form.Controls[0].Controls.OfType<Label>().Single();
                        Assert(label.Text.Contains("2026"));
                        Assert(!form.Controls[0].Controls.OfType<FlowLayoutPanel>().Single().Controls.OfType<Button>().First(button => button.Width == 210 && !button.Text.Contains(" / ")).Enabled);
                        form.Close();
                    }
                });
            }
            Test("translation failure does not return partial results", () => Fails(() => ModelTranslation.Run("ORIGINAL", "de", (text, from, to) => to == "fr" ? null : "PARTIAL")));
            Test("legacy portable settings identity and unknown values retained", () => {
                string directory = Folder(), file = Path.Combine(directory, "pdup_settings.xml");
                File.WriteAllText(file, "<configuration><userSettings><Projektduplicator_2017.Properties.Settings><setting name='id_code' serializeAs='String'><value>OLD</value></setting><setting name='future_setting' serializeAs='String'><value>KEEP</value></setting></Projektduplicator_2017.Properties.Settings></userSettings></configuration>");
                var provider = new FixtureSettings { DirectoryPath = directory }; provider.Initialize("fixture", new System.Collections.Specialized.NameValueCollection());
                var property = new System.Configuration.SettingsProperty("id_code") { PropertyType = typeof(string), SerializeAs = System.Configuration.SettingsSerializeAs.String, DefaultValue = "" };
                var properties = new System.Configuration.SettingsPropertyCollection(); properties.Add(property);
                var values = provider.GetPropertyValues(new System.Configuration.SettingsContext(), properties);
                Assert((string)values["id_code"].SerializedValue == "OLD"); values["id_code"].SerializedValue = "NEW";
                provider.SetPropertyValues(new System.Configuration.SettingsContext(), values);
                string xml = File.ReadAllText(file); Assert(xml.Contains("NEW") && xml.Contains("KEEP") && xml.Contains("Projektduplicator_2017.Properties.Settings"));
            });
            Test("blank backup root does not replace personal backup paths", () => {
                settings.backup2 = ""; settings.backup = Path.Combine(root, "personal-backup"); settings.user_backup = Path.Combine(root, "personal-snapshots");
                using (var form = new Form1()) typeof(Form1).GetMethod("Form1_Load", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(form, new object[] { null, EventArgs.Empty });
                Assert(settings.backup == Path.Combine(root, "personal-backup") && settings.user_backup == Path.Combine(root, "personal-snapshots"));
            });
            Test("translation rejects blank source and unsupported source language", () => { Fails(() => ModelTranslation.Run(" ", "en", null)); Fails(() => ModelTranslation.Run("text", "fr", null)); });
            Test("GitHub release identity and version", () => { using (var client = Client(Metadata())) Assert(client.Latest(CancellationToken.None).GetAwaiter().GetResult().Version == new Version(4, 6, 6, 60)); });
            foreach (string data in new[] { Metadata().Replace("\"prerelease\": false", "\"prerelease\": true"), Metadata().Replace("https://github.com/", "https://example.invalid/"), "{}" })
                Test("reject incompatible release metadata", () => { using (var client = Client(data)) Fails(() => client.Latest(CancellationToken.None).GetAwaiter().GetResult()); });
            Test("reject insecure update URLs", () => { Assert(!GithubUpdateClient.Trusted(new Uri("http://github.com/x"))); Assert(!GithubUpdateClient.Trusted(new Uri("https://user@github.com/x"))); });
            Test("cancel pending GitHub request", () => {
                using (var source = new CancellationTokenSource())
                using (var client = new GithubUpdateClient(new Handler { Reply = async (request, token) => { await Task.Delay(30000, token); return new HttpResponseMessage(HttpStatusCode.OK); } }))
                { var pending = client.Latest(source.Token); source.Cancel(); Fails(() => pending.GetAwaiter().GetResult()); }
            });
            foreach (bool correct in new[] { true, false }) Test("verified download before shutdown, valid checksum=" + correct, () => {
                var package = Package(); byte[] bytes = File.ReadAllBytes(package.ZipPath);
                string expected = correct ? package.Sha256 : new string('0', 64);
                using (var client = new GithubUpdateClient(new Handler { Reply = (request, token) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) {
                    Content = request.RequestUri.AbsolutePath.EndsWith(".txt") ? (HttpContent)new StringContent(expected + "  package.zip") : new ByteArrayContent(bytes) }) }))
                {
                    var release = new GithubRelease { ZipName = "package.zip", ZipUrl = "https://github.com/package.zip", ChecksumsUrl = "https://github.com/SHA256SUMS.txt", Version = new Version(package.Version) };
                    Action download = () => { var result = Task.Run(() => client.Download(release, Folder(), CancellationToken.None, null)).GetAwaiter().GetResult(); Assert(result.Sha256 == expected); };
                    if (correct) download(); else Fails(download);
                }
            });
            foreach (string path in new[] { "../escape.exe", "projects/model/System.ini", "pdup_settings.xml", "Path.txt", "SplineID.txt", "personal.ini", "C:/escape.exe", "de/../escape.dll" })
                Test("reject package data/path " + path, () => { var job = Package(path); Fails(() => UpdateCore.Install(job)); Assert(File.ReadAllText(Path.Combine(job.InstallDirectory, UpdateCore.MainExe)) == "OLD MAIN"); });
            Test("reject missing language assembly", () => { var job = Package(null, "fr/Projektduplicator_2017.resources.dll"); Fails(() => UpdateCore.Install(job)); });
            Test("reject package missing required info.txt", () => {
                var job = Package(null, "info.txt"); Fails(() => UpdateCore.Install(job));
                Assert(File.ReadAllText(Path.Combine(job.InstallDirectory, UpdateCore.MainExe)) == "OLD MAIN");
            });
            Test("first installation includes original info.txt", () => {
                var job = Package(); UpdateCore.Install(job);
                Assert(UpdateCore.Hash(Path.Combine(job.InstallDirectory, "info.txt")) == UpdateCore.Hash(Path.Combine(runtime, "info.txt")));
            });
            Test("update preserves and backs up existing info.txt", () => {
                var job = Package(); string info = Path.Combine(job.InstallDirectory, "info.txt");
                File.WriteAllText(info, "Eigene Informationen / personal notes / notes personnelles");
                string hash = UpdateCore.Hash(info); UpdateCore.Install(job);
                Assert(UpdateCore.Hash(info) == hash);
                Assert(UpdateCore.Hash(Path.Combine(job.BackupDirectory, "info.txt")) == hash);
            });
            Test("reject checksum mismatch before writing", () => { var job = Package(); job.Sha256 = new string('0', 64); Fails(() => UpdateCore.Install(job)); });
            Test("reject wrong executable version", () => { var job = Package(); job.Version = "99.0.0.0"; Fails(() => UpdateCore.Install(job)); });
            Test("complete installation preserves settings, paths and project bytes", () => {
                var job = Package(); UpdateCore.Install(job);
                Assert(UpdateCore.Hash(Path.Combine(job.InstallDirectory, UpdateCore.MainExe)) == UpdateCore.Hash(Path.Combine(runtime, UpdateCore.MainExe)));
                Assert(File.ReadAllText(Path.Combine(job.InstallDirectory, "pdup_settings.xml")) == "PERSONAL SETTINGS");
                Assert(File.ReadAllText(Path.Combine(job.InstallDirectory, "Path.txt")) == "PERSONAL PATHS");
                Assert(File.ReadAllText(Path.Combine(job.InstallDirectory, "projects/model/System.ini")) == "PERSONAL MODEL");
                Assert(File.ReadAllText(Path.Combine(job.BackupDirectory, "pdup_settings.xml")) == "PERSONAL SETTINGS");
            });
            Test("partial installation rolls back", () => {
                var job = Package(); Fails(() => UpdateCore.Install(job, count => { if (count == 2) throw new IOException("Injected failure"); }));
                Assert(File.ReadAllText(Path.Combine(job.InstallDirectory, UpdateCore.MainExe)) == "OLD MAIN");
                Assert(File.ReadAllText(Path.Combine(job.InstallDirectory, "IniFile.dll")) == "OLD LIBRARY");
                Assert(File.ReadAllText(Path.Combine(job.InstallDirectory, "pdup_settings.xml")) == "PERSONAL SETTINGS");
            });
            Test("locked executable prevents all writes", () => { var job = Package(); using (var locked = File.Open(Path.Combine(job.InstallDirectory, UpdateCore.MainExe), FileMode.Open, FileAccess.Read, FileShare.None)) Fails(() => UpdateCore.Install(job)); });
            Test("cancel package validation", () => { var job = Package(); using (var cancel = new CancellationTokenSource()) { cancel.Cancel(); Fails(() => UpdateCore.Extract(job, Folder(), cancel.Token)); } });
            foreach (string architecture in new[] { "x86", "x64" }) Test("stable process handoff " + architecture, () => {
                string directory = Folder(), exe = Path.Combine(directory, UpdateCore.MainExe);
                using (var compiler = new Microsoft.CSharp.CSharpCodeProvider()) {
                    var result = compiler.CompileAssemblyFromSource(new System.CodeDom.Compiler.CompilerParameters { GenerateExecutable = true, OutputAssembly = exe, CompilerOptions = "/platform:" + architecture },
                        "class Fixture { static void Main() { System.Threading.Thread.Sleep(700); } }"); Assert(!result.Errors.HasErrors);
                }
                using (var process = Process.Start(new ProcessStartInfo(exe) { UseShellExecute = false, CreateNoWindow = true })) {
                    var job = new UpdateJob { ProcessId = process.Id, ProcessStartTicks = process.StartTime.ToUniversalTime().Ticks, InstallDirectory = directory };
                    EditorProcess.WaitForExit(job, 10000); Assert(process.WaitForExit(1000));
                }
            });
            if (args.Length > 1) Test("complete local review package accepted", () => { var job = new UpdateJob { ZipPath = args[1], Sha256 = UpdateCore.Hash(args[1]), Version = FileVersionInfo.GetVersionInfo(Path.Combine(runtime, UpdateCore.MainExe)).FileVersion }; UpdateCore.Extract(job, Folder()); });
            Console.WriteLine(passed + " local checks passed. No live translation/GitHub call; only temporary installations changed.");
            Console.WriteLine("Evidence: " + root);
            return 0;
        }
        catch (Exception error) { Console.Error.WriteLine(error); Console.Error.WriteLine("Evidence: " + root); return 1; }
    }
}
