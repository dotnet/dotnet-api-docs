//<snippet1>
// Sample for the Environment.GetLogicalDrives method
open System

let drives = Environment.GetLogicalDrives()

String.concat ", " drives
|> printfn "\nGetLogicalDrives: %s" 
// This example produces the following results:
//     GetLogicalDrives: A:\, C:\, D:\
//</snippet1>