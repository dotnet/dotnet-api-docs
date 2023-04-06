//<snippet1>
type Complex() =
    member val m_Re = 0. with get, set
    member val m_Im = 0. with get, set

    override this.Equals(ob) =
        match ob with
        | :? Complex as c ->
            this.m_Re = c.m_Re && this.m_Im = c.m_Im
        | _ -> false
        
    override this.GetHashCode() =
        this.m_Re.GetHashCode() ^^^ this.m_Im.GetHashCode()
//</snippet1>