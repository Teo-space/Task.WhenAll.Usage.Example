global using static Print;


public static partial class Print
{
    public static void print()
    {
        lock (LOCK)
        {
            PrintTime();
            Console.WriteLine();
        }
    }

    public static void print<TInput>(TInput input, ConsoleColor color = ConsoleColor.White)
    {
        lock (LOCK)
        {
            PrintTime();
            Console.ForegroundColor = color;

            Console.Write(input?.ToString() ?? string.Empty);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public static void print(string text, ConsoleColor color = ConsoleColor.White)
    {
        lock (LOCK)
        {
            PrintTime();
            Console.ForegroundColor = color;

            Console.Write(text ?? string.Empty);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public static void print(params object[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            lock (LOCK)
            {
                print(args[i]);
            }
        }
    }

    public static void print<T>(IEnumerable<T> args)
    {
        foreach (var arg in args)
        {
            lock (LOCK)
            {
                print(arg);
            }
        }
    }

}