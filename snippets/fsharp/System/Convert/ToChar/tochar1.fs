module tochar1

open System

let convertByte () =
    // <Snippet1>
    let bytes = 
        [| Byte.MinValue; 40uy; 80uy; 120uy; 180uy; Byte.MaxValue|]
    for number in bytes do
        let result = Convert.ToChar number
        printfn $"{number} converts to '{result}'." 
    // The example displays the following output:
    //       0 converts to ' '.
    //       40 converts to '('.
    //       80 converts to 'P'.
    //       120 converts to 'x'.
    //       180 converts to '''.
    //       255 converts to 'ÿ'.
    // </Snippet1>

let convertInt16 () =
    // <Snippet2>
    let numbers = 
        [| Int16.MinValue; 0s; 40s; 160s 
           255s; 1028s; 2011s; Int16.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToChar number
            printfn $"{number} converts to '{result}'." 
        with :? OverflowException ->
        printfn $"{number} is outside the range of the Char data type."
    // The example displays the following output:
    //       -32768 is outside the range of the Char data type.
    //       0 converts to ' '.
    //       40 converts to '('.
    //       160 converts to ' '.
    //       255 converts to 'ÿ'.
    //       1028 converts to 'Є'.
    //       2011 converts to 'ߛ'.
    //       32767 converts to '翿'.
    // </Snippet2>

let convertInt32 () =
    // <Snippet3>
    let numbers = 
        [| -1; 0; 40; 160; 255; 1028; 2011
           30001; 207154; Int32.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToChar number
            printfn $"{number} converts to '{result}'." 
        with :? OverflowException ->
            printfn $"{number} is outside the range of the Char data type."
    //       -1 is outside the range of the Char data type.
    //       0 converts to ' '.
    //       40 converts to '('.
    //       160 converts to ' '.
    //       255 converts to 'ÿ'.
    //       1028 converts to 'Є'.
    //       2011 converts to 'ߛ'.
    //       30001 converts to '由'.
    //       207154 is outside the range of the Char data type.
    //       2147483647 is outside the range of the Char data type.
    // </Snippet3>

let convertSByte () =
    // <Snippet4>
    let numbers =
        [| SByte.MinValue; -1y; 40y; 80y; 120y; SByte.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToChar number
            printfn $"{number} converts to '{result}'." 
        with :? OverflowException ->
            printfn $"{number} is outside the range of the Char data type."
    // The example displays the following output:
    //       -128 is outside the range of the Char data type.
    //       -1 is outside the range of the Char data type.
    //       40 converts to '('.
    //       80 converts to 'P'.
    //       120 converts to 'x'.
    //       127 converts to '⌂'.
    // </Snippet4>

let convertString () =
    // <Snippet5>
    let nullString = null
    let strings = [| "A"; "This";  '\u0007'.ToString(); nullString |]
    for string in strings do
        try
            let result = Convert.ToChar string
            printfn $"'{string}' converts to '{result}'."
        with 
        | :? FormatException ->
            printfn $"'{string}' is not in the correct format for conversion to a Char."
        | :? ArgumentNullException ->
            printfn "A null string cannot be converted to a Char."
    // The example displays the following output:
    //       'A' converts to 'A'.
    //       'This' is not in the correct format for conversion to a Char.
    //       '       ' converts to ' '.
    //       A null string cannot be converted to a Char.
    // </Snippet5>

let convertUInt16 () =
    // <Snippet6>
    let numbers = 
        [| UInt16.MinValue; 40us; 160us; 255us
           1028us; 2011us; UInt16.MaxValue |]
    for number in numbers do
        let result = Convert.ToChar number
        printfn $"{number} converts to '{result}'." 
    // The example displays the following output:
    //       0 converts to ' '.
    //       40 converts to '('.
    //       160 converts to ' '.
    //       255 converts to 'ÿ'.
    //       1028 converts to 'Є'.
    //       2011 converts to 'ߛ'.
    //       65535 converts to '￿'.
    // </Snippet6>

let convertUInt32 () =
    // <Snippet7>
    let numbers =
        [| UInt32.MinValue; 40u; 160u; 255u; 1028u
           2011u; 30001u; 207154u; uint Int32.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToChar number
            printfn $"{number} converts to '{result}'." 
        with :? OverflowException ->
            printfn $"{number} is outside the range of the Char data type."
    // The example displays the following output:
    //       0 converts to ' '.
    //       40 converts to '('.
    //       160 converts to ' '.
    //       255 converts to 'ÿ'.
    //       1028 converts to 'Є'.
    //       2011 converts to 'ߛ'.
    //       30001 converts to '由'.
    //       207154 is outside the range of the Char data type.
    //       2147483647 is outside the range of the Char data type.
    // </Snippet7>

let convertUInt64 () =
    // <Snippet8>
    let numbers =
        [| UInt64.MinValue; 40uL; 160uL; 255uL; 1028uL
           2011uL; 30001uL; 207154uL; uint64 Int64.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToChar number
            printfn $"{number} converts to '{result}'." 
        with :? OverflowException ->
            printfn $"{number} is outside the range of the Char data type."
    // The example displays the following output:
    //       0 converts to ' '.
    //       40 converts to '('.
    //       160 converts to ' '.
    //       255 converts to 'ÿ'.
    //       1028 converts to 'Є'.
    //       2011 converts to 'ߛ'.
    //       30001 converts to '由'.
    //       207154 is outside the range of the Char data type.
    //       9223372036854775807 is outside the range of the Char data type.
    // </Snippet8>

let convertObject () =
    // <Snippet9>
    let values: obj[] = 
        [| 'r'; "s"; "word"; 83uy; 77; 109324; 335812911
           DateTime(2009, 3, 10); 1934u
           -17y; 169.34; 175.6m; null |]

    for value in values do
        try
            let result = Convert.ToChar(value)
            printfn $"The {value.GetType().Name} value {value} converts to {result}."
        with
        | :? FormatException as e ->
            printfn $"{e.Message}"
        | :? InvalidCastException ->
            printfn $"Conversion of the {value.GetType().Name} value {value} to a Char is not supported."
        | :? OverflowException ->
            printfn $"The {value.GetType().Name} value {value} is outside the range of the Char data type."
        | :? NullReferenceException ->
            printfn "Cannot convert a null reference to a Char."
    // The example displays the following output:
    //       The Char value r converts to r.
    //       The String value s converts to s.
    //       String must be exactly one character long.
    //       The Byte value 83 converts to S.
    //       The Int32 value 77 converts to M.
    //       The Int32 value 109324 is outside the range of the Char data type.
    //       The Int32 value 335812911 is outside the range of the Char data type.
    //       Conversion of the DateTime value 3/10/2009 12:00:00 AM to a Char is not supported.
    //       The UInt32 value 1934 converts to ?.
    //       The SByte value -17 is outside the range of the Char data type.
    //       Conversion of the Double value 169.34 to a Char is not supported.
    //       Conversion of the Decimal value 175.6 to a Char is not supported.
    //       Cannot convert a null reference to a Char.
    // </Snippet9>

convertByte ()
printfn "-----"
convertInt16 ()
printfn "-----"
convertInt32 ()
printfn "-----"
convertSByte ()
printfn "-----"
convertString ()
printfn "-----"
convertUInt16 ()
printfn "-----"
convertUInt32 ()
printfn "-----"
convertUInt64 ()
printfn "-----"
convertObject ()