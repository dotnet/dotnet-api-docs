Starting with the [!INCLUDE[net_v45](~/includes/net-v45-md.md)], you can perform asynchronous write operations by using the <xref:System.IO.Stream.WriteAsync%2A> method. The <xref:System.IO.Compression.DeflateStream.BeginWrite%2A> method is still available in the [!INCLUDE[net_v45](~/includes/net-v45-md.md)] to support legacy code; however, you can implement asynchronous I/O operations more easily by using the new async methods. For more information, see [Asynchronous File I/O](/dotnet/standard/io/asynchronous-file-i-o).

Pass the <xref:System.IAsyncResult> object returned by the current method to <xref:System.IO.Compression.DeflateStream.EndWrite%2A> to ensure that the write completes and frees resources appropriately. You can do this either by using the same code that called <xref:System.IO.Compression.DeflateStream.BeginWrite%2A> or in a callback passed to <xref:System.IO.Compression.DeflateStream.BeginWrite%2A>. If an error occurs during an asynchronous write operation, an exception will not be thrown until <xref:System.IO.Compression.DeflateStream.EndWrite%2A> is called with the <xref:System.IAsyncResult> returned by this method.

If a stream is writable, writing at the end of the stream expands the stream.

The current position in the stream is updated when you issue the asynchronous read or write operation, not when the I/O operation completes. Multiple simultaneous asynchronous requests render the request completion order uncertain.

Use the <xref:System.IO.Compression.DeflateStream.CanWrite%2A> property to determine whether the current <xref:System.IO.Compression.DeflateStream> object supports writing.

If a stream is closed or you pass an invalid argument, exceptions are thrown immediately from <xref:System.IO.Compression.DeflateStream.BeginWrite%2A>. Errors that occur during an asynchronous write request, such as a disk failure during the I/O request, occur on the thread pool thread and throw exceptions when calling <xref:System.IO.Compression.DeflateStream.EndWrite%2A>.
