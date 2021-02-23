A value of `true` for <xref:System.Diagnostics.Process.HasExited%2A> indicates that the associated process has terminated, either normally or abnormally. You can request or force the associated process to exit by calling <xref:System.Diagnostics.Process.CloseMainWindow%2A> or <xref:System.Diagnostics.Process.Kill%2A>. If a handle is open to the process, the operating system releases the process memory when the process has exited, but retains administrative information about the process, such as the handle, exit code, and exit time. To get this information, you can use the <xref:System.Diagnostics.Process.ExitCode%2A> and <xref:System.Diagnostics.Process.ExitTime%2A> properties. These properties are populated automatically for processes that were started by this component. The administrative information is released when all the <xref:System.Diagnostics.Process> components that are associated with the system process are destroyed and hold no more handles to the exited process.

A process can terminate independently of your code. If you started the process using this component, the system updates the value of <xref:System.Diagnostics.Process.HasExited%2A> automatically, even if the associated process exits independently.

> [!NOTE]
>  When standard output has been redirected to asynchronous event handlers, it is possible that output processing will not have completed when this property returns `true`. To ensure that asynchronous event handling has been completed, call the <xref:System.Diagnostics.Process.WaitForExit> overload that takes no parameter before checking <xref:System.Diagnostics.Process.HasExited%2A>.

## Examples

The following example starts an instance of Notepad. It then retrieves the physical memory usage of the associated process at 2 second intervals for a maximum of 10 seconds. The example detects whether the process exits before 10 seconds have elapsed. The example closes the process if it is still running after 10 seconds.

[!code-cpp[process_refresh#1](~/samples/snippets/cpp/VS_Snippets_CLR/process_refresh/CPP/process_refresh.cpp#1)]
[!code-csharp[process_refresh#1](~/samples/snippets/csharp/VS_Snippets_CLR/process_refresh/CS/process_refresh.cs#1)]
[!code-vb[process_refresh#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/process_refresh/VB/process_refresh.vb#1)]
