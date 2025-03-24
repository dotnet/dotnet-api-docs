module join2.fs
// Sample for String.Join(String, String[], int int)
//<snippet1>
open System

let vals = [| "apple"; "orange"; "grape"; "pear" |]
let sep   = ", "

printfn $"sep = '{sep}'"
printfn $"vals[] = {{'{vals[0]}' '{vals[1]}' '{vals[2]}' '{vals[3]}'}}"
let result = String.Join(sep, vals, 1, 2)
printfn $"String.Join(sep, vals, 1, 2) = '{result}'"

// This example produces the following results:
// sep = ', '
// vals[] = {'apple' 'orange' 'grape' 'pear'}
// String.Join(sep, vals, 1, 2) = 'orange, grape'
//</snippet1>
