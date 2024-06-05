//<snippet1>
// Sample for the Environment.ExpandEnvironmentVariables method
open System

let nl = Environment.NewLine

//  <-- Keep this information secure! -->
let query = "My system drive is %SystemDrive% and my system root is %SystemRoot%"
let str = Environment.ExpandEnvironmentVariables query
printfn $"\nExpandEnvironmentVariables: {nl}  {str}"

// This example produces the following results:
//     ExpandEnvironmentVariables:
//       My system drive is C: and my system root is C:\WINNT
//</snippet1>