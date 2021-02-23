Use <xref:System.Diagnostics.Process.ExitCode%2A> to get the status that the system process returned when it exited. You can use the exit code much like an integer return value from a `main()` procedure.

The <xref:System.Diagnostics.Process.ExitCode%2A> value for a process reflects the specific convention implemented by the application developer for that process. If you use the exit code value to make decisions in your code, be sure that you know the exit code convention used by the application process.

Developers usually indicate a successful exit by an <xref:System.Diagnostics.Process.ExitCode%2A> value of zero, and designate errors by nonzero values that the calling method can use to identify the cause of an abnormal process termination. It is not necessary to follow these guidelines, but they are the convention.

If you try to get the <xref:System.Diagnostics.Process.ExitCode%2A> before the process has exited, the attempt throws an exception. Examine the <xref:System.Diagnostics.Process.HasExited%2A> property first to verify whether the associated process has terminated.

> [!NOTE]
>  When standard output has been redirected to asynchronous event handlers, it is possible that output processing will not have completed when <xref:System.Diagnostics.Process.HasExited%2A> returns `true`. To ensure that asynchronous event handling has been completed, call the <xref:System.Diagnostics.Process.WaitForExit> overload that takes no parameter before checking <xref:System.Diagnostics.Process.HasExited%2A>.

You can use the <xref:System.Diagnostics.Process.CloseMainWindow%2A> or the <xref:System.Diagnostics.Process.Kill%2A> method to cause an associated process to exit.

There are two ways of being notified when the associated process exits: synchronously and asynchronously. Synchronous notification relies on calling the <xref:System.Diagnostics.Process.WaitForExit%2A> method to pause the processing of your application until the associated component exits. Asynchronous notification relies on the <xref:System.Diagnostics.Process.Exited> event. When using asynchronous notification, <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> must be set to `true` for the <xref:System.Diagnostics.Process> component to receive notification that the process has exited.

## Examples

The following example starts an instance of Notepad. The example then retrieves and displays various properties of the associated process. The example detects when the process exits, and displays the process's exit code.

[!code-cpp[Diag_Process_MemoryProperties64#1](~/samples/snippets/cpp/VS_Snippets_CLR/Diag_Process_MemoryProperties64/CPP/source.cpp#1)]
[!code-csharp[Diag_Process_MemoryProperties64#1](~/samples/snippets/csharp/VS_Snippets_CLR/Diag_Process_MemoryProperties64/CS/source.cs#1)]
[!code-vb[Diag_Process_MemoryProperties64#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Diag_Process_MemoryProperties64/VB/source.vb#1)]
