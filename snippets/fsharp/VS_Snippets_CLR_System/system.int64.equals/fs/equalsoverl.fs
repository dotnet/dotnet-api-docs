// <Snippet1>
let value = 112

let testObjectForEquality (obj: obj) =
    printfn $"{value} ({value.GetType().Name}) = {obj} ({obj.GetType().Name}): {value.Equals obj}\n"

let byte1 = 112uy
printfn $"value = byte1: {value.Equals(int byte1),15}"
testObjectForEquality byte1

let short1 = 112s
printfn $"value = short1: {value.Equals(int short1),15}"
testObjectForEquality short1

let int1 = 112
printfn $"value = int1: {value.Equals(int int1),17}"
testObjectForEquality int1

let sbyte1 = 112y
printfn $"value = sbyte1: {value.Equals(int sbyte1),15}"
testObjectForEquality sbyte1

let ushort1 = 112us
printfn $"value = ushort1: {value.Equals(int ushort1),15}"
testObjectForEquality ushort1

let uint1 = 112u
printfn $"value = uint1: {value.Equals(int uint1),17}"
testObjectForEquality uint1

let dec1 = 112M
printfn $"value = dec1: {value.Equals(int dec1),20}"
testObjectForEquality dec1

let dbl1 = 112.0
printfn $"value = dbl1: {value.Equals(int dbl1),19}"
testObjectForEquality dbl1


// The example displays the following output:
//       value = byte1:            True
//       112 (Int64) = 112 (Byte): False
//
//       value = short1:            True
//       112 (Int64) = 112 (Int16): False
//
//       value = int1:              True
//       112 (Int64) = 112 (Int32): False
//
//       value = sbyte1:            True
//       112 (Int64) = 112 (SByte): False
//
//       value = ushort1:            True
//       112 (Int64) = 112 (UInt16): False
//
//       value = uint1:              True
//       112 (Int64) = 112 (UInt32): False
//
//       value = dec1:                False
//       112 (Int64) = 112 (Decimal): False
//
//       value = dbl1:               False
//       112 (Int64) = 112 (Double): False
// </Snippet1>
