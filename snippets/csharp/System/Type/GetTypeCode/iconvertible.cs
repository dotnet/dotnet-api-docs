// <snippet1>
using System;

namespace ConsoleApplication2
{

    /// Class that implements IConvertible
    class Complex : IConvertible
    {
        double x;
        double y;

        public Complex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public TypeCode GetTypeCode() => TypeCode.Object;

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            if ((x != 0.0) || (y != 0.0))
                return true;
            else
                return false;
        }

        double GetDoubleValue() => Math.Sqrt(x * x + y * y);

        byte IConvertible.ToByte(IFormatProvider provider) => Convert.ToByte(GetDoubleValue());

        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(GetDoubleValue());

        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(GetDoubleValue());

        decimal IConvertible.ToDecimal(IFormatProvider provider) => Convert.ToDecimal(GetDoubleValue());

        double IConvertible.ToDouble(IFormatProvider provider) => GetDoubleValue();

        short IConvertible.ToInt16(IFormatProvider provider) => Convert.ToInt16(GetDoubleValue());

        int IConvertible.ToInt32(IFormatProvider provider) => Convert.ToInt32(GetDoubleValue());

        long IConvertible.ToInt64(IFormatProvider provider) => Convert.ToInt64(GetDoubleValue());

        sbyte IConvertible.ToSByte(IFormatProvider provider) => Convert.ToSByte(GetDoubleValue());

        float IConvertible.ToSingle(IFormatProvider provider) => Convert.ToSingle(GetDoubleValue());

        string IConvertible.ToString(IFormatProvider provider) => "( " + x.ToString() + " , " + y.ToString() + " )";

        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => Convert.ChangeType(GetDoubleValue(), conversionType);

        ushort IConvertible.ToUInt16(IFormatProvider provider) => Convert.ToUInt16(GetDoubleValue());

        uint IConvertible.ToUInt32(IFormatProvider provider) => Convert.ToUInt32(GetDoubleValue());

        ulong IConvertible.ToUInt64(IFormatProvider provider) => Convert.ToUInt64(GetDoubleValue());
    }

    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class Class1
    {
        static void Main(string[] args)
        {

            Complex testComplex = new(4, 7);

            WriteObjectInfo(testComplex);
            WriteObjectInfo(Convert.ToBoolean(testComplex));
            WriteObjectInfo(Convert.ToDecimal(testComplex));
            WriteObjectInfo(Convert.ToString(testComplex));
        }
        // <snippet2>
        static void WriteObjectInfo(object testObject)
        {
            TypeCode typeCode = Type.GetTypeCode(testObject.GetType());

            switch (typeCode)
            {
                case TypeCode.Boolean:
                    Console.WriteLine($"Boolean: {testObject}");
                    break;

                case TypeCode.Double:
                    Console.WriteLine($"Double: {testObject}");
                    break;

                default:
                    Console.WriteLine($"{typeCode.ToString()}: {testObject}");
                    break;
            }
        }
        // </snippet2>
    }
}

/*
This code example produces the following results:

Object: ConsoleApplication2.Complex
Boolean: True
Decimal: 8.06225774829855
String: ( 4 , 7 )

*/
// </snippet1>
