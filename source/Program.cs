using System;
using System.IO;
using System.Xml.Serialization;

namespace PrettierJson;

class Program
{
    private const string version = "0.1.0";

    static int Main(string[] args)
    {
        if (args.Length == 1 && (args[0] == "--version" || args[0] == "-v"))
        {
            PrintVersion();
            return 0;
        }

        if (args.Length == 1 && (args[0] == "--help" || args[0] == "-h"))
        {
            PrintHelp();
            return 0;
        }

        if (args.Length == 0)
        {
            PrintHelp();
            return 1;
        }

        string command = args[0].ToLower();

        if (command == "format")
        {
            if (args.Length < 2)
            {
                PrintError("No input file provided.");
                return 1;
            }

            string inputPath = args[1];
            string? outputPath = null;

            for (int i = 2; i < args.Length; i++)
            {
                if (args[i] == "--out")
                {
                    if (i + 1 >= args.Length || args[i + 1].StartsWith("-"))
                    {
                        PrintError("Error: No output file provided after --out");
                        return 1;
                    }

                    outputPath = args[i + 1];
                    i++;
                }
            }

            try
            {
                string result = Formatter.FormatFile(inputPath);

                if (outputPath == null)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    File.WriteAllText(outputPath, result);
                    PrintSuccess($"Saved formatted JSON to '{outputPath}'");
                }

                return 0;
            }
            catch (Exception ex)
            {
                PrintError($"Error: {ex.Message}");
                return 1;
            }
        }

        PrintError($"Unknown command '{command}'");
        PrintHelp();
        return 1;
    }

    static void PrintHelp()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  prettier.json format <file.json> [--out <output.json>]");
        Console.WriteLine();
        Console.WriteLine("Commands:");
        Console.WriteLine("  format    Format a JSON file to be prettier");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  --out     Save the formatted JSON to a file");
        Console.WriteLine("  --version / -v     Shows current program version");
        Console.WriteLine("  --help / -h     Shows this help menu");
        Console.WriteLine();
    }

    static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void PrintSuccess(string message)
    {
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void PrintVersion()
    {
        Console.Write("prettier.json v ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(version);
        Console.ResetColor();
        Console.WriteLine();
    }
}
