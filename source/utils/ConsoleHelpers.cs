using System;

namespace PrettierJson.Utils
{
    public static class ConsoleHelpers
    {
        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintVersion(string version)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"prettier.json v{version}");
            Console.ResetColor();
        }

        public static void ListFiles()
        {
            var jsonFiles = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.json");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"JSON files in current dir:\n");
            Console.ResetColor();

            if (!jsonFiles.Any())
            {
                Console.WriteLine(" (none found)");
                return;
            }

            foreach (var file in jsonFiles)
            {
                Console.WriteLine("  " + Path.GetFileName(file));
            }
        }
    }
}
