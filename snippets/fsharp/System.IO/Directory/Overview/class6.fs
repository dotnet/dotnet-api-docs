module class6

// <snippet14>
open System.IO

let sourceDirectory = @"C:\source"
let destinationDirectory = @"C:\destination"

try
    Directory.Move(sourceDirectory, destinationDirectory)
with e ->
    printfn $"{e.Message}"
// </snippet14>