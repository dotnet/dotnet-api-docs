When you create a <xref:System.Diagnostics.DataReceivedEventHandler> delegate, you identify the method that will handle the event. To associate the event with your event handler, add an instance of the delegate to the event. The event handler is called whenever the event occurs, unless you remove the delegate. For more information about event-handler delegates, see [Handling and Raising Events](/dotnet/standard/events/).

To asynchronously collect the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> or <xref:System.Diagnostics.Process.StandardError%2A> stream output of a process, add your event handler to the <xref:System.Diagnostics.Process.OutputDataReceived> or <xref:System.Diagnostics.Process.ErrorDataReceived> event. These events are raised each time the process writes a line to the corresponding redirected stream. When the redirected stream is closed, a null line is sent to the event handler. Ensure that your event handler checks for this condition before accessing the <xref:System.Diagnostics.DataReceivedEventArgs.Data%2A> property. For example, you can use the `static` method <xref:System.String.IsNullOrEmpty%2A?displayProperty=nameWithType> to validate the <xref:System.Diagnostics.DataReceivedEventArgs.Data%2A> property in your event handler.

## Examples

The following code example illustrates how to perform asynchronous read operations on the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream of the **sort** command. The **sort** command is a console application that reads and sorts text input.

The example creates a <xref:System.Diagnostics.DataReceivedEventHandler> delegate for the `SortOutputHandler` event handler and associates the delegate with the <xref:System.Diagnostics.Process.OutputDataReceived> event. The event handler receives text lines from the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream, formats the text, and writes the text to the screen.

[!code-cpp[Process_AsyncStreams#1](~/samples/snippets/cpp/VS_Snippets_CLR/process_asyncstreams/CPP/sort_async.cpp#1)]
[!code-csharp[Process_AsyncStreams#1](~/samples/snippets/csharp/VS_Snippets_CLR/process_asyncstreams/CS/sort_async.cs#1)]
[!code-vb[Process_AsyncStreams#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/process_asyncstreams/VB/sort_async.vb#1)]
