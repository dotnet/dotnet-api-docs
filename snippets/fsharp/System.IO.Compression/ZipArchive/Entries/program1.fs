module program1
// <snippet1>
open System
open System.IO;
open System.IO.Compression;

[<EntryPoint>]
let main _ =
    let zipPath = @".\result.zip"

    printfn "Provide path where to extract the zip file:"
    let extractPath = stdin.ReadLine();

    // Normalizes the path.
    let mutable extractPath = Path.GetFullPath extractPath

    // Ensures that the last character on the extraction path
    // is the directory separator char.
    // Without this, a malicious zip file could try to traverse outside of the expected
    // extraction path.
    if extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) |> not then
        extractPath <- extractPath + string Path.DirectorySeparatorChar

    use archive = ZipFile.OpenRead zipPath

    for entry in archive.Entries do
        if entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) then
            // Gets the full path to ensure that relative segments are removed.
            let destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName))

            // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
            // are case-insensitive.
            if destinationPath.StartsWith(extractPath, StringComparison.Ordinal) then
                entry.ExtractToFile destinationPath
    0
            
// </snippet1>