module fileopen2
// <Snippet1>
open System.IO
open System.Text

// This sample assumes that you have a folder named "c:\temp" on your computer.
let filePath = @"c:\temp\MyTest.txt"

// Delete the file if it exists.
if File.Exists filePath then
    File.Delete filePath

// Create the file.
do
    use fs = File.Create filePath

    let info =
        UTF8Encoding(true)
            .GetBytes "This is some text in the file."
    // Add some information to the file.
    fs.Write(info, 0, info.Length)

// Open the stream and read it back.
do
    use fs =
        File.Open(filePath, FileMode.Open, FileAccess.Read)

    let b = Array.zeroCreate 1024
    let temp = UTF8Encoding true

    while fs.Read(b, 0, b.Length) > 0 do
        printfn $"{temp.GetString b}"

    try
        // Try to write to the file.
        fs.Write(b, 0, b.Length)
    with
    | e -> printfn $"Writing was disallowed, as expected: {e}"
// </Snippet1>
