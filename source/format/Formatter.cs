using System;
using System.IO;
using System.Text.Json;

namespace PrettierJson
{
    public class Formatter
    {
        public static string FormatFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File not found: {path}");
            }

            string json = File.ReadAllText(path);

            try
            {
                using var doc = JsonDocument.Parse(json);
                return JsonSerializer.Serialize(
                        doc,
                        new JsonSerializerOptions { WriteIndented = true }
                    );
            }
            catch (JsonException ex)
            {
                throw new Exception($"Invalid JSON: {ex.Message}");
            }
        }
    }
}
