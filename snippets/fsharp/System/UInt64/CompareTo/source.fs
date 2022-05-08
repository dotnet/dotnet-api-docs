//<snippet3>
open System

type Temperature() =
    // The value holder
    let mutable m_value = 0uL

    interface IComparable with
        /// IComparable.CompareTo implementation.
        member _.CompareTo(obj) =
            match obj with
            | :? Temperature as temp ->
                m_value.CompareTo temp.Value
            | _ ->
                invalidArg "obj" "object is not a Temperature"

    member _.Value
        with get () =
            m_value
        and set (v) =
            m_value <- v
//</snippet3>