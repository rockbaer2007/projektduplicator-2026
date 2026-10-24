# Projektduplicator 2026

## Stand vom 24.10.2026

Form1 verwendet eine eindeutige Basisklasse; der Updater-Code liegt wieder in der
Hauptdatei. Die zusätzliche, von Visual Studio als Formular erkannte Teilklasse
entfällt. Der Designer wurde direkt in Visual Studio geprüft.

`info.txt` gehört verbindlich zu Build und Prüfpaket. Die Texte sind in DE/EN/FR/NL
korrigiert und beschreiben Projektduplicator 2026 sowie die manuelle GitHub-Prüfung.
Bei Updates bleiben vorhandene eigene Inhalte erhalten und werden
gesichert; fehlt die Datei, wird die mitgelieferte Fassung installiert.

Der aktuelle Produktname lautet **Projektduplicator 2026**. Der bisherige Ordnerzusatz
„Günthertest“ ist lediglich eine alte Arbeitskennzeichnung. Die technischen Projekt-
und Namespace-Namen bleiben aus Kompatibilitätsgründen erhalten.

Version: **4.6.6.59**, Visual Studio 2026, .NET Framework 4.8.
Die vorhandenen UGSo-Metadaten, ursprünglichen Projekte und Sicherungen bleiben erhalten.
[Windows-ZIP und Prüfsumme](https://github.com/rockbaer2007/projektduplicator-2026/releases/tag/v4.6.6.59) ·
[Dokumentation](https://opensource.ugso-software.de/eep/projektduplicator-2026/) ·
[English](README.en.md) · [Français](README.fr.md)

## Änderungen

- Englische und französische Bedienhinweise sowie alle 150 Symbolbeschreibungen
  überarbeitet; deutsche Schreibfehler und Ländernamen korrigiert. Ressourcen-IDs unverändert.
- Die bestehende niederländische Oberfläche bleibt erhalten; der neue Updater bietet ebenfalls Niederländisch.
- Modellname und Beschreibung verwenden wieder das richtige Ausgangsfeld.
  Organisation und Beschreibung sind korrekt zugeordnet; „Alles auswählen“ wird nicht mehr mit „Drucken“ überschrieben.
- Alle Zielsprachen werden direkt aus dem Originaltext übersetzt. Ergebnisse werden
  erst nach vollständigem Erfolg übernommen; bei Fehlern bleiben vorhandene Texte erhalten.
- Die bestehende Google-Webübersetzung verwendet HTTPS und prüft das Antwortformat.
  Sie ist keine offizielle Google-API und bleibt vom Webseitenformat abhängig.
  Die lokalen Tests verwenden ausschließlich simulierte Übersetzungen.

## Einstellungen und Projekte

`pdup_settings.xml` bleibt im Programmordner und verwendet weiterhin die ursprünglichen
Einstellungsnamen. Der neue Programmname ändert diese Zuordnung nicht. Projektordner,
`Path.txt`, `SplineID.txt`, `HN_splineID.txt`, eigene Informationen und Sicherungen werden
nicht mit dem Updatepaket ausgeliefert und nicht überschrieben.

Vor einem Update alle Editoren schließen und Änderungen an den Pfad-/Spline-Listen speichern.
Der Updater blockiert den Start bei geöffneten Dialogen oder ungespeicherten Listenänderungen.
Für die erste Umstellung die Anwendung sichern und anschließend **Projektduplicator_2017.exe**
verwenden; eine vorhandene alte EXE und ihre Verknüpfung werden nicht automatisch entfernt.

## GitHub-Updater

Die vorhandenen Update-Schaltflächen öffnen die manuelle GitHub-Prüfung. Keine automatische
Prüfung beim Start. Release-Quelle:
`rockbaer2007/projektduplicator-2026`. Ohne verfügbares Release erscheint ein entsprechender Hinweis.

Veröffentlichungen benötigen `v4.6.6.59` bzw. eine spätere Versionsnummer und genau diese Dateien:

- `Projektduplicator-2026-v4.6.6.59-windows.zip`
- `SHA256SUMS.txt`

Nur neuere stabile Releases werden angeboten. Download und ZIP-Prüfung sind abbrechbar,
HTTPS-Ziele sind begrenzt, SHA-256 und gegebenenfalls GitHubs Asset-Digest werden geprüft.
Es ist keine zusätzliche digitale Signatur implementiert.

Ein separater Helfer prüft Prozessidentität und Programmende, sichert vorhandene
Programmdateien und lokale Einstellungen und installiert nur ausdrücklich zugelassene
Programmdateien. Projektdateien im ZIP werden abgelehnt. Nach Fehlern versucht er,
bereits ersetzte Dateien wiederherzustellen. Nach Erfolg startet die Anwendung neu.
Berichte liegen unter `%LOCALAPPDATA%/UGSo/Projektduplicator2026/updates/<Kennung>/`.

## Lokal bauen und prüfen

Die alte Mappe `Projektduplicator_2017_45.sln` bleibt verwendbar. Die vorhandenen
Hilfsbibliotheken werden unter `lib/` unverändert mitgeführt; ihre alten absoluten
Entwicklerpfade werden nicht mehr benötigt. Lizenz- und Copyright-Hinweise stehen
in `LICENSE` und `THIRD-PARTY-NOTICES.md`.

```powershell
MSBuild.exe Projektduplicator_2017/Projektduplicator_2017_45.csproj /p:Configuration=Release
MSBuild.exe tests/Projektduplicator.Tests.csproj /p:Configuration=Release
./tests/bin/Projektduplicator.Tests.exe Projektduplicator_2017/bin/Release
./tools/package-local.ps1 -OutputDirectory C:/Pfad/zu/einem/neuen/Pruefpaket
```

Die Prüfungen verwenden eigene temporäre Installationen und Testprojekte. Sie ersetzen
keinen echten GitHub-Download mit Installation und Neustart; dieser gesonderte
Ende-zu-Ende-Test steht noch aus.
