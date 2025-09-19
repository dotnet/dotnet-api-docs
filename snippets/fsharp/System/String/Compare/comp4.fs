module comp4

//<snippet1>
open System

let str1 = "MACHINE"
let str2 = "machine"

printfn $"\nstr1 = '{str1}', str2 = '{str2}'"

printfn "Ignore case:"
let result = String.Compare(str1, 2, str2, 2, 2, true)
let str = 
    if result < 0 then "less than" 
    elif result > 0 then "greater than"
    else "equal to"

printf $"Substring '{str1.Substring(2, 2)}' in '{str1}' is "
printf $"{str} "
printfn $"substring '{str2.Substring(2, 2)}' in '{str2}'.\n"

printfn "Honor case:"
let result2 = String.Compare(str1, 2, str2, 2, 2, false)
let str3 = 
    if result < 0 then "less than" 
    elif result > 0 then "greater than" 
    else "equal to"

printfn $"Substring '{str1.Substring(2, 2)}' in '{str1}' is "
printf $"{str3} "
printfn $"substring '{str2.Substring(2, 2)}' in '{str2}'."

(*
This example produces the following results:

str1 = 'MACHINE', str2 = 'machine'
Ignore case:
Substring 'CH' in 'MACHINE' is equal to substring 'ch' in 'machine'.

Honor case:
Substring 'CH' in 'MACHINE' is greater than substring 'ch' in 'machine'.
*)
//</snippet1>