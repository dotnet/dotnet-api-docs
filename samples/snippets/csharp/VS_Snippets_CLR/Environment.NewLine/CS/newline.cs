//<snippet1>
// Sample for the Environment.NewLine property
using System;

class Sample
{
    public static void Main()
    {
        Console.WriteLine();
        Console.WriteLine($"NewLine: {Environment.NewLine}  first line{Environment.NewLine}  second line");
    }
}

/*
This example produces the following results:

NewLine:
  first line
  second line
*/
//</snippet1>
