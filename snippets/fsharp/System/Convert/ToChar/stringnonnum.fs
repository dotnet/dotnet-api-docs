module stringnonnum

//<Snippet2>
open System
open System.Globalization

type DummyProvider() = 
    interface IFormatProvider with
        // Normally, GetFormat returns an object of the requested type
        // (usually itself) if it is able; otherwise, it returns Nothing.
        member _.GetFormat(argType: Type) =
            // Here, GetFormat displays the name of argType, after removing
            // the namespace information. GetFormat always returns null.
            let argStr = string argType
            let argStr = if argStr = "" then "Empty" else argStr
            let argStr = argStr.Substring(argStr.LastIndexOf '.' + 1)

            printf $"{argStr,-20}"
            null

// Create an instance of IFormatProvider.
let provider =
    { new IFormatProvider with
        // Normally, GetFormat returns an object of the requested type
        // (usually itself) if it is able; otherwise, it returns Nothing.
        member _.GetFormat(argType: Type) =
            // Here, GetFormat displays the name of argType, after removing
            // the namespace information. GetFormat always returns null.
            let argStr = string argType
            let argStr = if argStr = "" then "Empty" else argStr
            let argStr = argStr.Substring(argStr.LastIndexOf '.' + 1)

            printf $"{argStr,-20}"
            null }

let format obj1 obj2 obj3 = printfn $"{obj1,-17}{obj2,-17}{obj3}"

// Convert these values using DummyProvider.
let Int32A   = "-252645135"
let DoubleA  = "61680.3855"
let DayTimeA = "2001/9/11 13:45"

let BoolA    = "True"
let StringA  = "Qwerty"
let CharA    = "$"

printfn 
    """This example of selected Convert.To<Type>( String, IFormatProvider ) 
methods generates the following output. The example displays the 
provider type if the IFormatProvider is called.

Note: For the ToBoolean, ToString, and ToChar methods, the 
IFormatProvider object is not referenced.
"""

// The format provider is called for the following conversions.
format "ToInt32" Int32A (Convert.ToInt32(Int32A, provider) )
format "ToDouble" DoubleA (Convert.ToDouble(DoubleA, provider) )
format "ToDateTime" DayTimeA (Convert.ToDateTime(DayTimeA, provider) )

// The format provider is not called for these conversions.
printfn ""
format "ToBoolean" BoolA (Convert.ToBoolean(BoolA, provider) )
format "ToString" StringA (Convert.ToString(StringA, provider) )
format "ToChar" CharA (Convert.ToChar(CharA, provider) )

// This example of selected Convert.To<Type>( String, IFormatProvider )
// methods generates the following output. The example displays the
// provider type if the IFormatProvider is called.
//
// Note: For the ToBoolean, ToString, and ToChar methods, the
// IFormatProvider object is not referenced.
//
// NumberFormatInfo    ToInt32          -252645135       -252645135
// NumberFormatInfo    ToDouble         61680.3855       61680.3855
// DateTimeFormatInfo  ToDateTime       2001/9/11 13:45  9/11/2001 1:45:00 PM
//
// ToBoolean        True             True
// ToString         Qwerty           Qwerty
// ToChar           $                $
//</Snippet2>
