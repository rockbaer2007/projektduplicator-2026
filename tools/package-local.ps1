param([Parameter(Mandatory=$true)][string]$OutputDirectory)
$ErrorActionPreference = 'Stop'
$repoRoot = Split-Path $PSScriptRoot -Parent
$runtime = Join-Path $repoRoot 'Projektduplicator_2017/bin/Release'
$version = [Diagnostics.FileVersionInfo]::GetVersionInfo((Join-Path $runtime 'Projektduplicator_2017.exe')).FileVersion
$destination = [IO.Path]::GetFullPath($OutputDirectory)
if (Test-Path -LiteralPath $destination) { throw 'Choose a new output directory; existing packages are never overwritten.' }
$stage = Join-Path $destination 'Projektduplicator 2026'
New-Item -ItemType Directory -Path $stage -Force | Out-Null
# Deliberately exclude settings, INI/PRJ models, path lists, snapshots and registration files.
$files = @('Projektduplicator_2017.exe','Projektduplicator_2017.exe.config','Projektduplicator.Updater.exe',
    'IniFile.dll','Newtonsoft.Json.dll','rbtools.dll','RichTextBoxPrintCtrl.dll','info.txt')
foreach ($name in $files) { Copy-Item -LiteralPath (Join-Path $runtime $name) -Destination $stage }
if ((Get-FileHash -LiteralPath (Join-Path $repoRoot 'info.txt')).Hash -ne
    (Get-FileHash -LiteralPath (Join-Path $stage 'info.txt')).Hash) {
    throw 'Packaged info.txt differs from the original source.'
}
foreach ($locale in @('de','en','fr','nl')) {
    $target = Join-Path $stage $locale
    New-Item -ItemType Directory -Path $target | Out-Null
    Copy-Item -LiteralPath (Join-Path $runtime "$locale/Projektduplicator_2017.resources.dll") -Destination $target
}
# ZIP matches the updater's strict program-only file contract. Documentation stays beside it.
$zip = Join-Path $destination "Projektduplicator-2026-v$version-windows.zip"
Compress-Archive -Path (Join-Path $stage '*') -DestinationPath $zip -CompressionLevel Optimal
$hash = (Get-FileHash -LiteralPath $zip -Algorithm SHA256).Hash.ToLowerInvariant()
[IO.File]::WriteAllText((Join-Path $destination 'SHA256SUMS.txt'), "$hash  $([IO.Path]::GetFileName($zip))`n", [Text.UTF8Encoding]::new($false))
foreach ($readme in @('README.md','README.en.md','README.fr.md')) {
    Copy-Item -LiteralPath (Join-Path $repoRoot $readme) -Destination $destination
}
Write-Output $zip
Write-Output "SHA256 $hash"
