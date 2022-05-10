open System
open System.Net

// <Snippet1>
let contoso = Uri "http://www.contoso.com/"

let wr = WebRequest.Create contoso
// </Snippet1>

// <Snippet2>
let uri = Uri "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName"

printfn $"AbsolutePath: {uri.AbsolutePath}"
printfn $"AbsoluteUri: {uri.AbsoluteUri}"
printfn $"DnsSafeHost: {uri.DnsSafeHost}"
printfn $"Fragment: {uri.Fragment}"
printfn $"Host: {uri.Host}"
printfn $"HostNameType: {uri.HostNameType}"
printfn $"IdnHost: {uri.IdnHost}"
printfn $"IsAbsoluteUri: {uri.IsAbsoluteUri}"
printfn $"IsDefaultPort: {uri.IsDefaultPort}"
printfn $"IsFile: {uri.IsFile}"
printfn $"IsLoopback: {uri.IsLoopback}"
printfn $"IsUnc: {uri.IsUnc}"
printfn $"LocalPath: {uri.LocalPath}"
printfn $"OriginalString: {uri.OriginalString}"
printfn $"PathAndQuery: {uri.PathAndQuery}"
printfn $"Port: {uri.Port}"
printfn $"Query: {uri.Query}"
printfn $"Scheme: {uri.Scheme}"
printfn $"""Segments: {String.Join(", ", uri.Segments)}"""
printfn $"UserEscaped: {uri.UserEscaped}"
printfn $"UserInfo: {uri.UserInfo}"

// AbsolutePath: /Home/Index.htm
// AbsoluteUri: https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName
// DnsSafeHost: www.contoso.com
// Fragment: #FragmentName
// Host: www.contoso.com
// HostNameType: Dns
// IdnHost: www.contoso.com
// IsAbsoluteUri: True
// IsDefaultPort: False
// IsFile: False
// IsLoopback: False
// IsUnc: False
// LocalPath: /Home/Index.htm
// OriginalString: https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName
// PathAndQuery: /Home/Index.htm?q1=v1&q2=v2
// Port: 80
// Query: ?q1=v1&q2=v2
// Scheme: https
// Segments: /, Home/, Index.htm
// UserEscaped: False
// UserInfo: user:password

// </Snippet2>