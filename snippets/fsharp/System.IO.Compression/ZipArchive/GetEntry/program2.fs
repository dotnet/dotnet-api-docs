module program2
// <snippet2>
open System
open System.IO
open System.IO.Compression

[<EntryPoint>]
let main _ =
    let zipPath = @"c:\example\result.zip"

    use archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)

    let entry = archive.GetEntry "ExistingFile.txt"
    use writer = new StreamWriter(entry.Open())

    writer.BaseStream.Seek(0, SeekOrigin.End) |> ignore
    writer.WriteLine "append line to file"

    entry.LastWriteTime <- DateTimeOffset.UtcNow.LocalDateTime
    0
// </snippet2>
