//<snippet1>
// Example for the String Inequality operator.
using System;

class InequalityOp
{
    public static void Main()
    {
        Console.WriteLine(
            "This example of the String Inequality operator\n" +
            "generates the following output.\n");

        CompareAndDisplay("ijkl");
        CompareAndDisplay("ABCD");
        CompareAndDisplay("abcd");
    }

    static void CompareAndDisplay(string Comparand)
    {
        string Lower = "abcd";

        Console.WriteLine($"\"{Lower}\" != \"{Comparand}\" ?  {Lower != Comparand}");
    }
}

/*
This example of the String Inequality operator
generates the following output.

"abcd" != "ijkl" ?  True
"abcd" != "ABCD" ?  True
"abcd" != "abcd" ?  False
*/
//</snippet1>
