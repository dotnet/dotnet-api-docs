using System;
using System.Diagnostics;

public class Form1
{
    protected enum Option
    {
        First,
        Second
    }

    private static Option SelectedOption { get; set; }

    private static double Result { get; set; }

    public static void Main()
    {
        try
        {
        }
        // <Snippet1>
        catch (Exception)
        {
            Debug.Fail($"Unknown Option {SelectedOption}, using the default.");
        }
        // </Snippet1>

        // <Snippet2>
        switch (SelectedOption)
        {
            case Option.First:
                Result = 1.0;
                break;

            // Insert additional cases.

            default:
                Debug.Fail($"Unknown Option {SelectedOption}");
                Result = 1.0;
                break;
        }
        // </Snippet2>
    }
}
