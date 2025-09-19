//<Snippet1>
open System
open System.Runtime.ExceptionServices

let firstChanceHandler _ (e: FirstChanceExceptionEventArgs) =
    printfn $"FirstChanceException event raised in {AppDomain.CurrentDomain.FriendlyName}: {e.Exception.Message}"

type Worker() =
    inherit MarshalByRefObject()

    let mutable w = Unchecked.defaultof<Worker>

    member _.Initialize(count, max) =
        // Handle the FirstChanceException event in all application domains except
        // AD1.
        if count <> 1 then
            AppDomain.CurrentDomain.FirstChanceException.AddHandler firstChanceHandler

        // Create another application domain, until the maximum is reached.
        // Field w remains null in the last application domain, as a signal
        // to TestException().
        if count < max then
            let next = count + 1
            let ad = AppDomain.CreateDomain("AD" + string next)
            w <-
                ad.CreateInstanceAndUnwrap(typeof<Worker>.Assembly.FullName, "Worker") :?> Worker
            w.Initialize(next, max)

    member _.TestException(handled) =
        // As long as there is another application domain, call TestException() on
        // its Worker object. When the last application domain is reached, throw a
        // handled or unhandled exception.
        if isNull (box w) then
            w.TestException handled
        elif handled then
            try
                raise (ArgumentException $"Thrown in {AppDomain.CurrentDomain.FriendlyName}")
            with :? ArgumentException as ex ->
                printfn $"ArgumentException caught in {AppDomain.CurrentDomain.FriendlyName}: {ex.Message}"
        else
            raise (ArgumentException $"Thrown in {AppDomain.CurrentDomain.FriendlyName}")

AppDomain.CurrentDomain.FirstChanceException.AddHandler firstChanceHandler

// Create a set of application domains, with a Worker object in each one.
// Each Worker object creates the next application domain.
let ad = AppDomain.CreateDomain "AD0"
let w = ad.CreateInstanceAndUnwrap(typeof<Worker>.Assembly.FullName, "Worker") :?> Worker
w.Initialize(0, 3)

printfn "\nThe last application domain throws an exception and catches it:\n"
w.TestException true

try
    printfn "\nThe last application domain throws an exception and does not catch it:\n"
    w.TestException false
with :? ArgumentException as ex ->
    printfn"ArgumentException caught in {AppDomain.CurrentDomain.FriendlyName}: {ex.Message}"

(* This example produces output similar to the following:

The last application domain throws an exception and catches it:

FirstChanceException event raised in AD3: Thrown in AD3
ArgumentException caught in AD3: Thrown in AD3

The last application domain throws an exception and does not catch it:

FirstChanceException event raised in AD3: Thrown in AD3
FirstChanceException event raised in AD2: Thrown in AD3
FirstChanceException event raised in AD0: Thrown in AD3
FirstChanceException event raised in Example.exe: Thrown in AD3
ArgumentException caught in Example.exe: Thrown in AD3
 *)
//</Snippet1>