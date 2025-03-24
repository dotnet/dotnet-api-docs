module TestValue1

open System

// <Snippet1>
AppContext.SetSwitch("Switch.AmazingLib.ThrowOnException", true)
// </Snippet1>

// <Snippet2>
module AmazingLib =
    let performAnOperation () =
        match AppContext.TryGetSwitch "Switch.AmazingLib.ThrowOnException" with
        | false, _ ->
            // This is the case where the switch value was not set by the application.
            // The library can choose to get the value of shouldThrow by other means.
            // If no overrides or default values are specified, the value should be 'false'.
            // A false value implies the latest behavior.
            ()
        | true, shouldThrow ->
            // The library can use the value of shouldThrow to throw exceptions or not.
            if shouldThrow then
                // old code
                ()
            else
                // new code
                ()
// </Snippet2>

AmazingLib.performAnOperation ()
