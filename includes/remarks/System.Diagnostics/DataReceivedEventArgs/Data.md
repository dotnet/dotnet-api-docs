When you redirect the <xref:System.Diagnostics.Process.StandardOutput%2A> or <xref:System.Diagnostics.Process.StandardError%2A> stream of a <xref:System.Diagnostics.Process> to your event handler, an event is raised each time the process writes a line to the redirected stream. The <xref:System.Diagnostics.DataReceivedEventArgs.Data%2A> property is the line that the <xref:System.Diagnostics.Process> wrote to the redirected output stream. Your event handler can use the <xref:System.Diagnostics.DataReceivedEventArgs.Data%2A> property to filter process output or write output to an alternate location. For example, you might create an event handler that stores all error output lines into a designated error log file.

A line is defined as a sequence of characters followed by a line feed ("\n") or a carriage return immediately followed by a line feed ("\r\n"). The line characters are encoded using the default system ANSI code page. The <xref:System.Diagnostics.DataReceivedEventArgs.Data%2A> property does not include the terminating carriage return or line feed.

When the redirected stream is closed, a null line is sent to the event handler. Ensure your event handler checks the <xref:System.Diagnostics.DataReceivedEventArgs.Data%2A> property appropriately before accessing it. For example, you can use the static method <xref:System.String.IsNullOrEmpty%2A?displayProperty=nameWithType> to validate the <xref:System.Diagnostics.DataReceivedEventArgs.Data%2A> property in your event handler.

## Examples

The following code example illustrates a simple event handler associated with the <xref:System.Diagnostics.Process.OutputDataReceived> event. The event handler receives text lines from the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream, formats the text, and writes the text to the screen.

[!code-cpp[Process_AsyncStreams#4](~/samples/snippets/cpp/VS_Snippets_CLR/process_asyncstreams/CPP/datareceivedevent.cpp#4)]
[!code-csharp[Process_AsyncStreams#4](~/samples/snippets/csharp/VS_Snippets_CLR/process_asyncstreams/CS/datareceivedevent.cs#4)]
[!code-vb[Process_AsyncStreams#4](~/samples/snippets/visualbasic/VS_Snippets_CLR/process_asyncstreams/VB/datareceivedevent.vb#4)]

