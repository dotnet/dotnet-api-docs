module nonnumeric

//<Snippet2>
// Example of Convert.ToString(non-numeric types, IFormatProvider).
open System
open System.Globalization

// Create an instance of the IFormatProvider with an object expression.
let provider =
    { new IFormatProvider with
        // Normally, GetFormat returns an object of the requested type
        // (usually itself) if it is able; otherwise, it returns Nothing.
        member _.GetFormat(argType: Type) =
            // Here, the type of argType is displayed, and GetFormat
            // always returns Nothing.
            printf $"{argType,-40}"
            null 
    }

// Convert these values using DummyProvider.
let Int32A     = -252645135
let DoubleA    = 61680.3855
let ObjDouble  = -98765.4321 :> obj
let DayTimeA   = DateTime(2001, 9, 11, 13, 45, 0)

let BoolA      = true
let StringA    = "Qwerty"
let CharA      = '$'
let TSpanA     = TimeSpan(0, 18, 0)
let ObjOther   = provider :> obj

[<EntryPoint>]
let main _ =
    printfn
        """This example of Convert.ToString(non-numeric, IFormatProvider) 
generates the following output. The provider type, argument type, 
and argument value are displayed.

Note: The IFormatProvider object is not called for Boolean, String, 
Char, TimeSpan, and non-numeric Object."""

    // The format provider is called for these conversions.
    printfn ""
    let converted = Convert.ToString(Int32A, provider)
    printfn $"int      {converted}"
    let converted = Convert.ToString(DoubleA, provider)
    printfn $"double   {converted}"
    let converted = Convert.ToString(ObjDouble, provider)
    printfn $"object   {converted}"
    let converted = Convert.ToString(DayTimeA, provider)
    printfn $"DateTime {converted}"

    // The format provider is not called for these conversions.
    printfn ""
    let converted = Convert.ToString(BoolA, provider)
    printfn $"bool     {converted}"
    let converted = Convert.ToString(StringA, provider)
    printfn $"string   {converted}"
    let converted = Convert.ToString(CharA, provider)
    printfn $"char     {converted}"
    let converted = Convert.ToString(TSpanA, provider)
    printfn $"TimeSpan {converted}"
    let converted = Convert.ToString(ObjOther, provider)
    printfn $"object   {converted}"

    0

// This example of Convert.ToString(non-numeric, IFormatProvider)
// generates the following output. The provider type, argument type,
// and argument value are displayed.
//
// Note: The IFormatProvider object is not called for Boolean, String,
// Char, TimeSpan, and non-numeric Object.
//
// System.Globalization.NumberFormatInfo   int      -252645135
// System.Globalization.NumberFormatInfo   double   61680.3855
// System.Globalization.NumberFormatInfo   object   -98765.4321
// System.Globalization.DateTimeFormatInfo DateTime 9/11/2001 1:45:00 PM
//
// bool     True
// string   Qwerty
// char     $
// TimeSpan 00:18:00
// object   DummyProvider
//</Snippet2>