module Example

// <Snippet5>
open System

type LazyValue<'T>(func: Func<'T>) =
    let mutable value = ValueNone

    member _.Value =
        match value with
        | ValueSome v -> v
        | ValueNone ->
            // Execute the delegate.
            let v = func.Invoke()
            value <- ValueSome v
            v

let expensiveOne () =
    printfn "\nExpensiveOne() is executing."
    1

let expensiveTwo (input: string) =
    printfn "\nExpensiveTwo() is executing."
    int64 input.Length

// Note that each lambda expression has no parameters.
let lazyOne = LazyValue(fun () -> expensiveOne ())
let lazyTwo = LazyValue(fun () -> expensiveTwo "apple")

printfn "LazyValue objects have been created."

// Get the values of the LazyValue objects.
printfn $"{lazyOne.Value}"
printfn $"{lazyTwo.Value}"


// The example produces the following output:
//     LazyValue objects have been created.
//
//     ExpensiveOne() is executing.
//     1
//
//     ExpensiveTwo() is executing.
//     5
// </Snippet5>