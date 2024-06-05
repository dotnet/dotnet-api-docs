module NDP_UE_FS

//<Snippet1>
// Example for the Exception.HResult property.
open System

let secondLevelHResult = 0x81234567

// Create the derived exception class.
// Set HResult for this exception, and include it in the exception message.
type SecondLevelException(message, inner) as this =
    inherit Exception($"(HRESULT:0x{secondLevelHResult:X8}) %s{message}", inner)
    do
        this.HResult <- secondLevelHResult

// The following forces a division by 0 and throws a second exception.
try
    try
        let zero = 0
        let ecks = 1 / zero
        ()
    with ex ->
        raise (SecondLevelException("Forced a division by 0 and threw a second exception.", ex) )
with ex ->
    printfn $"{ex}"

// This example of Exception.HResult generates the following output.
//
// NDP_UE_FS+SecondLevelException: (HRESULT:0x81234567) Forced a division by 0 and
//  threw a second exception. ---> System.DivideByZeroException: Attempted to divi
// de by zero.
//    at <StartupCode$fs>.$NDP_UE_FS.main@()
//    --- End of inner exception stack trace ---
//    at <StartupCode$fs>.$NDP_UE_FS.main@()
//</Snippet1>