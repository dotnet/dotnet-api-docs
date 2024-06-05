//<snippet1>
// Sample for the Environment.StackTrace property
open System

printfn $"\nStackTrace: '{Environment.StackTrace}'"

// This example produces the following results:
//     StackTrace: '   at System.Environment.GetStackTrace(Exception e)
//        at System.Environment.GetStackTrace(Exception e)
//        at System.Environment.get_StackTrace()
//        at <StartupCode$fs>.$Stacktrace.main@()'
//</snippet1>