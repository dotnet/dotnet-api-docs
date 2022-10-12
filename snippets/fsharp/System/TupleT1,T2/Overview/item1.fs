module item1

// <Snippet1>
open System

let integerDivide (dividend: int) divisor =
    try
        let quotient, remainder = Math.DivRem(dividend, divisor)
        Tuple<int, int>(quotient, remainder)
    with :? DivideByZeroException ->
        Unchecked.defaultof<Tuple<int, int>>

[<EntryPoint>]
let main _ =
    let dividend = 136945 
    let divisor = 178
    let result = integerDivide dividend divisor
    if box result <> null then
        printfn $@"{dividend} \ {divisor} = {result.Item1}, remainder {result.Item2}" 
    else
        printfn $@"{dividend} \ {divisor} = <Error>"
                    
    let dividend = Int32.MaxValue 
    let divisor = -2073
    let result = integerDivide dividend divisor
    if box result <> null then
        printfn $@"{dividend} \ {divisor} = {result.Item1}, remainder {result.Item2}" 
    else
        printfn $@"{dividend} \ {divisor} = <Error>"
    0
// The example displays the following output:
//       136945 \ 178 = 769, remainder 63
//       2147483647 \ -2073 = -1035930, remainder 757
// </Snippet1>