module program2

// <snippet2>
open System.IO
open System.IO.Compression

do
    use zipToOpen = new FileStream(@"c:\users\exampleuser\release.zip", FileMode.Open)

    use archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update)

    let readmeEntry = archive.CreateEntry("Readme.txt", CompressionLevel.Optimal)
    use writer = new StreamWriter(readmeEntry.Open())

    writer.WriteLine "Information about this package."
    writer.WriteLine "========================"
// </snippet2>