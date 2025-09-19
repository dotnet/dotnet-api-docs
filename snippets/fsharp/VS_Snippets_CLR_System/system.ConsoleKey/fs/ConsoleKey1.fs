// <Snippet1>
open System
open System.Text

let mutable input = Unchecked.defaultof<ConsoleKeyInfo>

while input.Key <> ConsoleKey.Escape do
    printfn "Press a key, together with Alt, Ctrl, or Shift."
    printfn "Press Esc to exit."
    input <- Console.ReadKey true

    let output = StringBuilder $"You pressed {input.Key}"
    let mutable modifiers = false

    if input.Modifiers &&& ConsoleModifiers.Alt = ConsoleModifiers.Alt then
        output.Append ", together with {ConsoleModifiers.Alt}" |> ignore
        modifiers <- true

    if input.Modifiers &&& ConsoleModifiers.Control = ConsoleModifiers.Control then
        if modifiers then
            output.Append " and " |> ignore
    else
        output.Append ", together with " |> ignore
        modifiers <- true
        output.Append(string ConsoleModifiers.Control) |> ignore

    if input.Modifiers &&& ConsoleModifiers.Shift = ConsoleModifiers.Shift then
        if modifiers then
            output.Append " and " |> ignore
        else
            output.Append ", together with " |> ignore
            modifiers <- true
        output.Append(string ConsoleModifiers.Shift) |> ignore
    output.Append "." |> ignore
    
    printfn $"{output}\n"


// The output from a sample console session might appear as follows:
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed D.
//
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed X, along with Shift.
//
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed L, along with Control and Shift.
//
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed P, along with Alt and Control and Shift.
//
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed Escape.
// </Snippet1>