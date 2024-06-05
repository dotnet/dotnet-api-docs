module todecimal11

open System


let convertBoolean () =
    // <Snippet1>
    let flags = [ true; false ]

    for flag in flags do
        let result = Convert.ToDecimal flag
        printfn $"Converted {flag} to {result}."
    // The example displays the following output:
    //       Converted True to 1.
    //       Converted False to 0.
    // </Snippet1>

let convertInt16 () =
    // <Snippet2>
    let numbers = 
        [| Int16.MinValue; -1000s; 0s; 1000s; Int16.MaxValue |]

    for number in numbers do
        let result = Convert.ToDecimal number
        printfn $"Converted the Int16 value {number} to the Decimal value {result}."
    // The example displays the following output:
    //       Converted the Int16 value -32768 to the Decimal value -32768.
    //       Converted the Int16 value -1000 to the Decimal value -1000.
    //       Converted the Int16 value 0 to the Decimal value 0.
    //       Converted the Int16 value 1000 to the Decimal value 1000.
    //       Converted the Int16 value 32767 to the Decimal value 32767.
    // </Snippet2>

let convertInt32 () =
    // <Snippet3>
    let numbers =
        [| Int32.MinValue; -1000; 0; 1000; Int32.MaxValue |]

    for number in numbers do
        let result = Convert.ToDecimal number
        printfn $"Converted the Int32 value {number} to the Decimal value {result}."
    // The example displays the following output:
    //    Converted the Int32 value -2147483648 to the Decimal value -2147483648.
    //    Converted the Int32 value -1000 to the Decimal value -1000.
    //    Converted the Int32 value 0 to the Decimal value 0.
    //    Converted the Int32 value 1000 to the Decimal value 1000.
    //    Converted the Int32 value 2147483647 to the Decimal value 2147483647.
    // </Snippet3>

let convertObject () =
    // <Snippet4>
    let values: obj[] =
        [| true; 'a'; 123; 1.764e32; "9.78"; "1e-02"; 1.67e03
           "A100"; "1,033.67"; DateTime.Now; Double.MaxValue |]

    for value in values do
        try
            let result = Convert.ToDecimal value
            printfn $"Converted the {value.GetType().Name} value {value} to {result}."
        with
        | :? OverflowException ->
            printfn $"The {value.GetType().Name} value {value} is out of range of the Decimal type."
        | :? FormatException ->
            printfn $"The {value.GetType().Name} value {value} is not recognized as a valid Decimal value."
        | :? InvalidCastException ->
            printfn $"Conversion of the {value.GetType().Name} value {value} to a Decimal is not supported."
    // The example displays the following output:
    //    Converted the Boolean value True to 1.
    //    Conversion of the Char value a to a Decimal is not supported.
    //    Converted the Int32 value 123 to 123.
    //    The Double value 1.764E+32 is out of range of the Decimal type.
    //    Converted the String value 9.78 to 9.78.
    //    The String value 1e-02 is not recognized as a valid Decimal value.
    //    Converted the Double value 1670 to 1670.
    //    The String value A100 is not recognized as a valid Decimal value.
    //    Converted the String value 1,033.67 to 1033.67.
    //    Conversion of the DateTime value 10/15/2008 05:40:42 PM to a Decimal is not supported.
    //    The Double value 1.79769313486232E+308 is out of range of the Decimal type.
    // </Snippet4>

let convertSByte () =
    // <Snippet5>
    let numbers = 
        [| SByte.MinValue, -23, 0, 17, SByte.MaxValue |]

    for number in numbers do
        let result = Convert.ToDecimal number
        printfn $"Converted the SByte value {number} to {result}."
    //       Converted the SByte value -128 to -128.
    //       Converted the SByte value -23 to -23.
    //       Converted the SByte value 0 to 0.
    //       Converted the SByte value 17 to 17.
    //       Converted the SByte value 127 to 127.
    // </Snippet5>

let convertSingle () =
    // <Snippet6>
    let numbers =
        [| Single.MinValue; -3e10f; -1093.54f; 0f
           1e-03f; 1034.23f; Single.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToDecimal number
            printfn $"Converted the Single value {number} to {result}."
        with :? OverflowException ->
            printfn $"{number} is out of range of the Decimal type."
    // The example displays the following output:
    //       -3.402823E+38 is out of range of the Decimal type.
    //       Converted the Single value -3E+10 to -30000000000.
    //       Converted the Single value -1093.54 to -1093.54.
    //       Converted the Single value 0 to 0.
    //       Converted the Single value 0.001 to 0.001.
    //       Converted the Single value 1034.23 to 1034.23.
    //       3.402823E+38 is out of range of the Decimal type.
    // </Snippet6>

let convertUInt16 () =
    // <Snippet7>
    let numbers = 
        [| UInt16.MinValue; 121us; 12345us; UInt16.MaxValue |]

    for number in numbers do
        let result = Convert.ToDecimal number
        printfn $"Converted the UInt16 value {number} to {result}."
    // The example displays the following output:
    //       Converted the UInt16 value 0 to 0.
    //       Converted the UInt16 value 121 to 121.
    //       Converted the UInt16 value 12345 to 12345.
    //       Converted the UInt16 value 65535 to 65535.
    // </Snippet7>

let convertUInt32 () =
    // <Snippet8>
    let numbers =
        [| UInt32.MinValue; 121u; 12345u; UInt32.MaxValue |]

    for number in numbers do
        let result = Convert.ToDecimal number
        printfn $"Converted the UInt32 value {number} to {result}."
    // The example displays the following output:
    //       Converted the UInt32 value 0 to 0.
    //       Converted the UInt32 value 121 to 121.
    //       Converted the UInt32 value 12345 to 12345.
    //       Converted the UInt32 value 4294967295 to 4294967295.
    // </Snippet8>

let convertUInt64 () =
    // <Snippet9>
    let numbers = 
        [| UInt64.MinValue; 121uL; 12345uL; UInt64.MaxValue |]

    for number in numbers do
        let result = Convert.ToDecimal number
        printfn $"Converted the UInt64 value {number} to {result}."
    // The example displays the following output:
    //    Converted the UInt64 value 0 to 0.
    //    Converted the UInt64 value 121 to 121.
    //    Converted the UInt64 value 12345 to 12345.
    //    Converted the UInt64 value 18446744073709551615 to 18446744073709551615.
    // </Snippet9>

convertBoolean ()
printfn "-----"
convertInt16 ()
printfn "-----"
convertInt32 ()
printfn "-----"
convertObject ()
printfn "-----"
convertSByte ()
printfn "-----"
convertSingle ()
printfn "-----"
convertUInt16 ()
printfn "-----"
convertUInt32 ()
printfn "-----"
convertUInt64 ()
