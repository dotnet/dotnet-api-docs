open System
open System.IO
open System.Reflection

let func (typ: Type) =
    // <Snippet1>
    let cInfo = typ.GetConstructor(BindingFlags.ExactBinding, null, Type.EmptyTypes, null)
    // </Snippet1>
    ()