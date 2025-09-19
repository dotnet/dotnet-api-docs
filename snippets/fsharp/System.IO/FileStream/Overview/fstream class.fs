module fstream_class
// <Snippet1>
open System
open System.IO
open System.Text

let addText (fs:FileStream) (value: string) =
    let info = UTF8Encoding(true).GetBytes value
    fs.Write(info, 0, info.Length);

let path = @"c:\temp\MyTest.txt"

// Delete the file if it exists.
if File.Exists path then
    File.Delete path

//Create the file.
do
    use fs = File.Create path

    addText fs "This is some text"
    addText fs "This is some more text,"
    addText fs "\r\nand this is on a new line"
    addText fs "\r\n\r\nThe following is a subset of characters:\r\n"

    for i = 1 to 119 do
        Convert.ToChar i
        |> string
        |> addText fs
    
do
    //Open the stream and read it back.
    use fs = File.OpenRead path
    let b = Array.zeroCreate 1024
    let temp = UTF8Encoding true
    let mutable readLen = fs.Read(b,0,b.Length);
    while readLen> 0 do
        printfn $"{temp.GetString(b,0,readLen)}"
        readLen <- fs.Read(b,0,b.Length)


// </Snippet1>
