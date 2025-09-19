module rwreadchar

// <Snippet1>
open System
open System.IO

let invalidPathChars = Path.GetInvalidPathChars()
let memStream = new MemoryStream()
let binWriter = new BinaryWriter(memStream)

// Write to memory.
printf "Invalid file path characters are: "
for i = 0 to invalidPathChars.Length - 1 do
    binWriter.Write invalidPathChars[i]

// Create the reader using the same MemoryStream
// as used with the writer.
let binReader = new BinaryReader(memStream)

// Set Position to the beginning of the stream.
memStream.Position <- 0

// Read the data from memory and write it to the console.
printf $"{binReader.ReadString()}"
let memoryData =
    [| for _ = 0L to memStream.Length - memStream.Position - 1L do
        Convert.ToChar(binReader.Read()) |]
printfn $"{memoryData}"
// </Snippet1>