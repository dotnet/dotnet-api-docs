module tosingle1

open System

let convertBoolean () =
    // <Snippet1>
    let flags = [| true; false |]

    for flag in flags do
        let result = Convert.ToSingle flag
        printfn $"Converted {flag} to {result}."
    // The example displays the following output:
    //       Converted True to 1.
    //       Converted False to 0.
    // </Snippet1>

let convertByte () =
    // <Snippet2>
    let numbers = [| Byte.MinValue; 10uy; 100uy; Byte.MaxValue |]

    for number in numbers do
        let result = Convert.ToSingle number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //       Converted the Byte value 0 to the Single value 0.
    //       Converted the Byte value 10 to the Single value 10.
    //       Converted the Byte value 100 to the Single value 100.
    //       Converted the Byte value 255 to the Single value 255.
    // </Snippet2>

let convertDecimal () =
    // <Snippet3>
    let values = 
        [| Decimal.MinValue; -1034.23m; -12m; 0m; 147m; 199.55m; 9214.16m; Decimal.MaxValue |]

    for value in values do
        let result = Convert.ToSingle value
        printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the Decimal value '-79228162514264337593543950335' to the Single value -7.9228163E+28.
    //    Converted the Decimal value '-1034.23' to the Single value -1034.23.
    //    Converted the Decimal value '-12' to the Single value -12.
    //    Converted the Decimal value '0' to the Single value 0.
    //    Converted the Decimal value '147' to the Single value 147.
    //    Converted the Decimal value '199.55' to the Single value 199.55.
    //    Converted the Decimal value '9214.16' to the Single value 9214.16.
    //    Converted the Decimal value '79228162514264337593543950335' to the Single value 7.9228163E+28.
    // </Snippet3>

let convertDouble () =
    // <Snippet4>
    let values = 
        [| Double.MinValue; -1.38e10; -1023.299; -12.98; 0; 9.113e-16; 103.919; 17834.191; Double.MaxValue |]

    for value in values do
        let result = Convert.ToSingle value
        printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the Double value '-1.79769313486232E+308' to the Single value -Infinity.
    //    Converted the Double value '-13800000000' to the Single value -1.38E+10.
    //    Converted the Double value '-1023.299' to the Single value -1023.299.
    //    Converted the Double value '-12.98' to the Single value -12.98.
    //    Converted the Double value '0' to the Single value 0.
    //   Converted the Double value '9.113E-16' to the Single value 9.113E-16.
    //    Converted the Double value '103.919' to the Single value 103.919.
    //    Converted the Double value '17834.191' to the Single value 17834.19.
    //    Converted the Double value '1.79769313486232E+308' to the Single value Infinity.
    // </Snippet4>

let convertInt16 () =
    // <Snippet5>
    let numbers = 
        [| Int16.MinValue; -1032s; 0s; 192s; Int16.MaxValue |]

    for number in numbers do
        let result = Convert.ToSingle number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the Int16 value '-32768' to the Single value -32768.
    //    Converted the Int16 value '-1032' to the Single value -1032.
    //    Converted the Int16 value '0' to the Single value 0.
    //    Converted the Int16 value '192' to the Single value 192.
    //    Converted the Int16 value '32767' to the Single value 32767.
    // </Snippet5>

let convertInt32 () =
    // <Snippet6>
    let numbers = 
        [| Int32.MinValue; -1000; 0; 1000; Int32.MaxValue |]

    for number in numbers do
        let result = Convert.ToSingle number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the Int32 value '-2147483648' to the Single value -2.147484E+09.
    //    Converted the Int32 value '-1000' to the Single value -1000.
    //    Converted the Int32 value '0' to the Single value 0.
    //    Converted the Int32 value '1000' to the Single value 1000.
    //    Converted the Int32 value '2147483647' to the Single value 2.147484E+09.
    // </Snippet6>

let convertInt64 () =
    // <Snippet7>
    let numbers = 
        [| Int64.MinValue; -903; 0; 172; Int64.MaxValue |]

    for number in numbers do
        let result = Convert.ToSingle number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the Int64 value '-9223372036854775808' to the Single value -9.223372E+18.
    //    Converted the Int64 value '-903' to the Single value -903.
    //    Converted the Int64 value '0' to the Single value 0.
    //    Converted the Int64 value '172' to the Single value 172.
    //    Converted the Int64 value '9223372036854775807' to the Single value 9.223372E+18.
    // </Snippet7>

let convertObject () =
    // <Snippet8>
    let values: obj[] =
        [| true; 'a'; 123; 1.764e32; "9.78"; "1e-02"; 1.67e03; "A100"; "1,033.67"; DateTime.Now; Decimal.MaxValue |]

    for value in values do
        try
            let result = Convert.ToSingle value            
            printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
        with
        | :? FormatException ->
            printfn $"The {value.GetType().Name} value {value} is not recognized as a valid Single value."
        | :? OverflowException ->
            printfn $"The {value.GetType().Name} value {value} is outside the range of the Single type."
        | :? InvalidCastException ->
            printfn $"Conversion of the {value.GetType().Name} value {value} to a Single is not supported."
    // The example displays the following output:
    //    Converted the Boolean value 'True' to the Single value 1.
    //    Conversion of the Char value a to a Single is not supported.
    //    Converted the Int32 value '123' to the Single value 123.
    //    Converted the Double value '1.764E+32' to the Single value 1.764E+32.
    //    Converted the String value '9.78' to the Single value 9.78.
    //    Converted the String value '1e-02' to the Single value 0.01.
    //    Converted the Double value '1670' to the Single value 1670.
    //    The String value A100 is not recognized as a valid Single value.
    //    Converted the String value '1,033.67' to the Single value 1033.67.
    //    Conversion of the DateTime value 11/7/2008 08:02:35 AM to a Single is not supported.
    //    Converted the Decimal value '79228162514264337593543950335' to the Single value 7.922816E+28.
    // </Snippet8>

let convertSByte () =
    // <Snippet9>
    let numbers = [| SByte.MinValue; -23y; 0y; 17y; SByte.MaxValue |]

    for number in numbers do
        let result = Convert.ToSingle number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the SByte value '-128' to the Single value -128.
    //    Converted the SByte value '-23' to the Single value -23.
    //    Converted the SByte value '0' to the Single value 0.
    //    Converted the SByte value '17' to the Single value 17.
    //    Converted the SByte value '127' to the Single value 127.
    // </Snippet9>

let convertString () =
    // <Snippet10>
    let values =
        [| "-1,035.77219"; "1AFF"; "1e-35"; "1.63f"; "1,635,592,999,999,999,999,999,999"
           "-17.455"; "190.34001"; "1.29e325" |]

    for value in values do
        try
            let result = Convert.ToSingle value
            printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
        with
        | :? FormatException ->
            printfn $"Unable to convert '{value}' to a Single."
        | :? OverflowException ->
            printfn $"'{value}' is outside the range of a Single."
    // The example displays the following output:
    //    Converted the String value '-1,035.77219' to the Single value -1035.772.
    //    Unable to convert '1AFF' to a Single.
    //    Converted the String value '1e-35' to the Single value 1E-35.
    //    Unable to convert '1.63f' to a Single.
    //    Converted the String value '1,635,592,999,999,999,999,999,999' to the Single value 1.635593E+24.
    //    Converted the String value '-17.455' to the Single value -17.455.
    //    Converted the String value '190.34001' to the Single value 190.34.
    //    1.29e325' is outside the range of a Single.
    // </Snippet10>

let convertUInt16 () =
    // <Snippet11>
    let numbers = [| UInt16.MinValue; 121us; 12345us; UInt16.MaxValue |]

    for number in numbers do
        let result = Convert.ToSingle number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the UInt16 value '0' to the Single value 0.
    //    Converted the UInt16 value '121' to the Single value 121.
    //    Converted the UInt16 value '12345' to the Single value 12345.
    //    Converted the UInt16 value '65535' to the Single value 65535.
    // </Snippet11>

let convertUInt32 () =
    // <Snippet12>
    let numbers = [| UInt32.MinValue; 121u; 12345u; UInt32.MaxValue |]

    for number in numbers do
        let result = Convert.ToSingle number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the UInt32 value '0' to the Single value 0.
    //    Converted the UInt32 value '121' to the Single value 121.
    //    Converted the UInt32 value '12345' to the Single value 12345.
    //    Converted the UInt32 value '4294967295' to the Single value 4.294967E+09.
    // </Snippet12>

let convertUInt64 () =
    // <Snippet13>
    let numbers = [| UInt64.MinValue; 121uL; 12345uL; UInt64.MaxValue |]

    for number in numbers do
        let result = Convert.ToSingle number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the UInt64 value '0' to the Single value 0.
    //    Converted the UInt64 value '121' to the Single value 121.
    //    Converted the UInt64 value '12345' to the Single value 12345.
    //    Converted the UInt64 value '18446744073709551615' to the Single value 1.844674E+19.
    // </Snippet13>

convertBoolean()
printfn "-----"
convertByte ()
printfn "-----"
convertDecimal ()
printfn "-----"
convertDouble ()
printfn "-----"
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
convertString ()
printfn "----"
convertUInt16 ()
printfn "-----"
convertUInt32 ()
printfn "------"
convertUInt64 ()
