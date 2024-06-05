//<snippet1>
let byteVal1 = 0x7fuy
let byteVal2 = 127uy
let objectVal3: obj = byteVal2

printfn $"byteVal1 = {byteVal1}, byteVal2 = {byteVal2}, objectVal3 = {objectVal3}\n"
printfn $"byteVal1 equals byteVal2?: {byteVal1.Equals byteVal2}"
printfn $"byteVal1 equals objectVal3?: {byteVal1.Equals objectVal3}"

// This code example produces the following results:
//
// byteVal1 = 127, byteVal2 = 127, objectVal3 = 127
//
// byteVal1 equals byteVal2?: True
// byteVal1 equals objectVal3?: True
//</snippet1>