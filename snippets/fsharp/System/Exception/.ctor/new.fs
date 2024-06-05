module NDP_UE_FS

//<Snippet1>
// Example for the Exception() constructor.
open System

// Derive an exception with a predefined message.
type NotEvenException() =
    inherit Exception "The argument to a function requiring even input is not divisible by 2."

// half throws a base exception if the input is not even.
let half input =
    if input % 2 <> 0 then
        raise (Exception())
    else input / 2

// half2 throws a derived exception if the input is not even.
let half2 input =
    if input % 2 <> 0 then
        raise (NotEvenException())
    else input / 2

// calcHalf calls Half and catches any thrown exceptions.
let calcHalf input =
    try
        let halfInput = half input
        printfn $"Half of {input} is {halfInput}."
    with ex ->
        printfn $"{ex}"

// calcHalf2 calls Half2 and catches any thrown exceptions.
let calcHalf2 input =
    try
        let halfInput = half2 input
        printfn $"Half of {input} is {halfInput}."
    with ex ->
        printfn $"{ex}"

printfn "This example of the Exception() constructor generates the following output." 
printfn "\nHere, an exception is thrown using the \nparameterless constructor of the base class.\n"

calcHalf 12
calcHalf 15

printfn "\nHere, an exception is thrown using the \nparameterless constructor of a derived class.\n"

calcHalf2 24
calcHalf2 27 


// This example of the Exception() constructor generates the following output.
// Here, an exception is thrown using the
// parameterless constructor of the base class.
//
// Half of 12 is 6.
// System.Exception: Exception of type 'System.Exception' was thrown.
//    at NDP_UE_FS.half(Int32 input)
//    at at NDP_UE_FS.calcHalf(Int32 input)
//
// Here, an exception is thrown using the
// parameterless constructor of a derived class.
//
// Half of 24 is 12.
// NDP_UE_FS+NotEvenException: The argument to a function requiring even input is
// not divisible by 2.
//    at NDP_UE_FS.half2(Int32 input)
//    at NDP_UE_FS.calcHalf2(Int32 input)
//</Snippet1>