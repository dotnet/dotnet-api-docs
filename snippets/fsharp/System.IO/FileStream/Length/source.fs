module source

let func (s: System.IO.FileStream) =
    // <Snippet1>
    if s.Length = s.Position then
        printfn "End of file has been reached."
// </Snippet1>
