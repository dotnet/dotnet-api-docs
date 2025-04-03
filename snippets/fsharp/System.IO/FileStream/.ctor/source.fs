module source
// <Snippet1>
open System
open System.IO


let fileName = "Test#@@#.dat"

// Create random data to write to the file.
let dataArray = Array.zeroCreate 100000
Random.Shared.NextBytes dataArray

do
    use fileStream = new FileStream(fileName, FileMode.Create)
    // Write the data to the file, byte by byte.
    for i = 0 to dataArray.Length - 1 do
        fileStream.WriteByte dataArray[i]

    // Set the stream position to the beginning of the file.
    fileStream.Seek(0, SeekOrigin.Begin) |> ignore

    // Read and verify the data.
    for i in 0L .. fileStream.Length - 1L do
        if dataArray[int i] <> (fileStream.ReadByte() |> byte) then
            printfn "Error writing data."
            exit 1

    printfn $"The data was written to {fileStream.Name} and verified."
// </Snippet1>
