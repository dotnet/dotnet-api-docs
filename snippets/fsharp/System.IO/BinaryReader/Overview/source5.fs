module source5

//<snippet6>
open System
open System.IO
open System.Text

let CHUNK_SIZE = 1024

let dumpBytes (bdata: byte[]) len =
    let mutable j = 0
    // 3 * 16 chars for hex display, 16 chars for text and 8 chars
    // for the 'gutter' int the middle.
    let dumptext = StringBuilder("        ", 16 * 4 + 8)
    for i = 0 to len - 1 do
        dumptext.Insert(j * 3, $"{int bdata[i]:X2} ") |> ignore
        let dchar = char bdata[i]
        //' replace 'non-printable' chars with a '.'.
        let dchar = 
            if Char.IsWhiteSpace dchar || Char.IsControl dchar then
                '.'
            else 
                dchar
        dumptext.Append dchar |> ignore
        j <- j + 1
        if j = 16 then
            printfn $"{dumptext}"
            dumptext.Length <- 0
            dumptext.Append "        " |> ignore
            j <- 0
    // display the remaining line
    if j > 0 then
        for i = j to 15 do
            dumptext.Insert(j * 3, "   ") |> ignore
        printfn $"{dumptext}"

[<EntryPoint>]
let main args =
    if args.Length = 0 || File.Exists args[0] |> not then
        printfn "Please provide an existing file name."
    else
        use fs = new FileStream(args[0], FileMode.Open, FileAccess.Read)
        use br = new BinaryReader(fs, ASCIIEncoding())
        
        let mutable chunk = br.ReadBytes CHUNK_SIZE
        while chunk.Length > 0 do
            dumpBytes chunk chunk.Length
            chunk <- br.ReadBytes CHUNK_SIZE
    0
//</snippet6>