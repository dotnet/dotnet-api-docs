using System;

public class Class1
{
    public static void Main()
    {
        ConvertBoolean();
        Console.WriteLine("-----");
        ConvertByte();
        Console.WriteLine("-----");
        ConvertChar();
        Console.WriteLine("-----");
        ConvertDecimal();
        Console.WriteLine("-----");
        ConvertDouble();
        Console.WriteLine("-----");
        ConvertInt32();
        Console.WriteLine("-----");
        ConvertInt64();
        Console.WriteLine("-----");
        ConvertObject();
        Console.WriteLine("-----");
        ConvertSByte();
        Console.WriteLine("-----");
        ConvertSingle();
        Console.WriteLine("----");
        ConvertUInt16();
        Console.WriteLine("-----");
        ConvertUInt32();
        Console.WriteLine("-----");
        ConvertUInt64();
    }

    private static void ConvertBoolean()
    {
        // <Snippet1>
        bool falseFlag = false;
        bool trueFlag = true;

        Console.WriteLine($"{falseFlag} converts to {Convert.ToInt16(falseFlag)}.");
        Console.WriteLine($"{trueFlag} converts to {Convert.ToInt16(trueFlag)}.");
        // The example displays the following output:
        //       False converts to 0.
        //       True converts to 1.
        // </Snippet1>
    }

    private static void ConvertByte()
    {
        // <Snippet2>
        byte[] bytes = { byte.MinValue, 14, 122, byte.MaxValue };
        short result;

        foreach (byte byteValue in bytes)
        {
            result = Convert.ToInt16(byteValue);
            Console.WriteLine($"The Byte value {byteValue} converts to {result}.");
        }
        // The example displays the following output:
        //       The Byte value 0 converts to 0.
        //       The Byte value 14 converts to 14.
        //       The Byte value 122 converts to 122.
        //       The Byte value 255 converts to 255.
        // </Snippet2>
    }

    private static void ConvertChar()
    {
        // <Snippet3>
        char[] chars = { 'a', 'z', '\x0007', '\x03FF',
                       '\x7FFF', '\xFFFE' };
        short result;

        foreach (char ch in chars)
        {
            try
            {
                result = Convert.ToInt16(ch);
                Console.WriteLine($"'{ch}' converts to {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Unable to convert u+{((int)ch).ToString("X4")} to an Int16.");
            }
        }
        // The example displays the following output:
        //       'a' converts to 97.
        //       'z' converts to 122.
        //       '' converts to 7.
        //       'Ͽ' converts to 1023.
        //       '翿' converts to 32767.
        //       Unable to convert u+FFFE to an Int16.
        // </Snippet3>
    }

    private static void ConvertDecimal()
    {
        // <Snippet4>
        decimal[] values = { decimal.MinValue, -1034.23m, -12m, 0m, 147m,
                                  9214.16m, decimal.MaxValue };
        short result;

        foreach (decimal value in values)
        {
            try
            {
                result = Convert.ToInt16(value);
                Console.WriteLine($"Converted {value} to {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{value} is outside the range of the Int16 type.");
            }
        }
        // The example displays the following output:
        //    -79228162514264337593543950335 is outside the range of the Int16 type.
        //    Converted -1034.23 to -1034.
        //    Converted -12 to -12.
        //    Converted 0 to 0.
        //    Converted 147 to 147.
        //    Converted 9214.16 to 9214.
        //    79228162514264337593543950335 is outside the range of the Int16 type.
        // </Snippet4>
    }

    private static void ConvertDouble()
    {
        // <Snippet5>
        double[] values = { double.MinValue, -1.38e10, -1023.299, -12.98,
                          0, 9.113e-16, 103.919, 17834.191, double.MaxValue };
        short result;

        foreach (double value in values)
        {
            try
            {
                result = Convert.ToInt16(value);
                Console.WriteLine($"Converted {value} to {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{value} is outside the range of the Int16 type.");
            }
        }
        //       -1.79769313486232E+308 is outside the range of the Int16 type.
        //       -13800000000 is outside the range of the Int16 type.
        //       Converted -1023.299 to -1023.
        //       Converted -12.98 to -13.
        //       Converted 0 to 0.
        //       Converted 9.113E-16 to 0.
        //       Converted 103.919 to 104.
        //       Converted 17834.191 to 17834.
        //       1.79769313486232E+308 is outside the range of the Int16 type.
        // </Snippet5>
    }

    private static void ConvertInt32()
    {
        // <Snippet6>
        int[] numbers = { int.MinValue, -1, 0, 121, 340, int.MaxValue };
        short result;

        foreach (int number in numbers)
        {
            try
            {
                result = Convert.ToInt16(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the Int16 type.");
            }
        }
        // The example displays the following output:
        //    The Int32 value -2147483648 is outside the range of the Int16 type.
        //    Converted the Int32 value -1 to a Int16 value -1.
        //    Converted the Int32 value 0 to a Int16 value 0.
        //    Converted the Int32 value 121 to a Int16 value 121.
        //    Converted the Int32 value 340 to a Int16 value 340.
        //    The Int32 value 2147483647 is outside the range of the Int16 type.
        // </Snippet6>
    }

    private static void ConvertInt64()
    {
        // <Snippet7>
        long[] numbers = { long.MinValue, -1, 0, 121, 340, long.MaxValue };
        short result;

        foreach (long number in numbers)
        {
            try
            {
                result = Convert.ToInt16(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the Int16 type.");
            }
        }
        // The example displays the following output:
        //    The Int64 value -9223372036854775808 is outside the range of the Int16 type.
        //    Converted the Int64 value -1 to the Int16 value -1.
        //    Converted the Int64 value 0 to the Int16 value 0.
        //    Converted the Int64 value 121 to the Int16 value 121.
        //    Converted the Int64 value 340 to the Int16 value 340.
        //    The Int64 value 9223372036854775807 is outside the range of the Int16 type.
        // </Snippet7>
    }

    private static void ConvertObject()
    {
        // <Snippet8>
        object[] values = { true, -12, 163, 935, 'x', new DateTime(2009, 5, 12),
                         "104", "103.0", "-1", "1.00e2", "One", 1.00e2};
        short result;

        foreach (object value in values)
        {
            try
            {
                result = Convert.ToInt16(value);
                Console.WriteLine($"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {value.GetType().Name} value {value} is outside the range of the Int16 type.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"The {value.GetType().Name} value {value} is not in a recognizable format.");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine($"No conversion to an Int16 exists for the {value.GetType().Name} value {value}.");
            }
        }
        // The example displays the following output:
        //    Converted the Boolean value True to the Int16 value 1.
        //    Converted the Int32 value -12 to the Int16 value -12.
        //    Converted the Int32 value 163 to the Int16 value 163.
        //    Converted the Int32 value 935 to the Int16 value 935.
        //    Converted the Char value x to the Int16 value 120.
        //    No conversion to an Int16 exists for the DateTime value 5/12/2009 12:00:00 AM.
        //    Converted the String value 104 to the Int16 value 104.
        //    The String value 103.0 is not in a recognizable format.
        //    Converted the String value -1 to the Int16 value -1.
        //    The String value 1.00e2 is not in a recognizable format.
        //    The String value One is not in a recognizable format.
        //    Converted the Double value 100 to the Int16 value 100.
        // </Snippet8>
    }

    private static void ConvertSByte()
    {
        // <Snippet9>
        sbyte[] numbers = { sbyte.MinValue, -1, 0, 10, sbyte.MaxValue };
        short result;

        foreach (sbyte number in numbers)
        {
            result = Convert.ToInt16(number);
            Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
        }
        // The example displays the following output:
        //       Converted the SByte value -128 to the Int16 value -128.
        //       Converted the SByte value -1 to the Int16 value -1.
        //       Converted the SByte value 0 to the Int16 value 0.
        //       Converted the SByte value 10 to the Int16 value 10.
        //       Converted the SByte value 127 to the Int16 value 127.
        // </Snippet9>
    }

    private static void ConvertSingle()
    {
        // <Snippet10>
        float[] values = { float.MinValue, -1.38e10f, -1023.299f, -12.98f,
                         0f, 9.113e-16f, 103.919f, 17834.191f, float.MaxValue };
        short result;

        foreach (float value in values)
        {
            try
            {
                result = Convert.ToInt16(value);
                Console.WriteLine($"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{value} is outside the range of the Int16 type.");
            }
        }
        // The example displays the following output:
        //    -3.4028235E+38 is outside the range of the Int16 type.
        //    -1.38E+10 is outside the range of the Int16 type.
        //    Converted the Single value -1023.299 to the Int16 value -1023.
        //    Converted the Single value -12.98 to the Int16 value -13.
        //    Converted the Single value 0 to the Int16 value 0.
        //    Converted the Single value 9.113E-16 to the Int16 value 0.
        //    Converted the Single value 103.919 to the Int16 value 104.
        //    Converted the Single value 17834.191 to the Int16 value 17834.
        //    3.4028235E+38 is outside the range of the Int16 type.
        // </Snippet10>
    }

    private static void ConvertUInt16()
    {
        // <Snippet11>
        ushort[] numbers = { ushort.MinValue, 121, 340, ushort.MaxValue };
        short result;
        foreach (ushort number in numbers)
        {
            try
            {
                result = Convert.ToInt16(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the Int16 type.");
            }
        }
        // The example displays the following output:
        //       Converted the UInt16 value 0 to a Int16 value 0.
        //       Converted the UInt16 value 121 to a Int16 value 121.
        //       Converted the UInt16 value 340 to a Int16 value 340.
        //       The UInt16 value 65535 is outside the range of the Int16 type.
        // </Snippet11>
    }

    private static void ConvertUInt32()
    {
        // <Snippet12>
        uint[] numbers = { uint.MinValue, 121, 340, uint.MaxValue };
        short result;

        foreach (uint number in numbers)
        {
            try
            {
                result = Convert.ToInt16(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the Int16 type.");
            }
        }
        // The example displays the following output:
        //    Converted the UInt32 value 0 to a Int16 value 0.
        //    Converted the UInt32 value 121 to a Int16 value 121.
        //    Converted the UInt32 value 340 to a Int16 value 340.
        //    The UInt32 value 4294967295 is outside the range of the Int16 type.
        // </Snippet12>
    }

    private static void ConvertUInt64()
    {
        // <Snippet13>
        ulong[] numbers = { ulong.MinValue, 121, 340, ulong.MaxValue };
        short result;

        foreach (ulong number in numbers)
        {
            try
            {
                result = Convert.ToInt16(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the Int16 type.");
            }
        }
        // The example displays the following output:
        //    Converted the UInt64 value 0 to a Int16 value 0.
        //    Converted the UInt64 value 121 to a Int16 value 121.
        //    Converted the UInt64 value 340 to a Int16 value 340.
        //    The UInt64 value 18446744073709551615 is outside the range of the Int16 type.
        // </Snippet13>
    }
}
