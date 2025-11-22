using PrettierJson.Commands;
using PrettierJson.Utils;

namespace PrettierJson;

class Program
{
    private const string version = "0.1.4";

    static int Main(string[] args)
    {
        if (args.Contains("--version") || args.Contains("-v"))
        {
            ConsoleHelpers.PrintVersion(version);
            return 0;
        }

        if (args.Contains("--help") || args.Contains("-h"))
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

        return command switch
        {
            "format" => FormatCommand.Run(args),
            "validate" => ValidateCommand.Run(args),
            _ => UnknownCommand(command)
        };
    }


    static int UnknownCommand(string cmd)
    {
        ConsoleHelpers.PrintError($"Unknown command '{cmd}'");
        PrintHelp();
        return 1;
    }

    static void PrintHelp()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Usage:");
        Console.WriteLine("  prettier.json format <file.json> [--out <output.json>]");
        Console.WriteLine();
        Console.WriteLine("Commands:");
        Console.WriteLine("  format      Format a JSON file or stdin into a prettier JSON file");
        Console.WriteLine("  validate      Validate a JSON file");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  --out       Save formatted JSON to a file");
        Console.WriteLine("  --version   Show version");
        Console.WriteLine("  --help      Show help");
        Console.WriteLine();
        Console.ResetColor();
    }
}
