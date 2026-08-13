// <Snippet12>
using System;
using System.Globalization;

public enum SignBit { Negative = -1, Zero = 0, Positive = 1 };

public struct ByteString3 : IConvertible
{
    private SignBit signBit;
    private string byteString;

    public SignBit Sign
    {
        set => signBit = value;
        get => signBit;
    }

    public string Value
    {
        set
        {
            if (value.Trim().Length > 2)
            {
                throw new ArgumentException("The string representation of a byte cannot have more than two characters.");
            }
            else
            {
                byteString = value;
            }
        }
        get => byteString;
    }

    // IConvertible implementations.
    public TypeCode GetTypeCode() => TypeCode.Object;

    public bool ToBoolean(IFormatProvider provider)
    {
        if (signBit == SignBit.Zero)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public byte ToByte(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            throw new OverflowException($"{Convert.ToSByte(byteString, 16)} is out of range of the Byte type.");
        }
        else
        {
            return byte.Parse(byteString, NumberStyles.HexNumber);
        }
    }

    public char ToChar(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            throw new OverflowException($"{Convert.ToSByte(byteString, 16)} is out of range of the Char type.");
        }
        else
        {
            byte byteValue = byte.Parse(this.byteString, NumberStyles.HexNumber);
            return Convert.ToChar(byteValue);
        }
    }

    public DateTime ToDateTime(IFormatProvider provider) => throw new InvalidCastException("ByteString3 to DateTime conversion is not supported.");

    public decimal ToDecimal(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            sbyte byteValue = sbyte.Parse(byteString, NumberStyles.HexNumber);
            return Convert.ToDecimal(byteValue);
        }
        else
        {
            byte byteValue = byte.Parse(byteString, NumberStyles.HexNumber);
            return Convert.ToDecimal(byteValue);
        }
    }

    public double ToDouble(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            return Convert.ToDouble(sbyte.Parse(byteString, NumberStyles.HexNumber));
        }
        else
        {
            return Convert.ToDouble(byte.Parse(byteString, NumberStyles.HexNumber));
        }
    }

    public short ToInt16(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            return Convert.ToInt16(sbyte.Parse(byteString, NumberStyles.HexNumber));
        }
        else
        {
            return Convert.ToInt16(byte.Parse(byteString, NumberStyles.HexNumber));
        }
    }

    public int ToInt32(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            return Convert.ToInt32(sbyte.Parse(byteString, NumberStyles.HexNumber));
        }
        else
        {
            return Convert.ToInt32(byte.Parse(byteString, NumberStyles.HexNumber));
        }
    }

    public long ToInt64(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            return Convert.ToInt64(sbyte.Parse(byteString, NumberStyles.HexNumber));
        }
        else
        {
            return Convert.ToInt64(byte.Parse(byteString, NumberStyles.HexNumber));
        }
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            try
            {
                return Convert.ToSByte(byte.Parse(byteString, NumberStyles.HexNumber));
            }
            catch (OverflowException e)
            {
                throw new OverflowException($"{byte.Parse(byteString, NumberStyles.HexNumber)} is outside the range of the SByte type.", e);
            }
        }
        else
        {
            return sbyte.Parse(byteString, NumberStyles.HexNumber);
        }
    }

    public float ToSingle(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            return Convert.ToSingle(sbyte.Parse(byteString, NumberStyles.HexNumber));
        }
        else
        {
            return Convert.ToSingle(byte.Parse(byteString, NumberStyles.HexNumber));
        }
    }

    public string ToString(IFormatProvider provider) => "0x" + this.byteString;

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
                if (typeof(ByteString3).Equals(conversionType))
                {
                    return this;
                }
                else
                {
                    throw new InvalidCastException($"Conversion to a {conversionType.Name} is not supported.");
                }

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
        {
            throw new OverflowException($"{sbyte.Parse(byteString, NumberStyles.HexNumber)} is outside the range of the UInt16 type.");
        }
        else
        {
            return Convert.ToUInt16(byte.Parse(byteString, NumberStyles.HexNumber));
        }
    }

    public uint ToUInt32(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            throw new OverflowException($"{sbyte.Parse(byteString, NumberStyles.HexNumber)} is outside the range of the UInt32 type.");
        }
        else
        {
            return Convert.ToUInt32(byte.Parse(byteString, NumberStyles.HexNumber));
        }
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
        if (signBit == SignBit.Negative)
        {
            throw new OverflowException($"{sbyte.Parse(byteString, NumberStyles.HexNumber)} is outside the range of the UInt64 type.");
        }
        else
        {
            return Convert.ToUInt64(byte.Parse(byteString, NumberStyles.HexNumber));
        }
    }
}
// </Snippet12>

// <Snippet13>
public class Class1
{
    public static void Main()
    {
        byte positiveByte = 216;
        sbyte negativeByte = -101;

        ByteString3 positiveString = new()
        {
            Sign = (SignBit)Math.Sign(positiveByte),
            Value = positiveByte.ToString("X2")
        };

        ByteString3 negativeString = new()
        {
            Sign = (SignBit)Math.Sign(negativeByte),
            Value = negativeByte.ToString("X2")
        };

        try
        {
            Console.WriteLine($"'{positiveString.Value}' converts to {Convert.ToByte(positiveString)}.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"0x{positiveString.Value} is outside the range of the Byte type.");
        }

        try
        {
            Console.WriteLine($"'{negativeString.Value}' converts to {Convert.ToByte(negativeString)}.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"0x{negativeString.Value} is outside the range of the Byte type.");
        }
    }
}
// The example displays the following output:
//       'D8' converts to 216.
//       0x9B is outside the range of the Byte type.
// </Snippet13>
