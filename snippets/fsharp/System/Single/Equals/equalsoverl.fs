module equalsoverl

// <Snippet2>
let value = 112f

let testObjectForEquality (obj: obj) =
    printfn $"{value} ({value.GetType().Name}) = {obj} ({obj.GetType().Name}): {value.Equals obj}\n"

[<EntryPoint>]
let main _ =
    let byte1= 112uy
    printfn $"value = byte1: {value.Equals byte1,16}"
    testObjectForEquality byte1

    let short1 = 112s
    printfn $"value = short1: {value.Equals short1,16}"
    testObjectForEquality short1

    let int1 = 112
    printfn $"value = int1: {value.Equals int1,18}"
    testObjectForEquality int1

    let long1 = 112L
    printfn $"value = long1: {value.Equals long1,17}"
    testObjectForEquality long1
    
    let sbyte1 = 112y
    printfn $"value = sbyte1: {value.Equals sbyte1,16}"
    testObjectForEquality sbyte1

    let ushort1 = 112us
    printfn $"value = ushort1: {value.Equals ushort1,16}"
    testObjectForEquality ushort1

    let uint1 = 112u
    printfn $"value = uint1: {value.Equals uint1,18}"
    testObjectForEquality uint1

    let ulong1 = 112uL
    printfn $"value = ulong1: {value.Equals ulong1,17}"
    testObjectForEquality ulong1
    
    let dec1 = 112m
    printfn $"value = dec1: {value.Equals dec1,21}"
    testObjectForEquality dec1

    let dbl1 = 112.
    printfn $"value = dbl1: {value.Equals dbl1,20}"
    testObjectForEquality dbl1
    0

// The example displays the following output:
//       value = byte1:             True
//       112 (Single) = 112 (Byte): False
//
//       value = short1:             True
//       112 (Single) = 112 (Int16): False
//
//       value = int1:               True
//       112 (Single) = 112 (Int32): False
//
//       value = long1:              True
//       112 (Single) = 112 (Int64): False
//
//       value = sbyte1:             True
//       112 (Single) = 112 (SByte): False
//
//       value = ushort1:             True
//       112 (Single) = 112 (UInt16): False
//
//       value = uint1:               True
//       112 (Single) = 112 (UInt32): False
//
//       value = ulong1:              True
//       112 (Single) = 112 (UInt64): False
//
//       value = dec1:                 False
//       112 (Single) = 112 (Decimal): False
//
//       value = dbl1:                False
//       112 (Single) = 112 (Double): False
// </Snippet2>