module TestDelegate

// <Snippet4>
open System
open System.IO

let message1 = "The first line of a message"
let message2 = "The second line of a message"

let writeToConsole string1 string2 = 
    printfn $"{string1}\n{string2}"

let writeToFile string1 string2 =
    use writer = new StreamWriter(Environment.GetCommandLineArgs().[1], false)
    writer.WriteLine $"{string1}\n{string2}"

let concat =
    Action<string,string>(
        if Environment.GetCommandLineArgs().Length > 1 then
            fun s1 s2 -> writeToFile s1 s2
        else
            fun s1 s2 -> writeToConsole s1 s2
    )

concat.Invoke(message1, message2)

// </Snippet4>
