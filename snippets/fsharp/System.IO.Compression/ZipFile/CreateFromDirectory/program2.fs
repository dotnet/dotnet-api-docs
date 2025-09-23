module program2
// <snippet2>
open System.IO.Compression

let startPath = @"c:\example\start"
let zipPath = @"c:\example\result.zip"
let extractPath = @"c:\example\extract"

ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true)

ZipFile.ExtractToDirectory(zipPath, extractPath)
// </snippet2>
