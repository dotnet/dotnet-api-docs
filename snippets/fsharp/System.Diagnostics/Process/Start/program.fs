//<Snippet1>
// NOTE: This example requires a text.txt file file in your Documents folder
open System
open System.Diagnostics
open System.Security
open System.ComponentModel

printf "Enter your domain: "
let domain = stdin.ReadLine()
printf "Enter you user name: "
let uname = stdin.ReadLine()
printf "Enter your password: "
let password = new SecureString()

let mutable key = Console.ReadKey(true)

while key.Key <> ConsoleKey.Enter do
    // Ignore any key out of range.
    if int key.Key >= 33 && int key.Key <= 90 && key.Key <> ConsoleKey.Enter then
        // Append the character to the password.
        password.AppendChar key.KeyChar
        Console.Write "*"

    key <- Console.ReadKey(true)

printfn ""

try
    printfn "\nTrying to launch NotePad using your login information..."
    Process.Start("notepad.exe", uname, password, domain) |> ignore
with :? Win32Exception as ex ->
    printfn $"{ex.Message}"

let path = Environment.GetFolderPath Environment.SpecialFolder.MyDocuments + @"\"

try
    // The following call to Start succeeds if test.txt exists.
    printfn "\nTrying to launch 'text.txt'..."
    Process.Start $"{path}text.txt" |> ignore
with :? Win32Exception as ex ->
    printfn $"{ex.Message}"

try
    try
        // Attempting to start in a shell using this Start overload fails. This causes
        // the following exception, which is picked up in the catch block below:
        // The specified executable is not a valid application for this OS platform.
        printfn "\nTrying to launch 'text.txt' with your login information..."
        Process.Start($"{path}text.txt", uname, password, domain) |> ignore
    with :? Win32Exception as ex ->
        printfn $"{ex.Message}"
finally
    password.Dispose()
//</Snippet1>
