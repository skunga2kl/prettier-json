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
    }
}
