using System.Diagnostics;


public static partial class Print
{
    static Stopwatch stopwatch = new Stopwatch();
    static Print() => stopwatch.Start();

    static readonly object LOCK = new object();

    private static void PrintTime()
    {
        DateTime dateTime = DateTime.Now;
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[");
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{dateTime.ToString("yyyy.MM.dd")}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(":");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{dateTime.ToString("HH:mm.ss")}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(".");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"{dateTime.ToString("fff")}");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("]");
            Console.Write(" ");
        }
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"{stopwatch.ElapsedMilliseconds} ms");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("]");
            stopwatch.Restart();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("	");
    }


}