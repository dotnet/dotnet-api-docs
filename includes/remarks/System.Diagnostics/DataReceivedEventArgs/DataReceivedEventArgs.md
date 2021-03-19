To asynchronously collect the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> or <xref:System.Diagnostics.Process.StandardError%2A> stream output of a process, you must create a method that handles the redirected stream output events. The event-handler method is called when the process writes to the redirected stream. The event delegate calls your event handler with an instance of <xref:System.Diagnostics.DataReceivedEventArgs>. The <xref:System.Diagnostics.DataReceivedEventArgs.Data%2A> property contains the text line that the process wrote to the redirected stream.

## Examples

The following code example illustrates how to perform asynchronous read operations on the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream of the `sort` command. The `sort` command is a console application that reads and sorts text input.

The example creates an event delegate for the `SortOutputHandler` event handler and associates it with the <xref:System.Diagnostics.Process.OutputDataReceived> event. The event handler receives text lines from the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream, formats the text, and writes the text to the screen.

[!code-cpp[Process_AsyncStreams#1](~/samples/snippets/cpp/VS_Snippets_CLR/process_asyncstreams/CPP/sort_async.cpp#1)]
[!code-csharp[Process_AsyncStreams#1](~/samples/snippets/csharp/VS_Snippets_CLR/process_asyncstreams/CS/sort_async.cs#1)]
[!code-vb[Process_AsyncStreams#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/process_asyncstreams/VB/sort_async.vb#1)]

