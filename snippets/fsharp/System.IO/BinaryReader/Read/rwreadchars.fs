// <Snippet1>
open System.IO

let invalidPathChars = Path.GetInvalidPathChars()
let memStream = new MemoryStream()
let binWriter = new BinaryWriter(memStream)

// Write to memory.
binWriter.Write "Invalid file path characters are: "
binWriter.Write(invalidPathChars, 0, invalidPathChars.Length)

// Create the reader using the same MemoryStream
// as used with the writer.
let binReader = new BinaryReader(memStream)

// Set Position to the beginning of the stream.
memStream.Position <- 0

// Read the data from memory and write it to the console.
printf $"{binReader.ReadString()}"
let arraySize = memStream.Length - memStream.Position |> int
let memoryData = Array.zeroCreate<char> arraySize
binReader.Read(memoryData, 0, arraySize) |> ignore
printfn $"{memoryData}"
// </Snippet1>