module issubclassof_interface1

// <Snippet1>
type IInterface =
    abstract Display : unit -> unit

type Implementation() =
    interface IInterface with
        member _.Display() = printfn "The implementation..."

printfn $"Implementation is a subclass of IInterface:   {typeof<Implementation>.IsSubclassOf typeof<IInterface>}"
printfn $"IInterface is assignable from Implementation: {typeof<IInterface>.IsAssignableFrom typeof<Implementation>}"
// The example displays the following output:
//       Implementation is a subclass of IInterface:   False
//       IInterface is assignable from Implementation: True
// </Snippet1>
