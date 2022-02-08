//<snippet1>
// This example demonstrates the Console.Beep() method.
open System

[<EntryPoint>]
let main args =
    if args.Length = 1 then
        match Int32.TryParse args[0] with
        | true, x when x >= 1 && x <= 9 ->
            for i = 1 to x do
                Console.WriteLine $"Beep number {i}."
                Console.Beep()
        | _ ->
            Console.WriteLine "Usage: Enter the number of times (between 1 and 9) to beep." 
    else
        Console.WriteLine "Usage: Enter the number of times (between 1 and 9) to beep."

    0

// This example produces the following results:

// >beep
// Usage: Enter the number of times (between 1 and 9) to beep

// >beep 9
// Beep number 1.
// Beep number 2.
// Beep number 3.
// Beep number 4.
// Beep number 5.
// Beep number 6.
// Beep number 7.
// Beep number 8.
// Beep number 9.
//</snippet1>