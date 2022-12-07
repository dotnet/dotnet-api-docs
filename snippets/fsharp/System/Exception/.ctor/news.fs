module NDP_UE_FS_2

//<Snippet2>
// Example for the Exception(string) constructor.
open System

let notEvenMessage = "The argument to a function requiring even input is not divisible by 2."

// Derive an exception with a specifiable message.
type NotEvenException =
    inherit Exception
    new () = { inherit Exception(notEvenMessage) }
    new (auxMessage) = { inherit Exception($"{auxMessage} - {notEvenMessage}") }

// half throws a base exception if the input is not even.
let half input =
    if input % 2 <> 0 then
        raise (Exception $"The argument {input} is not divisible by 2.")
    else input / 2

// half2 throws a derived exception if the input is not even.
let half2 input =
    if input % 2 <> 0 then
        raise (NotEvenException $"Invalid argument: {input}")
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

printfn "This example of the Exception(string)\nconstructor generates the following output."
printfn "\nHere, an exception is thrown using the \nconstructor of the base class.\n"

calcHalf 18
calcHalf 21

printfn "\nHere, an exception is thrown using the \nconstructor of a derived class.\n"

calcHalf2 30
calcHalf2 33


// This example of the Exception(string)
// constructor generates the following output.
//
// Here, an exception is thrown using the
// constructor of the base class.
//
// Half of 18 is 9.
// System.Exception: The argument 21 is not divisible by 2.
//    at NDP_UE_FS_2.half(Int32 input)
//    at NDP_UE_FS_2.calcHalf(Int32 input)
//
// Here, an exception is thrown using the
// constructor of a derived class.
//
// Half of 30 is 15.
// NDP_UE_FS_2+NotEvenException: Invalid argument: 33 - The argument to a function r
// equiring even input is not divisible by 2.
//    at NDP_UE_FS_2.half2(Int32 input)
//    at NDP_UE_FS_2.calcHalf2(Int32 input)
//</Snippet2>