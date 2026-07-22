using System;
using Microsoft.Win32;

namespace IconForge.Services
{
    public static class ShellIntegration
    {
        private static readonly string[] Extensions = { ".png", ".svg", ".ico" };
        private const string SystemAssocKeyPath = @"Software\Classes\SystemFileAssociations\{0}\Shell\IconForge";
        private const string StarShellKeyPath = @"Software\Classes\*\shell\IconForge";

        public static bool IsRegistered()
        {
            try
            {
                using var starKey = Registry.CurrentUser.OpenSubKey(StarShellKeyPath);
                if (starKey != null) return true;

                foreach (var ext in Extensions)
                {
                    string path = string.Format(SystemAssocKeyPath, ext);
                    using var key = Registry.CurrentUser.OpenSubKey(path);
                    if (key != null) return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static void Register(string menuTitle = "Сгенерировать иконки в IconForge")
        {
            string exePath = Environment.ProcessPath ?? System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName ?? "";
            if (string.IsNullOrEmpty(exePath)) return;

            try
            {
                // 1. Register under Software\Classes\*\shell\IconForge with AppliesTo filter
                using (var starKey = Registry.CurrentUser.CreateSubKey(StarShellKeyPath))
                {
                    if (starKey != null)
                    {
                        starKey.SetValue("", menuTitle);
                        starKey.SetValue("MUIVerb", menuTitle);
                        starKey.SetValue("Icon", exePath);
                        starKey.SetValue("AppliesTo", ".png OR .svg OR .ico");

                        using var cmdKey = starKey.CreateSubKey("Command");
                        cmdKey?.SetValue("", $"\"{exePath}\" \"%1\"");
                    }
                }

                // 2. Register under SystemFileAssociations for each extension
                foreach (var ext in Extensions)
                {
                    string path = string.Format(SystemAssocKeyPath, ext);
                    using var key = Registry.CurrentUser.CreateSubKey(path);
                    if (key != null)
                    {
                        key.SetValue("", menuTitle);
                        key.SetValue("MUIVerb", menuTitle);
                        key.SetValue("Icon", exePath);

                        using var commandKey = key.CreateSubKey("Command");
                        commandKey?.SetValue("", $"\"{exePath}\" \"%1\"");
                    }
                }
            }
            catch
            {
                // Ignore registration errors
            }
        }

        public static void Unregister()
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(StarShellKeyPath, throwOnMissingSubKey: false);
            }
            catch { }

            foreach (var ext in Extensions)
            {
                string path = string.Format(SystemAssocKeyPath, ext);
                try
                {
                    Registry.CurrentUser.DeleteSubKeyTree(path, throwOnMissingSubKey: false);
                }
                catch { }
            }
        }
    }
}
