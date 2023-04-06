// <Snippet1>
module Example
// Declare InnerClass as sealed.
[<Sealed>]
type InnerClass() = class end

let inner = InnerClass()
// Get the type of InnerClass.
let innerType = inner.GetType()
// Get the IsSealed property of  innerClass.
let isSealed = innerType.IsSealed
printfn $"{innerType.FullName} is sealed: {isSealed}."
// The example displays the following output:
//        Example+InnerClass is sealed: True.
// </Snippet1>