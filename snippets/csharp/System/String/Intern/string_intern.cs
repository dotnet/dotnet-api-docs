//<snippet1>
// Sample for String.Intern(String)
using System;
using System.Text;

class Sample
{
    public static void Main()
    {
        string s1 = new StringBuilder().Append("My").Append("Test").ToString();
        string s2 = new StringBuilder().Append("My").Append("Test").ToString();
        Console.WriteLine($"s1 == {s1}");
        Console.WriteLine($"s2 == {s2}");
        Console.WriteLine($"Are s1 and s2 equal in value? {s1 == s2}");
        Console.WriteLine($"Are s1 and s2 the same reference? {Object.ReferenceEquals(s1, s2)}");

        string i1 = String.Intern(s1);
        string i2 = String.Intern(s2);
        Console.WriteLine($"After interning:");
        Console.WriteLine($"  Are i1 and i2 equal in value? {i1 == i2}");
        Console.WriteLine($"  Are i1 and i2 the same reference? {Object.ReferenceEquals(i1, i2)}");
    }
}
/*
This example produces the following results:
s1 == MyTest
s2 == MyTest
Are s1 and s2 equal in value? True
Are s1 and s2 the same reference? False
After interning:
  Are i1 and i2 equal in value? True
  Are i1 and i2 the same reference? True
*/
//</snippet1>
