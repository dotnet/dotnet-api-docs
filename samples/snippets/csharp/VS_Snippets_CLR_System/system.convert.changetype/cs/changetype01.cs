// <Snippet2>
using System;

public class ChangeTypeTest {
    public static void Main() {

        Double d = -2.345;
        int i = (int)Convert.ChangeType(d, TypeCode.Int32);

        Console.WriteLine("The Double {0} when converted to an int is {1}", d, i);

        string s = "12/12/2009";
        DateTime dt = (DateTime)Convert.ChangeType(s, typeof(DateTime));

        Console.WriteLine("The string {0} when converted to a Date is {1}", s, dt);
    }
}
// The example displays the following output:
//    The Double -2.345 when converted to an int is -2
//    The string 12/12/2009 when converted to a Date is 12/12/2009 12:00:00 AM
// </Snippet2>
