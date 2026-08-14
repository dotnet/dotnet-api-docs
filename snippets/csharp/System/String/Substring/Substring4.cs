using System;

public class SubstringLengthExample
{
    public static void Run()
    {
        // <Snippet4>
        string value = "This is a string.";
        int startIndex = 5;
        int length = 2;
        string substring = value.Substring(startIndex, length);
        Console.WriteLine(substring);

        // The example displays the following output:
        //       is
        // </Snippet4>
    }
}
