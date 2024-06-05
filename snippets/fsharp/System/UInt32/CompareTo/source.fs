namespace Snippets2

open System

//<snippet2>
type Temperature() =
    // The value holder
    let mutable m_value = 0u

    static member MinValue =
        UInt32.MinValue

    static member MaxValue =
        UInt32.MaxValue

    member _.Value
        with get () =
            m_value
        and set (v) =
            m_value <- v
//</snippet2>

namespace Snippets3

open System
//<snippet3>
type Temperature() = 
    // The value holder
    let mutable m_value = 0u

    member _.Value
        with get () =
            m_value
        and set (v) =
            m_value <- v
   
    interface IComparable with
        /// IComparable.CompareTo implementation.
        member _.CompareTo(obj) =
            match obj with
            | :? Temperature as temp ->
                m_value.CompareTo temp.Value
            | _ ->
                invalidArg "obj" "object is not a Temperature"

//</snippet3>