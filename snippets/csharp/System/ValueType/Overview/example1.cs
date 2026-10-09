// <Snippet1>
using System;
using System.Numerics;

public class Utility
{
    public enum NumericRelationship
    {
        GreaterThan = 1,
        EqualTo = 0,
        LessThan = -1
    };

    public static NumericRelationship Compare(ValueType value1, ValueType value2)
    {
        if (!IsNumeric(value1))
            throw new ArgumentException("value1 is not a number.");
        else if (!IsNumeric(value2))
            throw new ArgumentException("value2 is not a number.");

        // Use BigInteger as common integral type
        if (IsInteger(value1) && IsInteger(value2))
        {
            BigInteger bigint1 = (BigInteger)value1;
            BigInteger bigint2 = (BigInteger)value2;
            return (NumericRelationship)BigInteger.Compare(bigint1, bigint2);
        }
        // At least one value is floating point; use Double.
        else
        {
            double dbl1 = 0;
            double dbl2 = 0;
            try
            {
                dbl1 = Convert.ToDouble(value1);
            }
            catch (OverflowException)
            {
                Console.WriteLine("value1 is outside the range of a Double.");
            }
            try
            {
                dbl2 = Convert.ToDouble(value2);
            }
            catch (OverflowException)
            {
                Console.WriteLine("value2 is outside the range of a Double.");
            }
            return (NumericRelationship)dbl1.CompareTo(dbl2);
        }
    }

    public static bool IsInteger(ValueType value) => (value is sbyte || value is short || value is int
               || value is long || value is byte || value is ushort
               || value is uint || value is ulong
               || value is BigInteger);

    public static bool IsFloat(ValueType value) => (value is float || value is double || value is decimal);

    public static bool IsNumeric(ValueType value) => (value is byte ||
               value is short ||
               value is int ||
               value is long ||
               value is sbyte ||
               value is ushort ||
               value is uint ||
               value is ulong ||
               value is BigInteger ||
               value is decimal ||
               value is double ||
               value is float);
}
// </Snippet1>

// <Snippet2>
public class Example
{
    public static void Main()
    {
        Console.WriteLine(Utility.IsNumeric(12));
        Console.WriteLine(Utility.IsNumeric(true));
        Console.WriteLine(Utility.IsNumeric('c'));
        Console.WriteLine(Utility.IsNumeric(new DateTime(2012, 1, 1)));
        Console.WriteLine(Utility.IsInteger(12.2));
        Console.WriteLine(Utility.IsInteger(123456789));
        Console.WriteLine(Utility.IsFloat(true));
        Console.WriteLine(Utility.IsFloat(12.2));
        Console.WriteLine(Utility.IsFloat(12));
        Console.WriteLine($"{12.1} {Utility.Compare(12.1, 12)} {12}");
    }
}
// The example displays the following output:
//       True
//       False
//       False
//       False
//       False
//       True
//       False
//       True
//       False
//       12.1 GreaterThan 12
// </Snippet2>
