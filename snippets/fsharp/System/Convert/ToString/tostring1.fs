module tostring1

open System

let convertDateTime () =
    // <Snippet1>
    let dates =
        [| DateTime(2009, 7, 14)
           DateTime(1, 1, 1, 18, 32, 0)
           DateTime(2009, 2, 12, 7, 16, 0) |]

    for dateValue in dates do
        let result = Convert.ToString dateValue
        printfn $"Converted the {dateValue.GetType().Name} value {dateValue} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the DateTime value 7/14/2009 12:00:00 AM to a String value 7/14/2009 12:00:00 AM.
    //    Converted the DateTime value 1/1/0001 06:32:00 PM to a String value 1/1/0001 06:32:00 PM.
    //    Converted the DateTime value 2/12/2009 07:16:00 AM to a String value 2/12/2009 07:16:00 AM.
    // </Snippet1>

let convertInt16 () =
    // <Snippet2>
    let numbers = [| Int16.MinValue; -138s; 0s; 19s; Int16.MaxValue |]

    for number in numbers do
        let result = Convert.ToString number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the Int16 value -32768 to the String value -32768.
    //    Converted the Int16 value -138 to the String value -138.
    //    Converted the Int16 value 0 to the String value 0.
    //    Converted the Int16 value 19 to the String value 19.
    //    Converted the Int16 value 32767 to the String value 32767.
    // </Snippet2>

let convertObject () =
    // <Snippet3>
    let values: obj[] =
        [| false; 12.63m; DateTime(2009, 6, 1, 6, 32, 15)
           16.09e-12; 'Z'; 15.15322; SByte.MinValue; Int32.MaxValue |]

    for value in values do
        let result = Convert.ToString value
        printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the Boolean value False to the String value False.
    //    Converted the Decimal value 12.63 to the String value 12.63.
    //    Converted the DateTime value 6/1/2009 06:32:15 AM to the String value 6/1/2009 06:32:15 AM.
    //    Converted the Double value 1.609E-11 to the String value 1.609E-11.
    //    Converted the Char value Z to the String value Z.
    //    Converted the Double value 15.15322 to the String value 15.15322.
    //    Converted the SByte value -128 to the String value -128.
    //    Converted the Int32 value 2147483647 to the String value 2147483647.
    // </Snippet3>

let convertSByte () =
    // <Snippet4>
    let numbers = [| SByte.MinValue; -12y; 0y; 16y; SByte.MaxValue |]

    for number in numbers do
        let result = Convert.ToString number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the SByte value -128 to the String value -128.
    //    Converted the SByte value -12 to the String value -12.
    //    Converted the SByte value 0 to the String value 0.
    //    Converted the SByte value 16 to the String value 16.
    //    Converted the SByte value 127 to the String value 127.
    // </Snippet4>

let convertSingle () =
    // <Snippet5>
    let numbers = 
        [| Single.MinValue; -1011.351f; -17.45f; -3e-16f; 0f; 4.56e-12f; 16.0001f; 10345.1221f; Single.MaxValue |]

    for number in numbers do
        let result = Convert.ToString number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the Single value -3.402823E+38 to the String value -3.402823E+38.
    //    Converted the Single value -1011.351 to the String value -1011.351.
    //    Converted the Single value -17.45 to the String value -17.45.
    //    Converted the Single value -3E-16 to the String value -3E-16.
    //    Converted the Single value 0 to the String value 0.
    //    Converted the Single value 4.56E-12 to the String value 4.56E-12.
    //    Converted the Single value 16.0001 to the String value 16.0001.
    //    Converted the Single value 10345.12 to the String value 10345.12.
    //    Converted the Single value 3.402823E+38 to the String value 3.402823E+38.
    // </Snippet5>

let convertUInt16 () =
    // <Snippet6>
    let numbers = [| UInt16.MinValue; 103us; 1045us; UInt16.MaxValue |]

    for number in numbers do
        let result = Convert.ToString number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the UInt16 value 0 to the String value 0.
    //    Converted the UInt16 value 103 to the String value 103.
    //    Converted the UInt16 value 1045 to the String value 1045.
    //    Converted the UInt16 value 65535 to the String value 65535.
    // </Snippet6>

let convertUInt32 () =
    // <Snippet7>
    let numbers = [| UInt32.MinValue; 103u; 1045u; 119543u; UInt32.MaxValue |]

    for number in numbers do
        let result = Convert.ToString number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the UInt32 value 0 to the String value 0.
    //    Converted the UInt32 value 103 to the String value 103.
    //    Converted the UInt32 value 1045 to the String value 1045.
    //    Converted the UInt32 value 119543 to the String value 119543.
    //    Converted the UInt32 value 4294967295 to the String value 4294967295.
    // </Snippet7>

let convertUInt64 () =
    // <Snippet8>
    let numbers = [| UInt64.MinValue; 1031uL; 189045uL; UInt64.MaxValue |]

    for number in numbers do
        let result = Convert.ToString number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
    // The example displays the following output:
    //    Converted the UInt64 value 0 to the String value 0.
    //    Converted the UInt64 value 1031 to the String value 1031.
    //    Converted the UInt64 value 189045 to the String value 189045.
    //    Converted the UInt64 value 18446744073709551615 to the String value 18446744073709551615.
    // </Snippet8>

convertDateTime ()
printfn "-----" 
convertInt16 ()
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
