//<snippet1>
using System;

public class ChangeTypeTest
{
    public static void Main()
    {

        double d = -2.345;
        int i = (int)Convert.ChangeType(d, typeof(int));

        Console.WriteLine($"The double value {d} when converted to an int becomes {i}");

        string s = "12/12/98";
        DateTime dt = (DateTime)Convert.ChangeType(s, typeof(DateTime));

        Console.WriteLine($"The string value {s} when converted to a Date becomes {dt}");
    }
}
//</snippet1>
