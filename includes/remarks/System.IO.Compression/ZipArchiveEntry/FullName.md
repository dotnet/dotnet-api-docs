The <xref:System.IO.Compression.ZipArchiveEntry.FullName%2A> property contains the relative path, including the subdirectory hierarchy, of an entry in a zip archive. (In contrast, the <xref:System.IO.Compression.ZipArchiveEntry.Name%2A> property contains only the name of the entry and does not include the subdirectory hierarchy.) For example, if you create two entries in a zip archive by using the <xref:System.IO.Compression.ZipFileExtensions.CreateEntryFromFile%2A> method and provide `NewEntry.txt` as the name for the first entry and `AddedFolder\\NewEntry.txt` for the second entry, both entries will have `NewEntry.txt` in the <xref:System.IO.Compression.ZipArchiveEntry.Name%2A> property. The first entry will also have `NewEntry.txt` in the <xref:System.IO.Compression.ZipArchiveEntry.FullName%2A> property, but the second entry will have `AddedFolder\\NewEntry.txt` in the <xref:System.IO.Compression.ZipArchiveEntry.FullName%2A> property.

You can specify any string as the path of an entry, including strings that specify invalid and absolute paths. Therefore, the <xref:System.IO.Compression.ZipArchiveEntry.FullName%2A> property might contain a value that is not correctly formatted. An invalid or absolute path might result in an exception when you extract the contents of the zip archive.

## Examples

The following example shows how to iterate through the contents of a .zip file, and extract files that contain the .txt extension.

:::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.ziparchive/cs/program1.cs" id="Snippet1":::
:::code language="vb" source="~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchive/vb/program1.vb" id="Snippet1":::

