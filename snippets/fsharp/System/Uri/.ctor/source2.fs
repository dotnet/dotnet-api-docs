module source2

open System

// <Snippet1>
let baseUri = Uri "http://www.contoso.com"
let myUri = Uri(baseUri, "catalog/shownew.htm")

printfn $"{myUri}"
// </Snippet1>