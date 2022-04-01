// <Snippet2>
let stripComments (lines: #seq<string>) =
    [|  for line in lines do
            if line.TrimStart(' ').StartsWith "//" then
                line.TrimStart(' ', '/') |]
// </Snippet2>

// <Snippet3>
let lines = 
    [| "module HelloWorld"
       ""
       "[<EntryPoint>]"
       "let main _ ="
       "    // This code displays a simple greeting"
       "    // to the console."
       "    printfn \"Hello, World.\""
       "    0" |]
printfn "Before call to StripComments:"
for line in lines do
    printfn $"   {line}"

let strippedLines = stripComments lines
printfn "After call to StripComments:"
for line in strippedLines do
    printfn $"   {line}"
// This code produces the following output to the console:
//    Before call to StripComments:
//       module HelloWorld
//
//       [<EntryPoint>]
//       let main _ =
//           // This code displays a simple greeting
//           // to the console.
//           printfn "Hello, World."
//           0
//    After call to StripComments:
//       This code displays a simple greeting
//       to the console.
// </Snippet3>
do
    // <Snippet1>
    // TrimStart examples
    let lineWithLeadingSpaces = "   Hello World!"
    let lineWithLeadingSymbols = "$$$$Hello World!"
    let lineWithLeadingUnderscores = "_____Hello World!"
    let lineWithLeadingLetters = "xxxxHello World!"

    // Make it easy to print out and work with all of the examples
    let lines = [| lineWithLeadingSpaces; lineWithLeadingSymbols; lineWithLeadingUnderscores; lineWithLeadingLetters |]

    for line in lines do
        printfn $"This line has leading characters: {line}"
    // Output:
    // This line has leading characters:    Hello World!
    // This line has leading characters: $$$$Hello World!
    // This line has leading characters: _____Hello World!
    // This line has leading characters: xxxxHello World!

    // A basic demonstration of TrimStart in action
    let lineAfterTrimStart = lineWithLeadingSpaces.TrimStart ' '
    printfn $"This is the result after calling TrimStart: {lineAfterTrimStart}"
    // This is the result after calling TrimStart: Hello World!   

    // Since TrimStart accepts a character array of leading items to be removed as an argument,
    // it's possible to do things like trim multiple pieces of data that each have different 
    // leading characters,
    for lineToEdit in lines do
        printfn $"""{lineToEdit.TrimStart(' ', '$', '_', 'x')}"""
    // Result for each: Hello World!

    // or handle pieces of data that have multiple kinds of leading characters 
    let lineToBeTrimmed = "__###__ John Smith"
    let lineAfterTrimStart2 = lineToBeTrimmed.TrimStart('_', '#', ' ')
    printfn $"{lineAfterTrimStart2}"
    // Result: John Smith
    // </Snippet1>