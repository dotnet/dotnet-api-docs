using System;

public class Example
{
    public static void Main()
    {
        ConvertByte();
        Console.WriteLine("-----");
        ConvertInt16();
        Console.WriteLine("-----");
        ConvertInt32();
        Console.WriteLine("-----");
        ConvertSByte();
        Console.WriteLine("-----");
        ConvertString();
        Console.WriteLine("-----");
        ConvertUInt16();
        Console.WriteLine("-----");
        ConvertUInt32();
        Console.WriteLine("-----");
        ConvertUInt64();
        Console.WriteLine("-----");
        ConvertObject();
    }

    private static void ConvertByte()
    {
        // <Snippet1>
        byte[] bytes = { byte.MinValue, 40, 80, 120, 180, byte.MaxValue };
        char result;
        foreach (byte number in bytes)
        {
            result = Convert.ToChar(number);
            Console.WriteLine($"{number} converts to '{result}'.");
        }
        // The example displays the following output:
        //       0 converts to ' '.
        //       40 converts to '('.
        //       80 converts to 'P'.
        //       120 converts to 'x'.
        //       180 converts to '''.
        //       255 converts to 'ÿ'.
        // </Snippet1>
    }

    private static void ConvertInt16()
    {
        // <Snippet2>
        short[] numbers = { short.MinValue, 0, 40, 160, 255, 1028,
                          2011, short.MaxValue };
        char result;
        foreach (short number in numbers)
        {
            try
            {
                result = Convert.ToChar(number);
                Console.WriteLine($"{number} converts to '{result}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{number} is outside the range of the Char data type.");
            }
        }
        // The example displays the following output:
        //       -32768 is outside the range of the Char data type.
        //       0 converts to ' '.
        //       40 converts to '('.
        //       160 converts to ' '.
        //       255 converts to 'ÿ'.
        //       1028 converts to 'Є'.
        //       2011 converts to 'ߛ'.
        //       32767 converts to '翿'.
        // </Snippet2>
    }

    private static void ConvertInt32()
    {
        // <Snippet3>
        int[] numbers = { -1, 0, 40, 160, 255, 1028,
                        2011, 30001, 207154, int.MaxValue };
        char result;
        foreach (int number in numbers)
        {
            try
            {
                result = Convert.ToChar(number);
                Console.WriteLine($"{number} converts to '{result}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{number} is outside the range of the Char data type.");
            }
        }
        //       -1 is outside the range of the Char data type.
        //       0 converts to ' '.
        //       40 converts to '('.
        //       160 converts to ' '.
        //       255 converts to 'ÿ'.
        //       1028 converts to 'Є'.
        //       2011 converts to 'ߛ'.
        //       30001 converts to '由'.
        //       207154 is outside the range of the Char data type.
        //       2147483647 is outside the range of the Char data type.
        // </Snippet3>
    }

    private static void ConvertSByte()
    {
        // <Snippet4>
        sbyte[] numbers = { sbyte.MinValue, -1, 40, 80, 120, sbyte.MaxValue };
        char result;
        foreach (sbyte number in numbers)
        {
            try
            {
                result = Convert.ToChar(number);
                Console.WriteLine($"{number} converts to '{result}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{number} is outside the range of the Char data type.");
            }
        }
        // The example displays the following output:
        //       -128 is outside the range of the Char data type.
        //       -1 is outside the range of the Char data type.
        //       40 converts to '('.
        //       80 converts to 'P'.
        //       120 converts to 'x'.
        //       127 converts to '⌂'.
        // </Snippet4>
    }

    private static void ConvertString()
    {
        // <Snippet5>
        string nullString = null;
        string[] strings = { "A", "This", '\u0007'.ToString(), nullString };
        char result;
        foreach (string strng in strings)
        {
            try
            {
                result = Convert.ToChar(strng);
                Console.WriteLine($"'{strng}' converts to '{result}'.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"'{strng}' is not in the correct format for conversion to a Char.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("A null string cannot be converted to a Char.");
            }
        }
        // The example displays the following output:
        //       'A' converts to 'A'.
        //       'This' is not in the correct format for conversion to a Char.
        //       '       ' converts to ' '.
        //       A null string cannot be converted to a Char.
        // </Snippet5>
    }

    private static void ConvertUInt16()
    {
        // <Snippet6>
        ushort[] numbers = { ushort.MinValue, 40, 160, 255, 1028,
                           2011, ushort.MaxValue };
        char result;
        foreach (ushort number in numbers)
        {
            result = Convert.ToChar(number);
            Console.WriteLine($"{number} converts to '{result}'.");
        }
        // The example displays the following output:
        //       0 converts to ' '.
        //       40 converts to '('.
        //       160 converts to ' '.
        //       255 converts to 'ÿ'.
        //       1028 converts to 'Є'.
        //       2011 converts to 'ߛ'.
        //       65535 converts to '￿'.
        // </Snippet6>
    }

    private static void ConvertUInt32()
    {
        // <Snippet7>
        uint[] numbers = { uint.MinValue, 40, 160, 255, 1028,
                         2011, 30001, 207154, int.MaxValue };
        char result;
        foreach (uint number in numbers)
        {
            try
            {
                result = Convert.ToChar(number);
                Console.WriteLine($"{number} converts to '{result}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{number} is outside the range of the Char data type.");
            }
        }
        // The example displays the following output:
        //       0 converts to ' '.
        //       40 converts to '('.
        //       160 converts to ' '.
        //       255 converts to 'ÿ'.
        //       1028 converts to 'Є'.
        //       2011 converts to 'ߛ'.
        //       30001 converts to '由'.
        //       207154 is outside the range of the Char data type.
        //       2147483647 is outside the range of the Char data type.
        // </Snippet7>
    }

    private static void ConvertUInt64()
    {
        // <Snippet8>
        ulong[] numbers = { ulong.MinValue, 40, 160, 255, 1028,
                          2011, 30001, 207154, long.MaxValue };
        char result;
        foreach (ulong number in numbers)
        {
            try
            {
                result = Convert.ToChar(number);
                Console.WriteLine($"{number} converts to '{result}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{number} is outside the range of the Char data type.");
            }
        }
        // The example displays the following output:
        //       0 converts to ' '.
        //       40 converts to '('.
        //       160 converts to ' '.
        //       255 converts to 'ÿ'.
        //       1028 converts to 'Є'.
        //       2011 converts to 'ߛ'.
        //       30001 converts to '由'.
        //       207154 is outside the range of the Char data type.
        //       9223372036854775807 is outside the range of the Char data type.
        // </Snippet8>
    }

    private static void ConvertObject()
    {
        // <Snippet9>
        object[] values = { 'r', "s", "word", (byte) 83, 77, 109324, 335812911,
                          new DateTime(2009, 3, 10), (uint) 1934,
                          (sbyte) -17, 169.34, 175.6m, null };
        char result;

        foreach (object value in values)
        {
            try
            {
                result = Convert.ToChar(value);
                Console.WriteLine($"The {value.GetType().Name} value {value} converts to {result}.");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine($"Conversion of the {value.GetType().Name} value {value} to a Char is not supported.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {value.GetType().Name} value {value} is outside the range of the Char data type.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Cannot convert a null reference to a Char.");
            }
        }
        // The example displays the following output:
        //       The Char value r converts to r.
        //       The String value s converts to s.
        //       String must be exactly one character long.
        //       The Byte value 83 converts to S.
        //       The Int32 value 77 converts to M.
        //       The Int32 value 109324 is outside the range of the Char data type.
        //       The Int32 value 335812911 is outside the range of the Char data type.
        //       Conversion of the DateTime value 3/10/2009 12:00:00 AM to a Char is not supported.
        //       The UInt32 value 1934 converts to ?.
        //       The SByte value -17 is outside the range of the Char data type.
        //       Conversion of the Double value 169.34 to a Char is not supported.
        //       Conversion of the Decimal value 175.6 to a Char is not supported.
        //       Cannot convert a null reference to a Char.
        // </Snippet9>
    }
}
