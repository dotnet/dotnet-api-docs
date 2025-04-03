module fstreamlock
// <Snippet1>
open System
open System.IO
open System.Text

let uniEncoding = UnicodeEncoding()
let lastRecordText = "The last processed record number was: "
let textLength = uniEncoding.GetByteCount lastRecordText
let mutable recordNumber = 13
let byteCount = string recordNumber |> uniEncoding.GetByteCount

do
    // <Snippet2>
    use fileStream =
        new FileStream("Test#@@#.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
    // </Snippet2>

    // <Snippet3>
    // Write the original file data.
    if fileStream.Length = 0 then
        let tempString = lastRecordText + string recordNumber
        fileStream.Write(uniEncoding.GetBytes tempString, 0, uniEncoding.GetByteCount tempString)

    // </Snippet3>

    // Allow the user to choose the operation.
    let mutable consoleInput = 'R'
    let readText = int fileStream.Length |> Array.zeroCreate

    while consoleInput <> 'X' do
        printf "\nEnter 'R' to read, 'W' to write, 'L' to lock, 'U' to unlock, anything else to exit: "

        let mutable tempString = stdin.ReadLine()

        if tempString.Length = 0 then
            consoleInput <- 'X'
        else
            consoleInput <- Char.ToUpper tempString[0]

            match consoleInput with
            | 'R' ->
                // Read data from the file and
                // write it to the console.
                try
                    fileStream.Seek(0, SeekOrigin.Begin) |> ignore
                    fileStream.Read(readText, 0, int fileStream.Length) |> ignore
                    tempString <- String(uniEncoding.GetChars readText, 0, readText.Length)
                    printfn $"{tempString}"
                    recordNumber <- tempString.IndexOf ':' + 2 |> tempString.Substring |> Int32.Parse

                // Catch the IOException generated if the
                // specified part of the file is locked.
                with :? IOException as e ->

                    printfn
                        $"{e.GetType().Name}: The read operation could not be performed because the specified part of the file is locked."

            // <Snippet4>
            | 'W' ->
                // Update the file.
                try

                    fileStream.Seek(textLength, SeekOrigin.Begin) |> ignore
                    fileStream.Read(readText, textLength - 1, byteCount) |> ignore
                    tempString <- String(uniEncoding.GetChars readText, textLength - 1, byteCount)
                    recordNumber <- Int32.Parse tempString + 1
                    fileStream.Seek(textLength, SeekOrigin.Begin) |> ignore
                    fileStream.Write(string recordNumber |> uniEncoding.GetBytes, 0, byteCount)
                    fileStream.Flush()
                    printfn "Record has been updated."
                // </Snippet4>

                // <Snippet6>
                // Catch the IOException generated if the
                // specified part of the file is locked.
                with :? IOException as e ->
                    printfn
                        $"{e.GetType().Name}: The write operation could not be performed because the specified part of the file is locked."
            // </Snippet6>

            // Lock the specified part of the file.
            | 'L' ->
                try
                    fileStream.Lock(textLength - 1 |> int64, byteCount)
                    printfn "The specified part of file has been locked."
                with :? IOException as e ->
                    printfn $"{e.GetType().Name}: The specified part of file is already locked."

            // <Snippet5>
            // Unlock the specified part of the file.
            | 'U' ->
                try
                    fileStream.Unlock(textLength - 1 |> int64, byteCount)
                    printfn "The specified part of file has been unlocked."

                with :? IOException as e ->
                    printfn $"{e.GetType().Name}: The specified part of file is not locked by the current process."
            // </Snippet5>

            // Exit the program.
            | _ -> consoleInput <- 'X'
// </Snippet1>
