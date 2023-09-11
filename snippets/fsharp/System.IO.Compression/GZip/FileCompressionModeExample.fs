module FileCompressionModeExample
//<snippet1>
open System.IO
open System.IO.Compression

let message =
    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."

let OriginalFileName = "original.txt"
let CompressedFileName = "compressed.gz"
let DecompressedFileName = "decompressed.txt"

let createFileToCompress () =
    File.WriteAllText(OriginalFileName, message)

let compressFile () =
    use originalFileStream = File.Open(OriginalFileName, FileMode.Open)
    use compressedFileStream = File.Create CompressedFileName
    use compressor = new GZipStream(compressedFileStream, CompressionMode.Compress)
    originalFileStream.CopyTo compressor

let decompressFile () =
    use compressedFileStream = File.Open(CompressedFileName, FileMode.Open)
    use outputFileStream = File.Create DecompressedFileName
    use decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress)
    decompressor.CopyTo outputFileStream

let printResults () =
    let originalSize = FileInfo(OriginalFileName).Length
    let compressedSize = FileInfo(CompressedFileName).Length
    let decompressedSize = FileInfo(DecompressedFileName).Length

    printfn
        $"The original file '{OriginalFileName}' weighs {originalSize} bytes. Contents: \"{File.ReadAllText OriginalFileName}\""

    printfn $"The compressed file '{CompressedFileName}' weighs {compressedSize} bytes."

    printfn
        $"The decompressed file '{DecompressedFileName}' weighs {decompressedSize} bytes. Contents: \"{File.ReadAllText DecompressedFileName}\""

let deleteFiles () =
    File.Delete OriginalFileName
    File.Delete CompressedFileName
    File.Delete DecompressedFileName

createFileToCompress ()
compressFile ()
decompressFile ()
printResults ()
deleteFiles ()

// Output:
//     The original file 'original.txt' weighs 445 bytes. Contents: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
//
//     The compressed file 'compressed.gz' weighs 283 bytes.
//
//     The decompressed file 'decompressed.txt' weighs 445 bytes. Contents: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
//</snippet1>
