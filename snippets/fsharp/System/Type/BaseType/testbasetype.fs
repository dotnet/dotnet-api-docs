module testbasetype

//<Snippet1>
let t = typeof<int>
printfn $"{t} inherits from {t.BaseType}."
//</Snippet1>