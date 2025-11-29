using PrettierJson.Utils;
using System.Text.Json;

namespace PrettierJson.Commands
{
    public static class ValidateCommand
    {
        public static int Run(string[] args)
        {
            if (args.Length < 2)
            {
                ConsoleHelpers.PrintError("No input file provided");
                return 1;
            }

            string path = args[1];

            if (!File.Exists(path))
            {
                ConsoleHelpers.PrintError($"File not found: {path}");
                return 1;
            }

            try
            {
                string json = File.ReadAllText(path);
                JsonDocument.Parse(json);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("JSON is valid");
                Console.ResetColor();

                return 0;
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("JSON is invalid");
                Console.WriteLine(ex.Message);
                Console.ResetColor();

                return 1;
            }
        }
    }
}
