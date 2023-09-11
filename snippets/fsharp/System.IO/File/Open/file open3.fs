module fileopen3
// <Snippet1>
open System.IO
open System.Text

let path = @"c:\temp\MyTest.txt"

// Create the file if it does not exist.
if File.Exists path |> not then
    // Create the file.
    use fs = File.Create path

    let info =
        UTF8Encoding(true)
            .GetBytes "This is some text in the file."

    // Add some information to the file.
    fs.Write(info, 0, info.Length)

// Open the stream and read it back.
do
    use fs =
        File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None)

    let b = Array.zeroCreate 1024
    let temp = UTF8Encoding true

    while fs.Read(b, 0, b.Length) > 0 do
        printfn $"{temp.GetString b}"

    try
        // Try to get another handle to the same file.
        use fs2 = File.Open(path, FileMode.Open)
        // Do some task here.
        ()
    with
    | e -> printf "Opening the file twice is disallowed, as expected: {e}"
// </Snippet1>
