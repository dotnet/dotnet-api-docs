When you create a new entry from an existing file by calling the <xref:System.IO.Compression.ZipFileExtensions.CreateEntryFromFile%2A> method, the <xref:System.IO.Compression.ZipArchiveEntry.LastWriteTime%2A> property for the entry is automatically set to the last time the file was modified. When you create a new entry programmatically by calling the <xref:System.IO.Compression.ZipArchive.CreateEntry%2A> method, the <xref:System.IO.Compression.ZipArchiveEntry.LastWriteTime%2A> property for the entry is automatically set to the time of execution. If you modify the entry, you must explicitly set the <xref:System.IO.Compression.ZipArchiveEntry.LastWriteTime%2A> property if you want the value to reflect the time of the latest change.

When you set this property, the <xref:System.DateTimeOffset> value is converted to a timestamp format that is specific to zip archives. This format supports a resolution of two seconds. The earliest permitted value is 1980 January 1 0:00:00 (midnight). The latest permitted value is 2107 December 31 23:59:58 (one second before midnight). If the value for the last write time is not valid, the property returns a default value of 1980 January 1 0:00:00 (midnight).

## Examples

The following example shows how to open an entry in a zip archive, modify it, and set the <xref:System.IO.Compression.ZipArchiveEntry.LastWriteTime%2A> property to the current time.

[!code-csharp[System.IO.Compression.ZipArchiveEntry#2](~/samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.ziparchiveentry/cs/program2.cs#2)]
[!code-vb[System.IO.Compression.ZipArchiveEntry#2](~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchiveentry/vb/program2.vb#2)]
