module todouble1

open System


let convertInt16 () =
    // <Snippet1>
    let numbers = 
        [| Int16.MinValue; -1032s; 0s; 192s; Int16.MaxValue |]

    for number in numbers do
        let result = Convert.ToDouble number
        printfn $"Converted the UInt16 value {number} to {result}."
    // The example displays the following output:
    //       Converted the UInt16 value -32768 to -32768.
    //       Converted the UInt16 value -1032 to -1032.
    //       Converted the UInt16 value 0 to 0.
    //       Converted the UInt16 value 192 to 192.
    //       Converted the UInt16 value 32767 to 32767.
    // </Snippet1>

let convertInt64 () =
    // <Snippet2>
    let numbers = 
        [| Int64.MinValue; -903L; 0L; 172L; Int64.MaxValue |]

    for number in numbers do
        let result = Convert.ToDouble number
        printfn $"Converted the {number.GetType().Name} value '{number}' to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the Int64 value '-9223372036854775808' to the Double value -9.22337203685478E+18.
    //    Converted the Int64 value '-903' to the Double value -903.
    //    Converted the Int64 value '0' to the Double value 0.
    //    Converted the Int64 value '172' to the Double value 172.
    //    Converted the Int64 value '9223372036854775807' to the Double value 9.22337203685478E+18.
    // </Snippet2>

let convertObject () =
    // <Snippet3>
    let values: obj[] =
        [| true; 'a'; 123; 1.764e32f; "9.78"; "1e-02";
           1.67e03f; "A100"; "1,033.67"; DateTime.Now
           Decimal.MaxValue |]

    for value in values do
        try
            let result = Convert.ToDouble value
            printfn $"Converted the {value.GetType().Name} value {value} to {result}."
        with
        | :? FormatException ->
            printfn $"The {value.GetType().Name} value {value} is not recognized as a valid Double value."
        | :? InvalidCastException ->
            printfn $"Conversion of the {value.GetType().Name} value {value} to a Double is not supported."
    // The example displays the following output:
    //    Converted the Boolean value True to 1.
    //    Conversion of the Char value a to a Double is not supported.
    //    Converted the Int32 value 123 to 123.
    //    Converted the Single value 1.764E+32 to 1.76399995098587E+32.
    //    Converted the String value 9.78 to 9.78.
    //    Converted the String value 1e-02 to 0.01.
    //    Converted the Single value 1670 to 1670.
    //    The String value A100 is not recognized as a valid Double value.
    //    Converted the String value 1,033.67 to 1033.67.
    //    Conversion of the DateTime value 10/21/2008 07:12:12 AM to a Double is not supported.
    //    Converted the Decimal value 79228162514264337593543950335 to 7.92281625142643E+28.
    // </Snippet3>

let convertSByte () =
    // <Snippet4>
    let numbers = 
        [| SByte.MinValue; -23y; 0y; 17y; SByte.MaxValue |]

    for number in numbers do
        let result = Convert.ToDouble number
        printfn $"Converted the SByte value {number} to {result}."
    //       Converted the SByte value -128 to -128.
    //       Converted the SByte value -23 to -23.
    //       Converted the SByte value 0 to 0.
    //       Converted the SByte value 17 to 17.
    //       Converted the SByte value 127 to 127.
    // </Snippet4>

let convertUInt16 () =
    // <Snippet5>
    let numbers = 
        [| UInt16.MinValue; 121us; 12345us; UInt16.MaxValue |]

    for number in numbers do
        let result = Convert.ToDouble number
        printfn $"Converted the UInt16 value {number} to {result}."
    // The example displays the following output:
    //       Converted the UInt16 value 0 to 0.
    //       Converted the UInt16 value 121 to 121.
    //       Converted the UInt16 value 12345 to 12345.
    //       Converted the UInt16 value 65535 to 65535.
    // </Snippet5>

let convertUInt32 () =
    // <Snippet6>
    let numbers =
        [| UInt32.MinValue; 121u; 12345u; UInt32.MaxValue |]

    for number in numbers do
        let result = Convert.ToDouble number
        printfn $"Converted the UInt32 value {number} to {result}."
    // The example displays the following output:
    //       Converted the UInt32 value 0 to 0.
    //       Converted the UInt32 value 121 to 121.
    //       Converted the UInt32 value 12345 to 12345.
    //       Converted the UInt32 value 4294967295 to 4294967295.
    // </Snippet6>

let convertUInt64 () =
    // <Snippet7>
    let numbers =
        [| UInt64.MinValue; 121uL; 12345uL; UInt64.MaxValue |]

    for number in numbers do
        let result = Convert.ToDouble number
        printfn $"Converted the UInt64 value {number} to {result}."
    // The example displays the following output:
    //    Converted the UInt64 value 0 to 0.
    //    Converted the UInt64 value 121 to 121.
    //    Converted the UInt64 value 12345 to 12345.
    //    Converted the UInt64 value 18446744073709551615 to 1.84467440737096E+19.
    // </Snippet7>

convertInt16 ()
printfn "-----"
convertInt64 ()
printfn "-----"
convertObject ()
printfn "-----"
convertSByte ()
printfn "----"
convertUInt16 ()
printfn "-----"
convertUInt32 ()
printfn "------"
convertUInt64 ()
