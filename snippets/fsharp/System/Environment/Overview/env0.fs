//<snippet1>
// Sample for Environment class summary
open System
open System.Collections

let nl = Environment.NewLine

printfn ""
printfn "-- Environment members --"

//  Invoke this sample with an arbitrary set of command line arguments.
printfn $"CommandLine: {Environment.CommandLine}"

Environment.GetCommandLineArgs()
|> String.concat ", "
|> printfn "GetCommandLineArgs: %s"

//  <-- Keep this information secure! -->
printfn $"CurrentDirectory: {Environment.CurrentDirectory}"

printfn $"ExitCode: {Environment.ExitCode}"

printfn $"HasShutdownStarted: {Environment.HasShutdownStarted}"

//  <-- Keep this information secure! -->
printfn $"MachineName: {Environment.MachineName}"

printfn $"NewLine: {nl}  first line{nl}  second line{nl}  third line"

printfn $"OSVersion: {Environment.OSVersion}"

printfn $"StackTrace: '{Environment.StackTrace}'"

//  <-- Keep this information secure! -->
printfn $"SystemDirectory: {Environment.SystemDirectory}"

printfn $"TickCount: {Environment.TickCount}"

//  <-- Keep this information secure! -->
printfn $"UserDomainName: {Environment.UserDomainName}"

printfn $"UserInteractive: {Environment.UserInteractive}"

//  <-- Keep this information secure! -->
printfn $"UserName: {Environment.UserName}"

printfn $"Version: {Environment.Version}"

printfn $"WorkingSet: {Environment.WorkingSet}"

//  No example for Exit(exitCode) because doing so would terminate this example.

//  <-- Keep this information secure! -->
let query = "My system drive is %SystemDrive% and my system root is %SystemRoot%"
let str = Environment.ExpandEnvironmentVariables query
printfn $"ExpandEnvironmentVariables: {nl}  {str}"

printfn $"""GetEnvironmentVariable: {nl}  My temporary directory is {Environment.GetEnvironmentVariable "TEMP"}."""

printfn "GetEnvironmentVariables: "
let environmentVariables = Environment.GetEnvironmentVariables()
for de in environmentVariables do
    let de = de :?> DictionaryEntry
    printfn $"  {de.Key} = {de.Value}"

printfn $"GetFolderPath: {Environment.GetFolderPath Environment.SpecialFolder.System}"

Environment.GetLogicalDrives()
|> String.concat ", "
|> printfn "GetLogicalDrives: %s"

// This example produces results similar to the following:
//     (Any result that is lengthy or reveals information that should remain
//     secure has been omitted and marked "!---OMITTED---!".)
//     
//     C:\>env0 ARBITRARY TEXT
//     
//     -- Environment members --
//     CommandLine: env0 ARBITRARY TEXT
//     GetCommandLineArgs: env0, ARBITRARY, TEXT
//     CurrentDirectory: C:\Documents and Settings\!---OMITTED---!
//     ExitCode: 0
//     HasShutdownStarted: False
//     MachineName: !---OMITTED---!
//     NewLine:
//       first line
//       second line
//       third line
//     OSVersion: Microsoft Windows NT 5.1.2600.0
//     StackTrace: '   at System.Environment.GetStackTrace(Exception e)
//        at System.Environment.GetStackTrace(Exception e)
//        at System.Environment.get_StackTrace()
//        at Sample.Main()'
//     SystemDirectory: C:\WINNT\System32
//     TickCount: 17995355
//     UserDomainName: !---OMITTED---!
//     UserInteractive: True
//     UserName: !---OMITTED---!
//     Version: !---OMITTED---!
//     WorkingSet: 5038080
//     ExpandEnvironmentVariables:
//       My system drive is C: and my system root is C:\WINNT
//     GetEnvironmentVariable:
//       My temporary directory is C:\DOCUME~1\!---OMITTED---!\LOCALS~1\Temp.
//     GetEnvironmentVariables:
//       !---OMITTED---!
//     GetFolderPath: C:\WINNT\System32
//     GetLogicalDrives: A:\, C:\, D:\
//</snippet1>