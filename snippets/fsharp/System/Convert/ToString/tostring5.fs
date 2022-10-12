module tostring5

// <Snippet26>
open System

type Temperature(temperature: decimal) =
    member _.Celsius =
        temperature

    member _.Kelvin =
        temperature + 273.15m

    member _.Fahrenheit =
        Math.Round(temperature * 9m / 5m + 32m |> decimal, 2)

    override _.ToString() =
        temperature.ToString("N2") + " °C"

let cold = Temperature -40
let freezing = Temperature 0
let boiling = Temperature 100

printfn $"{Convert.ToString(cold, null)}"
printfn $"{Convert.ToString(freezing, null)}"
printfn $"{Convert.ToString(boiling, null)}"
// The example dosplays the following output:
//       -40.00 °C
//       0.00 °C
//       100.00 °C
// </Snippet26>