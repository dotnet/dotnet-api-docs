using System;

class Example
{
    static void Main()
    {
        // <Snippet18>
        // Create upper-case characters from their Unicode code units.
        string stringUpper = "\x0041\x0042\x0043";

        // Create lower-case characters from their Unicode code units.
        string stringLower = "\x0061\x0062\x0063";

        // Display the strings.
        Console.WriteLine($"Comparing '{stringUpper}' and '{stringLower}':");

        // Compare the uppercased strings; the result is true.
        Console.WriteLine($"The Strings are equal when capitalized? {(string.Compare(stringUpper.ToUpper(), stringLower.ToUpper()) == 0 ? "true" : "false")}");

        // The previous method call is equivalent to this Compare method, which ignores case.
        Console.WriteLine($"The Strings are equal when case is ignored? {(string.Compare(stringUpper, stringLower, true) == 0 ? "true" : "false")}");

        // The example displays the following output:
        //       Comparing 'ABC' and 'abc':
        //       The Strings are equal when capitalized? true
        //       The Strings are equal when case is ignored? true
        // </Snippet18>
    }
}
