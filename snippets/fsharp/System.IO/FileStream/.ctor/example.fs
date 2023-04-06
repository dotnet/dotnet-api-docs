module example
//<SNIPPET1>
open System.IO
open System.Text

try
    // Create a file and write data to it.

    // Create an array of bytes.
    let messageByte = Encoding.ASCII.GetBytes "Here is some data."

    // Create a file using the FileStream class.
    let fWrite =
        new FileStream("test.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.None, 8, FileOptions.None)

    // Write the number of bytes to the file.
    byte messageByte.Length |> fWrite.WriteByte

    // Write the bytes to the file.
    fWrite.Write(messageByte, 0, messageByte.Length)

    // Close the stream.
    fWrite.Close()

    // Open a file and read the number of bytes.

    let fRead = new FileStream("test.txt", FileMode.Open)

    // The first byte is the string length.
    let length = fRead.ReadByte() |> int

    // Create a new byte array for the data.
    let readBytes = Array.zeroCreate length

    // Read the data from the file.
    fRead.Read(readBytes, 0, readBytes.Length) |> ignore

    // Close the stream.
    fRead.Close()

    // Display the data.
    printfn $"{Encoding.ASCII.GetString readBytes}"

    printfn "Done writing and reading data."

with e ->
    printfn $"{e}"
//</SNIPPET1>
