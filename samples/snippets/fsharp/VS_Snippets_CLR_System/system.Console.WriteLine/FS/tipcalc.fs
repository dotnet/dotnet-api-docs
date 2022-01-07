module tipcalc

// <Snippet1>
open System

let tipRate = 0.18

let args = Environment.GetCommandLineArgs()[1..] 

if args.Length = 0 then 
    Console.WriteLine "usage: TIPCALC total"
else
    match Double.TryParse args[0] with
    | true, billTotal ->
        let tip = billTotal * tipRate
        Console.WriteLine()
        Console.WriteLine $"Bill total:\t{billTotal,8:c}" 
        Console.WriteLine $"Tip total/rate:\t{tip,8:c} ({tipRate:p1})"
        Console.WriteLine("".PadRight(24, '-'))
        Console.WriteLine $"Grand total:\t{billTotal + tip,8:c}" 
    | _ ->
        Console.WriteLine "usage: TIPCALC total"

// >tipcalc 52.23
//
// Bill total:       $52.23
// Tip total/rate:    $9.40 (18.0 %)
// ------------------------
// Grand total:      $61.63
// </Snippet1>