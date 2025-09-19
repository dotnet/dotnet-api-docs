// <Snippet1>
open System

let uBuild = UriBuilder "http://www.contoso.com/"
uBuild.Path <- "index.htm"
uBuild.Fragment <- "main"

let myUri = uBuild.Uri
// </Snippet1>