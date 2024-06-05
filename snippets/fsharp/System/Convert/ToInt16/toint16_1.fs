module toint16_1

open System

let convertBoolean () =
    // <Snippet1>
    let falseFlag = false
    let trueFlag = true

    printfn $"{falseFlag} converts to {Convert.ToInt16 falseFlag}."
    printfn $"{trueFlag} converts to {Convert.ToInt16 trueFlag}."
    // The example displays the following output:
    //       False converts to 0.
    //       True converts to 1.
    // </Snippet1>

let convertByte () =
    // <Snippet2>
    let bytes = [| Byte.MinValue; 14uy; 122uy; Byte.MaxValue |]

    for byteValue in bytes do
        let result = Convert.ToInt16 byteValue
        printfn $"The Byte value {byteValue} converts to {result}."
    // The example displays the following output:
    //       The Byte value 0 converts to 0.
    //       The Byte value 14 converts to 14.
    //       The Byte value 122 converts to 122.
    //       The Byte value 255 converts to 255.
    // </Snippet2>

let convertChar () =
    // <Snippet3>
    let chars = 
        [| 'a'; 'z'; '\u0007'; '\u03FF'; '\u7FFF'; '\uFFFE' |]

    for ch in chars do
        try
            let result = Convert.ToInt16 ch
            printfn $"'{ch}' converts to {result}."
        with :? OverflowException ->
            printfn $"Unable to convert u+{int ch:X4} to an Int16."
    // The example displays the following output:
    //       'a' converts to 97.
    //       'z' converts to 122.
    //       '' converts to 7.
    //       'Ͽ' converts to 1023.
    //       '翿' converts to 32767.
    //       Unable to convert u+FFFE to an Int16.
    // </Snippet3>

let convertDecimal () =
    // <Snippet4>
    let values = 
        [| Decimal.MinValue; -1034.23m; -12m; 0m
           147m; 9214.16m; Decimal.MaxValue |]

    for value in values do
        try
            let result = Convert.ToInt16 value
            printfn $"Converted {value} to {result}."
        with :? OverflowException ->
            printfn $"{value} is outside the range of the Int16 type."
    // The example displays the following output:
    //    -79228162514264337593543950335 is outside the range of the Int16 type.
    //    Converted -1034.23 to -1034.
    //    Converted -12 to -12.
    //    Converted 0 to 0.
    //    Converted 147 to 147.
    //    Converted 9214.16 to 9214.
    //    79228162514264337593543950335 is outside the range of the Int16 type.
    // </Snippet4>

let convertDouble () =
    // <Snippet5>
    let values =
        [| Double.MinValue; -1.38e10; -1023.299; -12.98
           0; 9.113e-16; 103.919; 17834.191; Double.MaxValue |]

    for value in values do
        try
            let result = Convert.ToInt16 value
            printfn $"Converted {value} to {result}."
        with :? OverflowException ->
            printfn $"{value} is outside the range of the Int16 type."
    //       -1.79769313486232E+308 is outside the range of the Int16 type.
    //       -13800000000 is outside the range of the Int16 type.
    //       Converted -1023.299 to -1023.
    //       Converted -12.98 to -13.
    //       Converted 0 to 0.
    //       Converted 9.113E-16 to 0.
    //       Converted 103.919 to 104.
    //       Converted 17834.191 to 17834.
    //       1.79769313486232E+308 is outside the range of the Int16 type.
    // </Snippet5>

let convertInt32 () =
    // <Snippet6>
    let numbers = 
        [| Int32.MinValue; -1; 0; 121; 340; Int32.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToInt16 number
            printfn $"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Int16 type."
    // The example displays the following output:
    //    The Int32 value -2147483648 is outside the range of the Int16 type.
    //    Converted the Int32 value -1 to a Int16 value -1.
    //    Converted the Int32 value 0 to a Int16 value 0.
    //    Converted the Int32 value 121 to a Int16 value 121.
    //    Converted the Int32 value 340 to a Int16 value 340.
    //    The Int32 value 2147483647 is outside the range of the Int16 type.
    // </Snippet6>

let convertInt64 () =
    // <Snippet7>
    let numbers =
        [| Int64.MinValue; -1; 0; 121; 340; Int64.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToInt16 number
            printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Int16 type."
    // The example displays the following output:
    //    The Int64 value -9223372036854775808 is outside the range of the Int16 type.
    //    Converted the Int64 value -1 to the Int16 value -1.
    //    Converted the Int64 value 0 to the Int16 value 0.
    //    Converted the Int64 value 121 to the Int16 value 121.
    //    Converted the Int64 value 340 to the Int16 value 340.
    //    The Int64 value 9223372036854775807 is outside the range of the Int16 type.
    // </Snippet7>

let convertObject () =
    // <Snippet8>
    let values: obj[] =
        [| true; -12; 163; 935; 'x'; DateTime(2009, 5, 12)
           "104"; "103.0"; "-1"; "1.00e2"; "One"; 1.00e2 |]

    for value in values do
        try
            let result = Convert.ToInt16 value
            printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
        with 
        | :? OverflowException ->
            printfn $"The {value.GetType().Name} value {value} is outside the range of the Int16 type."
        | :? FormatException ->
            printfn $"The {value.GetType().Name} value {value} is not in a recognizable format."
        | :? InvalidCastException ->
            printfn $"No conversion to an Int16 exists for the {value.GetType().Name} value {value}."
    // The example displays the following output:
    //    Converted the Boolean value True to the Int16 value 1.
    //    Converted the Int32 value -12 to the Int16 value -12.
    //    Converted the Int32 value 163 to the Int16 value 163.
    //    Converted the Int32 value 935 to the Int16 value 935.
    //    Converted the Char value x to the Int16 value 120.
    //    No conversion to an Int16 exists for the DateTime value 5/12/2009 12:00:00 AM.
    //    Converted the String value 104 to the Int16 value 104.
    //    The String value 103.0 is not in a recognizable format.
    //    Converted the String value -1 to the Int16 value -1.
    //    The String value 1.00e2 is not in a recognizable format.
    //    The String value One is not in a recognizable format.
    //    Converted the Double value 100 to the Int16 value 100.
    // </Snippet8>

let convertSByte () =
    // <Snippet9>
    let numbers = 
        [| SByte.MinValue; -1y; 0y; 10y; SByte.MaxValue |]

    for number in numbers do
        let result = Convert.ToInt16 number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //       Converted the SByte value -128 to the Int16 value -128.
    //       Converted the SByte value -1 to the Int16 value -1.
    //       Converted the SByte value 0 to the Int16 value 0.
    //       Converted the SByte value 10 to the Int16 value 10.
    //       Converted the SByte value 127 to the Int16 value 127.
    // </Snippet9>

let convertSingle () =
    // <Snippet10>
    let values = 
        [| Single.MinValue; -1.38e10f; -1023.299f; -12.98f
           0f; 9.113e-16f; 103.919f; 17834.191f; Single.MaxValue |]

    for value in values do
        try
            let result = Convert.ToInt16 value
            printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"{value} is outside the range of the Int16 type."
    // The example displays the following output:
    //    -3.4028235E+38 is outside the range of the Int16 type.
    //    -1.38E+10 is outside the range of the Int16 type.
    //    Converted the Single value -1023.299 to the Int16 value -1023.
    //    Converted the Single value -12.98 to the Int16 value -13.
    //    Converted the Single value 0 to the Int16 value 0.
    //    Converted the Single value 9.113E-16 to the Int16 value 0.
    //    Converted the Single value 103.919 to the Int16 value 104.
    //    Converted the Single value 17834.191 to the Int16 value 17834.
    //    3.4028235E+38 is outside the range of the Int16 type.
    // </Snippet10>

let convertUInt16 () =
    // <Snippet11>
    let numbers = 
        [| UInt16.MinValue; 121us; 340us; UInt16.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToInt16 number
            printfn $"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Int16 type."
    // The example displays the following output:
    //       Converted the UInt16 value 0 to a Int16 value 0.
    //       Converted the UInt16 value 121 to a Int16 value 121.
    //       Converted the UInt16 value 340 to a Int16 value 340.
    //       The UInt16 value 65535 is outside the range of the Int16 type.
    // </Snippet11>

let convertUInt32 () =
    // <Snippet12>
    let numbers =
        [| UInt32.MinValue; 121u; 340u; UInt32.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToInt16 number
            printfn $"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Int16 type."
    // The example displays the following output:
    //    Converted the UInt32 value 0 to a Int16 value 0.
    //    Converted the UInt32 value 121 to a Int16 value 121.
    //    Converted the UInt32 value 340 to a Int16 value 340.
    //    The UInt32 value 4294967295 is outside the range of the Int16 type.
    // </Snippet12>

let convertUInt64 () =
    // <Snippet13>
    let numbers = 
        [| UInt64.MinValue; 121uL; 340uL; UInt64.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToInt16 number
            printfn $"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Int16 type."
    // The example displays the following output:
    //    Converted the UInt64 value 0 to a Int16 value 0.
    //    Converted the UInt64 value 121 to a Int16 value 121.
    //    Converted the UInt64 value 340 to a Int16 value 340.
    //    The UInt64 value 18446744073709551615 is outside the range of the Int16 type.
    // </Snippet13>

convertBoolean ()
printfn "-----"
convertByte ()
printfn "-----"
convertChar ()
printfn "-----"
convertDecimal ()
printfn "-----"
convertDouble ()
printfn "-----"
convertInt32 ()
printfn "-----"
convertInt64 ()
printfn "-----"
convertObject ()
printfn "-----"
convertSByte ()
printfn "-----"
convertSingle ()
printfn "----"
convertUInt16 ()
printfn "-----"
convertUInt32 ()
printfn "-----"
convertUInt64 ()
