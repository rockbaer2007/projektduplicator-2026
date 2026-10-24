# Projektduplicator 2026

Current product name: **Projektduplicator 2026**. “Günthertest” is an old folder label.
Technical project and namespace names remain unchanged for compatibility.
Version **4.6.6.59**, Visual Studio 2026 / .NET Framework 4.8.

[Windows ZIP and checksum](https://github.com/rockbaer2007/projektduplicator-2026/releases/tag/v4.6.6.59) ·
[Documentation](https://opensource.ugso-software.de/en/eep/projektduplicator-2026/) ·
[Deutsch](README.md) · [Français](README.fr.md)

English/French interface texts and 150 icon descriptions have been reviewed. German
typos and country names have been corrected; resource IDs remain unchanged. The Dutch
interface is retained, and the new updater also supports Dutch.

Model names and descriptions now use the correct source fields. Organisation and
description labels are no longer swapped. Each target language is translated directly
from the original, with all results prepared before replacing any text. Failed
translations retain the existing values. The legacy Google web translator now uses
HTTPS and validates its response, but still depends on Google's webpage format.
Tests use simulated translations only.

`pdup_settings.xml` keeps its original setting names. Project folders, path lists,
spline lists, personal information files and backups are excluded from update packages.
Close editors and save modified lists before updating. The initial migration requires
starting **Projektduplicator_2017.exe**; old executables and shortcuts are retained.

The existing update buttons now open a manual GitHub check. There is no startup check.
Release source: `rockbaer2007/projektduplicator-2026`.
A missing release is reported without changing the application.
Releases must contain `Projektduplicator-2026-v4.6.6.59-windows.zip` and `SHA256SUMS.txt`,
with matching executable and tag versions. Only newer stable releases are offered.
HTTPS downloads, bounded ZIP contents, SHA-256 and GitHub's asset digest are checked;
no additional digital signature is implemented.

A separate updater verifies the editor process, backs up program files and settings,
installs only explicitly allowed program files, attempts rollback on failure and
restarts the program on success. Reports are stored under
`%LOCALAPPDATA%/UGSo/Projektduplicator2026/updates/<id>/`.

Use the existing solution to build. `tools/package-local.ps1` prepares a program-only
ZIP and documentation in a new directory. Tests cover translations, rendered forms,
simulated GitHub responses, cancellation, installation, data retention, rollback and
x86/x64 process handoff. A real public GitHub installation/restart test is still
pending. License and copyright notices are recorded in `LICENSE` and
`THIRD-PARTY-NOTICES.md`. Existing UGSo changes are preserved.

## Local changes on 24 October 2026

Form1 now declares its fully qualified Windows Forms base class. The additional
Form1 updater partial class has been merged into the main file to avoid a second
form entry in Visual Studio. The real Visual Studio designer was checked.
The required info.txt has been corrected in DE/EN/FR/NL and now describes
Projektduplicator 2026 and its manual GitHub update check. Updates
back up and retain an existing info.txt; missing files receive the bundled copy.
