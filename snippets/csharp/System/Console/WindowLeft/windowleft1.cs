// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        ConsoleKeyInfo key;
        bool moved = false;

        Console.BufferWidth += 4;
        Console.Clear();

        ShowConsoleStatistics();
        do
        {
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.LeftArrow)
            {
                int pos = Console.WindowLeft - 1;
                if (pos >= 0 && pos + Console.WindowWidth <= Console.BufferWidth)
                {
                    Console.WindowLeft = pos;
                    moved = true;
                }
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                int pos = Console.WindowLeft + 1;
                if (pos + Console.WindowWidth <= Console.BufferWidth)
                {
                    Console.WindowLeft = pos;
                    moved = true;
                }
            }
            if (moved)
            {
                ShowConsoleStatistics();
                moved = false;
            }
            Console.WriteLine();
        } while (true);
    }

    private static void ShowConsoleStatistics()
    {
        Console.WriteLine("Console statistics:");
        Console.WriteLine($"   Buffer: {Console.BufferHeight} x {Console.BufferWidth}");
        Console.WriteLine($"   Window: {Console.WindowHeight} x {Console.WindowWidth}");
        Console.WriteLine($"   Window starts at {Console.WindowLeft}.");
        Console.WriteLine("Press <- or -> to move window, Ctrl+C to exit.");
    }
}
// </Snippet1>
