module remarks

// <Snippet2>
type Base<'T, 'U>() = class end

type G<'T>() = class end

type Derived<'V>() =
    inherit Base<string, 'V>()
    
    [<DefaultValue>]
    val mutable public F : G<Derived<'V>>
// </Snippet2>
