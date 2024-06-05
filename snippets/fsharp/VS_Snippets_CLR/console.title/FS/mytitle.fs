//<snippet1>
// This example demonstrates the Console.Title property.
open System

printfn $"The current console title is: \"{Console.Title}\""
printfn "  (Press any key to change the console title.)"
Console.ReadKey true |> ignore

Console.Title <- "The title has changed!"
printfn $"Note that the new console title is \"{Console.Title}\"\n  (Press any key to quit.)"
Console.ReadKey true |> ignore


// This example produces the following results:
//
// > myTitle
// The current console title is: "Command Prompt - myTitle"
//   (Press any key to change the console title.)
// Note that the new console title is "The title has changed!"
//   (Press any key to quit.)
//</snippet1>