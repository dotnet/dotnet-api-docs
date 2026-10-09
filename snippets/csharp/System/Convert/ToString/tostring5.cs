// <Snippet26>
using System;

public class Temperature
{
    private decimal m_Temp;

    public Temperature(decimal temperature) => this.m_Temp = temperature;

    public decimal Celsius => this.m_Temp;

    public decimal Kelvin => this.m_Temp + 273.15m;

    public decimal Fahrenheit => Math.Round((decimal)(this.m_Temp * 9 / 5 + 32), 2);

    public override string ToString() => m_Temp.ToString("N2") + " °C";
}

public class Example
{
    public static void Main()
    {
        Temperature cold = new(-40);
        Temperature freezing = new(0);
        Temperature boiling = new(100);

        Console.WriteLine(Convert.ToString(cold, null));
        Console.WriteLine(Convert.ToString(freezing, null));
        Console.WriteLine(Convert.ToString(boiling, null));
    }
}
// The example dosplays the following output:
//       -40.00 °C
//       0.00 °C
//       100.00 °C
// </Snippet26>
