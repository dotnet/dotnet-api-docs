// <Snippet2>
using System;

public class ChangeTypeTest
{
    public static void Main()
    {

        double d = -2.345;
        int i = (int)Convert.ChangeType(d, TypeCode.Int32);

        Console.WriteLine($"The Double {d} when converted to an Int32 is {i}");

        string s = "12/12/2009";
        DateTime dt = (DateTime)Convert.ChangeType(s, typeof(DateTime));

        Console.WriteLine($"The String {s} when converted to a Date is {dt}");
    }
}
// The example displays the following output:
//    The Double -2.345 when converted to an Int32 is -2
//    The String 12/12/2009 when converted to a Date is 12/12/2009 12:00:00 AM
// </Snippet2>
