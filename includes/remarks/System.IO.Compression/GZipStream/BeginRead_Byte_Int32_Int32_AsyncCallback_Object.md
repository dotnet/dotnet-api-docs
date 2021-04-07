Starting with the .NET Framework 4.5, you can perform asynchronous read operations by using the <xref:System.IO.Stream.ReadAsync%2A?displayProperty=nameWithType> method. The <xref:System.IO.Compression.GZipStream.BeginRead%2A> method is still available in .NET Framework 4.5 to support legacy code; however, you can implement asynchronous I/O operations more easily by using the new async methods. For more information, see [Asynchronous File I/O](/dotnet/standard/io/asynchronous-file-i-o).

Pass the <xref:System.IAsyncResult> return value to the <xref:System.IO.Compression.GZipStream.EndRead%2A> method of the stream to determine how many bytes were read and to release operating system resources used for reading. You can do this either by using the same code that called <xref:System.IO.Compression.GZipStream.BeginRead%2A> or in a callback passed to <xref:System.IO.Compression.GZipStream.BeginRead%2A>.

The current position in the stream is updated when the asynchronous read or write is issued, not when the I/O operation completes.

Multiple simultaneous asynchronous requests render the request completion order uncertain.

Use the <xref:System.IO.Compression.GZipStream.CanRead%2A> property to determine whether the current <xref:System.IO.Compression.GZipStream> object supports reading.

If a stream is closed or you pass an invalid argument, exceptions are thrown immediately from <xref:System.IO.Compression.GZipStream.BeginRead%2A>. Errors that occur during an asynchronous read request, such as a disk failure during the I/O request, occur on the thread pool thread and throw exceptions when calling <xref:System.IO.Compression.GZipStream.EndRead%2A>.

## Examples

The following code example shows how to use the <xref:System.IO.Compression.GZipStream> class to compress and decompress a file.

:::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_CLR/IO.Compression.GZip1/CS/gziptest.cs" id="Snippet1":::
:::code language="vb" source="~/samples/snippets/visualbasic/VS_Snippets_CLR/IO.Compression.GZip1/VB/gziptest.vb" id="Snippet1":::
