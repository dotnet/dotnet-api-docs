// <Snippet2>
using System;

public class BackgroundColorExample2
{
    public static void Run()
    {
        if (Console.BackgroundColor == ConsoleColor.Black)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}
// </Snippet2>
