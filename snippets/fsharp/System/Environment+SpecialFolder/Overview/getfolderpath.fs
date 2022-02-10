//<snippet1>
// Sample for the Environment.GetFolderPath method
open System

printfn $"\nGetFolderPath: {Environment.GetFolderPath Environment.SpecialFolder.System}"
            
// This example produces the following results:
//     GetFolderPath: C:\WINNT\System32
//</snippet1>