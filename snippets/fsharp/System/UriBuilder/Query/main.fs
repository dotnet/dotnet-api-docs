// <snippet1>
open System

let baseUri = UriBuilder "http://www.contoso.com/default.aspx?Param1=7890"
let queryToAppend = "param2=1234"

baseUri.Query <-
    if baseUri.Query <> null && baseUri.Query.Length > 1 then
        // Note: In .NET Core and .NET 5+, you can simplify by removing
        // the call to Substring(), which removes the leading "?" character.
        baseUri.Query.Substring 1 + "&" + queryToAppend 
    else
        queryToAppend 
    // </snippet1>