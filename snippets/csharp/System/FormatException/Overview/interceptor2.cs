// <Snippet11>
using System;
using System.Globalization;

public class InterceptProvider : IFormatProvider, ICustomFormatter
{
    public object GetFormat(Type formatType)
    {
        if (formatType == typeof(ICustomFormatter))
            return this;
        else
            return null;
    }

    public string Format(string format, object obj, IFormatProvider provider)
    {
        // Display information about method call.
        string formatString = format ?? "<null>";
        Console.WriteLine($"Provider: {provider.GetType().Name}, Object: {obj ?? "<null>"}, Format String: {formatString}");

        if (obj == null) return string.Empty;

        // If this is a byte and the "R" format string, format it with Roman numerals.
        if (obj is byte && formatString.ToUpper().Equals("R"))
        {
            byte value = (byte)obj;
            int remainder;
            int result;
            string returnString = string.Empty;

            // Get the hundreds digit(s)
            result = Math.DivRem(value, 100, out remainder);
            if (result > 0)
                returnString = new('C', result);
            value = (byte)remainder;
            // Get the 50s digit
            result = Math.DivRem(value, 50, out remainder);
            if (result == 1)
                returnString += "L";
            value = (byte)remainder;
            // Get the tens digit.
            result = Math.DivRem(value, 10, out remainder);
            if (result > 0)
                returnString += new string('X', result);
            value = (byte)remainder;
            // Get the fives digit.
            result = Math.DivRem(value, 5, out remainder);
            if (result > 0)
                returnString += "V";
            value = (byte)remainder;
            // Add the ones digit.
            if (remainder > 0)
                returnString += new string('I', remainder);

            // Check whether we have too many X characters.
            int pos = returnString.IndexOf("XXXX");
            if (pos >= 0)
            {
                int xPos = returnString.IndexOf("L");
                if (xPos >= 0 & xPos == pos - 1)
                    returnString = returnString.Replace("LXXXX", "XC");
                else
                    returnString = returnString.Replace("XXXX", "XL");
            }
            // Check whether we have too many I characters
            pos = returnString.IndexOf("IIII");
            if (pos >= 0)
                if (returnString.IndexOf("V") >= 0)
                    returnString = returnString.Replace("VIIII", "IX");
                else
                    returnString = returnString.Replace("IIII", "IV");

            return returnString;
        }

        // Use default for all other formatting.
        if (obj is IFormattable)
            return ((IFormattable)obj).ToString(format, CultureInfo.CurrentCulture);
        else
            return obj.ToString();
    }
}

public class FormatExample12
{
    public static void Main()
    {
        int n = 10;
        double value = 16.935;
        DateTime day = DateTime.Now;
        InterceptProvider provider = new();
        Console.WriteLine($"{n:N0}: {value:C2} on {day:d}\n");
        Console.WriteLine($"{"Today: "}: {(DayOfWeek)DateTime.Now.DayOfWeek:F}\n");
        Console.WriteLine($"{(byte)2:X}, {(byte)12}, {(byte)199}\n");
        Console.WriteLine($"{(byte)2:R}, {(byte)12:R}, {(byte)199:R}\n");
    }
}
// The example displays the following output:
//    Provider: InterceptProvider, Object: 10, Format String: N0
//    Provider: InterceptProvider, Object: 16.935, Format String: C2
//    Provider: InterceptProvider, Object: 1/31/2013 6:10:28 PM, Format String: d
//    10: $16.94 on 1/31/2013
//
//    Provider: InterceptProvider, Object: Today: , Format String: <null>
//    Provider: InterceptProvider, Object: Thursday, Format String: F
//    Today: : Thursday
//
//    Provider: InterceptProvider, Object: 2, Format String: X
//    Provider: InterceptProvider, Object: 12, Format String: <null>
//    Provider: InterceptProvider, Object: 199, Format String: <null>
//    2, 12, 199
//
//    Provider: InterceptProvider, Object: 2, Format String: R
//    Provider: InterceptProvider, Object: 12, Format String: R
//    Provider: InterceptProvider, Object: 199, Format String: R
//    II, XII, CXCIX
// </Snippet11>
