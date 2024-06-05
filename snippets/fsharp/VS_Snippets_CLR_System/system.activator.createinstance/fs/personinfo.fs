namespace global

// <Snippet1>
type Person(name) =
    member val Name = name with get, set

    override this.ToString() = this.Name

    new () = Person Unchecked.defaultof<string>

// </Snippet1>
