using System.Configuration;
using System.IO;

namespace Projektduplicator_2017
{
    internal static class SettingsMigration
    {
        internal static void UpgradeIfNeeded()
        {
            string configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            if (File.Exists(configuration)) return;
            // Upgrade versioned Windows preferences; the portable XML remains under its original identity.
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.Save();
        }
    }
}
