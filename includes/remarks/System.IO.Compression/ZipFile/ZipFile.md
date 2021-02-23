> [!IMPORTANT]
>  To use the <xref:System.IO.Compression.ZipFile> class, you must add a reference to the `System.IO.Compression.FileSystem` assembly in your project; otherwise, you'll get the following error message when trying to compile : **The name 'ZipFile' does not exist in the current context**. For more information on how to add a reference to your project in Visual Studio, see [How to: Add or Remove References By Using the Reference Manager](/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager).

The methods for manipulating zip archives and their files are spread across three classes: <xref:System.IO.Compression.ZipFile>, <xref:System.IO.Compression.ZipArchive> and <xref:System.IO.Compression.ZipArchiveEntry>.

|To...|Use...|
|---------|----------|
|Create a zip archive from a directory|<xref:System.IO.Compression.ZipFile.CreateFromDirectory%2A?displayProperty=nameWithType>|
|Extract the contents of a zip archive to a directory|<xref:System.IO.Compression.ZipFile.ExtractToDirectory%2A?displayProperty=nameWithType>|
|Add new files to an existing zip archive|<xref:System.IO.Compression.ZipArchive.CreateEntry%2A?displayProperty=nameWithType>|
|Retrieve a file in a zip archive|<xref:System.IO.Compression.ZipArchive.GetEntry%2A?displayProperty=nameWithType>|
|Retrieve all of the files in a zip archive|<xref:System.IO.Compression.ZipArchive.Entries%2A?displayProperty=nameWithType>|
|To open a stream to an individual file contained in a zip archive|<xref:System.IO.Compression.ZipArchiveEntry.Open%2A?displayProperty=nameWithType>|
|Delete a file from a zip archive|<xref:System.IO.Compression.ZipArchiveEntry.Delete%2A?displayProperty=nameWithType>|

You cannot use the <xref:System.IO.Compression.ZipFile> or  <xref:System.IO.Compression.ZipFileExtensions> classes  in [!INCLUDE[win8_appname_long](~/includes/win8-appname-long-md.md)] apps. In [!INCLUDE[win8_appname_long](~/includes/win8-appname-long-md.md)] apps, you should use the following classes to work with compressed files.

-   <xref:System.IO.Compression.ZipArchive>

-   <xref:System.IO.Compression.ZipArchiveEntry>

-   <xref:System.IO.Compression.DeflateStream>

-   <xref:System.IO.Compression.GZipStream>

## Examples

This example shows how to create and extract a zip archive by using the <xref:System.IO.Compression.ZipFile> class. It compresses the contents of a folder into a zip archive, and then extracts that content to a new folder.

> [!TIP]
>  To use the <xref:System.IO.Compression.ZipFile> class, you must reference the `System.IO.Compression.FileSystem` assembly in your project.

[!code-csharp[System.IO.Compression.ZipFile#1](~/samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.zipfile/cs/program1.cs#1)]
[!code-vb[System.IO.Compression.ZipFile#1](~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.zipfile/vb/program1.vb#1)]
