module class1

open System
open System.IO
open System.Text

let inputFileName = "fs.fsproj"
let outputFileName = "out.xml"

//<Snippet2>
let encodeWithCharArray () =
    try
        use inFile =
            new FileStream(inputFileName, FileMode.Open, FileAccess.Read)

        let binaryData =
            Array.zeroCreate<byte> (int inFile.Length)

        inFile.Read(binaryData, 0, int inFile.Length)
        |> ignore

        // Convert the binary input into Base64 UUEncoded output.
        // Each 3 byte sequence in the source data becomes a 4 byte
        // sequence in the character array.
        let arrayLength =
            (4. / 3.) * float binaryData.Length |> int64

        // If array length is not divisible by 4, shadow up to the next multiple of 4.
        let arrayLength =
            if arrayLength % 4L <> 0L then
                arrayLength + (4L - arrayLength % 4L)
            else
                arrayLength

        let base64CharArray = Array.zeroCreate<char> (int arrayLength)

        Convert.ToBase64CharArray(binaryData, 0, binaryData.Length, base64CharArray, 0)
        |> ignore
        // Write the UUEncoded version to the output file.
        use outFile =
            new StreamWriter(outputFileName, false, Encoding.ASCII)

        outFile.Write(base64CharArray)
        outFile.Close()
    with
    | :? ArgumentNullException -> printfn "Binary data array is null."
    | :? ArgumentOutOfRangeException -> printfn "Char Array is not large enough."
    | e ->
        // Error creating stream or writing to it.
        printfn $"{e.Message}"
//</Snippet2>

//<Snippet3>
let decodeWithCharArray () =
    try
        let inFile =
            new StreamReader(inputFileName, Encoding.ASCII)

        let base64CharArray =
            Array.zeroCreate<char> (int inFile.BaseStream.Length)

        inFile.Read(base64CharArray, 0, (int) inFile.BaseStream.Length)
        |> ignore

        // Convert the Base64 UUEncoded input into binary output.
        let binaryData =
            Convert.FromBase64CharArray(base64CharArray, 0, base64CharArray.Length)
        // Write out the decoded data.
        use outFile =
            new FileStream(outputFileName, FileMode.Create, FileAccess.Write)

        outFile.Write(binaryData, 0, binaryData.Length)
    with
    | :? ArgumentNullException -> printfn "Base 64 character array is null."
    | :? FormatException -> printfn "Base 64 Char Array length is not 4 or is not an even multiple of 4."
    | e -> printfn $"{e.Message}"

//</Snippet3>
