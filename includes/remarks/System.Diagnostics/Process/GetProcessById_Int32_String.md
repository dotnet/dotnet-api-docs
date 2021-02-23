Use this method to create a new <xref:System.Diagnostics.Process> component and associate it with a process resource on a remote computer on the network. The process resource must already exist on the specified computer, because <xref:System.Diagnostics.Process.GetProcessById%28System.Int32%2CSystem.String%29> does not create a system resource, but rather associates a resource with an application-generated <xref:System.Diagnostics.Process> component. A process <xref:System.Diagnostics.Process.Id%2A> can be retrieved only for a process that is currently running on the computer. After the process terminates, <xref:System.Diagnostics.Process.GetProcessById%28System.Int32%2CSystem.String%29> throws an exception if you pass it an expired identifier.

On any particular computer, the identifier of a process is unique. <xref:System.Diagnostics.Process.GetProcessById%28System.Int32%2CSystem.String%29> returns one process at most. If you want to get all the processes running a particular application, use <xref:System.Diagnostics.Process.GetProcessesByName%28System.String%29>. If multiple processes exist on the computer running the specified application, <xref:System.Diagnostics.Process.GetProcessesByName%28System.String%29> returns an array containing all the associated processes. You can query each of these processes in turn for its identifier. The process identifier can be viewed in the `Processes` panel of the Windows Task Manager. The `PID` column displays the process identifier that is assigned to a process.

If you do not specify a `machineName`, the local computer is used. Alternatively, you can specify the local computer by setting `machineName` to the value "." or to an empty string ("").

The `processId` parameter is an <xref:System.Int32> (a 32-bit signed integer), although the underlying Windows API uses a `DWORD` (an unsigned 32-bit integer) for similar APIs. This is for historical reasons.

## Examples

The following example retrieves information of the current process, processes running on the local computer, all instances of Notepad running on the local computer, and a specific process on the local computer. It then retrieves information for the same processes on a remote computer.

[!code-cpp[Process.GetProcesses_noexception#1](~/samples/snippets/cpp/VS_Snippets_CLR/Process.GetProcesses_noexception/CPP/processstaticget.cpp#1)]
[!code-csharp[Process.GetProcesses_noexception#1](~/samples/snippets/csharp/VS_Snippets_CLR/Process.GetProcesses_noexception/CS/processstaticget.cs#1)]
[!code-vb[Process.GetProcesses_noexception#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Process.GetProcesses_noexception/VB/processstaticget.vb#1)]
