//<snippet1>
// Sample for Environment class summary
using System;
using System.Collections;

class Sample
{
    public static void Main()
    {
        string str;
        string nl = Environment.NewLine;
        //
        Console.WriteLine();
        Console.WriteLine("-- Environment members --");

        //  Invoke this sample with an arbitrary set of command line arguments.
        Console.WriteLine($"CommandLine: {Environment.CommandLine}");

        string[] arguments = Environment.GetCommandLineArgs();
        Console.WriteLine($"GetCommandLineArgs: {string.Join(", ", arguments)}");

        //  <-- Keep this information secure! -->
        Console.WriteLine($"CurrentDirectory: {Environment.CurrentDirectory}");

        Console.WriteLine($"ExitCode: {Environment.ExitCode}");

        Console.WriteLine($"HasShutdownStarted: {Environment.HasShutdownStarted}");

        //  <-- Keep this information secure! -->
        Console.WriteLine($"MachineName: {Environment.MachineName}");

        Console.WriteLine("NewLine: {0}  first line{0}  second line{0}  third line",
                              Environment.NewLine);

        Console.WriteLine($"OSVersion: {Environment.OSVersion.ToString()}");

        Console.WriteLine($"StackTrace: '{Environment.StackTrace}'");

        //  <-- Keep this information secure! -->
        Console.WriteLine($"SystemDirectory: {Environment.SystemDirectory}");

        Console.WriteLine($"TickCount: {Environment.TickCount}");

        //  <-- Keep this information secure! -->
        Console.WriteLine($"UserDomainName: {Environment.UserDomainName}");

        Console.WriteLine($"UserInteractive: {Environment.UserInteractive}");

        //  <-- Keep this information secure! -->
        Console.WriteLine($"UserName: {Environment.UserName}");

        Console.WriteLine($"Version: {Environment.Version.ToString()}");

        Console.WriteLine($"WorkingSet: {Environment.WorkingSet}");

        //  No example for Exit(exitCode) because doing so would terminate this example.

        //  <-- Keep this information secure! -->
        string query = "My system drive is %SystemDrive% and my system root is %SystemRoot%";
        str = Environment.ExpandEnvironmentVariables(query);
        Console.WriteLine($"ExpandEnvironmentVariables: {nl}  {str}");

        Console.WriteLine($"GetEnvironmentVariable: {nl}  My temporary directory is {Environment.GetEnvironmentVariable("TEMP")}.");

        Console.WriteLine("GetEnvironmentVariables: ");
        IDictionary environmentVariables = Environment.GetEnvironmentVariables();
        foreach (DictionaryEntry de in environmentVariables)
        {
            Console.WriteLine($"  {de.Key} = {de.Value}");
        }

        Console.WriteLine($"GetFolderPath: {Environment.GetFolderPath(Environment.SpecialFolder.System)}");

        string[] drives = Environment.GetLogicalDrives();
        Console.WriteLine($"GetLogicalDrives: {string.Join(", ", drives)}");
    }
}
/*
This example produces results similar to the following:
(Any result that is lengthy or reveals information that should remain
secure has been omitted and marked "!---OMITTED---!".)

C:\>env0 ARBITRARY TEXT

-- Environment members --
CommandLine: env0 ARBITRARY TEXT
GetCommandLineArgs: env0, ARBITRARY, TEXT
CurrentDirectory: C:\Documents and Settings\!---OMITTED---!
ExitCode: 0
HasShutdownStarted: False
MachineName: !---OMITTED---!
NewLine:
  first line
  second line
  third line
OSVersion: Microsoft Windows NT 5.1.2600.0
StackTrace: '   at System.Environment.GetStackTrace(Exception e)
   at System.Environment.GetStackTrace(Exception e)
   at System.Environment.get_StackTrace()
   at Sample.Main()'
SystemDirectory: C:\WINNT\System32
TickCount: 17995355
UserDomainName: !---OMITTED---!
UserInteractive: True
UserName: !---OMITTED---!
Version: !---OMITTED---!
WorkingSet: 5038080
ExpandEnvironmentVariables:
  My system drive is C: and my system root is C:\WINNT
GetEnvironmentVariable:
  My temporary directory is C:\DOCUME~1\!---OMITTED---!\LOCALS~1\Temp.
GetEnvironmentVariables:
  !---OMITTED---!
GetFolderPath: C:\WINNT\System32
GetLogicalDrives: A:\, C:\, D:\

*/
//</snippet1>
