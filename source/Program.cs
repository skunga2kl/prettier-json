using PrettierJson.Commands;
using PrettierJson.Utils;

namespace PrettierJson;

class Program
{
    private const string version = "0.1.0";

    static int Main(string[] args)
    {
        if (args.Length == 1 && (args[0] == "--version" || args[0] == "-v"))
        {
            ConsoleHelpers.PrintVersion(version);
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

        return command switch
        {
            "format" => FormatCommand.Run(args),
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
        Console.WriteLine("Usage:");
        Console.WriteLine("  prettier.json format <file.json> [--out <output.json>]");
        Console.WriteLine();
        Console.WriteLine("Commands:");
        Console.WriteLine("  format      Format a JSON file or stdin into pretty JSON");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  --out       Save formatted JSON to a file");
        Console.WriteLine("  --version   Show version");
        Console.WriteLine("  --help      Show help");
    }
}
