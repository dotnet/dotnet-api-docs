Use this method to create an array of new <xref:System.Diagnostics.Process> components and associate them with all the process resources on the specified (usually remote) computer. The process resources must already exist on the local computer, because <xref:System.Diagnostics.Process.GetProcesses%2A> does not create system resources but rather associates resources with application-generated <xref:System.Diagnostics.Process> components. Because the operating system itself is running background processes, this array is never empty.

If you do not want to retrieve all the processes running on the computer, you can restrict their number by using the <xref:System.Diagnostics.Process.GetProcessById%2A> or <xref:System.Diagnostics.Process.GetProcessesByName%2A> method. <xref:System.Diagnostics.Process.GetProcessById%2A> creates a <xref:System.Diagnostics.Process> component that is associated with the process identified on the system by the process identifier that you pass to the method. <xref:System.Diagnostics.Process.GetProcessesByName%2A> creates an array of <xref:System.Diagnostics.Process> components whose associated process resources share the executable file you pass to the method.

This overload of the <xref:System.Diagnostics.Process.GetProcesses%2A> method is generally used to retrieve the list of process resources running on a remote computer on the network, but you can specify the local computer by passing ".".

> [!NOTE]
>  Multiple Windows services can be loaded within the same instance of the Service Host process (svchost.exe). GetProcesses does not identify those individual services; for that, see <xref:System.ServiceProcess.ServiceController.GetServices%2A>.

## Examples

The following example retrieves information of the current process, processes running on the local computer, all instances of Notepad running on the local computer, and a specific process on the local computer. It then retrieves information for the same processes on a remote computer.

[!code-cpp[Process.GetProcesses_noexception#1](~/samples/snippets/cpp/VS_Snippets_CLR/Process.GetProcesses_noexception/CPP/processstaticget.cpp#1)]
[!code-csharp[Process.GetProcesses_noexception#1](~/samples/snippets/csharp/VS_Snippets_CLR/Process.GetProcesses_noexception/CS/processstaticget.cs#1)]
[!code-vb[Process.GetProcesses_noexception#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Process.GetProcesses_noexception/VB/processstaticget.vb#1)]
