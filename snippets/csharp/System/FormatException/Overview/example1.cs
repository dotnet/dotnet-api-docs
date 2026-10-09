// <Snippet1>
using System;

public class Example1
{
    public enum TemperatureScale
    { Celsius, Fahrenheit, Kelvin }

    public static void Run()
    {
        string info = GetCurrentTemperature();
        Console.WriteLine(info);
    }

    private static string GetCurrentTemperature()
    {
        DateTime dat = DateTime.Now;
        decimal temp = 20.6m;
        TemperatureScale scale = TemperatureScale.Celsius;
        string result;

        result = string.Format("At {0:t} on {1:D}, the temperature is {2:F1} {3:G}",
                               dat, temp, scale);
        return result;
    }
}

// The example displays output like the following:
//    Unhandled Exception: System.FormatException: Format specifier was invalid.
//       at System.Number.FormatDecimal(Decimal value, String format, NumberFormatInfo info)
//       at System.Decimal.ToString(String format, IFormatProvider provider)
//       at System.Text.StringBuilder.AppendFormat(IFormatProvider provider, String format, Object[] args)
//       at System.String.Format(IFormatProvider provider, String format, Object[] args)
//       at Example.Main()
// </Snippet1>
