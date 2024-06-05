open System.IO
let name = ""
// <Snippet1>
let s2 = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read)
// </Snippet1>
