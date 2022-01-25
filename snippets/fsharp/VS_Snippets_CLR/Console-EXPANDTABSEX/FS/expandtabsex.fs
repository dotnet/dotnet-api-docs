// <Snippet1>
open System
open System.IO

let tabSize = 4
let usageText = "Usage: EXPANDTABSEX inputfile.txt outputfile.txt"

[<EntryPoint>]
let main args =
    if args.Length < 2 then
        printfn $"{usageText}"
    else 
        try
            use writer = new StreamWriter(args[1])
            Console.SetOut writer
            Console.SetIn(new StreamReader(args[0]))
            let mutable i = Console.Read()
            while i <> -1 do
                let c = char i
                if c = '\t' then
                    Console.WriteLine(("").PadRight(tabSize, ' '))
                else
                    printf $"{c}"
                i <- Console.Read()
            // Recover the standard output stream so that a
            // completion message can be displayed.
            use standardOutput = new StreamWriter(Console.OpenStandardOutput())
            standardOutput.AutoFlush <- true
            Console.SetOut standardOutput
            printfn $"EXPANDTABSEX has completed the processing of {args[0]}."
        with :? IOException as e ->
            let errorWriter = Console.Error
            errorWriter.WriteLine e.Message
            errorWriter.WriteLine usageText
    0

// </Snippet1>