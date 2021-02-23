<xref:System.Diagnostics.Process.WaitForExit> makes the current thread wait until the associated process terminates.  It should be called after all other methods are called on the process. To avoid blocking the current thread, use the <xref:System.Diagnostics.Process.Exited> event.

This method instructs the <xref:System.Diagnostics.Process> component to wait an infinite amount of time for the process and event handlers to exit. This can cause an application to stop responding. For example, if you call <xref:System.Diagnostics.Process.CloseMainWindow%2A> for a process that has a user interface, the request to the operating system to terminate the associated process might not be handled if the process is written to never enter its message loop.

> [!NOTE]
> In .NET Framework 3.5 and earlier versions, the <xref:System.Diagnostics.Process.WaitForExit> overload waits for <xref:System.Int32.MaxValue> milliseconds (approximately 24 days), not indefinitely. Also, those versions do not wait for the event handlers to exit if the full <xref:System.Int32.MaxValue> time is reached.

This overload ensures that all processing has been completed, including the handling of asynchronous events for redirected standard output. You should use this overload after a call to the <xref:System.Diagnostics.Process.WaitForExit%28System.Int32%29> overload when standard output has been redirected to asynchronous event handlers.

When an associated process exits (that is, when it is shut down by the operation system through a normal or abnormal termination), the system stores administrative information about the process and returns to the component that had called <xref:System.Diagnostics.Process.WaitForExit>. The <xref:System.Diagnostics.Process> component can then access the information, which includes the <xref:System.Diagnostics.Process.ExitTime%2A>, by using the <xref:System.Diagnostics.Process.Handle%2A> to the exited process.

Because the associated process has exited, the <xref:System.Diagnostics.Process.Handle%2A> property of the component no longer points to an existing process resource. Instead, the handle can be used only to access the operating system's information about the process resource. The system is aware of handles to exited processes that have not been released by <xref:System.Diagnostics.Process> components, so it keeps the <xref:System.Diagnostics.Process.ExitTime%2A> and <xref:System.Diagnostics.Process.Handle%2A> information in memory until the <xref:System.Diagnostics.Process> component specifically frees the resources. For this reason, any time you call <xref:System.Diagnostics.Process.Start%2A> for a <xref:System.Diagnostics.Process> instance, call <xref:System.Diagnostics.Process.Close%2A> when the associated process has terminated and you no longer need any administrative information about it. <xref:System.Diagnostics.Process.Close%2A> frees the memory allocated to the exited process.

## Examples

See the Remarks section of the <xref:System.Diagnostics.Process.StandardError%2A> property reference page.
