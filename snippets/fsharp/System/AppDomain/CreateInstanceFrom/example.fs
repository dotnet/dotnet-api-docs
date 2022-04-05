//<Snippet1>
open System

type ITest =
    abstract Test: string -> unit

type MarshalableExample() =
    inherit MarshalByRefObject()
    
    member _.Test greeting =
        printfn $"{greeting} from '{AppDomain.CurrentDomain.FriendlyName}'!"

    interface ITest with
        member this.Test message = this.Test message 

// Construct a path to the current assembly.
let assemblyPath = 
    Environment.CurrentDirectory + "\\" + typeof<MarshalableExample>.Assembly.GetName().Name + ".exe"

let ad = AppDomain.CreateDomain "MyDomain"

let oh =
    ad.CreateInstanceFrom(assemblyPath, "MarshalableExample")

let obj = oh.Unwrap()

// Three ways to use the newly created object, depending on how
// much is known about the type: Late bound, early bound through
// a mutually known interface, or early binding of a known type.
//
obj.GetType().InvokeMember("Test",
    System.Reflection.BindingFlags.InvokeMethod,
    Type.DefaultBinder, obj, [| box "Hello" |])
|> ignore

let it = obj :?> ITest
it.Test "Hi"

let ex = obj :?> MarshalableExample
ex.Test("Goodbye")

(* This example produces the following output:

Hello from 'MyDomain'!
Hi from 'MyDomain'!
Goodbye from 'MyDomain'!
 *)
//</Snippet1>