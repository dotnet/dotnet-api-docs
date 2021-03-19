The process <xref:System.Diagnostics.Process.Id%2A> is not valid if the associated process is not running. Therefore, you should ensure that the process is running before attempting to retrieve the <xref:System.Diagnostics.Process.Id%2A> property. Until the process terminates, the process identifier uniquely identifies the process throughout the system.

You can connect a process that is running on a local or remote computer to a new <xref:System.Diagnostics.Process> instance by passing the process identifier to the <xref:System.Diagnostics.Process.GetProcessById%2A> method. <xref:System.Diagnostics.Process.GetProcessById%2A> is a `static` method that creates a new component and sets the <xref:System.Diagnostics.Process.Id%2A> property for the new <xref:System.Diagnostics.Process> instance automatically.

Process identifiers can be reused by the system. The <xref:System.Diagnostics.Process.Id%2A> property value is unique only while the associated process is running. After the process has terminated, the system can reuse the <xref:System.Diagnostics.Process.Id%2A> property value for an unrelated process.

Because the identifier is unique on the system, you can pass it to other threads as an alternative to passing a <xref:System.Diagnostics.Process> instance. This action can save system resources yet guarantee that the process is correctly identified.

## Examples

The following example demonstrates how to obtain the <xref:System.Diagnostics.Process.Id%2A> for all running instances of an application. The code creates a new instance of Notepad, lists all the instances of Notepad, and then allows the user to enter the <xref:System.Diagnostics.Process.Id%2A> number to remove a specific instance.

[!code-csharp[System.Diagnostics.Process.Id#1](~/samples/snippets/csharp/VS_Snippets_CLR_System/system.Diagnostics.Process.Id/CS/program.cs#1)]
[!code-vb[System.Diagnostics.Process.Id#1](~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.Diagnostics.Process.Id/VB/program.vb#1)]
