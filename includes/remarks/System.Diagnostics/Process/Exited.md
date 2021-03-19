The <xref:System.Diagnostics.Process.Exited> event indicates that the associated process exited. This occurrence means either that the process terminated (aborted) or successfully closed. This event can occur only if the value of the <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> property is `true`.

There are two ways of being notified when the associated process exits: synchronously and asynchronously. Synchronous notification means calling the <xref:System.Diagnostics.Process.WaitForExit%2A> method to block the current thread until the process exits. Asynchronous notification uses the <xref:System.Diagnostics.Process.Exited> event, which allows the calling thread to continue execution in the meantime. In the latter case, <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> must be set to `true` for the calling application to receive the Exited event.

When the operating system shuts down a process, it notifies all other processes that have registered handlers for the Exited event. At this time, the handle of the process that just exited can be used to access some properties such as  <xref:System.Diagnostics.Process.ExitTime%2A> and <xref:System.Diagnostics.Process.HasExited%2A> that the operating system maintains until it releases that handle completely.

> [!NOTE]
>  Even if you have a handle to an exited process, you cannot call <xref:System.Diagnostics.Process.Start%2A> again to reconnect to the same process. Calling <xref:System.Diagnostics.Process.Start%2A> automatically releases the associated process and connects to a process with the same file but an entirely new <xref:System.Diagnostics.Process.Handle%2A>.

For more information about the use of the <xref:System.Diagnostics.Process.Exited> event in Windows Forms applications, see the <xref:System.Diagnostics.Process.SynchronizingObject%2A> property.

## Examples

The following code example creates a process that prints a file. It raises the <xref:System.Diagnostics.Process.Exited> event when the process exits because the <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> property was set when the process was created. The <xref:System.Diagnostics.Process.Exited> event handler displays process information.

[!code-csharp[System.Diagnostics.Process.EnableExited#1](~/samples/snippets/csharp/VS_Snippets_CLR_System/system.Diagnostics.Process.EnableExited/CS/processexitedevent.cs#1)]
[!code-vb[System.Diagnostics.Process.EnableExited#1](~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.Diagnostics.Process.EnableExited/VB/processexitedevent.vb#1)]
