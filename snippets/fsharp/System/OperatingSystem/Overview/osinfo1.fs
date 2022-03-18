// <Snippet1>
open System

let os = Environment.OSVersion
printfn "Current OS Information:\n"
printfn $"Platform: {os.Platform:G}"
printfn $"Version String: {os.VersionString}"
printfn $"Version Information:"
printfn $"   Major: {os.Version.Major}"
printfn $"   Minor: {os.Version.Minor}"
printfn $"Service Pack: '{os.ServicePack}'"
// If run on a Windows 8.1 system, the example displays output like the following:
//       Current OS Information:
//
//       Platform: Win32NT
//       Version String: Microsoft Windows NT 6.2.9200.0
//       Version Information:
//          Major: 6
//          Minor: 2
//       Service Pack: ''
// If run on a Windows 7 system, the example displays output like the following:
//       Current OS Information:
//
//       Platform: Win32NT
//       Version String: Microsoft Windows NT 6.1.7601 Service Pack 1
//       Version Information:
//          Major: 6
//          Minor: 1
//       Service Pack: 'Service Pack 1'
// </Snippet1>