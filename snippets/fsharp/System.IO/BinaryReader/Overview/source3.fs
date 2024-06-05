module source3

//<snippet5>
open System.IO
open System.Text

let testfile = @"C:\temp\testfile.bin"

// create a test file using BinaryWriter
let fs = File.Create testfile
let utf8 = UTF8Encoding()

let bw = new BinaryWriter(fs, utf8)
// write a series of bytes to the file, each time incrementing
// the value from 0 - 127

for pos = 0 to 127 do
    bw.Write(byte pos)

// reset the stream position for the next write pass
bw.Seek(0, SeekOrigin.Begin) |> ignore
// write marks in file with the value of 255 going forward
for _ in 0..8..119 do
    bw.Seek(7, SeekOrigin.Current) |> ignore
    bw.Write(byte 255)

// reset the stream position for the next write pass
bw.Seek(0, SeekOrigin.End) |> ignore
// write marks in file with the value of 254 going backward
for _ in 128 .. -6 .. 6 do
    bw.Seek(-6, SeekOrigin.Current) |> ignore
    bw.Write(byte 254)
    bw.Seek(-1, SeekOrigin.Current) |> ignore

// now dump the contents of the file using the original file stream
fs.Seek(0, SeekOrigin.Begin) |> ignore
let rawbytes = Array.zeroCreate<byte> (int fs.Length)
fs.Read(rawbytes, 0, int fs.Length) |> ignore

let mutable i = 0
for b in rawbytes do
    match b with
    | 254uy ->
        printf "-%%- "
    | 255uy ->
        printf "-*- "
    | _ ->
        printf $"{b:d3} "
    i <- i + 1
    if i = 16 then
        printfn ""
        i <- 0
fs.Close()

//The output from the program is this:
//
// 000 001 -%- 003 004 005 006 -*- -%- 009 010 011 012 013 -%- -*-
// 016 017 018 019 -%- 021 022 -*- 024 025 -%- 027 028 029 030 -*-
// -%- 033 034 035 036 037 -%- -*- 040 041 042 043 -%- 045 046 -*-
// 048 049 -%- 051 052 053 054 -*- -%- 057 058 059 060 061 -%- -*-
// 064 065 066 067 -%- 069 070 -*- 072 073 -%- 075 076 077 078 -*-
// -%- 081 082 083 084 085 -%- -*- 088 089 090 091 -%- 093 094 -*-
// 096 097 -%- 099 100 101 102 -*- -%- 105 106 107 108 109 -%- -*-
// 112 113 114 115 -%- 117 118 -*- 120 121 -%- 123 124 125 126 127
//</snippet5>