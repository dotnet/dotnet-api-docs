// <Snippet1>
open System.IO

let invalidPathChars = Path.GetInvalidPathChars()
let memStream = new MemoryStream()
let binWriter = new BinaryWriter(memStream)

// Write to memory.
binWriter.Write "Invalid file path characters are: "
for i = 0 to invalidPathChars.Length - 1 do
    binWriter.Write invalidPathChars[i]

// Create the reader using the same MemoryStream
// as used with the writer.
let binReader = new BinaryReader(memStream)

// Set Position to the beginning of the stream.
memStream.Position <- 0

// Read the data from memory and write it to the console.
printf $"{binReader.ReadString()}"
let memoryData = Array.zeroCreate<char> (int (memStream.Length - memStream.Position))
for i = 0 to memoryData.Length - 1 do
    memoryData[i] <- binReader.ReadChar()
printfn $"{memoryData}"
// </Snippet1>