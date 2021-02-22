<xref:System.Diagnostics.Process.BeginOutputReadLine%2A> starts an asynchronous read operation on the <xref:System.Diagnostics.Process.StandardOutput%2A> stream. <xref:System.Diagnostics.Process.CancelOutputRead%2A> ends the asynchronous read operation.

After canceling, you can resume asynchronous read operations by calling <xref:System.Diagnostics.Process.BeginOutputReadLine%2A> again.

When you call <xref:System.Diagnostics.Process.CancelOutputRead%2A>, all in-progress read operations for <xref:System.Diagnostics.Process.StandardOutput%2A> are completed and then the event handler is disabled. All further redirected output to <xref:System.Diagnostics.Process.StandardOutput%2A> is saved in a buffer. If you re-enable the event handler with a call to <xref:System.Diagnostics.Process.BeginOutputReadLine%2A>, the saved output is sent to the event handler and asynchronous read operations resume. If you want to change the event handler before resuming asynchronous read operations, you must remove the existing event handler before adding the new event handler:

```csharp
// At this point the DataReceivedEventHandler(OutputHandler1)
// has executed a CancelOutputRead.

// Remove the prior event handler.
process.OutputDataReceived -= new DataReceivedEventHandler(OutputHandler1);

// Register a new event handler.
process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler2);

// Call the corresponding BeginOutputReadLine.
process.BeginOutputReadLine();
```

> [!NOTE]
>  You cannot mix asynchronous and synchronous read operations on the redirected <xref:System.Diagnostics.Process.StandardOutput%2A> stream. Once the redirected stream of a <xref:System.Diagnostics.Process> is opened in either asynchronous or synchronous mode, all further read operations on that stream must be in the same mode. If you cancel an asynchronous read operation on <xref:System.Diagnostics.Process.StandardOutput%2A> and then need to read from the stream again, you must use <xref:System.Diagnostics.Process.BeginOutputReadLine%2A> to resume asynchronous read operations. Do not follow <xref:System.Diagnostics.Process.CancelOutputRead%2A> with a call to the synchronous read methods of <xref:System.Diagnostics.Process.StandardOutput%2A> such as <xref:System.IO.StreamReader.Read%2A>, <xref:System.IO.StreamReader.ReadLine%2A>, or <xref:System.IO.StreamReader.ReadToEnd%2A>.


## Examples

The following example starts the `nmake` command with user supplied arguments. The error and output streams are read asynchronously; the collected text lines are displayed to the console as well as written to a log file. If the command output exceeds a specified number of lines, the asynchronous read operations are canceled.

[!code-cpp[Process_AsyncStreams#3](~/samples/snippets/cpp/VS_Snippets_CLR/process_asyncstreams/CPP/nmake_async.cpp#3)]
[!code-csharp[Process_AsyncStreams#3](~/samples/snippets/csharp/VS_Snippets_CLR/process_asyncstreams/CS/nmake_async.cs#3)]
[!code-vb[Process_AsyncStreams#3](~/samples/snippets/visualbasic/VS_Snippets_CLR/process_asyncstreams/VB/nmake_async.vb#3)]  