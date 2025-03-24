module fsread
// <Snippet1>
open System.IO

// Specify a file to read from and to create.
let pathSource = @"c:\tests\source.txt"
let pathNew = @"c:\tests\newfile.txt"

try
    use fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read)

    // Read the source file into a byte array.
    let mutable numBytesToRead = int fsSource.Length
    let bytes = numBytesToRead |> Array.zeroCreate
    let mutable numBytesRead = 0

    while numBytesToRead > 0 do
        // Read may return anything from 0 to numBytesToRead.
        let n = fsSource.Read(bytes, numBytesRead, numBytesToRead)

        // Break when the end of the file is reached.
        if n <> 0 then
            numBytesRead <- numBytesRead + n
            numBytesToRead <- numBytesToRead - n

    let numBytesToRead = bytes.Length

    // Write the byte array to the other FileStream.
    use fsNew = new FileStream(pathNew, FileMode.Create, FileAccess.Write)
    fsNew.Write(bytes, 0, numBytesToRead)
with :? FileNotFoundException as ioEx ->
    printfn $"{ioEx.Message}"
// </Snippet1>
