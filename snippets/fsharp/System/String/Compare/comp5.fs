module comp5

//<snippet1>
// Sample for String.Compare(String, Int32, String, Int32, Int32, Boolean, CultureInfo)
open System
open System.Globalization

//                 0123456
let str1 = "MACHINE"
let str2 = "machine"

printfn $"\nstr1 = '{str1}', str2 = '{str2}'"
printfn "Ignore case, Turkish culture:"
let result = String.Compare(str1, 4, str2, 4, 2, true, CultureInfo "tr-TR")
let str = if result < 0 then "less than" elif result > 0 then "greater than" else "equal to"
printf $"Substring '{str1.Substring(4, 2)}' in '{str1}' is "
printf $"{str} "
printfn $"substring '{str2.Substring(4, 2)}' in '{str2}'."

printfn "\nIgnore case, invariant culture:"
let result2 = String.Compare(str1, 4, str2, 4, 2, true, CultureInfo.InvariantCulture)
let str3 = if result < 0 then "less than" elif result > 0 then "greater than" else "equal to"
printf $"Substring '{str1.Substring(4, 2)}' in '{str1}' is "
printf $"{str3} "
printfn $"substring '{str2.Substring(4, 2)}' in '{str2}'."

(*
This example produces the following results:

str1 = 'MACHINE', str2 = 'machine'
Ignore case, Turkish culture:
Substring 'IN' in 'MACHINE' is less than substring 'in' in 'machine'.

Ignore case, invariant culture:
Substring 'IN' in 'MACHINE' is equal to substring 'in' in 'machine'.
*)
//</snippet1>