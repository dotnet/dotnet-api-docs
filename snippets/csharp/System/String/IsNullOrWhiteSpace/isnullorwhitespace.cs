using System;

public class IsNullOrWhiteSpaceEquivalentExample
{
    public static void Run() => Console.WriteLine(ShowCode());

    private static bool ShowCode()
    {
        string value = null;
        // <Snippet2>
        return string.IsNullOrEmpty(value) || value.Trim().Length == 0;
        // </Snippet2>
    }
}
