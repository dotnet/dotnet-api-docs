Use this overload to create a new process and its primary thread by specifying its file name, command-line arguments, user name, password, and domain. The new process then runs the specified executable file in the security context of the specified credentials (user, domain, and password).

> [!NOTE]
>  When the executable file is located on a remote drive, you must identify the network share by using a uniform resource identifier (URI), not a linked drive letter.

> [!NOTE]
>  If the address of the executable file to start is a URL, the process is not started and `null` is returned.

This overload lets you start a process without first creating a new <xref:System.Diagnostics.Process> instance. The overload is an alternative to the explicit steps of creating a new <xref:System.Diagnostics.Process> instance, setting the <xref:System.Diagnostics.ProcessStartInfo.FileName%2A>, <xref:System.Diagnostics.ProcessStartInfo.Arguments%2A>, <xref:System.Diagnostics.ProcessStartInfo.UserName%2A>, <xref:System.Diagnostics.ProcessStartInfo.Password%2A>, and <xref:System.Diagnostics.ProcessStartInfo.Domain%2A> properties of the <xref:System.Diagnostics.Process.StartInfo%2A> property, and calling <xref:System.Diagnostics.Process.Start%2A> for the <xref:System.Diagnostics.Process> instance.

Similarly, in the same way that the **Run** dialog box can accept an executable file name with or without the .exe extension, the .exe extension is optional in the `fileName` parameter. For example, you can set the `fileName` parameter to either "Notepad.exe" or "Notepad". If the `fileName` parameter represents an executable file, the `arguments` parameter might represent a file to act upon, such as the text file in `Notepad.exe myfile.txt`.

> [!NOTE]
>  The file name must represent an executable file in the <xref:System.Diagnostics.Process.Start%2A> overloads that have `userName`, `password`, and `domain` parameters.

Whenever you use <xref:System.Diagnostics.Process.Start%2A> to start a process, you might need to close it or you risk losing system resources. Close processes using <xref:System.Diagnostics.Process.CloseMainWindow%2A> or <xref:System.Diagnostics.Process.Kill%2A>. You can check whether a process has already been closed by using its <xref:System.Diagnostics.Process.HasExited%2A> property.
