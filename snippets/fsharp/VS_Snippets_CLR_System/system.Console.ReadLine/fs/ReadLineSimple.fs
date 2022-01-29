module ReadLineSimple

// <Snippet6>
open System

Console.Clear()

let dat = DateTime.Now

printfn $"\nToday is {dat:d} at {dat:T}." 
printf "\nPress any key to continue... "
Console.ReadLine() |> ignore

// The example displays output like the following:
//     Today is 12/28/2021 at 8:23:50 PM.
//
//     Press any key to continue...

// </Snippet6>