module changetype00

// <Snippet1>
open System
open System.Globalization

type InterceptProvider() =
    interface IFormatProvider with
        member _.GetFormat(formatType: Type) =
            if formatType = typeof<NumberFormatInfo> then
                printfn "   Returning a fr-FR numeric format provider."
                CultureInfo("fr-FR").NumberFormat
            elif formatType = typeof<DateTimeFormatInfo> then
                printfn "   Returning an en-US date/time format provider."
                CultureInfo("en-US").DateTimeFormat
            else
                printfn $"   Requesting a format provider of {formatType.Name}."
                null

let values: obj[] = [| 103.5; DateTime(2010, 12, 26, 14, 34, 0)|]
let provider = InterceptProvider()

// Convert value to each of the types represented in TypeCode enum.
for value in values do
    // Iterate types in TypeCode enum.
    for enumType in Enum.GetValues typeof<TypeCode> :?> TypeCode[] do
        match enumType with
        | TypeCode.DBNull | TypeCode.Empty -> ()
        | _ ->
            try
                printfn $"{value} ({value.GetType().Name}) --> {Convert.ChangeType(value, enumType, provider)} ({enumType})."
            with
            | :? InvalidCastException ->
                printfn $"Cannot convert a {value.GetType().Name} to a {enumType}"
            | :? OverflowException ->
                printfn $"Overflow: {value} is out of the range of a {enumType}"
    printfn ""

// The example displays the following output:
//    103.5 (Double) --> 103.5 (Object).
//    103.5 (Double) --> True (Boolean).
//    Cannot convert a Double to a Char
//    103.5 (Double) --> 104 (SByte).
//    103.5 (Double) --> 104 (Byte).
//    103.5 (Double) --> 104 (Int16).
//    103.5 (Double) --> 104 (UInt16).
//    103.5 (Double) --> 104 (Int32).
//    103.5 (Double) --> 104 (UInt32).
//    103.5 (Double) --> 104 (Int64).
//    103.5 (Double) --> 104 (UInt64).
//    103.5 (Double) --> 103.5 (Single).
//    103.5 (Double) --> 103.5 (Double).
//    103.5 (Double) --> 103.5 (Decimal).
//    Cannot convert a Double to a DateTime
//       Returning a fr-FR numeric format provider.
//    103.5 (Double) --> 103,5 (String).
//
//    12/26/2010 2:34:00 PM (DateTime) --> 12/26/2010 2:34:00 PM (Object).
//    Cannot convert a DateTime to a Boolean
//    Cannot convert a DateTime to a Char
//    Cannot convert a DateTime to a SByte
//    Cannot convert a DateTime to a Byte
//    Cannot convert a DateTime to a Int16
//    Cannot convert a DateTime to a UInt16
//    Cannot convert a DateTime to a Int32
//    Cannot convert a DateTime to a UInt32
//    Cannot convert a DateTime to a Int64
//    Cannot convert a DateTime to a UInt64
//    Cannot convert a DateTime to a Single
//    Cannot convert a DateTime to a Double
//    Cannot convert a DateTime to a Decimal
//    12/26/2010 2:34:00 PM (DateTime) --> 12/26/2010 2:34:00 PM (DateTime).
//       Returning an en-US date/time format provider.
//    12/26/2010 2:34:00 PM (DateTime) --> 12/26/2010 2:34:00 PM (String).
// </Snippet1>