//<Snippet2>
// Example of Convert.ToString( non-numeric types, IFormatProvider ).
using System;


// An instance of this class can be passed to methods that require
// an IFormatProvider.
public class DummyProvider : IFormatProvider
{
    // Normally, GetFormat returns an object of the requested type
    // (usually itself) if it is able; otherwise, it returns Nothing.
    public object GetFormat(Type argType)
    {
        // Here, the type of argType is displayed, and GetFormat
        // always returns Nothing.
        Console.Write($"{argType.ToString(),-40}");
        return null;
    }
}

class ConvertNonNumericProviderDemo
{
    static void Main()
    {
        // Create an instance of the IFormatProvider.
        DummyProvider provider = new();
        string converted;

        // Convert these values using DummyProvider.
        int Int32A = -252645135;
        double DoubleA = 61680.3855;
        object ObjDouble = (object)(-98765.4321);
        DateTime DayTimeA = new(2001, 9, 11, 13, 45, 0);

        bool BoolA = true;
        string StringA = "Qwerty";
        char CharA = '$';
        TimeSpan TSpanA = new(0, 18, 0);
        object ObjOther = (object)provider;

        Console.WriteLine("This example of " +
            "Convert.ToString( non-numeric, IFormatProvider ) \n" +
            "generates the following output. The provider type, " +
            "argument type, \nand argument value are displayed.");
        Console.WriteLine("\nNote: The IFormatProvider object is " +
            "not called for Boolean, String, \nChar, TimeSpan, " +
            "and non-numeric Object.");

        // The format provider is called for these conversions.
        Console.WriteLine();
        converted = Convert.ToString(Int32A, provider);
        Console.WriteLine($"int      {converted}");
        converted = Convert.ToString(DoubleA, provider);
        Console.WriteLine($"double   {converted}");
        converted = Convert.ToString(ObjDouble, provider);
        Console.WriteLine($"object   {converted}");
        converted = Convert.ToString(DayTimeA, provider);
        Console.WriteLine($"DateTime {converted}");

        // The format provider is not called for these conversions.
        Console.WriteLine();
        converted = Convert.ToString(BoolA, provider);
        Console.WriteLine($"bool     {converted}");
        converted = Convert.ToString(StringA, provider);
        Console.WriteLine($"string   {converted}");
        converted = Convert.ToString(CharA, provider);
        Console.WriteLine($"char     {converted}");
        converted = Convert.ToString(TSpanA, provider);
        Console.WriteLine($"TimeSpan {converted}");
        converted = Convert.ToString(ObjOther, provider);
        Console.WriteLine($"object   {converted}");
    }
}

/*
This example of Convert.ToString( non-numeric, IFormatProvider )
generates the following output. The provider type, argument type,
and argument value are displayed.

Note: The IFormatProvider object is not called for Boolean, String,
Char, TimeSpan, and non-numeric Object.

System.Globalization.NumberFormatInfo   int      -252645135
System.Globalization.NumberFormatInfo   double   61680.3855
System.Globalization.NumberFormatInfo   object   -98765.4321
System.Globalization.DateTimeFormatInfo DateTime 9/11/2001 1:45:00 PM

bool     True
string   Qwerty
char     $
TimeSpan 00:18:00
object   DummyProvider

*/
//</Snippet2>
