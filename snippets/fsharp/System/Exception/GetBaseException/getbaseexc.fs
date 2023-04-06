module NDP_UE_FS

//<Snippet1>
// Example for the Exception.GetBaseException method.
open System

// Define two derived exceptions to demonstrate nested exceptions.
type SecondLevelException(message, inner: Exception) =
    inherit Exception(message, inner)

type ThirdLevelException(message, inner: Exception) = 
    inherit Exception(message, inner)

printfn 
    """This example of Exception.GetBaseException generates the following output.

The program forces a division by 0, then throws the exception
twice more, using a different derived exception each time.
"""


// This function forces a division by 0 and throws a second exception.
let divideBy0 () =
    try
        let zero = 0
        let ecks = 1 / zero
        ()
    with ex ->
        raise (SecondLevelException("Forced a division by 0 and threw a second exception.", ex) )

// This function catches the exception from the called
// function divideBy0() and throws another in response.
let rethrow () =
    try
        divideBy0 ()
    with ex ->
        raise (ThirdLevelException("Caught the second exception and threw a third in response.", ex) )

try
    // This function calls another that forces a
    // division by 0.
    rethrow ()
with ex ->
    printfn "Unwind the nested exceptions using the InnerException property:\n"

    // This code unwinds the nested exceptions using the
    // InnerException property.
    let mutable current = ex
    while current <> null do
        printfn $"{current}\n"
        current <- current.InnerException

    // Display the innermost exception.
    printfn "Display the base exception using the GetBaseException method:\n"
    printfn $"{ex.GetBaseException()}"


// This example of Exception.GetBaseException generates the following output.
//
// The program forces a division by 0, then throws the exception
// twice more, using a different derived exception each time.
//
// Unwind the nested exceptions using the InnerException property:
//
// NDP_UE_FS+ThirdLevelException: Caught the second exception and threw a third in
//  response. ---> NDP_UE_FS.SecondLevelException: Forced a division by 0 and thre
// w a second exception. ---> System.DivideByZeroException: Attempted to divide by
//  zero.
//    at NDP_UE_FS.divideBy0()
//    --- End of inner exception stack trace ---
//    at NDP_UE_FS.divideBy0()
//    at NDP_UE_FS.rethrow()
//    --- End of inner exception stack trace ---
//    at NDP_UE_FS.rethrow()
//    at<StartupCode$fs>.$NDP_UE_FS.main@()
//
// NDP_UE_FS.SecondLevelException: Forced a division by 0 and threw a second excep
// tion. ---> System.DivideByZeroException: Attempted to divide by zero.
//    at NDP_UE_FS.divideBy0()
//    --- End of inner exception stack trace ---
//    at NDP_UE_FS.divideBy0()
//    at NDP_UE_FS.rethrow()
//
// System.DivideByZeroException: Attempted to divide by zero.
//    at NDP_UE_FS.divideBy0()
//
// Display the base exception using the GetBaseException method:
//
// System.DivideByZeroException: Attempted to divide by zero.
//    at NDP_UE_FS.divideBy0()
//</Snippet1>