Use this method to create an array of new <xref:System.Diagnostics.Process> components and associate them with all the process resources that are running the same executable file on the specified computer. The process resources must already exist on the computer, because <xref:System.Diagnostics.Process.GetProcessesByName%2A> does not create system resources but rather associates them with application-generated <xref:System.Diagnostics.Process> components. A `processName` can be specified for an executable file that is not currently running on the local computer, so the array the method returns can be empty.

The process name is a friendly name for the process, such as Outlook, that does not include the .exe extension or the path. <xref:System.Diagnostics.Process.GetProcessesByName%2A> is helpful for getting and manipulating all the processes that are associated with the same executable file. For example, you can pass an executable file name as the `processName` parameter, in order to shut down all the running instances of that executable file.

Although a process <xref:System.Diagnostics.Process.Id%2A> is unique to a single process resource on the system, multiple processes on the local computer can be running the application specified by the `processName` parameter. Therefore, <xref:System.Diagnostics.Process.GetProcessById%2A> returns one process at most, but <xref:System.Diagnostics.Process.GetProcessesByName%2A> returns an array containing all the associated processes. If you need to manipulate the process using standard API calls, you can query each of these processes in turn for its identifier. You cannot access process resources through the process name alone but, once you have retrieved an array of <xref:System.Diagnostics.Process> components that have been associated with the process resources, you can start, terminate, and otherwise manipulate the system resources.

You can use this overload to get processes on the local computer as well as on a remote computer. Use "." to specify the local computer. Another overload exists that uses the local computer by default.

You can access processes on remote computers only to view information, such as statistics, about the processes. You cannot close, terminate (using <xref:System.Diagnostics.Process.Kill%2A>), or start processes on remote computers.

## Examples

The following example retrieves information of the current process, processes running on the local computer, all instances of Notepad running on the local computer, and a specific process on the local computer. It then retrieves information for the same processes on a remote computer.

[!code-cpp[Process.GetProcesses_noexception#1](~/samples/snippets/cpp/VS_Snippets_CLR/Process.GetProcesses_noexception/CPP/processstaticget.cpp#1)]
[!code-csharp[Process.GetProcesses_noexception#1](~/samples/snippets/csharp/VS_Snippets_CLR/Process.GetProcesses_noexception/CS/processstaticget.cs#1)]
[!code-vb[Process.GetProcesses_noexception#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Process.GetProcesses_noexception/VB/processstaticget.vb#1)]

