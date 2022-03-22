open System

let name = "Fred"
// <Snippet9>
String.Format("Name = {0}, hours = {1:hh}", name, DateTime.Now)
// </Snippet9>
|> ignore