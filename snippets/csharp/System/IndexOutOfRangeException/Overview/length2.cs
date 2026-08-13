// <Snippet4>
using System;
using System.Collections.Generic;

public class LengthExample2
{
    public static void Run()
    {
        List<char> characters = new();
        characters.InsertRange(0, new char[] { 'a', 'b', 'c', 'd', 'e', 'f' });
        for (int ctr = 0; ctr < characters.Count; ctr++)
            Console.Write($"'{characters[ctr]}'    ");
    }
}
// The example displays the following output:
//        'a'    'b'    'c'    'd'    'e'    'f'
// </Snippet4>
