// <Snippet1>
open System

let baseUri = Uri "http://www.contoso.com:8080/"
let myUri = Uri(baseUri, "shownew.htm?date=today")

printfn $"{myUri.Authority}"
// </Snippet1>