// <snippet23>
using System;

public class CharStructureSample
{
    public static void Main()
    {
        char chA = 'A';
        char ch1 = '1';
        string str = "test string";

        Console.WriteLine(chA.CompareTo('B'));          //-----------  Output: "-1" (meaning 'A' is 1 less than 'B')
        Console.WriteLine(chA.Equals('A'));             //-----------  Output: "True"
        Console.WriteLine(char.GetNumericValue(ch1));   //-----------  Output: "1"
        Console.WriteLine(char.IsControl('\t'));        //-----------  Output: "True"
        Console.WriteLine(char.IsDigit(ch1));           //-----------  Output: "True"
        Console.WriteLine(char.IsLetter(','));          //-----------  Output: "False"
        Console.WriteLine(char.IsLower('u'));           //-----------  Output: "True"
        Console.WriteLine(char.IsNumber(ch1));          //-----------  Output: "True"
        Console.WriteLine(char.IsPunctuation('.'));     //-----------  Output: "True"
        Console.WriteLine(char.IsSeparator(str, 4));    //-----------  Output: "True"
        Console.WriteLine(char.IsSymbol('+'));          //-----------  Output: "True"
        Console.WriteLine(char.IsWhiteSpace(str, 4));   //-----------  Output: "True"
        Console.WriteLine(char.Parse("S"));             //-----------  Output: "S"
        Console.WriteLine(char.ToLower('M'));           //-----------  Output: "m"
        Console.WriteLine('x'.ToString());              //-----------  Output: "x"
    }
}
// </snippet23>
