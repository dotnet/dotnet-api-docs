module touint16_1

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
        let result = Convert.ToUInt16 byteValue
        printfn $"Converted the {byteValue.GetType().Name} value '{byteValue}' to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //       Converted the Byte value '0' to the UInt16 value 0.
    //       Converted the Byte value '14' to the UInt16 value 14.
    //       Converted the Byte value '122' to the UInt16 value 122.
    //       Converted the Byte value '255' to the UInt16 value 255.
    // </Snippet2>

let convertChar () =
    // <Snippet3>
    let chars = 
        [| 'a'; 'z'; '\u0007'; '\u03FF'; '\u7FFF'; '\uFFFE' |]

    for ch in chars do
        try
            let result = Convert.ToUInt16 ch
            printfn $"Converted the {ch.GetType().Name} value '{ch}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"Unable to convert u+{int ch:X4} to a UInt16."
    // The example displays the following output:
    //    Converted the Char value 'a' to the UInt16 value 97.
    //    Converted the Char value 'z' to the UInt16 value 122.
    //    Converted the Char value '' to the UInt16 value 7.
    //    Converted the Char value '?' to the UInt16 value 1023.
    //    Converted the Char value '?' to the UInt16 value 32767.
    //    Converted the Char value '?' to the UInt16 value 65534.
    // </Snippet3>

let convertDecimal () =
    // <Snippet4>
    let numbers = 
        [| Decimal.MinValue; -1034.23m; -12m; 0m; 147m; 9214.16m; Decimal.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToUInt16 number
            printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"{number} is outside the range of the UInt16 type."
    // The example displays the following output:
    //    -79228162514264337593543950335 is outside the range of the UInt16 type.
    //    -1034.23 is outside the range of the UInt16 type.
    //    -12 is outside the range of the UInt16 type.
    //    Converted the Decimal value '0' to the UInt16 value 0.
    //    Converted the Decimal value '147' to the UInt16 value 147.
    //    Converted the Decimal value '9214.16' to the UInt16 value 9214.
    //    79228162514264337593543950335 is outside the range of the UInt16 type.
    // </Snippet4>

let convertDouble () =
    // <Snippet5>
    let numbers = 
        [| Double.MinValue; -1.38e10; -1023.299; -12.98
           0; 9.113e-16; 103.919; 17834.191; Double.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToUInt16 number
            printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"{number} is outside the range of the UInt16 type."
    // The example displays the following output:
    //    -1.79769313486232E+308 is outside the range of the UInt16 type.
    //    -13800000000 is outside the range of the UInt16 type.
    //    -1023.299 is outside the range of the UInt16 type.
    //    -12.98 is outside the range of the UInt16 type.
    //    Converted the Double value '0' to the UInt16 value 0.
    //    Converted the Double value '9.113E-16' to the UInt16 value 0.
    //    Converted the Double value '103.919' to the UInt16 value 104.
    //    Converted the Double value '17834.191' to the UInt16 value 17834.
    //    1.79769313486232E+308 is outside the range of the UInt16 type.
    // </Snippet5>

let convertInt16 () =
    // <Snippet6>
    let numbers = [| Int16.MinValue; -132s; 0s; 121s; 16103s; Int16.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToUInt16 number
            printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the UInt16 type."
    // The example displays the following output:
    //    The Int16 value -32768 is outside the range of the UInt16 type.
    //    The Int16 value -132 is outside the range of the UInt16 type.
    //    Converted the Int16 value '0' to the UInt16 value 0.
    //    Converted the Int16 value '121' to the UInt16 value 121.
    //    Converted the Int16 value '16103' to the UInt16 value 16103.
    //    Converted the Int16 value '32767' to the UInt16 value 32767.
    // </Snippet6>

let convertInt32 () =
    // <Snippet7>
    let numbers = [| Int32.MinValue; -1; 0; 121; 340; Int32.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToUInt16 number
            printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn "The {number.GetType().Name} value {number} is outside the range of the UInt16 type."
                            
    // The example displays the following output:
    //    The Int32 value -2147483648 is outside the range of the UInt16 type.
    //    The Int32 value -1 is outside the range of the UInt16 type.
    //    Converted the Int32 value '0' to the UInt16 value 0.
    //    Converted the Int32 value '121' to the UInt16 value 121.
    //    Converted the Int32 value '340' to the UInt16 value 340.
    //    The Int32 value 2147483647 is outside the range of the UInt16 type.
    // </Snippet7>

let convertInt64 () =
    // <Snippet8>
    let numbers = [| Int64.MinValue; -1; 0; 121; 340; Int64.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToUInt16 number
            printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn "The {number.GetType().Name} value {number} is outside the range of the UInt16 type."
    // The example displays the following output:
    //    The Int64 value -9223372036854775808 is outside the range of the UInt16 type.
    //    The Int64 value -1 is outside the range of the UInt16 type.
    //    Converted the Int64 value '0' to the UInt16 value 0.
    //    Converted the Int64 value '121' to the UInt16 value 121.
    //    Converted the Int64 value '340' to the UInt16 value 340.
    //    The Int64 value 9223372036854775807 is outside the range of the UInt16 type.
    // </Snippet8>

let convertObject () =
    // <Snippet9>
    let values: obj[] =
        [| true; -12; 163; 935; 'x'; DateTime(2009, 5, 12)
           "104"; "103.0"; "-1"; "1.00e2"; "One"; 1.00e2 |]

    for value in values do
        try
            let result = Convert.ToUInt16 value
            printfn $"Converted the {value.GetType().Name} value '{value}' to the {result.GetType().Name} value {result}."
        with 
        | :? OverflowException ->
            printfn $"The {value.GetType().Name} value {value} is outside the range of the UInt16 type."
        | :? FormatException ->
            printfn $"The {value.GetType().Name} value {value} is not in a recognizable format."
        | :? InvalidCastException ->
            printfn $"No conversion to a UInt16 exists for the {value.GetType().Name} value {value}."
    // The example displays the following output:
    //    Converted the Boolean value 'True' to the UInt16 value 1.
    //    The Int32 value -12 is outside the range of the UInt16 type.
    //    Converted the Int32 value '163' to the UInt16 value 163.
    //    Converted the Int32 value '935' to the UInt16 value 935.
    //    Converted the Char value 'x' to the UInt16 value 120.
    //    No conversion to a UInt16 exists for the DateTime value 5/12/2009 12:00:00 AM.
    //    Converted the String value '104' to the UInt16 value 104.
    //    The String value 103.0 is not in a recognizable format.
    //    The String value -1 is outside the range of the UInt16 type.
    //    The String value 1.00e2 is not in a recognizable format.
    //    The String value One is not in a recognizable format.
    //    Converted the Double value '100' to the UInt16 value 100.
    // </Snippet9>

let convertSByte () =
    // <Snippet10>
    let numbers = [| SByte.MinValue; -1y; 0y; 10y; SByte.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToUInt16 number
            printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"{number} is outside the range of the UInt16 type."
    // The example displays the following output:
    //    -128 is outside the range of the UInt16 type.
    //    -1 is outside the range of the UInt16 type.
    //    Converted the SByte value '0' to the UInt16 value 0.
    //    Converted the SByte value '10' to the UInt16 value 10.
    //    Converted the SByte value '127' to the UInt16 value 127.
    // </Snippet10>

let convertSingle () =
    // <Snippet11>
    let numbers = 
        [| Single.MinValue; -1.38e10f; -1023.299f; -12.98f
           0f; 9.113e-16f; 103.919f; 17834.191f; Single.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToUInt16 number
            printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"{number} is outside the range of the UInt16 type."
    // The example displays the following output:
    //    -3.402823E+38 is outside the range of the UInt16 type.
    //    -1.38E+10 is outside the range of the UInt16 type.
    //    -1023.299 is outside the range of the UInt16 type.
    //    -12.98 is outside the range of the UInt16 type.
    //    Converted the Single value '0' to the UInt16 value 0.
    //    Converted the Single value '9.113E-16' to the UInt16 value 0.
    //    Converted the Single value '103.919' to the UInt16 value 104.
    //    Converted the Single value '17834.19' to the UInt16 value 17834.
    //    3.402823E+38 is outside the range of the UInt16 type.
    // </Snippet11>

let convertString () =
    // <Snippet12>
    let values =
        [| "1603"; "1,603"; "one"; "1.6e03"
           "1.2e-02"; "-1326"; "1074122" |]

    for value in values do
        try
            let result = Convert.ToUInt16 value
            printfn $"Converted the {value.GetType().Name} value '{value}' to the {result.GetType().Name} value {result}."
        with
        | :? FormatException ->
            printfn $"The {value.GetType().Name} value {value} is not in a recognizable format."
        | :? OverflowException ->
            printfn $"{value} is outside the range of the UInt16 type." 
    // The example displays the following output:
    //    Converted the String value '1603' to the UInt16 value 1603.
    //    The String value 1,603 is not in a recognizable format.
    //    The String value one is not in a recognizable format.
    //    The String value 1.6e03 is not in a recognizable format.
    //    The String value 1.2e-02 is not in a recognizable format.
    //    -1326 is outside the range of the UInt16 type.
    //    1074122 is outside the range of the UInt16 type.
    // </Snippet12>

let convertUInt32 () =
    // <Snippet13>
    let numbers = [| UInt32.MinValue; 121u; 340u; UInt32.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToUInt16 number
            printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the UInt16 type."
                            
    // The example displays the following output:
    //    Converted the UInt32 value '0' to the UInt16 value 0.
    //    Converted the UInt32 value '121' to the UInt16 value 121.
    //    Converted the UInt32 value '340' to the UInt16 value 340.
    //    The UInt32 value 4294967295 is outside the range of the UInt16 type.
    // </Snippet13>

let convertUInt64 () =
    // <Snippet14>
    let numbers = [| UInt64.MinValue; 121uL; 340uL; UInt64.MaxValue |]

    for number in numbers do
        try
            let result = Convert.ToUInt16 number
            printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the UInt16 type."
    // The example displays the following output:
    //    Converted the UInt64 value '0' to the UInt16 value 0.
    //    Converted the UInt64 value '121' to the UInt16 value 121.
    //    Converted the UInt64 value '340' to the UInt16 value 340.
    //    The UInt64 value 18446744073709551615 is outside the range of the UInt16 type.
    // </Snippet14>

convertBoolean ()
printfn "-----" 
convertByte ()
printfn "-----" 
convertChar ()
printfn "-----" 
convertDecimal ()
printfn "-----" 
convertDouble ()
printfn "----"
convertInt16 ()
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
convertString()
printfn "-----" 
convertUInt32 ()
printfn "-----" 
convertUInt64 ()