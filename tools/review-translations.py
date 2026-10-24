"""Reproduce the reviewed UI text corrections without changing resource keys or IDs."""
from pathlib import Path
from xml.dom import minidom

ROOT = Path(__file__).resolve().parents[1] / 'Projektduplicator_2017'


def update(family, locale, values):
    path = ROOT / f'{family}.{locale}.resx'
    doc = minidom.parse(str(path))
    nodes = {node.getAttribute('name'): node for node in doc.getElementsByTagName('data')}
    for key, text in values.items():
        if key not in nodes:
            raise ValueError(f'Unknown resource key: {path.name}/{key}')
        value = nodes[key].getElementsByTagName('value')[0]
        for child in list(value.childNodes):
            value.removeChild(child)
        value.appendChild(doc.createTextNode(text))
    path.write_bytes(doc.toxml(encoding='utf-8'))


def rows(filename):
    result = []
    for line in (Path(__file__).parent / filename).read_text(encoding='utf-8').splitlines():
        if not line.strip() or line.startswith('#'):
            continue
        parts = line.split('|')
        if len(parts) != 3:
            raise ValueError(f'Expected key|English|French: {line}')
        result.append(parts)
    return result


for family, filename in [('langres', 'ui-translations.txt'), ('iconres', 'icon-translations.txt')]:
    entries = rows(filename)
    for index, locale in [(1, 'en'), (2, 'fr')]:
        update(family, locale, {row[0]: row[index] for row in entries})

update('langres', 'de', {
    '$this.Text': 'Projektduplicator 2026', 'pictureBox1.tt': 'Schließen',
    'tabPage4.Text': 'Über', 'tabPage4.ToolTip': 'Über das Programm',
    'tabPage2.Text': 'Projekt-Sicherungen', 'tabPage5.Text': 'Automatische Sicherungen',
    'label6.Text': 'Gespeicherte Konstrukteursignatur:', 'pictureBox8.tt': 'Niederländisch',
    'dataGridViewTextBoxColumn2.HeaderText': 'Gespeicherte Projekt-Sicherungen',
    'ed_saerch': 'Durchsuchen …', 'label8.Text': 'Gespeicherter Arbeitsbereich:',
    'mnedit_1': 'Rückgängig', 'btn12.Text': 'Zurück zum ersten Tab',
    'wmtext3': 'Die Konstrukteursignatur muss eingetragen werden.',
    'edverweis1': 'Maximal 23 Zeichen; ein Unterstrich und das Konstrukteurkürzel werden angehängt.',
    'edverweis2': 'Enthält Sonderzeichen oder Leerzeichen',
    'ed_lb77': 'Ein deutscher Text ist erforderlich. Modellnamen und Beschreibungen ohne Unterstriche eingeben.',
    'ed_info1': 'Bitte eine deutsche Beschreibung eingeben.', 'ed_info2': 'Bitte einen deutschen Modellnamen eingeben.',
    'ed_mldg2': 'Vor dem Kopieren wird das Projekt gesichert.',
    'ed_mldg3': 'Der Zielordner wird auf vorhandene Projekte geprüft.',
    'ed_mldg4': 'Existiert der Zielordner bereits, wird das Kopieren abgebrochen.',
    'ed_mldg6': 'Der Projektpfad existiert bereits. Das Erstellen wurde abgebrochen.',
    'ed_mldg7': 'Der Zielpfad ist frei. Das Projekt kann kopiert werden.',
    'ed_mldg8': 'Mit OK das Kopieren fortsetzen.',
    'ed_spmsg1': 'Die ID-Liste wird erstellt. Bitte einen Moment warten.',
    'ed_spmsg2': 'Im Programmordner wird gleichzeitig',
    'ed_spmsg3': 'die Datei HN_splineID.txt erstellt',
    'ed_spmsg4': 'oder die vorhandene Liste ergänzt.',
    'lb13_t': 'Diese Datei enthält die Grundlage für die ExportToEEP-Einstellungen im Editor.',
    'lb14_t': 'Diese Datei enthält die Spline-IDs der Konstrukteure für den Editor.',
    'lbl1_xfile': 'X-Import-Dateien vorhanden. Wenn das Modell gemäß den Modellbaurichtlinien nur eine Textur verwendet, kann deren ID in allen .x.ini-Dateien geändert werden.',
    'btn2_xfile': 'Übernehmen', 'ed_lb26': 'Erweiterung für die neuen Symbole',
})

for locale in ['de', 'en', 'fr', 'nl']:
    update('langres', locale, {'$this.Text': 'Projektduplicator 2026'})

update('optionres', 'en', {'opt_3': 'Designer signature', 'opt_4': 'Enable project deletion', 'opt_5': 'Browse',
    'opt_8': 'Caution: enable this function at your own risk.', 'opt_9': 'Backup'})
update('optionres', 'fr', {'opt_2': 'Dernière ID spline', 'opt_3': 'Signature du créateur', 'opt_5': 'Parcourir',
    'opt_4': 'Activer la suppression de projets', 'opt_8': 'Attention : activez cette fonction à vos risques et périls.',
    'opt_9': 'Sauvegarde'})
update('optionres', 'de', {'opt_3': 'Konstrukteursignatur', 'opt_9': 'Sicherung'})
update('iconres', 'de', {'country19': 'Großbritannien', 'country26': 'Liechtenstein'})
print('Reviewed resources updated; resource keys and numeric icon IDs preserved.')
