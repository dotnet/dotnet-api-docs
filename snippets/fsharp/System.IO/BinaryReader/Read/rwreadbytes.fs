module rwreadbytes

// <Snippet1>
open System
open System.IO

let arrayLength = 1000
let dataArray = Array.zeroCreate<byte> arrayLength
let verifyArray = Array.zeroCreate<byte> arrayLength

Random().NextBytes dataArray

do
    use binWriter = new BinaryWriter(new MemoryStream())
    printfn "Writing the data."
    binWriter.Write(dataArray, 0, arrayLength)

    use binReader = new BinaryReader(binWriter.BaseStream)
    binReader.BaseStream.Position <- 0

    if binReader.Read(verifyArray, 0, arrayLength) <> arrayLength then
        printfn "Error writing the data."
    else
        for i = 0 to arrayLength - 1 do
            if verifyArray[i] <> dataArray[i] then
                printfn "Error writing the data."
            else
                printfn "The data was written and verified."
// </Snippet1>