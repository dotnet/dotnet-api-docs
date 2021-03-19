Use this overload to start a process resource by specifying its file name. The overload associates the resource with a new <xref:System.Diagnostics.Process> object.

> [!NOTE]
>  If the address of the executable file to start is a URL, the process is not started and `null` is returned.

This overload lets you start a process without first creating a new <xref:System.Diagnostics.Process> instance. The overload is an alternative to the explicit steps of creating a new <xref:System.Diagnostics.Process> instance, setting the <xref:System.Diagnostics.ProcessStartInfo.FileName%2A> member of the <xref:System.Diagnostics.Process.StartInfo%2A> property, and calling <xref:System.Diagnostics.Process.Start%2A> for the <xref:System.Diagnostics.Process> instance.

You can start a ClickOnce application by setting the `fileName` parameter to the location (for example, a Web address) from which you originally installed the application. Do not start a ClickOnce application by specifying its installed location on your hard drive.

Starting a process by specifying its file name is similar to typing the information in the `Run` dialog box of the Windows `Start` menu. Therefore, the file name does not need to represent an executable file. It can be of any file type for which the extension has been associated with an application installed on the system. For example the file name can have a .txt extension if you have associated text files with an editor, such as Notepad, or it can have a .doc if you have associated .doc files with a word processing tool, such as Microsoft Word. Similarly, in the same way that the `Run` dialog box can accept an executable file name with or without the .exe extension, the .exe extension is optional in the `fileName` parameter. For example, you can set the `fileName` parameter to either "Notepad.exe" or "Notepad".

This overload does not allow command-line arguments for the process. If you need to specify one or more command-line arguments for the process, use the <xref:System.Diagnostics.Process.Start%28System.Diagnostics.ProcessStartInfo%29?displayProperty=nameWithType> or <xref:System.Diagnostics.Process.Start%28System.String%2CSystem.String%29?displayProperty=nameWithType> overloads.

Unlike the other overloads, the overload of <xref:System.Diagnostics.Process.Start%2A> that has no parameters is not a `static` member. Use that overload when you have already created a <xref:System.Diagnostics.Process> instance and specified start information (including the file name), and you want to start a process resource and associate it with the existing <xref:System.Diagnostics.Process> instance. Use one of the `static` overloads when you want to create a new <xref:System.Diagnostics.Process> component rather than start a process for an existing component. Both this overload and the overload that has no parameters allow you to specify the file name of the process resource to start.

If you have a path variable declared in your system using quotes, you must fully qualify that path when starting any process found in that location. Otherwise, the system will not find the path. For example, if `c:\mypath` is not in your path, and you add it using quotation marks: `path = %path%;"c:\mypath"`, you must fully qualify any process in `c:\mypath` when starting it.

> [!NOTE]
>  ASP.NET Web page and server control code executes in the context of the ASP.NET worker process on the Web server.  If you use the <xref:System.Diagnostics.Process.Start%2A> method in an ASP.NET Web page or server control, the new process executes on the Web server with restricted permissions. The process does not start in the same context as the client browser, and does not have access to the user desktop.

Whenever you use <xref:System.Diagnostics.Process.Start%2A> to start a process, you might need to close it or you risk losing system resources. Close processes using <xref:System.Diagnostics.Process.CloseMainWindow%2A> or <xref:System.Diagnostics.Process.Kill%2A>. You can check whether a process has already been closed by using its <xref:System.Diagnostics.Process.HasExited%2A> property.

A note about apartment states in managed threads is necessary here. When <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute%2A> is `true` on the process component's <xref:System.Diagnostics.Process.StartInfo%2A> property, make sure you have set a threading model on your application by setting the attribute `[STAThread]` on the `main()` method. Otherwise, a managed thread can be in an `unknown` state or put in the `MTA` state, the latter of which conflicts with <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute%2A> being `true`. Some methods require that the apartment state not be `unknown`. If the state is not explicitly set, when the application encounters such a method, it defaults to `MTA`, and once set, the apartment state cannot be changed. However, `MTA` causes an exception to be thrown when the operating system shell is managing the thread.

## Examples

The following example first spawns an instance of Internet Explorer and displays the contents of the Favorites folder in the browser. It then starts some other instances of Internet Explorer and displays some specific pages or sites. Finally it starts Internet Explorer with the window being minimized while navigating to a specific site.

[!code-cpp[Process.Start_static#1](~/samples/snippets/cpp/VS_Snippets_CLR/Process.Start_static/CPP/processstartstatic.cpp)]
[!code-csharp[Process.Start_static#1](~/samples/snippets/csharp/VS_Snippets_CLR/Process.Start_static/CS/processstartstatic.cs)]
[!code-vb[Process.Start_static#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Process.Start_static/VB/processstartstatic.vb)]
