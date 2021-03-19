The value returned by this property represents the most recently refreshed priority of the process. To get the most up to date priority, you need to call <xref:System.Diagnostics.Process.Refresh> method first.

A process priority class encompasses a range of thread priority levels. Threads with different priorities that are running in the process run relative to the priority class of the process. Win32 uses four priority classes with seven base priority levels per class. These process priority classes are captured in the <xref:System.Diagnostics.ProcessPriorityClass> enumeration, which lets you set the process priority to <xref:System.Diagnostics.ProcessPriorityClass.Idle>, <xref:System.Diagnostics.ProcessPriorityClass.Normal>, <xref:System.Diagnostics.ProcessPriorityClass.High>, <xref:System.Diagnostics.ProcessPriorityClass.AboveNormal>, <xref:System.Diagnostics.ProcessPriorityClass.BelowNormal>, or <xref:System.Diagnostics.ProcessPriorityClass.RealTime>. Based on the time elapsed or other boosts, the base priority level can be changed by the operating system when a process needs to be put ahead of others for access to the processor. In addition, you can set the <xref:System.Diagnostics.Process.PriorityBoostEnabled%2A> to temporarily boost the priority level of threads that have been taken out of the wait state. The priority is reset when the process returns to the wait state.

The <xref:System.Diagnostics.Process.BasePriority%2A> property lets you view the starting priority that is assigned to a process. However, because it is read-only, you cannot use the <xref:System.Diagnostics.Process.BasePriority%2A> property to set the priority of a process. To change the priority, use the <xref:System.Diagnostics.Process.PriorityClass%2A> property, which gets or sets the overall priority category for the process.

The priority class cannot be viewed using System Monitor. The following table shows the relationship between the <xref:System.Diagnostics.Process.BasePriority%2A> and <xref:System.Diagnostics.Process.PriorityClass%2A> values.

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
