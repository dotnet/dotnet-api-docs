let complexFromByte () =

    // <Snippet1>
    let byteValue = 122
    let c1: System.Numerics.Complex = byteValue
    printfn $"{c1}"
    // The example displays the following output:
    //       (122, 0)
    // </Snippet1>

let complexFromDouble () =

    // <Snippet2>
    let doubleValue = 1.032e-16
    let c1: System.Numerics.Complex = doubleValue
    printfn $"{c1}"
    // The example displays the following output:
    //       (1.032E-16, 0)
    // </Snippet2>

let complexFromInt16 () =

    // <Snippet3>
    let shortValue = 16024
    let c1: System.Numerics.Complex = shortValue
    printfn $"{c1}"
    // The example displays the following output:
    //       (16024, 0)
    // </Snippet3>

let complexFromInt32 () =

    // <Snippet4>
    let intValue = 1034217
    let c1: System.Numerics.Complex = intValue
    printfn $"{c1}"
    // The example displays the following output:
    //       (1034217, 0)
    // </Snippet4>

let complexFromInt64 () =

    // <Snippet5>
    let longValue = 951034217
    let c1: System.Numerics.Complex = longValue
    printfn $"{c1}"
    // The example displays the following output:
    //       (951034217, 0)
    // </Snippet5>

let complexFromSByte () =

    // <Snippet6>
    let sbyteValue = -12
    let c1: System.Numerics.Complex = sbyteValue
    printfn $"{c1}"
    // The example displays the following output:
    //       (-12, 0)
    // </Snippet6>

let complexFromSingle () =

    // <Snippet7>
    let singleValue = 1.032e-08f
    let c1: System.Numerics.Complex = singleValue
    printfn $"{c1}"
    // The example displays the following output:
    //       (1.03199999657022E-08, 0)
    // </Snippet7>

let complexFromUInt16 () =

    // <Snippet8>
    let shortValue = 421
    let c1: System.Numerics.Complex = shortValue
    printfn $"{c1}"
    // The example displays the following output:
    //       (421, 0)
    // </Snippet8>

let complexFromUInt32 () =

    // <Snippet9>
    let value = 197461
    let c1: System.Numerics.Complex = value
    printfn $"{c1}"
    // The example displays the following output:
    //       (197461, 0)
    // </Snippet9>

let complexFromUInt64 () =

    // <Snippet10>
    let longValue = 951034217
    let c1: System.Numerics.Complex = longValue
    printfn $"{c1}"
    // The example displays the following output:
    //       (951034217, 0)
    // </Snippet10>

complexFromByte ()
complexFromDouble ()
complexFromInt16 ()
complexFromInt32 ()
complexFromInt64 ()
complexFromSByte ()
complexFromSingle ()
complexFromUInt16 ()
complexFromUInt32 ()
complexFromUInt64 ()
