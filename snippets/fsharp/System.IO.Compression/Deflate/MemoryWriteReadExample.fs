//<snippet1>
module MemoryWriteReadExample

open System.IO
open System.IO.Compression
open System.Text

let message =
    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."

let s_messageBytes = Encoding.ASCII.GetBytes message

let compressBytesToStream stream =
    use compressor = new DeflateStream(stream, CompressionMode.Compress, true)
    compressor.Write(s_messageBytes, 0, s_messageBytes.Length)

let decompressStreamToBytes (stream: Stream) =
    stream.Position <- 0
    let bufferSize = 512
    let decompressedBytes = Array.zeroCreate bufferSize
    use decompressor = new DeflateStream(stream, CompressionMode.Decompress)
    decompressor.Read(decompressedBytes, 0, bufferSize)

[<EntryPoint>]
let main _ =
    printfn $"The original string length is {s_messageBytes.Length} bytes."
    use stream = new MemoryStream()
    compressBytesToStream stream
    printfn $"The compressed stream length is {stream.Length} bytes."
    let decompressedLength = decompressStreamToBytes stream
    printfn $"The decompressed string length is {decompressedLength} bytes, same as the original length."
    0

// Output:
//     The original string length is 445 bytes.
//     The compressed stream length is 265 bytes.
//     The decompressed string length is 445 bytes, same as the original length.
//</snippet1>
