// <Snippet1>
open System

// Configure console.
Console.TreatControlCAsInput <- true

printfn "Enter a string. Press <Enter> or Esc to exit."

let mutable inputString = String.Empty
let mutable keyInfo = Unchecked.defaultof<ConsoleKeyInfo>

while keyInfo.Key <> ConsoleKey.Enter && keyInfo.Key <> ConsoleKey.Escape do
    keyInfo <- Console.ReadKey true
    
    // Ignore if Alt or Ctrl is pressed.
    if keyInfo.Modifiers &&& ConsoleModifiers.Alt <> ConsoleModifiers.Alt &&
       keyInfo.Modifiers &&& ConsoleModifiers.Control <> ConsoleModifiers.Control &&
       // Ignore if KeyChar value is \u0000.
       keyInfo.KeyChar <> '\u0000' &&
       // Ignore tab key.
       keyInfo.Key <> ConsoleKey.Tab then
        
        // Handle backspace.
        if keyInfo.Key = ConsoleKey.Backspace then
            // Are there any characters to erase?
            if inputString.Length >= 1 then
                // Determine where we are in the console buffer.
                let cursorCol = Console.CursorLeft - 1
                let oldLength = inputString.Length
                let extraRows = oldLength / 80

                inputString <- inputString.Substring(0, oldLength - 1)
                Console.CursorLeft <- 0
                Console.CursorTop <- Console.CursorTop - extraRows
                printf $"{inputString + String(' ', oldLength - inputString.Length)}"
                Console.CursorLeft <- cursorCol
        else
            // Handle key by adding it to input string.
            printf $"{keyInfo.KeyChar}"
            inputString <- inputString + string keyInfo.KeyChar
    
printfn $"""

You entered:
    {if String.IsNullOrEmpty inputString then "<nothing>" else inputString}"""
// </Snippet1>