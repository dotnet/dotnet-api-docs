// This sample opens a file whose name is passed to it as a parameter.
// It reads each line in the file and replaces every occurrence of 4
// space characters with a tab character.
//
// It takes two command-line arguments: the input file name, and
// the output file name.
//
// Usage:
//
//   INSERTTABS inputfile.txt outputfile.txt
//
// <Snippet1>
open System
open System.IO

let tabSize = 4
let usageText = "Usage: INSERTTABS inputfile.txt outputfile.txt"

[<EntryPoint>]
let main args =
    if args.Length < 2 then
        Console.WriteLine usageText
        1
    else
        try
            // Attempt to open output file.
            use reader = new StreamReader(args[0])
            use writer = new StreamWriter(args[1])
            
            // Redirect standard output from the console to the output file.
            Console.SetOut writer
            
            // Redirect standard input from the console to the input file.
            Console.SetIn reader
            
            let mutable line = Console.ReadLine()
            while line <> null do
                let newLine = line.Replace(("").PadRight(tabSize, ' '), "\t")
                Console.WriteLine newLine
                line <- Console.ReadLine()

            // Recover the standard output stream so that a
            // completion message can be displayed.
            let standardOutput = new StreamWriter(Console.OpenStandardOutput())
            standardOutput.AutoFlush <- true
            Console.SetOut standardOutput
            Console.WriteLine $"INSERTTABS has completed the processing of {args[0]}."
            0

        with :? IOException as e -> 
            let errorWriter = Console.Error
            errorWriter.WriteLine e.Message
            errorWriter.WriteLine usageText
            1
// </Snippet1>