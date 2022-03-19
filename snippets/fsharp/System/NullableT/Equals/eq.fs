//<snippet1>
// This code example demonstrates the Nullable<T>.Equals
// methods.
open System

let nullInt1 = Nullable 100
let nullInt2 = Nullable 200

// Determine if two nullable of System.Int32 values are equal.
// The nullable objects have different values.
printf "1) nullInt1 and nullInt2 "
if nullInt1.Equals nullInt1 then
    printf "are"
else
    printf "are not"
printfn " equal."

// Determine if a nullable of System.Int32 and an object
// are equal. The object contains the boxed value of the
// nullable object.

let myObj = box nullInt1
printf "2) nullInt1 and myObj "
if nullInt1.Equals myObj then
    printf "are"
else
    printf "are not"
printfn " equal."

// This code example produces the following results:
//     1) nullInt1 and nullInt2 are not equal.
//     2) nullInt1 and myObj are equal.
//</snippet1>