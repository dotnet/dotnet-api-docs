open System
open System.IO

[<EntryPoint>]
let main _ =
    // <Snippet1>
    Console.WriteLine "Hello World"
    use fs = new FileStream("Test.txt", FileMode.Create)
    // First, save the standard output.
    let tmp = Console.Out
    use sw = new StreamWriter(fs)
    Console.SetOut sw
    Console.WriteLine "Hello file"
    Console.SetOut tmp
    Console.WriteLine "Hello World"
    // </Snippet1>
    0