module fileopenwrite
// <Snippet1>
open System.IO
open System.Text

let path = @"c:\temp\MyTest.txt"

// Open the stream and write to it.
do
    use fs = File.OpenWrite path

    let info =
        UTF8Encoding(true)
            .GetBytes "This is to test the OpenWrite method."

    // Add some information to the file.
    fs.Write(info, 0, info.Length)

// Open the stream and read it back.
do
    use fs = File.OpenRead path
    let b = Array.zeroCreate 1024
    let temp = UTF8Encoding true

    while fs.Read(b, 0, b.Length) > 0 do
        printfn $"{temp.GetString b}"
// </Snippet1>
