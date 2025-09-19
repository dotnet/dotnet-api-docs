// <Snippet1>
open System
open System.IO

let arrayLength = 1000

// Create random data to write to the stream.
let randomGenerator = Random()
let dataArray = 
    Array.init arrayLength (fun _ -> 100.1 * randomGenerator.NextDouble())
do
    use binWriter = new BinaryWriter(new MemoryStream())
    // Write the data to the stream.
    printfn $"Writing data to the stream."
    for num in dataArray do
        binWriter.Write num

    // Create a reader using the stream from the writer.
    use binReader = new BinaryReader(binWriter.BaseStream)
    try
        // Return to the beginning of the stream.
        binReader.BaseStream.Position <- 0

        // Read and verify the data.
        printfn "Verifying the written data."
        for num in dataArray do
            if binReader.ReadDouble() <> num then
                printfn "Error writing data."
        printfn "The data was written and verified."
    with :? EndOfStreamException as e ->
        printfn $"Error writing data: {e.GetType().Name}."
// </Snippet1>