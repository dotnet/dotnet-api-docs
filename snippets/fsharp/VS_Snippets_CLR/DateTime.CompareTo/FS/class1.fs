// <Snippet1>
open System

let theDay = DateTime(DateTime.Today.Year, 7, 28)

try
    let compareValue = theDay.CompareTo DateTime.Today

    if compareValue < 0 then
        printfn $"{theDay:d} is in the past."
    elif compareValue = 0 then
        printfn $"{theDay:d} is today!"
    else // compareValue > 0
        printfn $"{theDay:d} has not come yet."
        
with :? ArgumentException ->
    Console.WriteLine("Value is not a DateTime");

// </Snippet1>