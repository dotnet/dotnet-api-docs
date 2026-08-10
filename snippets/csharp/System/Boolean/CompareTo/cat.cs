//<snippet1>
// This example demonstrates the generic and non-generic versions of the
// CompareTo method for several base types.
// The non-generic version takes a parameter of type Object, while the generic
// version takes a type-specific parameter, such as Boolean, Int32, or Double.

using System;

class Sample
{
    public static void Main()
    {
        string nl = Environment.NewLine;
        string msg = "{0}The following is the result of using the generic and non-generic{0}" +
                        "versions of the CompareTo method for several base types:{0}";

        DateTime now = DateTime.Now;
        // Time span = 11 days, 22 hours, 33 minutes, 44 seconds
        TimeSpan tsX = new(11, 22, 33, 44);
        // Version = 1.2.333.4
        Version versX = new("1.2.333.4");
        // Guid = CA761232-ED42-11CE-BACD-00AA0057B223
        Guid guidX = new("{CA761232-ED42-11CE-BACD-00AA0057B223}");

        bool a1 = true, a2 = true;
        byte b1 = 1, b2 = 1;
        short c1 = -2, c2 = 2;
        int d1 = 3, d2 = 3;
        long e1 = 4, e2 = -4;
        decimal f1 = -5.5m, f2 = 5.5m;
        float g1 = 6.6f, g2 = 6.6f;
        double h1 = 7.7d, h2 = -7.7d;
        char i1 = 'A', i2 = 'A';
        string j1 = "abc", j2 = "abc";
        DateTime k1 = now, k2 = now;
        TimeSpan l1 = tsX, l2 = tsX;
        Version m1 = versX, m2 = new("2.0");
        Guid n1 = guidX, n2 = guidX;

        // The following types are not CLS-compliant.
        sbyte w1 = 8, w2 = 8;
        ushort x1 = 9, x2 = 9;
        uint y1 = 10, y2 = 10;
        ulong z1 = 11, z2 = 11;
        //
        Console.WriteLine(msg, nl);
        try
        {
            // The second and third Show method call parameters are automatically boxed because
            // the second and third Show method declaration arguments expect type Object.

            Show("Boolean:  ", a1, a2, a1.CompareTo(a2), a1.CompareTo((object)a2));
            Show("Byte:     ", b1, b2, b1.CompareTo(b2), b1.CompareTo((object)b2));
            Show("Int16:    ", c1, c2, c1.CompareTo(c2), c1.CompareTo((object)c2));
            Show("Int32:    ", d1, d2, d1.CompareTo(d2), d1.CompareTo((object)d2));
            Show("Int64:    ", e1, e2, e1.CompareTo(e2), e1.CompareTo((object)e2));
            Show("Decimal:  ", f1, f2, f1.CompareTo(f2), f1.CompareTo((object)f2));
            Show("Single:   ", g1, g2, g1.CompareTo(g2), g1.CompareTo((object)g2));
            Show("Double:   ", h1, h2, h1.CompareTo(h2), h1.CompareTo((object)h2));
            Show("Char:     ", i1, i2, i1.CompareTo(i2), i1.CompareTo((object)i2));
            Show("String:   ", j1, j2, j1.CompareTo(j2), j1.CompareTo((object)j2));
            Show("DateTime: ", k1, k2, k1.CompareTo(k2), k1.CompareTo((object)k2));
            Show("TimeSpan: ", l1, l2, l1.CompareTo(l2), l1.CompareTo((object)l2));
            Show("Version:  ", m1, m2, m1.CompareTo(m2), m1.CompareTo((object)m2));
            Show("Guid:     ", n1, n2, n1.CompareTo(n2), n1.CompareTo((object)n2));
            //
            Console.WriteLine($"{nl}The following types are not CLS-compliant:");
            Show("SByte:    ", w1, w2, w1.CompareTo(w2), w1.CompareTo((object)w2));
            Show("UInt16:   ", x1, x2, x1.CompareTo(x2), x1.CompareTo((object)x2));
            Show("UInt32:   ", y1, y2, y1.CompareTo(y2), y1.CompareTo((object)y2));
            Show("UInt64:   ", z1, z2, z1.CompareTo(z2), z1.CompareTo((object)z2));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void Show(string caption, object var1, object var2,
                            int resultGeneric, int resultNonGeneric)
    {
        string relation;

        Console.Write(caption);
        if (resultGeneric == resultNonGeneric)
        {
            if (resultGeneric < 0)
            {
                relation = "less than";
            }
            else if (resultGeneric > 0)
            {
                relation = "greater than";
            }
            else
            {
                relation = "equal to";
            }

            Console.WriteLine($"{var1} is {relation} {var2}");
        }

        // The following condition will never occur because the generic and non-generic
        // CompareTo methods are equivalent.

        else
        {
            Console.WriteLine($"Generic CompareTo = {resultGeneric}; non-generic CompareTo = {resultNonGeneric}");
        }
    }
}
/*
This example produces the following results:

The following is the result of using the generic and non-generic versions of the
CompareTo method for several base types:

Boolean:  True is equal to True
Byte:     1 is equal to 1
Int16:    -2 is less than 2
Int32:    3 is equal to 3
Int64:    4 is greater than -4
Decimal:  -5.5 is less than 5.5
Single:   6.6 is equal to 6.6
Double:   7.7 is greater than -7.7
Char:     A is equal to A
String:   abc is equal to abc
DateTime: 12/1/2003 5:37:46 PM is equal to 12/1/2003 5:37:46 PM
TimeSpan: 11.22:33:44 is equal to 11.22:33:44
Version:  1.2.333.4 is less than 2.0
Guid:     ca761232-ed42-11ce-bacd-00aa0057b223 is equal to ca761232-ed42-11ce-bacd-00
aa0057b223

The following types are not CLS-compliant:
SByte:    8 is equal to 8
UInt16:   9 is equal to 9
UInt32:   10 is equal to 10
UInt64:   11 is equal to 11
*/
//</snippet1>
