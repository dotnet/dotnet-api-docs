module filecreatetext

// <Snippet1>
open System.IO

let path = @"c:\temp\MyTest.txt"

if File.Exists path |> not then
    // Create a file to write to.
    use sw = File.CreateText path
    sw.WriteLine "Hello"
    sw.WriteLine "Welcome"

// Open the file to read from.
do
    use sr = File.OpenText path
    let mutable s = sr.ReadLine()

    while isNull s |> not do
        printfn $"{s}"
        s <- sr.ReadLine()
// </Snippet1>
