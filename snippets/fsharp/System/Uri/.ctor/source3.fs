module source3

open System

// <Snippet1>
let baseUri = Uri "http://www.contoso.com"
let myUri = Uri(baseUri, "Hello%20World.htm", false)
// </Snippet1>