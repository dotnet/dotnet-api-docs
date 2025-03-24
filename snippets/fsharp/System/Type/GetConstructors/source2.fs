module source2

// <Snippet2>
open System.Reflection

type t() =
    static do ()
    new (i: int) = t ()

let p = typeof<t>.GetConstructors(BindingFlags.Public ||| BindingFlags.Static ||| BindingFlags.NonPublic ||| BindingFlags.Instance)
printfn $"{p.Length}"

for c in p do
    printfn $"{c.IsStatic}"
// </Snippet2>