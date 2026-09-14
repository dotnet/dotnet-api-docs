using System;
using System.Diagnostics;

public class Form2
{
    protected enum MyOption
    {
        First,
        Second
    }

    private MyOption SelectedOption { get; set; }
    private double Result { get; set; }
    private double Value { get; set; }
    private double NewValue { get; set; }
    protected void Method()
    {
        try
        {
        }
        // <Snippet1>
        catch (Exception)
        {
            Debug.Fail($"Invalid value: {Value}",
               "Resetting value to newValue.");
            Value = NewValue;
        }
        // </Snippet1>

        // <Snippet2>
        switch (SelectedOption)
        {
            case MyOption.First:
                Result = 1.0;
                break;

            // Insert additional cases.

            default:
                Debug.Fail($"Unknown Option {SelectedOption}", "Result set to 1.0");
                Result = 1.0;
                break;
        }
        // </Snippet2>
    }
}
