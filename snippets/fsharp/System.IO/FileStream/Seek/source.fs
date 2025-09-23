module source
// <Snippet1>
open System.IO

// alphabet.txt contains "abcdefghijklmnopqrstuvwxyz"
using (new FileStream(@"c:\temp\alphabet.txt", FileMode.Open, FileAccess.Read)) (fun fs ->
    for offset in 1L .. fs.Length do
        fs.Seek(-offset, SeekOrigin.End) |> ignore
        printf $"{fs.ReadByte() |> char}"

    printfn ""

    fs.Seek(20, SeekOrigin.Begin) |> ignore

    let mutable nextByte = fs.ReadByte()

    while nextByte > 0 do
        printf $"{char nextByte}"
        nextByte <- fs.ReadByte())

// This code example displays the following output:
//
// zyxwvutsrqponmlkjihgfedcba
// uvwxyz
// </Snippet1>
