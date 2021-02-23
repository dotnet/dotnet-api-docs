The <xref:System.Diagnostics.Process.ErrorDataReceived> event indicates that the associated <xref:System.Diagnostics.Process> has written a line that's terminated with a newline (carriage return (CR), line feed (LF), or CR+LF) to its redirected <xref:System.Diagnostics.Process.StandardError%2A> stream.

The event only occurs during asynchronous read operations on <xref:System.Diagnostics.Process.StandardError%2A>. To start asynchronous read operations, you must redirect the <xref:System.Diagnostics.Process.StandardError%2A> stream of a <xref:System.Diagnostics.Process>, add your event handler to the <xref:System.Diagnostics.Process.ErrorDataReceived> event, and call <xref:System.Diagnostics.Process.BeginErrorReadLine%2A>. Thereafter, the <xref:System.Diagnostics.Process.ErrorDataReceived> event signals each time the process writes a line to the redirected <xref:System.Diagnostics.Process.StandardError%2A> stream, until the process exits or calls <xref:System.Diagnostics.Process.CancelErrorRead%2A>.

> [!NOTE]
>  The application that is processing the asynchronous output should call the <xref:System.Diagnostics.Process.WaitForExit> method to ensure that the output buffer has been flushed. Note that specifying a timeout by using the <xref:System.Diagnostics.Process.WaitForExit(System.Int32)> overload does *not* ensure the output buffer has been flushed.

## Examples

The following example uses the `net view` command to list the available network resources on a remote computer. The user supplies the target computer name as a command-line argument. The user can also supply a file name for error output. The example collects the output of the net command, waits for the process to finish, and then writes the output results to the console. If the user supplies the optional error file, the example writes errors to the file.

[!code-cpp[Process_AsyncStreams#2](~/samples/snippets/cpp/VS_Snippets_CLR/process_asyncstreams/CPP/net_async.cpp#2)]
[!code-csharp[Process_AsyncStreams#2](~/samples/snippets/csharp/VS_Snippets_CLR/process_asyncstreams/CS/net_async.cs#2)]
[!code-vb[Process_AsyncStreams#2](~/samples/snippets/visualbasic/VS_Snippets_CLR/process_asyncstreams/VB/net_async.vb#2)]
