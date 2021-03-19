The value returned by this property represents the most recently refreshed base priority of the process. To get the most up to date base priority, you need to call <xref:System.Diagnostics.Process.Refresh> method first.

The <xref:System.Diagnostics.Process.BasePriority%2A> of the process is the starting priority for threads created within the associated process. You can view information about the base priority through the System Monitor's Priority Base counter.

Based on the time elapsed or other boosts, the operating system can change the base priority when a process should be placed ahead of others.

The <xref:System.Diagnostics.Process.BasePriority%2A> property lets you view the starting priority assigned to a process. However, because it is read-only, you cannot use the <xref:System.Diagnostics.Process.BasePriority%2A> to set the priority of the process. To change the priority, use the <xref:System.Diagnostics.Process.PriorityClass%2A> property. The <xref:System.Diagnostics.Process.BasePriority%2A> is viewable using the System Monitor, while the <xref:System.Diagnostics.Process.PriorityClass%2A> is not. Both the <xref:System.Diagnostics.Process.BasePriority%2A> and the <xref:System.Diagnostics.Process.PriorityClass%2A> can be viewed programmatically. The following table shows the relationship between <xref:System.Diagnostics.Process.BasePriority%2A> values and <xref:System.Diagnostics.Process.PriorityClass%2A> values.

|BasePriority|PriorityClass|
|------------------|-------------------|
|4|<xref:System.Diagnostics.ProcessPriorityClass.Idle>|
|8|<xref:System.Diagnostics.ProcessPriorityClass.Normal>|
|13|<xref:System.Diagnostics.ProcessPriorityClass.High>|
|24|<xref:System.Diagnostics.ProcessPriorityClass.RealTime>|


## Examples

The following example starts an instance of Notepad. The example then retrieves and displays various properties of the associated process. The example detects when the process exits, and displays the process's exit code.

[!code-cpp[Diag_Process_MemoryProperties64#1](~/samples/snippets/cpp/VS_Snippets_CLR/Diag_Process_MemoryProperties64/CPP/source.cpp#1)]
[!code-csharp[Diag_Process_MemoryProperties64#1](~/samples/snippets/csharp/VS_Snippets_CLR/Diag_Process_MemoryProperties64/CS/source.cs#1)]
[!code-vb[Diag_Process_MemoryProperties64#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Diag_Process_MemoryProperties64/VB/source.vb#1)]
