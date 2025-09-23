module program1
// <snippet1>
open System.IO.Compression

let startPath = @".\start"
let zipPath = @".\result.zip"
let extractPath = @".\extract"

ZipFile.CreateFromDirectory(startPath, zipPath)

ZipFile.ExtractToDirectory(zipPath, extractPath)

// </snippet1>
