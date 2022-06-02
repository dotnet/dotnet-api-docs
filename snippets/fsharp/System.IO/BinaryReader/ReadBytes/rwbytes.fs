// <Snippet1>
open System
open System.IO

let arrayLength = 1000

// Create random data to write to the stream.
let dataArray = Array.zeroCreate<byte> arrayLength
Random().NextBytes dataArray

let binWriter = new BinaryWriter(new MemoryStream())

// Write the data to the stream.ch
printfn "Writing the data."
binWriter.Write dataArray

// Create the reader using the stream from the writer.
let binReader = new BinaryReader(binWriter.BaseStream)

// Set Position to the beginning of the stream.
binReader.BaseStream.Position <- 0

// Read and verify the data.
let verifyArray = binReader.ReadBytes arrayLength
if verifyArray.Length <> arrayLength then
    printfn "Error writing the data."
else
    let mutable failed = false
    for i = 0 to arrayLength - 1 do
        if verifyArray[i] <> dataArray[i] then
            printfn "Error writing the data."
            failed <- true
    if not failed then
        printfn "The data was written and verified."
// </Snippet1>