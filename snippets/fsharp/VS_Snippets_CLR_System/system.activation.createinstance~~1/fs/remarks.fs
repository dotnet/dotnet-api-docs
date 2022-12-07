module remarks

// <Snippet1>
let factory<'T when 'T : (new: unit -> 'T)> =
    new 'T()
// </Snippet1>