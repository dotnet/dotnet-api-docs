The `Kill` method forces a termination of the process, while <xref:System.Diagnostics.Process.CloseMainWindow%2A> only requests a termination.
When a process with a graphical interface is executing, its message loop is in a wait state.
The message loop executes every time a Windows message is sent to the process by the operating system.
Calling <xref:System.Diagnostics.Process.CloseMainWindow%2A> sends a request to close the main window, which, in a well-formed application, closes child windows and revokes all running message loops for the application.
The request to exit the process by calling <xref:System.Diagnostics.Process.CloseMainWindow%2A> does not force the application to quit.
The application can ask for user verification before quitting, or it can refuse to quit.
To force the application to quit, use the `Kill` method.

The behavior of <xref:System.Diagnostics.Process.CloseMainWindow%2A> is identical to that of a user closing an application's main window using the system menu.
Therefore, the request to exit the process by closing the main window does not force the application to quit immediately.

> [!NOTE]
> The <xref:System.Diagnostics.Process.Kill%2A> method executes asynchronously.
> After calling the `Kill` method, call the <xref:System.Diagnostics.Process.WaitForExit%2A> method to wait for the process to exit, or check the <xref:System.Diagnostics.Process.HasExited%2A> property to determine if the process has exited.

> [!NOTE]
> The <xref:System.Diagnostics.Process.WaitForExit%2A> method and the <xref:System.Diagnostics.Process.HasExited%2A> property do not reflect the status of descendant processes.
> When `Kill(entireProcessTree: true)` is used, <xref:System.Diagnostics.Process.WaitForExit%2A> and <xref:System.Diagnostics.Process.HasExited%2A> will indicate that exiting has completed after the given process exits, even if all descendants have not yet exited.

Data edited by the process or resources allocated to the process can be lost if you call `Kill`.
`Kill` causes an abnormal process termination and should be used only when necessary.
<xref:System.Diagnostics.Process.CloseMainWindow%2A> enables an orderly termination of the process and closes all windows, so it is preferable for applications with an interface.
If <xref:System.Diagnostics.Process.CloseMainWindow%2A> fails, you can use `Kill` to terminate the process.
`Kill` is the only way to terminate processes that do not have graphical interfaces.

You can call `Kill` and <xref:System.Diagnostics.Process.CloseMainWindow%2A> only for processes that are running on the local computer.
You cannot cause processes on remote computers to exit. You can only view information for processes running on remote computers.
