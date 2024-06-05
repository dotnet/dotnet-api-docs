using System;
using System.Data;
using System.Diagnostics;

public class Form1
{
    protected enum Option { First, Second };

    protected Option option;

    protected double result;

    public static void Main()
    {
        try
        { }
        // <Snippet1>
        catch (Exception)
        {
            Debug.Fail("Unknown Option " + option + ", using the default.");
        }
        // </Snippet1>

        // <Snippet2>
        switch (option)
        {
            case Option.First:
                result = 1.0;
                break;

            // Insert additional cases.

            default:
                Debug.Fail("Unknown Option " + option);
                result = 1.0;
                break;
        }
        // </Snippet2>
    }
}
