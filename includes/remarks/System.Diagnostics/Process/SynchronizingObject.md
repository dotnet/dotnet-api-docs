When <xref:System.Diagnostics.EventLog.SynchronizingObject%2A> is `null`, methods that handle the <xref:System.Diagnostics.Process.Exited> event are called on a thread from the system thread pool. For more information about system thread pools, see <xref:System.Threading.ThreadPool>.

When the <xref:System.Diagnostics.Process.Exited> event is handled by a visual Windows Forms component, such as a <xref:System.Windows.Forms.Button>, accessing the component through the system thread pool might not work, or might result in an exception. Avoid this by setting <xref:System.Diagnostics.Process.SynchronizingObject%2A> to a Windows Forms component, which causes the methods handling the <xref:System.Diagnostics.Process.Exited> event to be called on the same thread on which the component was created.

If the <xref:System.Diagnostics.Process> is used inside [!INCLUDE[vsprvslong](~/includes/vsprvslong-md.md)] in a Windows Forms designer, <xref:System.Diagnostics.Process.SynchronizingObject%2A> is automatically set to the control that contains the <xref:System.Diagnostics.Process>. For example, if you place a <xref:System.Diagnostics.Process> on a designer for `Form1` (which inherits from <xref:System.Windows.Forms.Form>) the <xref:System.Diagnostics.Process.SynchronizingObject%2A> property of <xref:System.Diagnostics.Process> is set to the instance of `Form1`:

[!code-cpp[Process_SynchronizingObject#2](~/samples/snippets/cpp/VS_Snippets_CLR/Process_SynchronizingObject/CPP/remarks.cpp#2)]
[!code-csharp[Process_SynchronizingObject#2](~/samples/snippets/csharp/VS_Snippets_CLR/Process_SynchronizingObject/CS/remarks.cs#2)]
[!code-vb[Process_SynchronizingObject#2](~/samples/snippets/visualbasic/VS_Snippets_CLR/Process_SynchronizingObject/VB/remarks.vb#2)]

Typically, this property is set when the component is placed inside a control or form, because those components are bound to a specific thread.

## Examples
[!code-cpp[Process_SynchronizingObject#1](~/samples/snippets/cpp/VS_Snippets_CLR/Process_SynchronizingObject/CPP/process_synchronizingobject.cpp#1)]
[!code-csharp[Process_SynchronizingObject#1](~/samples/snippets/csharp/VS_Snippets_CLR/Process_SynchronizingObject/CS/process_synchronizingobject.cs#1)]
[!code-vb[Process_SynchronizingObject#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Process_SynchronizingObject/VB/process_synchronizingobject.vb#1)]
  
