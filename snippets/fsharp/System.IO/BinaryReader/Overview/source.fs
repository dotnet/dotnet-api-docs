module source

// <Snippet1>
open System.IO
open System.Text

let fileName = "AppSettings.dat"

let writeDefaultValues () =
    use stream = File.Open(fileName, FileMode.Create)
    use writer = new BinaryWriter(stream, Encoding.UTF8, false)
    writer.Write 1.250F
    writer.Write @"c:\Temp"
    writer.Write 10
    writer.Write true

let displayValues () =
    if File.Exists fileName then
        use stream = File.Open(fileName, FileMode.Open)
        use reader = new BinaryReader(stream, Encoding.UTF8, false)
        let aspectRatio = reader.ReadSingle()
        let tempDirectory = reader.ReadString()
        let autoSaveTime = reader.ReadInt32()
        let showStatusBar = reader.ReadBoolean()

        printfn $"Aspect ratio set to: {aspectRatio}"
        printfn $"Temp directory is: {tempDirectory}"
        printfn $"Auto save time set to: {autoSaveTime}"
        printfn $"Show status bar: {showStatusBar}"

writeDefaultValues ()
displayValues ()
// </Snippet1>