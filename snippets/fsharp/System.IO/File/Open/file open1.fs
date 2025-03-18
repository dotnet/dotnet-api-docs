module fileopen1
// <Snippet1>
open System.IO
open System.Text

// Create a temporary file, and put some data into it.
let path = Path.GetTempFileName()

do
    use fs =
        File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None)

    let info =
        UTF8Encoding(true)
            .GetBytes "This is some text in the file."
    // Add some information to the file.
    fs.Write(info, 0, info.Length)

// Open the stream and read it back.
do
    use fs = File.Open(path, FileMode.Open)
    let b = Array.zeroCreate 1024
    let temp = UTF8Encoding true

    while fs.Read(b, 0, b.Length) > 0 do
        printfn $"{temp.GetString b}"
// </Snippet1>
