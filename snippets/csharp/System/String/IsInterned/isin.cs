//<snippet1>
// Sample for String.IsInterned(String)
using System;
using System.Text;

class Sample
{
    public static void Main()
    {
        // Constructed strings are not automatically interned.
        string s1 = new StringBuilder().Append("My").Append("Test").ToString();
        string s2 = new StringBuilder().Append("My").Append("Test").ToString();

        // Neither string is in the intern pool yet.
        Console.WriteLine($"Is s1 interned? {String.IsInterned(s1) != null}");
        Console.WriteLine($"Is s2 interned? {String.IsInterned(s2) != null}");

        // Intern s1 explicitly.
        string i1 = String.Intern(s1);

        // Now s2 can be found in the intern pool.
        string i2 = String.IsInterned(s2);

        Console.WriteLine($"Is s2 interned after interning s1? {i2 != null}");
        Console.WriteLine($"Are i1 and i2 the same reference? {Object.ReferenceEquals(i1, i2)}");
    }
}

// This example produces the following results:
//
// Is s1 interned? False
// Is s2 interned? False
// Is s2 interned after interning s1? True
// Are i1 and i2 the same reference? True

//</snippet1>