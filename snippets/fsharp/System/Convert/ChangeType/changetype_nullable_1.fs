module changetype_nullable_1

// <Snippet8>
open System

let intValue1 = Nullable 12893
let dValue1 = Convert.ChangeType(intValue1, typeof<Double>, null) :?> double
printfn $"{intValue1} ({intValue1.GetType().Name})--> {dValue1} ({dValue1.GetType().Name})"

let fValue1 = 16.3478f
let intValue2 = Nullable(int fValue1)
printfn $"{fValue1} ({fValue1.GetType().Name})--> {intValue2} ({intValue2.GetType().Name})"

// The example displays the following output:
//    12893 (Int32)--> 12893 (Double)
//    16.3478 (Single)--> 16 (Int32)
// </Snippet8>