Starting with the [!INCLUDE[net_v45](~/includes/net-v45-md.md)], you can perform asynchronous read operations by using the <xref:System.IO.Stream.ReadAsync%2A> method. The <xref:System.IO.Compression.DeflateStream.BeginRead%2A> method is still available in the [!INCLUDE[net_v45](~/includes/net-v45-md.md)] to support legacy code; however, you can implement asynchronous I/O operations more easily by using the new async methods. For more information, see [Asynchronous File I/O](/dotnet/standard/io/asynchronous-file-i-o).

Pass the <xref:System.IAsyncResult> return value to the <xref:System.IO.Compression.DeflateStream.EndRead%2A> method of the stream to determine how many bytes were read and to release operating system resources used for reading. You can do this either by using the same code that called <xref:System.IO.Compression.DeflateStream.BeginRead%2A> or in a callback passed to <xref:System.IO.Compression.DeflateStream.BeginRead%2A>.

The current position in the stream is updated when the asynchronous read or write operation is issued, not when the I/O operation completes.

Multiple simultaneous asynchronous requests render the request completion order uncertain.

Use the <xref:System.IO.Compression.DeflateStream.CanRead%2A> property to determine whether the current <xref:System.IO.Compression.DeflateStream> object supports reading.

If a stream is closed or you pass an invalid argument, exceptions are thrown immediately from <xref:System.IO.Compression.DeflateStream.BeginRead%2A>. Errors that occur during an asynchronous read request, such as a disk failure during the I/O request, occur on the thread pool thread and throw exceptions when calling <xref:System.IO.Compression.DeflateStream.EndRead%2A>.
