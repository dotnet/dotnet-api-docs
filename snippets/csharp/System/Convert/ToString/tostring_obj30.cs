// <Snippet30>
using System;

public class Temperature : IFormattable
{
    private decimal m_Temp;

    public Temperature(decimal temperature) => this.m_Temp = temperature;

    public decimal Celsius => this.m_Temp;

    public decimal Kelvin => this.m_Temp + 273.15m;

    public decimal Fahrenheit => Math.Round(this.m_Temp * 9m / 5m + 32m, 2);

    public override string ToString() => ToString("G", null);

    public string ToString(string fmt, IFormatProvider provider)
    {
        TemperatureProvider formatter = null;
        if (provider != null)
            formatter = provider.GetFormat(typeof(TemperatureProvider))
                                          as TemperatureProvider;

        if (string.IsNullOrWhiteSpace(fmt))
        {
            if (formatter != null)
                fmt = formatter.Format;
            else
                fmt = "G";
        }

        switch (fmt.ToUpper())
        {
            case "G":
            case "C":
                return m_Temp.ToString("N2") + " °C";
            case "F":
                return Fahrenheit.ToString("N2") + " °F";
            case "K":
                return Kelvin.ToString("N2") + " K";
            default:
                throw new FormatException($"'{fmt}' is not a valid format specifier.");
        }
    }
}

public class TemperatureProvider : IFormatProvider
{
    private string[] fmtStrings = { "C", "G", "F", "K" };
    private Random rnd = new();

    public object GetFormat(Type formatType) => this;

    public string Format => fmtStrings[rnd.Next(0, fmtStrings.Length)];
}

public class Example
{
    public static void Main()
    {
        Temperature cold = new(-40);
        Temperature freezing = new(0);
        Temperature boiling = new(100);

        TemperatureProvider tp = new();

        Console.WriteLine(Convert.ToString(cold, tp));
        Console.WriteLine(Convert.ToString(freezing, tp));
        Console.WriteLine(Convert.ToString(boiling, tp));
    }
}
// The example displays output like the following:
//       -40.00 °C
//       273.15 K
//       100.00 °C
// </Snippet30>
