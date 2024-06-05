open System

do
    // <Snippet1>
    let baseUri = Uri "http://www.contoso.com/"
    let myUri = Uri(baseUri, "catalog/shownew.htm?date=today")

    printfn $"{myUri.PathAndQuery}"
    // </Snippet1>

    // <Snippet2>
    let baseUri = Uri "http://www.contoso.com/"
    let myUri = Uri (baseUri, "catalog/shownew.htm?date=today")

    printfn $"{myUri.Query}"
    // </Snippet2>