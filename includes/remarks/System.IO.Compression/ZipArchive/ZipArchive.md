The methods for manipulating zip archives and their file entries are spread across three classes: <xref:System.IO.Compression.ZipFile>, <xref:System.IO.Compression.ZipArchive>, and <xref:System.IO.Compression.ZipArchiveEntry>.

|To|Use|
|--------|---------|
|Create a zip archive from a directory|<xref:System.IO.Compression.ZipFile.CreateFromDirectory%2A?displayProperty=nameWithType>|
|Extract the contents of a zip archive to a directory|<xref:System.IO.Compression.ZipFile.ExtractToDirectory%2A?displayProperty=nameWithType>|
|Add new files to an existing zip archive|<xref:System.IO.Compression.ZipArchive.CreateEntry%2A?displayProperty=nameWithType>|
|Retrieve a file from a zip archive|<xref:System.IO.Compression.ZipArchive.GetEntry%2A?displayProperty=nameWithType>|
|Retrieve all the files from a zip archive|<xref:System.IO.Compression.ZipArchive.Entries%2A?displayProperty=nameWithType>|
|Open a stream to a single file contained in a zip archive|<xref:System.IO.Compression.ZipArchiveEntry.Open%2A?displayProperty=nameWithType>|
|Delete a file from a zip archive|<xref:System.IO.Compression.ZipArchiveEntry.Delete%2A?displayProperty=nameWithType>|

When you create a new entry, the file is compressed and added to the zip package. The <xref:System.IO.Compression.ZipArchive.CreateEntry%2A> method enables you to specify a directory hierarchy when adding the entry. You include the relative path of the new entry within the zip package. For example, creating a new entry with a relative path of `AddedFolder\NewFile.txt` creates a compressed text file in a directory named AddedFolder.

If you reference the `System.IO.Compression.FileSystem` assembly in your project, you can access four extension methods (from the <xref:System.IO.Compression.ZipFileExtensions> class) for the <xref:System.IO.Compression.ZipArchive> class: <xref:System.IO.Compression.ZipFileExtensions.CreateEntryFromFile(System.IO.Compression.ZipArchive,System.String,System.String)>, <xref:System.IO.Compression.ZipFileExtensions.CreateEntryFromFile(System.IO.Compression.ZipArchive,System.String,System.String,System.IO.Compression.CompressionLevel)>, <xref:System.IO.Compression.ZipFileExtensions.ExtractToDirectory(System.IO.Compression.ZipArchive,System.String)>, and <xref:System.IO.Compression.ZipFileExtensions.ExtractToDirectory(System.IO.Compression.ZipArchive,System.String,System.Boolean)> (available in .NET Core 2.0 and later versions). These extension methods enable you to compress and decompress the contents of the entry to a file. The `System.IO.Compression.FileSystem` assembly is not available for Windows 8.x Store apps. In Windows 8.x Store apps, you can compress and decompress files by using the <xref:System.IO.Compression.DeflateStream> or <xref:System.IO.Compression.GZipStream> class, or you can use the Windows Runtime types <xref:Windows.Storage.Compression.Compressor> and <xref:Windows.Storage.Compression.Decompressor>.

## Examples

The first example shows how to create a new entry and write to it by using a stream.

:::code language="csharp" source="~/snippets/csharp/System.IO.Compression/ZipArchive/CreateEntry/program1.cs" id="Snippet1":::
:::code language="vb" source="~/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchivemode/vb/program1.vb" id="Snippet1":::

The following example shows how to open a zip archive and iterate through the collection of entries.

:::code language="csharp" source="~/snippets/csharp/System.IO.Compression/ZipArchive/Entries/program1.cs" id="Snippet1":::
:::code language="vb" source="~/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchive/vb/program1.vb" id="Snippet1":::

The third example shows how to use extension methods to create a new entry in a zip archive from an existing file and extract the archive contents. You must reference the `System.IO.Compression.FileSystem` assembly to execute the code.

:::code language="csharp" source="~/snippets/csharp/System.IO.Compression/ZipArchive/Entries/program3.cs" id="Snippet3":::
:::code language="vb" source="~/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchive/vb/program3.vb" id="Snippet3":::
