module tostringby

// <Snippet1>
type Shade =
    | White = 0
    | Gray = 1
    | Grey = 1
    | Black = 2
// </Snippet1>

let callDefault () =
    // <Snippet2>
    let shadeName = (enum<Shade> 1).ToString()
    // </Snippet2>
    printfn $"{shadeName}"

let callWithFormatString () =
    // <Snippet3>
    let shadeName = (enum<Shade> 1).ToString "F"
    // </Snippet3>
    printfn $"{shadeName}"

callDefault ()
callWithFormatString ()
