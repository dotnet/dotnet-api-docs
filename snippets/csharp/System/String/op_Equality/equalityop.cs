//<snippet1>
// Example for the String Equality operator.
using System;

class EqualityOp
{
    public static void Main()
    {
        Console.WriteLine(
            "This example of the String Equality operator\n" +
            "generates the following output.\n");

        CompareAndDisplay("ijkl");
        CompareAndDisplay("ABCD");
        CompareAndDisplay("abcd");
    }

    static void CompareAndDisplay(string Comparand)
    {
        string Lower = "abcd";

        Console.WriteLine($"\"{Lower}\" == \"{Comparand}\" ?  {Lower == Comparand}");
    }
}

/*
This example of the String Equality operator
generates the following output.

"abcd" == "ijkl" ?  False
"abcd" == "ABCD" ?  False
"abcd" == "abcd" ?  True
*/
//</snippet1>
