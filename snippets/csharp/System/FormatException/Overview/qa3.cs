using System;

public class FormatExample13
{
    public static void Main()
    {
        WillThrow();
        Console.WriteLine();
        WontThrow();
        Console.WriteLine();
        Recommended();
    }

    public static void WillThrow()
    {
        string result;
        int nOpen = 1;
        int nClose = 2;
        try
        {
            // <Snippet23>
            result = string.Format("The text has {0} '{' characters and {1} '}' characters.",
                                   nOpen, nClose);
            // </Snippet23>
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("FormatException");
        }
    }

    public static void WontThrow()
    {
        // <Snippet24>
        string result;
        int nOpen = 1;
        int nClose = 2;
        result = $"The text has {nOpen} '{{' characters and {nClose} '}}' characters.";
        Console.WriteLine(result);
        // </Snippet24>
    }

    public static void Recommended()
    {
        // <Snippet25>
        string result;
        int nOpen = 1;
        int nClose = 2;
        result = $"The text has {nOpen} '{"{"}' characters and {nClose} '{"}"}' characters.";
        Console.WriteLine(result);
        // </Snippet25>
    }
}
