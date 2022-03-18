﻿#define TRACE

using System;
using System.Data;
using System.Diagnostics;

public class Form2
{
    public enum Option { First, Second };

    protected double result;

    public void Method(Option option, string userInput)
    {
        int value = 0;
        int newValue = 1;
        try
        {
            value = int.Parse(userInput);
        }
        // <Snippet1>
        catch (Exception)
        {
            Trace.Fail("Invalid value: " + value.ToString(),
               "Resetting value to newValue.");
            value = newValue;
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
                Trace.Fail("Unsupported option " + option, "Result set to 1.0");
                result = 1.0;
                break;
        }
        // </Snippet2>
    }

    [STAThread]
    static void Main()
    {
        var myForm = new Form2();
        myForm.Method(Option.Second, "not an integer string");
    }
}
