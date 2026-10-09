// <Snippet4>
using System;

public class Automobile
{
    private int _doors;
    private string _cylinders;
    private int _year;
    private string _model;

    public Automobile(string model, int year, int doors,
                      string cylinders)
    {
        _model = model;
        _year = year;
        _doors = doors;
        _cylinders = cylinders;
    }

    public int Doors => _doors;

    public string Model => _model;

    public int Year => _year;

    public string Cylinders => _cylinders;

    public override string ToString() => ToString("G");

    public string ToString(string fmt)
    {
        if (string.IsNullOrEmpty(fmt))
            fmt = "G";

        switch (fmt.ToUpperInvariant())
        {
            case "G":
                return $"{_year} {_model}";
            case "D":
                return $"{_year} {_model}, {_doors} dr.";
            case "C":
                return $"{_year} {_model}, {_cylinders}";
            case "A":
                return $"{_year} {_model}, {_doors} dr. {_cylinders}";
            default:
                string msg = $"'{fmt}' is an invalid format string";
                throw new ArgumentException(msg);
        }
    }
}

public class Example7
{
    public static void Main()
    {
        var auto = new Automobile("Lynx", 2016, 4, "V8");
        Console.WriteLine(auto.ToString());
        Console.WriteLine(auto.ToString("A"));
    }
}
// The example displays the following output:
//       2016 Lynx
//       2016 Lynx, 4 dr. V8
// </Snippet4>
