// <Snippet1>
open System
open System.IO

// Create random data to write to the stream.
let writeArray = Array.zeroCreate<byte> 1000
Random().NextBytes writeArray

let binWriter = new BinaryWriter(new MemoryStream())
let binReader = new BinaryReader(binWriter.BaseStream)

try
    // Write the data to the stream.
    printfn "Writing the data."
    for i = 0 to writeArray.Length - 1 do
        binWriter.Write writeArray[i]

    // Set the stream position to the beginning of the stream.
    binReader.BaseStream.Position <- 0

    let mutable failed = false
    // Read and verify the data from the stream.
    for i = 0 to writeArray.Length - 1 do
        if binReader.ReadByte() <> writeArray[i] then
            printfn "Error writing the data."
            failed <- true
    if not failed then
        printfn "The data was written and verified."

// Catch the EndOfStreamException and write an error message.
with :? EndOfStreamException as e ->
    printfn $"Error writing the data.\n{e.GetType().Name}"
// </Snippet1>