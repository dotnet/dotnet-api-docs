module condition1

// <Snippet1>
open System
open System.Reflection

// Windows DLL (non-.NET assembly)
let filePath = 
    let filePath = Environment.ExpandEnvironmentVariables "%windir%"
    let filePath =
        if not (filePath.Trim().EndsWith @"\") then
            filePath + @"\"
        else filePath
    filePath + @"System32\Kernel32.dll"

try
    Assembly.LoadFile filePath |> ignore
with :? BadImageFormatException as e ->
   printfn $"Unable to load {filePath}."
   printfn $"{e.Message[0 .. e.Message.IndexOf '.']}"

// The example displays an error message like the following:
//       Unable to load C:\WINDOWS\System32\Kernel32.dll.
//       Bad IL format.
// </Snippet1>
