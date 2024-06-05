module tocharray1

//<snippet1>
// Sample for String.ToCharArray(Int32, Int32)
let str = "012wxyz789"

let arr = str.ToCharArray(3, 4)
printf $"The letters in '{str}' are: '"
printf $"{arr}"
printfn "'"
printfn $"Each letter in '{str}' is:"
for c in arr do
    printfn $"{c}"
(*
This example produces the following results:
The letters in '012wxyz789' are: 'wxyz'
Each letter in '012wxyz789' is:
w
x
y
z
*)
//</snippet1>