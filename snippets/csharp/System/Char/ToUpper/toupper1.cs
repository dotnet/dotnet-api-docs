using System;

public class Example1
{
    public static void Run()
    {
        // <Snippet1>
        char[] chars = { 'e', 'E', '6', ',', 'ж', 'ä' };
        foreach (char ch in chars)
            Console.WriteLine($"{ch} --> {char.ToUpper(ch)} {(ch == char.ToUpper(ch) ? "(Same Character)" : "")}");

        // The example displays the following output:
        //       e --> E
        //       E --> E (Same Character)
        //       6 --> 6 (Same Character)
        //       , --> , (Same Character)
        //       ж --> Ж
        //       ä --> Ä
        // </Snippet1>
    }
}
