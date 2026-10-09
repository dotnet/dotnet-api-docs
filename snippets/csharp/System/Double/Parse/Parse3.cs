// <Snippet2>
using System;
using System.Globalization;

public class Temperature
{
    // Parses the temperature from a string. Temperature scale is
    // indicated by 'F (for Fahrenheit) or 'C (for Celsius) at the end
    // of the string.
    public static Temperature Parse(string s, NumberStyles styles,
                                    IFormatProvider provider)
    {
        Temperature temp = new();

        if (s.TrimEnd(null).EndsWith("'F"))
        {
            temp.Value = double.Parse(s.Remove(s.LastIndexOf((char)39), 2),
                                      styles, provider);
        }
        else
        {
            if (s.TrimEnd(null).EndsWith("'C"))
                temp.Celsius = double.Parse(s.Remove(s.LastIndexOf((char)39), 2),
                                            styles, provider);
            else
                temp.Value = double.Parse(s, styles, provider);
        }
        return temp;
    }

    // Declare private constructor so Temperature so only Parse method can
    // create a new instance
    private Temperature() { }

    protected double m_value;

    public double Value
   {
      get => m_value;
      private set => m_value = value;
   }

    public double Celsius
   {
      get => (m_value - 32) / 1.8;
      private set => m_value = value * 1.8 + 32;
   }

    public double Fahrenheit => m_value;
}

public class TestTemperature
{
    public static void Main()
    {
        string value;
        NumberStyles styles;
        IFormatProvider provider;
        Temperature temp;

        value = "25,3'C";
        styles = NumberStyles.Float;
        provider = CultureInfo.CreateSpecificCulture("fr-FR");
        temp = Temperature.Parse(value, styles, provider);
        Console.WriteLine($"{temp.Fahrenheit} degrees Fahrenheit equals {temp.Celsius} degrees Celsius.");

        value = " (40) 'C";
        styles = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite
                 | NumberStyles.AllowParentheses;
        provider = NumberFormatInfo.InvariantInfo;
        temp = Temperature.Parse(value, styles, provider);
        Console.WriteLine($"{temp.Fahrenheit} degrees Fahrenheit equals {temp.Celsius} degrees Celsius.");

        value = "5,778E03'C";      // Approximate surface temperature of the Sun
        styles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands |
                 NumberStyles.AllowExponent;
        provider = CultureInfo.CreateSpecificCulture("en-GB");
        temp = Temperature.Parse(value, styles, provider);
        Console.WriteLine($"{temp.Fahrenheit.ToString("N")} degrees Fahrenheit equals {temp.Celsius.ToString("N")} degrees Celsius.");
    }
}
// </Snippet2>
