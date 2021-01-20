using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project_1.Main
{
    class Settings
    {
        [JsonPropertyName("textColor")]
        public int? TextColor { get; set; }

        [JsonPropertyName("backgroundColor")]
        public int? BackgroundColor { get; set; }

        public Settings() { }

        public Settings(int textColor, int backgroundColor)
        {
            TextColor = textColor;
            BackgroundColor = backgroundColor;
        }
    }
}
