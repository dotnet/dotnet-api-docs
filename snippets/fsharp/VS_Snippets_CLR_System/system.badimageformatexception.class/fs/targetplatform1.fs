module targetplatform1

// <Snippet4>
open System
open System.IO
open System.Reflection

let args = Environment.GetCommandLineArgs()

if args.Length = 1 then
    printfn "\nSyntax:   PlatformInfo <filename>\n"
else
    printfn ""
    // Loop through files and display information about their platform.
    for i = 1 to args.Length - 1 do
        let fn = args[i]
        if not (File.Exists fn) then
            printfn $"File: {fn}"
            printfn "The file does not exist.\n"
        else
            try
                let an = AssemblyName.GetAssemblyName fn
                printfn $"Assembly: {an.Name}"
                if an.ProcessorArchitecture = ProcessorArchitecture.MSIL then
                    printfn "Architecture: AnyCPU"
                else
                    printfn $"Architecture: {an.ProcessorArchitecture}"
                printfn ""

            with :? BadImageFormatException ->
                printfn $"File: {fn}"
                printfn "Not a valid assembly.\n"
            
// </Snippet4>