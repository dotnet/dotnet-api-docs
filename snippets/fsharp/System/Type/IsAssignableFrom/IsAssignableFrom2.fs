// <Snippet2>
open System.IO

type GenericWithConstraint<'T when 'T :> Stream>() = class end

let t = typeof<Stream>
let genericT = typeof<GenericWithConstraint<_>>.GetGenericTypeDefinition()
let genericParam = genericT.GetGenericArguments()[0]
printfn $"{t.IsAssignableFrom genericParam}"
// Displays True.
// </Snippet2>