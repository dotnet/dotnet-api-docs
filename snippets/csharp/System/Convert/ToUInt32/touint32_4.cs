// <Snippet17>
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public enum SignBit { Negative = -1, Zero = 0, Positive = 1 };

public struct HexString : IConvertible
{
    private SignBit signBit;
    private string hexString;

    public SignBit Sign
   {
      set => signBit = value;
      get => signBit;
   }

    public string Value
    {
        set
        {
            if (value.Trim().Length > 8)
                throw new ArgumentException("The string representation of a 32-bit integer cannot have more than 8 characters.");
            else if (!Regex.IsMatch(value, "([0-9,A-F]){1,8}", RegexOptions.IgnoreCase))
                throw new ArgumentException("The hexadecimal representation of a 32-bit integer contains invalid characters.");
            else
                hexString = value;
        }
        get => hexString;
    }

    // IConvertible implementations.
    public TypeCode GetTypeCode() => TypeCode.Object;

    public bool ToBoolean(IFormatProvider provider) => signBit != SignBit.Zero;

    public byte ToByte(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            throw new OverflowException($"{Convert.ToInt32(hexString, 16)} is out of range of the Byte type.");
        else
            try
            {
                return byte.Parse(hexString, NumberStyles.HexNumber);
            }
            catch (OverflowException e)
            {
                throw new OverflowException($"{Convert.ToUInt32(hexString, 16)} is out of range of the Byte type.", e);
            }
    }

    public char ToChar(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            throw new OverflowException($"{Convert.ToInt32(hexString, 16)} is out of range of the Char type.");

        try
        {
            ushort codePoint = ushort.Parse(this.hexString, NumberStyles.HexNumber);
            return Convert.ToChar(codePoint);
        }
        catch (OverflowException e)
        {
            throw new OverflowException($"{Convert.ToUInt32(hexString, 16)} is out of range of the Char type.", e);
        }
    }

    public DateTime ToDateTime(IFormatProvider provider) => throw new InvalidCastException("Hexadecimal to DateTime conversion is not supported.");

    public decimal ToDecimal(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            int hexValue = int.Parse(hexString, NumberStyles.HexNumber);
            return Convert.ToDecimal(hexValue);
        }
        else
        {
            uint hexValue = uint.Parse(hexString, NumberStyles.HexNumber);
            return Convert.ToDecimal(hexValue);
        }
    }

    public double ToDouble(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            return Convert.ToDouble(int.Parse(hexString, NumberStyles.HexNumber));
        else
            return Convert.ToDouble(uint.Parse(hexString, NumberStyles.HexNumber));
    }

    public short ToInt16(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            try
            {
                return Convert.ToInt16(int.Parse(hexString, NumberStyles.HexNumber));
            }
            catch (OverflowException e)
            {
                throw new OverflowException($"{Convert.ToInt32(hexString, 16)} is out of range of the Int16 type.", e);
            }
        else
            try
            {
                return Convert.ToInt16(uint.Parse(hexString, NumberStyles.HexNumber));
            }
            catch (OverflowException e)
            {
                throw new OverflowException($"{Convert.ToUInt32(hexString, 16)} is out of range of the Int16 type.", e);
            }
    }

    public int ToInt32(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            return int.Parse(hexString, NumberStyles.HexNumber);
        else
            try
            {
                return Convert.ToInt32(uint.Parse(hexString, NumberStyles.HexNumber));
            }
            catch (OverflowException e)
            {
                throw new OverflowException($"{Convert.ToUInt32(hexString, 16)} is out of range of the Int32 type.", e);
            }
    }

    public long ToInt64(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            return Convert.ToInt64(int.Parse(hexString, NumberStyles.HexNumber));
        else
            return long.Parse(hexString, NumberStyles.HexNumber);
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            try
            {
                return Convert.ToSByte(int.Parse(hexString, NumberStyles.HexNumber));
            }
            catch (OverflowException e)
            {
                throw new OverflowException(string.Format("{0} is outside the range of the SByte type.",
                                                          int.Parse(hexString, NumberStyles.HexNumber), e));
            }
        else
            try
            {
                return Convert.ToSByte(uint.Parse(hexString, NumberStyles.HexNumber));
            }
            catch (OverflowException e)
            {
                throw new OverflowException($"{uint.Parse(hexString, NumberStyles.HexNumber)} is outside the range of the SByte type.", e);
            }
    }

    public float ToSingle(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            return Convert.ToSingle(int.Parse(hexString, NumberStyles.HexNumber));
        else
            return Convert.ToSingle(uint.Parse(hexString, NumberStyles.HexNumber));
    }

    public string ToString(IFormatProvider provider) => "0x" + this.hexString;

    public object ToType(Type conversionType, IFormatProvider provider)
    {
        switch (Type.GetTypeCode(conversionType))
        {
            case TypeCode.Boolean:
                return this.ToBoolean(null);
            case TypeCode.Byte:
                return this.ToByte(null);
            case TypeCode.Char:
                return this.ToChar(null);
            case TypeCode.DateTime:
                return this.ToDateTime(null);
            case TypeCode.Decimal:
                return this.ToDecimal(null);
            case TypeCode.Double:
                return this.ToDouble(null);
            case TypeCode.Int16:
                return this.ToInt16(null);
            case TypeCode.Int32:
                return this.ToInt32(null);
            case TypeCode.Int64:
                return this.ToInt64(null);
            case TypeCode.Object:
                if (typeof(HexString).Equals(conversionType))
                    return this;
                else
                    throw new InvalidCastException($"Conversion to a {conversionType.Name} is not supported.");
            case TypeCode.SByte:
                return this.ToSByte(null);
            case TypeCode.Single:
                return this.ToSingle(null);
            case TypeCode.String:
                return this.ToString(null);
            case TypeCode.UInt16:
                return this.ToUInt16(null);
            case TypeCode.UInt32:
                return this.ToUInt32(null);
            case TypeCode.UInt64:
                return this.ToUInt64(null);
            default:
                throw new InvalidCastException($"Conversion to {conversionType.Name} is not supported.");
        }
    }

    public ushort ToUInt16(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            throw new OverflowException($"{int.Parse(hexString, NumberStyles.HexNumber)} is outside the range of the UInt16 type.");
        else
            try
            {
                return Convert.ToUInt16(uint.Parse(hexString, NumberStyles.HexNumber));
            }
            catch (OverflowException e)
            {
                throw new OverflowException($"{Convert.ToUInt32(hexString, 16)} is out of range of the UInt16 type.", e);
            }
    }

    public uint ToUInt32(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            throw new OverflowException($"{int.Parse(hexString, NumberStyles.HexNumber)} is outside the range of the UInt32 type.");
        else
            return Convert.ToUInt32(hexString, 16);
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
            throw new OverflowException($"{int.Parse(hexString, NumberStyles.HexNumber)} is outside the range of the UInt64 type.");
        else
            return Convert.ToUInt64(hexString, 16);
    }
}
// </Snippet17>

// <Snippet18>
public class Example
{
    public static void Main()
    {
        uint positiveValue = 320000000;
        int negativeValue = -1;

        HexString positiveString = new()
        {
            Sign = (SignBit)Math.Sign(positiveValue),
            Value = positiveValue.ToString("X4")
        };

        HexString negativeString = new()
        {
            Sign = (SignBit)Math.Sign(negativeValue),
            Value = negativeValue.ToString("X4")
        };

        try
        {
            Console.WriteLine($"0x{positiveString.Value} converts to {Convert.ToUInt32(positiveString)}.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"{int.Parse(positiveString.Value, NumberStyles.HexNumber)} is outside the range of the UInt32 type.");
        }

        try
        {
            Console.WriteLine($"0x{negativeString.Value} converts to {Convert.ToUInt32(negativeString)}.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"{int.Parse(negativeString.Value, NumberStyles.HexNumber)} is outside the range of the UInt32 type.");
        }
    }
}
// The example dosplays the following output:
//       0x1312D000 converts to 320000000.
//       -1 is outside the range of the UInt32 type.
// </Snippet18>
