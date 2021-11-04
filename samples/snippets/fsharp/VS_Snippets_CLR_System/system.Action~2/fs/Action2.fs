module TestLambdaExpression

// <Snippet2>
open System
open System.IO

let message1 = "The first line of a message"
let message2 = "The second line of a message"

let writeToConsole string1 string2 = 
    printfn $"{string1}\n{string2}"

let writeToFile string1 string2 =
    use writer = new StreamWriter(Environment.GetCommandLineArgs().[1], false)
    try
        writer.WriteLine $"{string1}\n{string2}"
    with _ -> printfn "File write operation failed..."

let concat =
    Action<string, string>(
        if Environment.GetCommandLineArgs().Length > 1 then
            writeToFile
        else
            writeToConsole
    )

concat.Invoke(message1, message2)

// </Snippet2>
