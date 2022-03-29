module System.String.Class.fs
// <Snippet1>
let characters = "abc\u0000def"
printfn $"{characters.Length}" // Displays 7
// </Snippet1>
