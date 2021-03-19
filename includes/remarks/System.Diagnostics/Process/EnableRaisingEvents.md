The <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> property suggests whether the component should be notified when the operating system has shut down a process. The <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> property is used in asynchronous processing to notify your application that a process has exited. To force your application to synchronously wait for an exit event (which interrupts processing of the application until the exit event has occurred), use the <xref:System.Diagnostics.Process.WaitForExit%2A> method.

> [!NOTE]
> If you're using Visual Studio and double-click a <xref:System.Diagnostics.Process> component in your project, an <xref:System.Diagnostics.Process.Exited> event delegate and event handler are automatically generated. Additional code sets the <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> property to `false`. You must change this property to `true` for your event handler to execute when the associated process exits.

If the component's <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> value is `true`, or when <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> is `false` and a <xref:System.Diagnostics.Process.HasExited%2A> check is invoked by the component, the component can access the administrative information for the associated process. This information remains stored by the operating system and includes the <xref:System.Diagnostics.Process.ExitTime%2A> and the <xref:System.Diagnostics.Process.ExitCode%2A>.

After the associated process exits, the <xref:System.Diagnostics.Process.Handle%2A> of the component no longer points to an existing process resource. Instead, it can only be used to access the operating system's information about the process resource. The operating system is aware that there are handles to exited processes that haven't been released by <xref:System.Diagnostics.Process> components, so it keeps the <xref:System.Diagnostics.Process.ExitTime%2A> and <xref:System.Diagnostics.Process.Handle%2A> information in memory.

There's a cost associated with watching for a process to exit. If <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> is `true`, the <xref:System.Diagnostics.Process.Exited> event is raised when the associated process terminates. Your procedures for the <xref:System.Diagnostics.Process.Exited> event run at that time.

Sometimes, your application starts a process but doesn't require notification of its closure. For example, your application can start Notepad to allow the user to perform text editing but make no further use of the Notepad application. You can choose to avoid notification when the process exits because it's not relevant to the continued operation of your application. Setting <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> to `false` can save system resources.

## Examples

The following code example creates a process that prints a file. It sets the <xref:System.Diagnostics.Process.EnableRaisingEvents%2A> property to cause the process to raise the <xref:System.Diagnostics.Process.Exited> event when it exits. The <xref:System.Diagnostics.Process.Exited> event handler displays process information.

[!code-csharp[System.Diagnostics.Process.EnableExited#1](~/samples/snippets/csharp/VS_Snippets_CLR_System/system.Diagnostics.Process.EnableExited/CS/processexitedevent.cs#1)]
[!code-vb[System.Diagnostics.Process.EnableExited#1](~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.Diagnostics.Process.EnableExited/VB/processexitedevent.vb#1)]
