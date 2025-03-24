module source1

// <Snippet1>
type t() =
    static do ()
    new(i: int) = t ()

let p = typeof<t>.GetConstructors()
printfn $"{p.Length}"

for c in p do
    printfn $"{c.IsStatic}"
// </Snippet1>
