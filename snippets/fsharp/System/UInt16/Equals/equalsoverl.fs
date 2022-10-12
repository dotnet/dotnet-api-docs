module equalsoverl

// <Snippet1>
let value = 112us

let testObjectForEquality (obj: obj) =
    printfn $"{value} ({value.GetType().Name}) = {obj} ({obj.GetType().Name}): {value.Equals obj}\n"

let byte1= 112uy
printfn $"value = byte1: {value.Equals byte1,16}"
testObjectForEquality byte1

let short1 = 112s
printfn $"value = short1: {value.Equals short1,17}"
testObjectForEquality short1

let int1 = 112
printfn $"value = int1: {value.Equals int1,19}"
testObjectForEquality int1

let sbyte1 = 112y
printfn $"value = sbyte1: {value.Equals sbyte1,17}"
testObjectForEquality sbyte1

let dec1 = 112m
printfn $"value = dec1: {value.Equals dec1,21}"
testObjectForEquality dec1

let dbl1 = 112.
printfn $"value = dbl1: {value.Equals dbl1,20}"
testObjectForEquality dbl1

// The example displays the following output:
//       value = byte1:             True
//       112 (UInt16) = 112 (Byte): False
//
//       value = short1:             False
//       112 (UInt16) = 112 (Int16): False
//
//       value = int1:               False
//       112 (UInt16) = 112 (Int32): False
//
//       value = sbyte1:             False
//       112 (UInt16) = 112 (SByte): False
//
//       value = dec1:                 False
//       112 (UInt16) = 112 (Decimal): False
//
//       value = dbl1:                False
//       112 (UInt16) = 112 (Double): False
// </Snippet1>