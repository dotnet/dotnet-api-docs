open System.Numerics

let showByteConversion () =
    printfn "Implicit Byte Conversion:"
    // <Snippet1>
    let byteValue = 254uy
    let number = BigInteger(byteValue)
    let mutable number = BigInteger.Add(number, byteValue)
    printfn $"{number > byteValue}" // Displays True
    // </Snippet1>
    printfn ""

let showShortConversion () =
    printfn "Implicit Short Conversion:"
    // <Snippet2>
    let shortValue = 25064s
    let number = BigInteger(shortValue)
    let mutable number = BigInteger.Add(number, shortValue)
    printfn $"{number > shortValue}" // Displays False
    // </Snippet2>
    printfn ""


let showIntConversion () =
    printfn "Implicit Int Conversion:"
    // <Snippet3>
    let intValue = 65000
    let number = BigInteger(intValue)
    let mutable number = BigInteger.Multiply(number, intValue)
    printfn $"{number = intValue}" // Displays False
    // </Snippet3>
    printfn ""

let showLongConversion () =
    printfn "Implicit Long Conversion:"
    // <Snippet4>
    let longValue = 1358754982L
    let number = BigInteger longValue
    let mutable number = BigInteger.Add(number, longValue / 2L |> bigint)
    printfn $"{((number * bigint longValue) / (bigint longValue))}" // Displays 2038132473

    // </Snippet4>
    printfn ""

let showSByteConversion () =
    printfn "Implicit SByte Conversion:"
    // <Snippet5>
    let sByteValue = -12y
    let number = BigInteger.Pow(sByteValue, 3)
    printfn $"{number < sByteValue}" // Displays True
    // </Snippet5>
    printfn ""


let showUShortConversion () =
    printfn "Implicit UShort Conversion:"
    // <Snippet6>
    let uShortValue = 25064us
    let number = BigInteger(uShortValue)
    let mutable number = BigInteger.Add(number, uShortValue)
    printfn $"{number < uShortValue}" // Displays False
    // </Snippet6>
    printfn ""

let showUIntConversion () =
    printfn "Implicit UInt Conversion:"
    // <Snippet7>
    let uIntValue = 65000u
    let number = BigInteger(uIntValue)
    let mutable number = BigInteger.Multiply(number, uIntValue)
    printfn $"{number = uIntValue}" // Displays "False
    // </Snippet7>
    printfn ""

let showULongConversion () =
    printfn "Implicit ULong Conversion:"
    // <Snippet8>
    let uLongValue = 1358754982UL
    let number = BigInteger(uLongValue)
    let mutable number = BigInteger.Add(number, uLongValue / 2UL |> bigint)
    printfn $"{number * bigint uLongValue / bigint uLongValue}" // Displays 1358754982
    // </Snippet8>
    printfn ""

showByteConversion ()
showShortConversion ()
showIntConversion ()
showLongConversion ()
showSByteConversion ()
showUShortConversion ()
showUIntConversion ()
showULongConversion ()
