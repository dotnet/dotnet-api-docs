The <xref:System.Diagnostics.Process.OutputDataReceived> event indicates that the associated <xref:System.Diagnostics.Process> has written a line that's terminated with a newline (carriage return (CR), line feed (LF), or CR+LF) to its redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream.

The event is enabled during asynchronous read operations on <xref:System.Diagnostics.Process.StandardOutput%2A>. To start asynchronous read operations, you must redirect the <xref:System.Diagnostics.Process.StandardOutput%2A> stream of a <xref:System.Diagnostics.Process>, add your event handler to the <xref:System.Diagnostics.Process.OutputDataReceived> event, and call <xref:System.Diagnostics.Process.BeginOutputReadLine%2A>. Thereafter, the <xref:System.Diagnostics.Process.OutputDataReceived> event signals each time the process writes a line to the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream, until the process exits or calls <xref:System.Diagnostics.Process.CancelOutputRead%2A>.

> [!NOTE]
>  The application that is processing the asynchronous output should call the <xref:System.Diagnostics.Process.WaitForExit%2A> method to ensure that the output buffer has been flushed.

## Examples
The following example illustrates how to perform asynchronous read operations on the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream of the `ipconfig` command.

The example creates an event delegate for the `OutputHandler` event handler and associates it with the <xref:System.Diagnostics.Process.OutputDataReceived> event. The event handler receives text lines from the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream, formats the text, and saves it in an output string that's later shown in the example's console window.

[!code-cpp[Process_AsyncStreams#4](~/samples/snippets/cpp/VS_Snippets_CLR/process_asyncstreams/CPP/datareceivedevent.cpp#4)]
[!code-csharp[Process_AsyncStreams#4](~/samples/snippets/csharp/VS_Snippets_CLR/process_asyncstreams/CS/datareceivedevent.cs#4)]
[!code-vb[Process_AsyncStreams#4](~/samples/snippets/visualbasic/VS_Snippets_CLR/process_asyncstreams/VB/datareceivedevent.vb#4)]
