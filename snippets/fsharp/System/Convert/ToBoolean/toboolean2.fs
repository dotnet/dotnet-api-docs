module toboolean2

open System

let convertByte () =
    // <Snippet12>
    let bytes = [| Byte.MinValue; 100uy; 200uy; Byte.MaxValue |]

    for byteValue in bytes do
        let result = Convert.ToBoolean byteValue
        printfn $"{byteValue,-5}  -->  {result}"
    // The example displays the following output:
    //       0      -->  False
    //       100    -->  True
    //       200    -->  True
    //       255    -->  True
    // </Snippet12>

let convertDecimal () =
    // <Snippet2>
    let numbers = 
        [| Decimal.MinValue; -12034.87m; -100m; 0m
           300m; 6790823.45m; Decimal.MaxValue |]

    for number in numbers do
        let result = Convert.ToBoolean number
        printfn $"{number,-30}  -->  {result}"
    // The example displays the following output:
    //       -79228162514264337593543950335  -->  True
    //       -12034.87                       -->  True
    //       -100                            -->  True
    //       0                               -->  False
    //       300                             -->  True
    //       6790823.45                      -->  True
    //       79228162514264337593543950335   -->  True
    // </Snippet2>

let convertInt16 () =
    // <Snippet3>
    let numbers = 
        [| Int16.MinValue; -10000s; -154s; 0s
           216s; 21453s; Int16.MaxValue |]

    for number in numbers do
        let result = Convert.ToBoolean number
        printfn $"{number,-7:N0}  -->  {result}"
    // The example displays the following output:
    //       -32,768  -->  True
    //       -10,000  -->  True
    //       -154     -->  True
    //       0        -->  False
    //       216      -->  True
    //       21,453   -->  True
    //       32,767   -->  True
    // </Snippet3>

let convertInt32 () =
    // <Snippet4>
    let numbers = 
        [| Int32.MinValue; -201649; -68; 0
           612; 4038907; Int32.MaxValue |]

    for number in numbers do
        let result = Convert.ToBoolean number
        printfn $"{number,-15:N0}  -->  {result}"
    // The example displays the following output:
    //       -2,147,483,648   -->  True
    //       -201,649         -->  True
    //       -68              -->  True
    //       0                -->  False
    //       612              -->  True
    //       4,038,907        -->  True
    //       2,147,483,647    -->  True
    // </Snippet4>

let convertInt64 () =
    // <Snippet5>
    let numbers =
        [| Int64.MinValue; -2016493; -689
           0; 6121; 403890774; Int64.MaxValue |]

    for number in numbers do
        let result = Convert.ToBoolean number
        printfn $"{number,-26:N0}  -->  {result}"
    // The example displays the following output:
    //       -9,223,372,036,854,775,808  -->  True
    //       -2,016,493                  -->  True
    //       -689                        -->  True
    //       0                           -->  False
    //       6,121                       -->  True
    //       403,890,774                 -->  True
    //       9,223,372,036,854,775,807   -->  True
    // </Snippet5>

let convertSByte () =
    // <Snippet6>
    let numbers = 
        [| SByte.MinValue; -1y; 0y
           10y; 100y; SByte.MaxValue |]

    for number in numbers do
        let result = Convert.ToBoolean number
        printfn $"{number,-5}  -->  {result}"
    // The example displays the following output:
    //       -128   -->  True
    //       -1     -->  True
    //       0      -->  False
    //       10     -->  True
    //       100    -->  True
    //       127    -->  True
    // </Snippet6>

let convertSingle () =
    // <Snippet7>
    let numbers = 
        [| Single.MinValue; -193.0012f; 20e-15f; 0f
           10551e-10f; 100.3398f; Single.MaxValue |]

    for number in numbers do
        let result = Convert.ToBoolean number
        printfn $"{number,-15}  -->  {result}"
    // The example displays the following output:
    //       -3.402823E+38    -->  True
    //       -193.0012        -->  True
    //       2E-14            -->  True
    //       0                -->  False
    //       1.0551E-06       -->  True
    //       100.3398         -->  True
    //       3.402823E+38     -->  True
    // </Snippet7>

let convertUInt16 () =
    // <Snippet8>
    let numbers = 
        [| UInt16.MinValue; 216us; 21453us; UInt16.MaxValue |]

    for number in numbers do
        let result = Convert.ToBoolean number
        printfn $"{number,-7:N0}  -->  {result}"
    // The example displays the following output:
    //       0        -->  False
    //       216      -->  True
    //       21,453   -->  True
    //       65,535   -->  True
    // </Snippet8>

let convertUInt32 () =
    // <Snippet9>
    let numbers =
        [| UInt32.MinValue; 612u; 4038907u; uint Int32.MaxValue |]

    for number in numbers do
        let result = Convert.ToBoolean number
        printfn $"{number,-15:N0}  -->  {result}"
    // The example displays the following output:
    //       0                -->  False
    //       612              -->  True
    //       4,038,907        -->  True
    //       2,147,483,647    -->  True
    // </Snippet9>

let convertUInt64 () =
    // <Snippet10>
    let numbers = 
        [| UInt64.MinValue; 6121uL; 403890774uL; UInt64.MaxValue |]

    for number in numbers do
        let result = Convert.ToBoolean number
        printfn $"{number,-26:N0}  -->  {result}"
    // The example displays the following output:
    //       0                           -->  False
    //       6,121                       -->  True
    //       403,890,774                 -->  True
    //       18,446,744,073,709,551,615  -->  True
    // </Snippet10>

let convertObject () =
    // <Snippet11>
    let objects: obj[] =
        [| 16.33; -24; 0; "12"; "12.7"; String.Empty
           "1String"; "True"; "false"; null
           System.Collections.ArrayList() |]

    for obj in objects do
        printf $"""{(if obj <> null then $"{obj} ({obj.GetType().Name})" else "null"),-40}  -->  """
        try
            Console.WriteLine("{0}", Convert.ToBoolean(obj))
        with
        | :? FormatException ->
            printfn "Bad Format"
        | :? InvalidCastException ->
            printfn "No Conversion"
    // The example displays the following output:
    //       16.33 (Double)                            -->  True
    //       -24 (Int32)                               -->  True
    //       0 (Int32)                                 -->  False
    //       12 (String)                               -->  Bad Format
    //       12.7 (String)                             -->  Bad Format
    //        (String)                                 -->  Bad Format
    //       1String (String)                          -->  Bad Format
    //       True (String)                             -->  True
    //       false (String)                            -->  False
    //       null                                      -->  False
    //       System.Collections.ArrayList (ArrayList)  -->  No Conversion
    // </Snippet11>


convertByte ()
printfn "-----"
convertDecimal ()
printfn "-----"
convertInt16 ()
printfn "-----"
convertInt32 ()
printfn "-----"
convertInt64 ()
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
printfn "-----"
convertObject ()