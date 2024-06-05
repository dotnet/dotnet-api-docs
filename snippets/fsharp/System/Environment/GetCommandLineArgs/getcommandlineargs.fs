//<snippet1>
open System

//  Invoke this sample with an arbitrary set of command line arguments.
let arguments = Environment.GetCommandLineArgs()

String.concat ", " arguments
|> printfn "\nGetCommandLineArgs: %s"

// This example produces output like the following:
//     C:\>GetCommandLineArgs ARBITRARY TEXT
//
//       GetCommandLineArgs: GetCommandLineArgs, ARBITRARY, TEXT
// </snippet1>