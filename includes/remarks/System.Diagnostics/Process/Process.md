A <xref:System.Diagnostics.Process> component provides access to a process that is running on a computer. A process, in the simplest terms, is a running app. A thread is the basic unit to which the operating system allocates processor time. A thread can execute any part of the code of the process, including parts currently being executed by another thread.

The <xref:System.Diagnostics.Process> component is a useful tool for starting, stopping, controlling, and monitoring apps. You can use the <xref:System.Diagnostics.Process> component, to obtain a list of the processes that are running, or you can start a new process. A <xref:System.Diagnostics.Process> component is used to access system processes. After a <xref:System.Diagnostics.Process> component has been initialized, it can be used to obtain information about the running process. Such information includes the set of threads, the loaded modules (.dll and .exe files), and performance information such as the amount of memory the process is using.

This type implements the <xref:System.IDisposable> interface. When you have finished using the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its <xref:System.IDisposable.Dispose%2A> method in a `try`/`finally` block. To dispose of it indirectly, use a language construct such as `using` (in C#) or `Using` (in Visual Basic). For more information, see the "Using an Object that Implements IDisposable" section in the <xref:System.IDisposable> interface topic.

> [!NOTE]
> 32-bit processes cannot access the modules of a 64-bit process. If you try to get information about a 64-bit process from a 32-bit process, you will get a <xref:System.ComponentModel.Win32Exception> exception. A 64-bit process, on the other hand, can access the modules of a 32-bit process.

The process component obtains information about a group of properties all at once. After the <xref:System.Diagnostics.Process> component has obtained information about one member of any group, it will cache the values for the other properties in that group and not obtain new information about the other members of the group until you call the <xref:System.Diagnostics.Process.Refresh%2A> method. Therefore, a property value is not guaranteed to be any newer than the last call to the <xref:System.Diagnostics.Process.Refresh%2A> method. The group breakdowns are operating-system dependent.

If you have a path variable declared in your system using quotes, you must fully qualify that path when starting any process found in that location. Otherwise, the system will not find the path. For example, if `c:\mypath` is not in your path, and you add it using quotation marks: `path = %path%;"c:\mypath"`, you must fully qualify any process in `c:\mypath` when starting it.

A system process is uniquely identified on the system by its process identifier. Like many Windows resources, a process is also identified by its handle, which might not be unique on the computer. A handle is the generic term for an identifier of a resource. The operating system persists the process handle, which is accessed through the <xref:System.Diagnostics.Process.Handle%2A> property of the <xref:System.Diagnostics.Process> component, even when the process has exited. Thus, you can get the process's administrative information, such as the <xref:System.Diagnostics.Process.ExitCode%2A> (usually either zero for success or a nonzero error code) and the <xref:System.Diagnostics.Process.ExitTime%2A>. Handles are an extremely valuable resource, so leaking handles is more virulent than leaking memory.

> [!NOTE]
> This class contains a link demand and an inheritance demand at the class level that applies to all members. A <xref:System.Security.SecurityException> is thrown when either the immediate caller or the derived class does not have full-trust permission. For details about security demands, see [Link Demands](/dotnet/framework/misc/link-demands).

<a name="Core"></a>
## .NET Core notes
In .NET Framework, the <xref:System.Diagnostics.Process> class by default uses <xref:System.Console> encodings, which are typically code page encodings, for the input, output, and error streams. For example code, on systems whose culture is English (United States), code page 437 is the default encoding for the <xref:System.Console> class. However, .NET Core may make only a limited subset of these encodings available. If this is the case, it uses <xref:System.Text.Encoding.UTF8%2A?displayProperty=nameWithType> as the default encoding.

If a <xref:System.Diagnostics.Process> object depends on specific code page encodings, you can still make them available by doing the following *before* you call any <xref:System.Diagnostics.Process> methods:

1.  Add a reference to the System.Text.Encoding.CodePages.dll assembly to your project.

2.  Retrieve the <xref:System.Text.EncodingProvider> object from the <xref:System.Text.CodePagesEncodingProvider.Instance%2A?displayProperty=nameWithType> property.

3.  Pass the <xref:System.Text.EncodingProvider> object to the <xref:System.Text.Encoding.RegisterProvider%2A?displayProperty=nameWithType> method to make the additional encodings supported by the encoding provider available.

The <xref:System.Diagnostics.Process> class will then automatically use the default system encoding rather than UTF8, provided that you have registered the encoding provider before calling any <xref:System.Diagnostics.Process> methods.


## Examples

The following example uses an instance of the <xref:System.Diagnostics.Process> class to start a process.

[!code-cpp[Process.Start_instance#1](~/samples/snippets/cpp/VS_Snippets_CLR/Process.Start_instance/CPP/processstart.cpp#1)]
[!code-csharp[Process.Start_instance#1](~/samples/snippets/csharp/VS_Snippets_CLR/Process.Start_instance/CS/processstart.cs#1)]
[!code-vb[Process.Start_instance#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Process.Start_instance/VB/processstart.vb#1)]

The following example uses the <xref:System.Diagnostics.Process> class itself and a static <xref:System.Diagnostics.Process.Start%2A> method to start a process.

[!code-cpp[Process.Start_static#1](~/samples/snippets/cpp/VS_Snippets_CLR/Process.Start_static/CPP/processstartstatic.cpp)]
[!code-csharp[Process.Start_static#1](~/samples/snippets/csharp/VS_Snippets_CLR/Process.Start_static/CS/processstartstatic.cs)]
[!code-vb[Process.Start_static#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Process.Start_static/VB/processstartstatic.vb)]

The following F# example defines a `runProc` function that starts a process, captures all output and error information, and records the number of milliseconds that the process has run.  The `runProc` function has three parameters: the name of application to launch, the arguments to supply to the application, and the starting directory.

[!code-fsharp[System.Diagnostics.Process#1](~/samples/snippets/fsharp/VS_Snippets_CLR_System/system.diagnostics.process/fs/Start1.fs#1)]

The code for the `runProc` function was written by [ImaginaryDevelopment](http://fssnip.net/authors/ImaginaryDevelopment) and is available under the [Microsoft Public License](https://opensource.org/licenses/ms-pl).
