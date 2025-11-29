using PrettierJson.Core;
using PrettierJson.Utils;

namespace PrettierJson.Commands
{
    public static class FormatCommand
    {
        public static int Run(string[] args)
        {
            string? inputPath = null;
            string? outputPath = null;

            if (args.Length >= 2 && !args[1].StartsWith("--"))
                inputPath = args[1];

            for (int i = 2; i < args.Length; i++)
            {
                if (args[i] == "--out")
                {
                    if (i + 1 >= args.Length || args[i + 1].StartsWith("-"))
                    {
                        ConsoleHelpers.PrintError("Error: No output file provided after --out");
                        return 1;
                    }

                    outputPath = args[i + 1];
                    i++;
                }
            }

            if (inputPath == null && !Console.IsInputRedirected)
            {
                ConsoleHelpers.PrintError("No input file provided and no stdin detected.");
                return 1;
            }

            if (inputPath != null && Directory.Exists(inputPath))
                return FormatDir(inputPath);

            if (inputPath != null && !File.Exists(inputPath) && !Console.IsInputRedirected)
            {
                ConsoleHelpers.PrintError($"Error: '{inputPath}' does not exist.");
                return 1;
            }

            try
            {
                string json = Console.IsInputRedirected
                    ? Console.In.ReadToEnd()
                    : File.ReadAllText(inputPath!);

                string result = Formatter.FormatString(json);

                if (outputPath == null)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    File.WriteAllText(outputPath, result);
                    ConsoleHelpers.PrintSuccess($"Saved formatted JSON to '{outputPath}'");
                }

                return 0;
            }
            catch (Exception ex)
            {
                ConsoleHelpers.PrintError($"Error: {ex.Message}");
                return 1;
            }
        }

        private static int FormatDir(string directory)
        {
            var files = Directory.GetFiles(directory, "*.json");

            if (files.Length == 0)
            {
                ConsoleHelpers.PrintError("No JSON files found in current directory");
                return 1;
            }

            foreach (var file in files)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    string result = Formatter.FormatString(json);
                    File.WriteAllText(file, result);

                    ConsoleHelpers.PrintSuccess($"Formatted {Path.GetFileName(file)}");
                }
                catch (Exception ex)
                {
                    ConsoleHelpers.PrintError($"Failed to format '{file}': {ex.Message}");
                }
            }

            return 0;
        }
    }
}
