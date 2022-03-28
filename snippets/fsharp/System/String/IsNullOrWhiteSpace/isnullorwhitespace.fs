module isnullorwhitespace.fs
open System

let value = ""
(
// <Snippet2>
String.IsNullOrEmpty value || value.Trim().Length = 0
// </Snippet2>
)
|> ignore