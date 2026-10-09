// <Snippet10>
using System;


public class Temperature : IConvertible
{
    private decimal m_Temp;

    public Temperature(decimal temperature) => this.m_Temp = temperature;

    public decimal Celsius => this.m_Temp;

    public decimal Kelvin => this.m_Temp + 273.15m;

    public decimal Fahrenheit => Math.Round((decimal)(this.m_Temp * 9 / 5 + 32), 2);

    public override string ToString() => m_Temp.ToString("N2") + " °C";

    // IConvertible implementations.
    public TypeCode GetTypeCode() => TypeCode.Object;

    public bool ToBoolean(IFormatProvider provider)
    {
        if (m_Temp == 0)
            return false;
        else
            return true;
    }

    public byte ToByte(IFormatProvider provider)
    {
        if (m_Temp < byte.MinValue || m_Temp > byte.MaxValue)
            throw new OverflowException($"{this.m_Temp} is out of range of the Byte type.");
        else
            return decimal.ToByte(this.m_Temp);
    }

    public char ToChar(IFormatProvider provider) => throw new InvalidCastException("Temperature to Char conversion is not supported.");

    public DateTime ToDateTime(IFormatProvider provider) => throw new InvalidCastException("Temperature to DateTime conversion is not supported.");

    public decimal ToDecimal(IFormatProvider provider) => this.m_Temp;

    public double ToDouble(IFormatProvider provider) => decimal.ToDouble(this.m_Temp);

    public short ToInt16(IFormatProvider provider)
    {
        if (this.m_Temp < short.MinValue || this.m_Temp > short.MaxValue)
            throw new OverflowException($"{this.m_Temp} is out of range of the Int16 type.");
        else
            return decimal.ToInt16(this.m_Temp);
    }

    public int ToInt32(IFormatProvider provider)
    {
        if (this.m_Temp < int.MinValue || this.m_Temp > int.MaxValue)
            throw new OverflowException($"{this.m_Temp} is out of range of the Int32 type.");
        else
            return decimal.ToInt32(this.m_Temp);
    }

    public long ToInt64(IFormatProvider provider)
    {
        if (this.m_Temp < long.MinValue || this.m_Temp > long.MaxValue)
            throw new OverflowException($"{this.m_Temp} is out of range of the Int64 type.");
        else
            return decimal.ToInt64(this.m_Temp);
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
        if (this.m_Temp < sbyte.MinValue || this.m_Temp > sbyte.MaxValue)
            throw new OverflowException($"{this.m_Temp} is out of range of the SByte type.");
        else
            return decimal.ToSByte(this.m_Temp);
    }

    public float ToSingle(IFormatProvider provider) => decimal.ToSingle(this.m_Temp);

    public string ToString(IFormatProvider provider) => m_Temp.ToString("N2", provider) + " °C";

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
                if (typeof(Temperature).Equals(conversionType))
                    return this;
                else
                    throw new InvalidCastException($"Conversion to a {conversionType.Name} is not supported.");
            case TypeCode.SByte:
                return this.ToSByte(null);
            case TypeCode.Single:
                return this.ToSingle(null);
            case TypeCode.String:
                return this.ToString(provider);
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
        if (this.m_Temp < ushort.MinValue || this.m_Temp > ushort.MaxValue)
            throw new OverflowException($"{this.m_Temp} is out of range of the UInt16 type.");
        else
            return decimal.ToUInt16(this.m_Temp);
    }

    public uint ToUInt32(IFormatProvider provider)
    {
        if (this.m_Temp < uint.MinValue || this.m_Temp > uint.MaxValue)
            throw new OverflowException($"{this.m_Temp} is out of range of the UInt32 type.");
        else
            return decimal.ToUInt32(this.m_Temp);
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
        if (this.m_Temp < ulong.MinValue || this.m_Temp > ulong.MaxValue)
            throw new OverflowException($"{this.m_Temp} is out of range of the UInt64 type.");
        else
            return decimal.ToUInt64(this.m_Temp);
    }
}
// </Snippet10>

// <Snippet11>
public class Example
{
    public static void Main()
    {
        Temperature cold = new(-40);
        Temperature freezing = new(0);
        Temperature boiling = new(100);

        Console.WriteLine(Convert.ToDecimal(cold, null));
        Console.WriteLine(Convert.ToDecimal(freezing, null));
        Console.WriteLine(Convert.ToDecimal(boiling, null));
    }
}
// The example dosplays the following output:
//       -40
//       0
//       100
// </Snippet11>
