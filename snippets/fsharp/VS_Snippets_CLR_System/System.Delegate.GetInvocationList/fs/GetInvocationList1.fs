// <Snippet1>
open System
open System.IO
open System.Reflection
open System.Windows.Forms

let outputToFile (s: string) =
    use sw = new StreamWriter(@".\output.txt")
    sw.WriteLine s

let showMessageBox s =
    MessageBox.Show s |> ignore

let outputMessage =
    Delegate.Combine(
        Action<string>(Console.WriteLine),
        Action<string>(outputToFile),
        Action<string>(showMessageBox))
    :?> Action<string>

printfn $"Invocation list has {outputMessage.GetInvocationList().Length} methods."

// Invoke delegates normally.
outputMessage.Invoke "Hello there!"
printfn "Press <Enter> to continue..."
stdin.ReadLine() |> ignore

// Invoke each delegate in the invocation list in reverse order.
for i = outputMessage.GetInvocationList().Length - 1 downto 0 do
    let outputMsg = outputMessage.GetInvocationList()[i]
    outputMsg.DynamicInvoke "Greetings and salutations!"
    |> ignore

printfn "Press <Enter> to continue..."
stdin.ReadLine() |> ignore

// Invoke each delegate that doesn't write to a file.
for i = 0 to outputMessage.GetInvocationList().Length - 1 do
    let outputMsg = outputMessage.GetInvocationList()[i]
    if not (outputMsg.GetMethodInfo().Name.Contains "File") then
        outputMsg.DynamicInvoke "Hi!"
        |> ignore
// </Snippet1>