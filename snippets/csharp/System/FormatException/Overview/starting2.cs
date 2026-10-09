using System;

public class Example15
{
    public static void Main()
    {
        // <Snippet35>
        decimal pricePerOunce = 17.36m;
        string s = $"The current price is {pricePerOunce} per ounce.";
        Console.WriteLine(s);
        // Result: The current price is 17.36 per ounce.
        // </Snippet35>
        ShowFormatted();
    }

    private static void ShowFormatted()
    {
        // <Snippet36>
        decimal pricePerOunce = 17.36m;
        string s = $"The current price is {pricePerOunce:C2} per ounce.";
        Console.WriteLine(s);
        // Result if current culture is en-US:
        //      The current price is $17.36 per ounce.
        // </Snippet36>
    }
}
