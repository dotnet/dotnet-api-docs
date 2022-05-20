module comp3

//<snippet1>
open System

let str1 = "machine"
let str2 = "device"

printfn "\nstr1 = '{str1}', str2 = '{str2}'"

let result = String.Compare(str1, 2, str2, 0, 2)
let str = 
    if result < 0 then "less than" 
    elif result > 0 then "greater than" 
    else "equal to"

printf $"Substring '{str1.Substring(2, 2)}' in '{str1}' is "
printf $"{str} "
printfn $"substring '{str2.Substring(0, 2)}' in '{str2}'."

(*
This example produces the following results:

str1 = 'machine', str2 = 'device'
Substring 'ch' in 'machine' is less than substring 'de' in 'device'.
*)
//</snippet1>