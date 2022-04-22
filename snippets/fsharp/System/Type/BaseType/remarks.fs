module remarks

// <Snippet1>
type B<'U>() = class end
type C<'T>() = inherit B<'T>()
// </Snippet1>
