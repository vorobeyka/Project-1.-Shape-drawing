using System;
using System.IO;
using System.Text.Json;

namespace Project_1.Main
{
    static class SettingsController
    {
        private static readonly string _filePath = "settings.json";

        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static void LoadSettings()
        {
            try
            {
                var json = File.ReadAllText(_filePath);
                var clone = JsonSerializer.Deserialize<Settings>(json);
                if (clone == null)
                {
                    throw new ArgumentNullException();
                }
                Console.ForegroundColor = (ConsoleColor)(clone.TextColor ?? throw new ArgumentNullException());
                Console.BackgroundColor = (ConsoleColor)(clone.BackgroundColor ?? throw new ArgumentNullException());
            }
            catch (Exception) { }
        }

        public static void SaveSettings(Settings settings)
        {
            var json = JsonSerializer.Serialize(settings, _options);
            File.WriteAllText(_filePath, json);
        }
    }
}
