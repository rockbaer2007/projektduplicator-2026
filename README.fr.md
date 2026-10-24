# Projektduplicator 2026

Le nom actuel du produit est **Projektduplicator 2026**. « Günthertest » est une
ancienne indication dans le nom du dossier. Les noms techniques du projet et des
espaces de noms restent inchangés pour assurer la compatibilité.
Version **4.6.6.59**, Visual Studio 2026 / .NET Framework 4.8.

[ZIP Windows et empreinte](https://github.com/rockbaer2007/projektduplicator-2026/releases/tag/v4.6.6.59) ·
[Documentation](https://opensource.ugso-software.de/fr/eep/projektduplicator-2026/) ·
[Deutsch](README.md) · [English](README.en.md)

Les textes anglais et français de l’interface et les 150 descriptions d’icônes ont
été révisés. Des fautes allemandes et des noms de pays ont été corrigés sans modifier
les identifiants de ressources. L’interface néerlandaise est conservée ; le nouveau
programme de mise à jour prend aussi en charge le néerlandais.

Les noms de modèles et descriptions utilisent désormais les bons champs sources.
Les libellés d’organisation et de description ne sont plus inversés. Chaque langue
cible est traduite directement depuis l’original. Les textes ne sont remplacés que
lorsque tous les résultats sont disponibles ; un échec conserve les valeurs existantes.
La traduction Google historique utilise HTTPS et vérifie la réponse, mais dépend
toujours du format de la page Google. Les tests simulent les traductions.

`pdup_settings.xml` conserve ses noms de paramètres. Les projets, listes de chemins
et de splines, informations personnelles et sauvegardes sont exclus des paquets de
mise à jour. Fermer les éditeurs et enregistrer les listes modifiées avant l’opération.
Pour la première migration, lancer **Projektduplicator_2017.exe** ; les anciens
exécutables et raccourcis sont conservés.

Les boutons existants ouvrent une vérification GitHub manuelle, jamais automatique
au démarrage. Source des versions : `rockbaer2007/projektduplicator-2026`.
L’absence de version publique est signalée sans modifier l’application.
Chaque version doit fournir `Projektduplicator-2026-v4.6.6.59-windows.zip` et
`SHA256SUMS.txt`, avec des versions cohérentes dans le tag et l’exécutable. Seules les
versions stables plus récentes sont proposées. HTTPS, limites du ZIP, SHA-256 et
empreinte GitHub sont vérifiés ; aucune signature numérique supplémentaire n’est prévue.

Un programme séparé vérifie le processus de l’éditeur, sauvegarde les fichiers du
programme et les paramètres, n’installe que les fichiers explicitement autorisés,
tente une restauration en cas d’échec et redémarre le programme après réussite.
Rapports : `%LOCALAPPDATA%/UGSo/Projektduplicator2026/updates/<identifiant>/`.

La solution existante reste utilisable. `tools/package-local.ps1` crée un ZIP limité
aux fichiers du programme et place la documentation à côté. Les tests couvrent les
textes, le rendu, GitHub simulé, l’annulation, l’installation, la conservation des
données, la restauration et le transfert entre processus x86/x64. Un test réel avec
une version GitHub publique reste à effectuer. Les mentions de licence et de
copyright figurent dans `LICENSE` et `THIRD-PARTY-NOTICES.md`.
Les modifications UGSo existantes sont conservées.

## Modifications locales du 24 octobre 2026

Form1 déclare explicitement sa classe de base Windows Forms. Le code de mise à
jour a été réintégré dans le fichier principal pour éviter une deuxième entrée de
formulaire dans Visual Studio. Le concepteur Visual Studio a été vérifié.
Le fichier obligatoire info.txt a été corrigé en DE/EN/FR/NL et décrit désormais
Projektduplicator 2026 et sa recherche manuelle de mises à jour GitHub.
Les mises à jour sauvegardent et conservent une version existante ;
si le fichier manque, la version fournie est installée.
