// <Snippet1>
open System

let getKeyPress msg validChars =
    Console.WriteLine()
    
    let mutable valid = false
    let mutable keyChar = ' '
    
    while not valid do
        printfn "%s" msg
        let keyPressed = Console.ReadKey()
        printfn ""
        if validChars |> List.exists (fun ch -> ch.Equals(Char.ToUpper keyPressed.KeyChar)) then
            valid <- true
            keyChar <- keyPressed.KeyChar
    keyChar

// Save colors so they can be restored when use finishes input.
let dftForeColor = Console.ForegroundColor
let dftBackColor = Console.BackgroundColor
let mutable continueFlag = true
Console.Clear()

while continueFlag do
    let foreColorSelection = 
        getKeyPress "Select Text Color (B for Blue, R for Red, Y for Yellow): " [ 'B'; 'R'; 'Y' ]
    
    let newForeColor = 
        match foreColorSelection with
        | 'B' | 'b' ->
            ConsoleColor.DarkBlue
        | 'R' | 'r' ->
            ConsoleColor.DarkRed
        | 'Y' | 'y' ->
            ConsoleColor.DarkYellow
        | _ -> ConsoleColor.White

    let backColorSelection = 
        getKeyPress "Select Background Color (W for White, G for Green, M for Magenta): " [ 'W'; 'G'; 'M' ]

    let newBackColor = 
        match backColorSelection with
        | 'W' | 'w' ->
            ConsoleColor.White
        | 'G' | 'g' ->
            ConsoleColor.Green
        | 'M' | 'm' ->
            ConsoleColor.Magenta
        | _ -> ConsoleColor.Black

    printfn ""
    printf "Enter a message to display: "
    let textToDisplay = Console.ReadLine()
    printfn ""
    Console.ForegroundColor <- newForeColor
    Console.BackgroundColor <- newBackColor
    printfn "%s" textToDisplay
    printfn ""
    if Char.ToUpper(getKeyPress "Display another message (Y/N): " [ 'Y'; 'N' ] ) = 'N' then
        continueFlag <- false

    // Restore the default settings and clear the screen.
    Console.ForegroundColor <- dftForeColor
    Console.BackgroundColor <- dftBackColor
    Console.Clear()
// </Snippet1>