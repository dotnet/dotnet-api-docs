open System

// <SnippetHostComparison>
// Demonstrate differences between Host, IdnHost, and DnsSafeHost.

// Example 1: Regular hostname (ASCII).
printfn "Example 1: Regular ASCII hostname"
let uri1 = Uri("http://www.contoso.com:8080/path")
printfn $"  Host:        {uri1.Host}"        // www.contoso.com
printfn $"  IdnHost:     {uri1.IdnHost}"     // www.contoso.com
printfn $"  DnsSafeHost: {uri1.DnsSafeHost}" // www.contoso.com
printfn ""

// Example 2: International domain name (non-ASCII).
printfn "Example 2: International domain name"
let uri2 = Uri("http://münchen.de/path")
printfn $"  Host:        {uri2.Host}"        // münchen.de (original)
printfn $"  IdnHost:     {uri2.IdnHost}"     // xn--mnchen-3ya.de (punycode)
printfn $"  DnsSafeHost: {uri2.DnsSafeHost}" // depends on configuration
printfn ""

// Example 3: IPv6 address without zone ID.
printfn "Example 3: IPv6 address without zone ID"
let uri3 = Uri("http://[::1]:8080/path")
printfn $"  Host:        {uri3.Host}"        // [::1] (with brackets)
printfn $"  IdnHost:     {uri3.IdnHost}"     // ::1 (without brackets)
printfn $"  DnsSafeHost: {uri3.DnsSafeHost}" // ::1 (without brackets)
printfn ""

// Example 4: IPv6 link-local address with zone ID.
printfn "Example 4: IPv6 link-local address with zone ID"
let uri4 = Uri("http://[fe80::1%10]:8080/path")
printfn $"  Host:        {uri4.Host}"        // [fe80::1] (with brackets, no zone ID)
printfn $"  IdnHost:     {uri4.IdnHost}"     // fe80::1%10 (without brackets, with zone ID)
printfn $"  DnsSafeHost: {uri4.DnsSafeHost}" // fe80::1%10 (without brackets, with zone ID)
printfn ""

// Example 5: IPv4 address.
printfn "Example 5: IPv4 address"
let uri5 = Uri("http://192.168.1.1:8080/path")
printfn $"  Host:        {uri5.Host}"        // 192.168.1.1
printfn $"  IdnHost:     {uri5.IdnHost}"     // 192.168.1.1
printfn $"  DnsSafeHost: {uri5.DnsSafeHost}" // 192.168.1.1
// </SnippetHostComparison>
