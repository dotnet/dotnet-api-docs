module file_appendtext
// <Snippet1>
open System.IO

let path = @"c:\temp\MyTest.txt"

// This text is added only once to the file.
if File.Exists path |> not then
    // Create a file to write to.
    use sw = File.CreateText path
    sw.WriteLine "Hello"
    sw.WriteLine "And"
    sw.WriteLine "Welcome"

// This text is always added, making the file longer over time
// if it is not deleted.
do
    use sw = File.AppendText path
    sw.WriteLine "This"
    sw.WriteLine "is Extra"
    sw.WriteLine "Text"

// Open the file to read from.
do
    use sr = File.OpenText path

    let mutable s = sr.ReadLine()

    while isNull s |> not do
        printfn $"{s}"
        s <- sr.ReadLine()
// </Snippet1>
