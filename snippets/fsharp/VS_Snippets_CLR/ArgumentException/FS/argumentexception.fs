module argumentexception
// Types:System.ArgumentException
//<snippet1>
open System

//<snippet2>
let divideByTwo num =
    // If num is an odd number, raise an ArgumentException.
    if num % 2 = 1 then
        raise (ArgumentException("num", "Number must be even"))

    // num is even, return half of its value.
    num / 2;
//</snippet2>

// ArgumentException is not thrown because 10 is an even number.
printfn $"10 divided by 2 is {divideByTwo 10}"
try
    // ArgumentException is thrown because 7 is not an even number.
    printfn $"7 divided by 2 is {divideByTwo 7}"
        
with 
| :? ArgumentException ->
    // Show the user that 7 cannot be divided by 2.
    printfn "7 is not divided by 2 integrally."
        
// This code produces the following output.
//
// 10 divided by 2 is 5
// 7 is not divided by 2 integrally.
//</snippet1>