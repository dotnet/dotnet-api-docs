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
        ConvertInt16();
        Console.WriteLine("-----");
        ConvertInt32();
        Console.WriteLine("-----");
        ConvertInt64();
        Console.WriteLine("-----");
        ConvertObject();
        Console.WriteLine("-----");
        ConvertSingle();
        Console.WriteLine("-----");
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

        Console.WriteLine($"{falseFlag} converts to {Convert.ToSByte(falseFlag)}.");
        Console.WriteLine($"{trueFlag} converts to {Convert.ToSByte(trueFlag)}.");
        // The example displays the following output:
        //       false converts to 0.
        //       true converts to 1.
        // </Snippet1>
    }

    private static void ConvertByte()
    {
        // <Snippet2>
        byte[] numbers = { byte.MinValue, 10, 100, byte.MaxValue };
        sbyte result;

        foreach (byte number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    Converted the Byte value 0 to the SByte value 0.
        //    Converted the Byte value 10 to the SByte value 10.
        //    Converted the Byte value 100 to the SByte value 100.
        //    The Byte value 255 is outside the range of the SByte type.
        // </Snippet2>
    }

    private static void ConvertChar()
    {
        // <Snippet3>
        char[] chars = { 'a', 'z', '\u0007', '\u0200', '\u1023' };
        foreach (char ch in chars)
        {
            try
            {
                sbyte result = Convert.ToSByte(ch);
                Console.WriteLine($"{ch} is converted to {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Unable to convert u+{Convert.ToInt16(ch).ToString("X4")} to a byte.");
            }
        }
        // The example displays the following output:
        //    a is converted to 97.
        //    z is converted to 122.
        //     is converted to 7.
        //    Unable to convert u+00C8 to a byte.
        //    Unable to convert u+03FF to a byte.
        // </Snippet3>
    }

    private static void ConvertDecimal()
    {
        // <Snippet4>
        decimal[] numbers = { decimal.MinValue, -129.5m, -12.7m, 0m, 16m,
                            103.6m, 255.0m, decimal.MaxValue };
        sbyte result;

        foreach (decimal number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    The Decimal value -79228162514264337593543950335 is outside the range of the SByte type.
        //    The Decimal value -129.5 is outside the range of the SByte type.
        //    Converted the Decimal value -12.7 to the SByte value -13.
        //    Converted the Decimal value 0 to the SByte value 0.
        //    Converted the Decimal value 16 to the SByte value 16.
        //    Converted the Decimal value 103.6 to the SByte value 104.
        //    The Decimal value 255 is outside the range of the SByte type.
        //    The Decimal value 79228162514264337593543950335 is outside the range of the SByte type.
        // </Snippet4>
    }

    private static void ConvertDouble()
    {
        // <Snippet5>
        double[] numbers = { double.MinValue, -129.5, -12.7, 0, 16,
                           103.6, 255.0, 1.63509e17, double.MaxValue};
        sbyte result;

        foreach (double number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    The Double value -1.79769313486232E+308 is outside the range of the SByte type.
        //    The Double value -129.5 is outside the range of the SByte type.
        //    Converted the Double value -12.7 to the SByte value -13.
        //    Converted the Double value 0 to the SByte value 0.
        //    Converted the Double value 16 to the SByte value 16.
        //    Converted the Double value 103.6 to the SByte value 104.
        //    The Double value 255 is outside the range of the SByte type.
        //    The Double value 1.63509E+17 is outside the range of the SByte type.
        //    The Double value 1.79769313486232E+308 is outside the range of the SByte type.
        // </Snippet5>
    }

    private static void ConvertInt16()
    {
        // <Snippet6>
        short[] numbers = { short.MinValue, -1, 0, 121, 340, short.MaxValue };
        sbyte result;
        foreach (short number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    The Int16 value -32768 is outside the range of the SByte type.
        //    Converted the Int16 value -1 to the SByte value -1.
        //    Converted the Int16 value 0 to the SByte value 0.
        //    Converted the Int16 value 121 to the SByte value 121.
        //    The Int16 value 340 is outside the range of the SByte type.
        //    The Int16 value 32767 is outside the range of the SByte type.
        // </Snippet6>
    }

    private static void ConvertInt32()
    {
        // <Snippet7>
        int[] numbers = { int.MinValue, -1, 0, 121, 340, int.MaxValue };
        sbyte result;

        foreach (int number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    The Int32 value -2147483648 is outside the range of the SByte type.
        //    Converted the Int32 value -1 to the SByte value -1.
        //    Converted the Int32 value 0 to the SByte value 0.
        //    Converted the Int32 value 121 to the SByte value 121.
        //    The Int32 value 340 is outside the range of the SByte type.
        //    The Int32 value 2147483647 is outside the range of the SByte type.
        // </Snippet7>
    }

    private static void ConvertInt64()
    {
        // <Snippet8>
        long[] numbers = { long.MinValue, -1, 0, 121, 340, long.MaxValue };
        sbyte result;
        foreach (long number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    The Int64 value -9223372036854775808 is outside the range of the SByte type.
        //    Converted the Int64 value -1 to the SByte value -1.
        //    Converted the Int64 value 0 to the SByte value 0.
        //    Converted the Int64 value 121 to the SByte value 121.
        //    The Int64 value 340 is outside the range of the SByte type.
        //    The Int64 value 9223372036854775807 is outside the range of the SByte type.
        // </Snippet8>
    }

    private static void ConvertObject()
    {
        // <Snippet9>
        object[] values = { true, -12, 163, 935, 'x', "104", "103.0", "-1",
                          "1.00e2", "One", 1.00e2};
        sbyte result;

        foreach (object value in values)
        {
            try
            {
                result = Convert.ToSByte(value);
                Console.WriteLine($"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {value.GetType().Name} value {value} is outside the range of the SByte type.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"The {value.GetType().Name} value {value} is not in a recognizable format.");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine($"No conversion to a Byte exists for the {value.GetType().Name} value {value}.");
            }
        }
        // The example displays the following output:
        //    Converted the Boolean value true to the SByte value 1.
        //    Converted the Int32 value -12 to the SByte value -12.
        //    The Int32 value 163 is outside the range of the SByte type.
        //    The Int32 value 935 is outside the range of the SByte type.
        //    Converted the Char value x to the SByte value 120.
        //    Converted the String value 104 to the SByte value 104.
        //    The String value 103.0 is not in a recognizable format.
        //    Converted the String value -1 to the SByte value -1.
        //    The String value 1.00e2 is not in a recognizable format.
        //    The String value One is not in a recognizable format.
        //    Converted the Double value 100 to the SByte value 100.
        // </Snippet9>
    }

    private static void ConvertSingle()
    {
        // <Snippet10>
        float[] numbers = { float.MinValue, -129.5f, -12.7f, 0f, 16f,
                          103.6f, 255.0f, 1.63509e17f, float.MaxValue };
        sbyte result;

        foreach (float number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    The Single value -3.402823E+38 is outside the range of the SByte type.
        //    The Single value -129.5 is outside the range of the SByte type.
        //    Converted the Single value -12.7 to the SByte value -13.
        //    Converted the Single value 0 to the SByte value 0.
        //    Converted the Single value 16 to the SByte value 16.
        //    Converted the Single value 103.6 to the SByte value 104.
        //    The Single value 255 is outside the range of the SByte type.
        //    The Single value 1.63509E+17 is outside the range of the SByte type.
        //    The Single value 3.402823E+38 is outside the range of the SByte type.
        // </Snippet10>
    }

    private static void ConvertUInt16()
    {
        // <Snippet11>
        ushort[] numbers = { ushort.MinValue, 121, 340, ushort.MaxValue };
        sbyte result;

        foreach (ushort number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    Converted the UInt16 value 0 to the SByte value 0.
        //    Converted the UInt16 value 121 to the SByte value 121.
        //    The UInt16 value 340 is outside the range of the SByte type.
        //    The UInt16 value 65535 is outside the range of the SByte type.
        // </Snippet11>
    }

    private static void ConvertUInt32()
    {
        // <Snippet12>
        uint[] numbers = { uint.MinValue, 121, 340, uint.MaxValue };
        sbyte result;

        foreach (uint number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    Converted the UInt32 value 0 to the SByte value 0.
        //    Converted the UInt32 value 121 to the SByte value 121.
        //    The UInt32 value 340 is outside the range of the SByte type.
        //    The UInt32 value 4294967295 is outside the range of the SByte type.
        // </Snippet12>
    }

    private static void ConvertUInt64()
    {
        // <Snippet13>
        ulong[] numbers = { ulong.MinValue, 121, 340, ulong.MaxValue };
        sbyte result;

        foreach (ulong number in numbers)
        {
            try
            {
                result = Convert.ToSByte(number);
                Console.WriteLine($"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The {number.GetType().Name} value {number} is outside the range of the SByte type.");
            }
        }
        // The example displays the following output:
        //    Converted the UInt64 value 0 to the SByte value 0.
        //    Converted the UInt64 value 121 to the SByte value 121.
        //    The UInt64 value 340 is outside the range of the SByte type.
        //    The UInt64 value 18446744073709551615 is outside the range of the SByte type.
        // </Snippet13>
    }
}
