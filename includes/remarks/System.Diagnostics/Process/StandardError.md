When a <xref:System.Diagnostics.Process> writes text to its standard error stream, that text is normally displayed on the console. By redirecting the <xref:System.Diagnostics.Process.StandardError%2A> stream, you can manipulate or suppress the error output of a process. For example, you can filter the text, format it differently, or write the output to both the console and a designated log file.

> [!NOTE]
>  To use <xref:System.Diagnostics.Process.StandardError%2A>, you must set <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute%2A?displayProperty=nameWithType> to `false`, and you must set <xref:System.Diagnostics.ProcessStartInfo.RedirectStandardError%2A?displayProperty=nameWithType> to `true`. Otherwise, reading from the <xref:System.Diagnostics.Process.StandardError%2A> stream throws an exception.

The redirected <xref:System.Diagnostics.Process.StandardError%2A> stream can be read synchronously or asynchronously. Methods such as <xref:System.IO.StreamReader.Read%2A>, <xref:System.IO.StreamReader.ReadLine%2A>, and <xref:System.IO.StreamReader.ReadToEnd%2A> perform synchronous read operations on the error output stream of the process. These synchronous read operations do not complete until the associated <xref:System.Diagnostics.Process> writes to its <xref:System.Diagnostics.Process.StandardError%2A> stream, or closes the stream.

In contrast, <xref:System.Diagnostics.Process.BeginErrorReadLine%2A> starts asynchronous read operations on the <xref:System.Diagnostics.Process.StandardError%2A> stream. This method enables a designated event handler for the stream output and immediately returns to the caller, which can perform other work while the stream output is directed to the event handler.

Synchronous read operations introduce a dependency between the caller reading from the <xref:System.Diagnostics.Process.StandardError%2A> stream and the child process writing to that stream. These dependencies can result in deadlock conditions. When the caller reads from the redirected stream of a child process, it is dependent on the child. The caller waits on the read operation until the child writes to the stream or closes the stream. When the child process writes enough data to fill its redirected stream, it is dependent on the parent. The child process waits on the next write operation until the parent reads from the full stream or closes the stream. The deadlock condition results when the caller and child process wait on each other to complete an operation, and neither can proceed. You can avoid deadlocks by evaluating dependencies between the caller and child process.

The last two examples in this section use the <xref:System.Diagnostics.Process.Start%2A> method to launch an executable named *Write500Lines.exe*. The following example contains its source code.

[!code-csharp[Executable launched by Process.Start](~/samples/snippets/csharp/api/system.diagnostics/process/standardoutput/write500lines.cs)]
[!code-vb[Executable launched by Process.Start](~/samples/snippets/visualbasic/api/system.diagnostics/process/standardoutput/write500lines.vb)]

The following example shows how to read from a redirected error stream and wait for the child process to exit. It avoids a deadlock condition by calling `p.StandardError.ReadToEnd` before `p.WaitForExit`. A deadlock condition can result if the parent process calls `p.WaitForExit` before `p.StandardError.ReadToEnd` and the child process writes enough text to fill the redirected stream. The parent process would wait indefinitely for the child process to exit. The child process would wait indefinitely for the parent to read from the full <xref:System.Diagnostics.Process.StandardError%2A> stream.

[!code-csharp[Reading from the error stream](~/samples/snippets/csharp/api/system.diagnostics/process/standarderror/stderror-sync.cs)]
[!code-vb[Reading from the error stream](~/samples/snippets/visualbasic/api/system.diagnostics/process/standarderror/stderror-sync.vb)]

There is a similar issue when you read all text from both the standard output and standard error streams. The following example performs a read operation on both streams. It avoids the deadlock condition by performing asynchronous read operations on the <xref:System.Diagnostics.Process.StandardError%2A> stream. A deadlock condition results if the parent process calls `p.StandardOutput.ReadToEnd` followed by `p.StandardError.ReadToEnd` and the child process writes enough text to fill its error stream. The parent process would wait indefinitely for the child process to close its <xref:System.Diagnostics.Process.StandardOutput%2A> stream. The child process would wait indefinitely for the parent to read from the full <xref:System.Diagnostics.Process.StandardError%2A> stream.
[!code-csharp[Reading from both streams](~/samples/snippets/csharp/api/system.diagnostics/process/standardoutput/stdoutput-async.cs)]
[!code-vb[Reading from both streams](~/samples/snippets/visualbasic/api/system.diagnostics/process/standardoutput/stdoutput-async.vb)]

You can use asynchronous read operations to avoid these dependencies and their deadlock potential. Alternately, you can avoid the deadlock condition by creating two threads and reading the output of each stream on a separate thread.

> [!NOTE]
>  You cannot mix asynchronous and synchronous read operations on a redirected stream. Once the redirected stream of a <xref:System.Diagnostics.Process> is opened in either asynchronous or synchronous mode, all further read operations on that stream must be in the same mode. For example, do not follow <xref:System.Diagnostics.Process.BeginErrorReadLine%2A> with a call to <xref:System.IO.StreamReader.ReadLine%2A> on the <xref:System.Diagnostics.Process.StandardError%2A> stream, or vice versa. However, you can read two different streams in different modes. For example, you can call <xref:System.Diagnostics.Process.BeginOutputReadLine%2A> and then call <xref:System.IO.StreamReader.ReadLine%2A> for the <xref:System.Diagnostics.Process.StandardError%2A> stream.

## Examples

The following example uses the `net use` command together with a user supplied argument to map a network resource. It then reads the standard error stream of the net command and writes it to console.

[!code-cpp[Process_StandardError#1](~/samples/snippets/cpp/VS_Snippets_CLR/Process_StandardError/CPP/source.cpp#1)]
[!code-csharp[Process_StandardError#1](~/samples/snippets/csharp/VS_Snippets_CLR/Process_StandardError/CS/source.cs#1)]
[!code-vb[Process_StandardError#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Process_StandardError/VB/source.vb#1)]
 