// <Snippet1>
module Test

open System

// Define a delegate to handle string display.
type CheckAndDisplayDelegate = delegate of string -> unit

type StringContainer() =
    // A generic ResizeArray object that holds the strings.
    let container = ResizeArray()

    // A method that adds strings to the collection.
    member _.AddString(str) =
        container.Add str

    // Iterate through the strings and invoke the method(s) that the delegate points to.
    member _.DisplayAllQualified(displayDelegate: CheckAndDisplayDelegate) =
        for str in container do
            displayDelegate.Invoke str

// This module defines some functions to display strings.
module StringExtensions =
    // Display a string if it starts with a consonant.
    let conStart (str: string) =
        match str[0] with
        | 'a' | 'e' | 'i' | 'o' | 'u' -> ()
        | _ -> printfn $"{str}"
 
    // Display a string if it starts with a vowel.
    let vowelStart (str: string) =
        match str[0] with
        | 'a' | 'e' | 'i' | 'o' | 'u' -> printfn $"{str}"
        | _ -> ()
 
// Demonstrate the use of delegates, including the Remove and
// Combine methods to create and modify delegate combinations.
[<EntryPoint>]
let main _ =
    // Declare the StringContainer class and add some strings
    let container = StringContainer()
    container.AddString "This"
    container.AddString "is"
    container.AddString "a"
    container.AddString "multicast"
    container.AddString "delegate"
    container.AddString "example"

    // Create two delegates individually using different methods.
    let conStart = CheckAndDisplayDelegate StringExtensions.conStart
    let vowelStart = CheckAndDisplayDelegate StringExtensions.vowelStart 

    // Get the list of all delegates assigned to this MulticastDelegate instance.
    let delegateList = conStart.GetInvocationList()
    printfn $"conStart contains {delegateList.Length} delegate(s)."
    let delegateList = vowelStart.GetInvocationList()
    printfn $"vowelStart contains {delegateList.Length} delegate(s).\n"

    // Determine whether the delegates are System.Multicast delegates.
    if box conStart :? System.MulticastDelegate && box vowelStart :? System.MulticastDelegate then
        printfn "conStart and vowelStart are derived from MulticastDelegate.\n"

    // Execute the two delegates.
    printfn "Executing the conStart delegate:"
    container.DisplayAllQualified conStart
    printfn "\nExecuting the vowelStart delegate:"
    container.DisplayAllQualified vowelStart
    printfn ""

    // Create a new MulticastDelegate and call Combine to add two delegates.
    let multipleDelegates =
        Delegate.Combine(conStart, vowelStart) :?> CheckAndDisplayDelegate

    // How many delegates does multipleDelegates contain?
    let delegateList = multipleDelegates.GetInvocationList()
    printfn $"\nmultipleDelegates contains {delegateList.Length} delegates.\n"

    // Pass this multicast delegate to DisplayAllQualified.
    printfn "Executing the multipleDelegate delegate."
    container.DisplayAllQualified multipleDelegates

    // Call remove and combine to change the contained delegates.
    let multipleDelegates = Delegate.Remove(multipleDelegates, vowelStart) :?> CheckAndDisplayDelegate
    let multipleDelegates = Delegate.Combine(multipleDelegates, conStart) :?> CheckAndDisplayDelegate

    // Pass multipleDelegates to DisplayAllQualified again.
    printfn "\nExecuting the multipleDelegate delegate with two conStart delegates:"
    printfn $"{multipleDelegates}"
    0
// The example displays the following output:
//    conStart contains 1 delegate(s).
//    vowelStart contains 1 delegate(s).
//
//    conStart and vowelStart are derived from MulticastDelegate.
//
//    Executing the conStart delegate:
//    This
//    multicast
//    delegate
//
//    Executing the vowelStart delegate:
//    is
//    a
//    example
//
//
//    multipleDelegates contains 2 delegates.
//
//    Executing the multipleDelegate delegate.
//    This
//    is
//    a
//    multicast
//    delegate
//    example
//
//    Executing the multipleDelegate delegate with two conStart delegates:
//    This
//    This
//    multicast
//    multicast
//    delegate
//    delegate
// </Snippet1>