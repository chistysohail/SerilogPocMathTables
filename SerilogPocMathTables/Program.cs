using System;
using System.Threading;
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        // Generate a unique log file name using a timestamp
        string logFileName = $"logs/mathtables_{DateTime.Now:yyyyMMdd_HHmmss}.log";

        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logFileName)
            .CreateLogger();

        // Log startup information
        Log.Information("MathTablesLogger starting up...");

        if (args.Length != 1 || !int.TryParse(args[0], out int number))
        {
            Log.Error("Invalid argument. Please provide a valid integer.");
            Console.WriteLine("Usage: MathTablesLogger <number>");
            return;
        }

        Log.Information("Starting to print math tables for number: {Number}", number);

        while (true)
        {
            PrintMathTable(number);
            Thread.Sleep(5000); // Sleep for 5 seconds before printing the table again
        }

        Log.CloseAndFlush(); // Ensure logs are flushed before application exit
    }

    static void PrintMathTable(int number)
    {
        for (int i = 1; i <= 10; i++)
        {
            int result = number * i;
            string logMessage = $"{number} x {i} = {result}";
            Console.WriteLine(logMessage);
            Log.Information(logMessage);
        }
    }
}
