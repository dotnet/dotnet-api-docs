The <xref:System.Diagnostics.Process.StandardError%2A> stream can be read synchronously or asynchronously. Methods such as <xref:System.IO.StreamReader.Read%2A>, <xref:System.IO.StreamReader.ReadLine%2A>, and <xref:System.IO.StreamReader.ReadToEnd%2A> perform synchronous read operations on the error output stream of the process. These synchronous read operations do not complete until the associated <xref:System.Diagnostics.Process> writes to its <xref:System.Diagnostics.Process.StandardError%2A> stream, or closes the stream.

In contrast, <xref:System.Diagnostics.Process.BeginErrorReadLine%2A> starts asynchronous read operations on the <xref:System.Diagnostics.Process.StandardError%2A> stream. This method enables the designated event handler for the stream output and immediately returns to the caller, which can perform other work while the stream output is directed to the event handler.

Follow these steps to perform asynchronous read operations on <xref:System.Diagnostics.Process.StandardError%2A> for a <xref:System.Diagnostics.Process>:

1. Set <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute%2A> to `false`.

2. Set <xref:System.Diagnostics.ProcessStartInfo.RedirectStandardError%2A> to `true`.

3. Add your event handler to the <xref:System.Diagnostics.Process.ErrorDataReceived> event. The event handler must match the <xref:System.Diagnostics.DataReceivedEventHandler?displayProperty=nameWithType> delegate signature.

4. Start the <xref:System.Diagnostics.Process>.

5. Call <xref:System.Diagnostics.Process.BeginErrorReadLine%2A> for the <xref:System.Diagnostics.Process>. This call starts asynchronous read operations on <xref:System.Diagnostics.Process.StandardError%2A>.

When asynchronous read operations start, the event handler is called each time the associated <xref:System.Diagnostics.Process> writes a line of text to its <xref:System.Diagnostics.Process.StandardError%2A> stream.

You can cancel an asynchronous read operation by calling <xref:System.Diagnostics.Process.CancelErrorRead%2A>. The read operation can be canceled by the caller or by the event handler. After canceling, you can call <xref:System.Diagnostics.Process.BeginErrorReadLine%2A> again to resume asynchronous read operations.

> [!NOTE]
> You cannot mix asynchronous and synchronous read operations on a redirected stream. Once the redirected stream of a <xref:System.Diagnostics.Process> is opened in either asynchronous or synchronous mode, all further read operations on that stream must be in the same mode. For example, do not follow <xref:System.Diagnostics.Process.BeginErrorReadLine%2A> with a call to <xref:System.IO.StreamReader.ReadLine%2A> on the <xref:System.Diagnostics.Process.StandardError%2A> stream, or vice versa. However, you can read two different streams in different modes. For example, you can call <xref:System.Diagnostics.Process.BeginErrorReadLine%2A> and then call <xref:System.IO.StreamReader.ReadLine%2A> for the <xref:System.Diagnostics.Process.StandardOutput%2A> stream.


## Examples

The following example uses the `net view` command to list the available network resources on a remote computer. The user supplies the target computer name as a command-line argument. The user can also supply a file name for error output. The example collects the output of the net command, waits for the process to finish, and then writes the output results to the console. If the user supplies the optional error file, the example writes errors to the file.

[!code-cpp[Process_AsyncStreams#2](~/samples/snippets/cpp/VS_Snippets_CLR/process_asyncstreams/CPP/net_async.cpp#2)]
[!code-csharp[Process_AsyncStreams#2](~/samples/snippets/csharp/VS_Snippets_CLR/process_asyncstreams/CS/net_async.cs#2)]
[!code-vb[Process_AsyncStreams#2](~/samples/snippets/visualbasic/VS_Snippets_CLR/process_asyncstreams/VB/net_async.vb#2)]
