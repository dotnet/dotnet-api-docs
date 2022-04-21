// <Snippet1>
type B<'T, 'U>() = class end
type A<'V>() =
    member _.GetSomething<'X>() =
        B<'V, 'X>()
// </Snippet1>