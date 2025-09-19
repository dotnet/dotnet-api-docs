open System

// <Snippet1>
let baseUri = Uri "http://www.contoso.com:8080/"
let myUri = Uri(baseUri, "shownew.htm?date=today")

printfn $"{myUri.Host}"
// </Snippet1>