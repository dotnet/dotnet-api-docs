// <Snippet1>
open System

type Temperature(temperature) =
    override this.ToString() =
        this.ToString "C"

    member _.ToString(format) =
        let format = 
            if String.IsNullOrEmpty format then "G"
            else format

        match format.ToUpper() with
        | "G" | "C" ->
            $"{temperature:N}  °C"
        | "F" ->
            $"{9. * temperature / 5. + 32.:N}  °F"
        | "K" ->
            $"{temperature + 273.15:N}  °K"
        | _ ->
            raise (FormatException $"The '{format}' format specifier is not supported")

    member this.Display([<ParamArray>]formats: string[]) =
        if formats.Length = 0 then
            printfn $"""{this.ToString "G"}"""
        else
            for format in formats do
                try
                    printfn $"{this.ToString format}"
                // If there is an exception, do nothing.
                with _ -> ()
// </Snippet1>

// <Snippet2>
let temp1 = Temperature 100.
let formats = [| "C"; "G"; "F"; "K" |]

// Call Display method with a string array.
printfn "Calling Display with a string array:"
temp1.Display formats

// Call Display method with individual string arguments.
printfn "\nCalling Display with individual arguments:"
temp1.Display("C", "F", "K", "G")

// Call parameterless Display method.
printfn "\nCalling Display with an implicit parameter array:"
temp1.Display()
// The example displays the following output:
//       Calling Display with a string array:
//       100.00  °C
//       100.00  °C
//       212.00  °F
//       373.15  °K
//
//       Calling Display with individual arguments:
//       100.00  °C
//       212.00  °F
//       373.15  °K
//       100.00  °C
//
//       Calling Display with an implicit parameter array:
//       100.00  °C
// </Snippet2>