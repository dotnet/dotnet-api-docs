module filecreate1

// <Snippet1>
open System.IO
open System.Text

let path = @"c:\temp\MyTest.txt"

// Create the file, or overwrite if the file exists.
do
    use fs = File.Create path

    let info =
        UTF8Encoding(true)
            .GetBytes "This is some text in the file."
    // Add some information to the file.
    fs.Write(info, 0, info.Length)

// Open the stream and read it back.
do
    use sr = File.OpenText path
    let mutable s = sr.ReadLine()

    while isNull s |> not do
        printfn $"{s}"
        s <- sr.ReadLine()
// </Snippet1>
