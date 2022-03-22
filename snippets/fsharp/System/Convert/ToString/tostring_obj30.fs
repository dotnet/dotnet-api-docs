module tostring_obj30

// <Snippet30>
open System

[<AllowNullLiteral>]
type TemperatureProvider() =
    let fmtStrings = [| "C"; "G"; "F"; "K" |]
    let rnd = Random()

    member _.Format =
        fmtStrings[rnd.Next(0, fmtStrings.Length)]

    interface IFormatProvider with
        member this.GetFormat(formatType: Type) =
            this

type Temperature(temperature: decimal) =
    member _.Celsius =
        temperature
    member _.Kelvin =
        temperature + 273.15m

    member _.Fahrenheit =
        Math.Round(temperature * 9m / 5m + 32m, 2)

    override this.ToString() =
        this.ToString("G", null)

    member this.ToString(fmt: string, provider: IFormatProvider) =
        let formatter =
            match provider with
            | null -> null
            | _ ->
                match provider.GetFormat typeof<TemperatureProvider> with
                | :? TemperatureProvider as x -> x
                | _ -> null 

        let fmt = 
            if String.IsNullOrWhiteSpace fmt then
                if formatter <> null then
                    formatter.Format
                else
                    "G"
            else fmt

        match fmt.ToUpper() with
        | "G"
        | "C" ->
            $"{temperature:N2} °C"
        | "F" ->
            $"{this.Fahrenheit:N2}  °F"
        | "K" ->
            $"{this.Kelvin:N2} K"
        | _ ->
            raise (FormatException $"'{fmt}' is not a valid format specifier.")

let cold = Temperature -40
let freezing = Temperature 0
let boiling = Temperature 100

let tp = TemperatureProvider()

printfn $"{Convert.ToString(cold, tp)}"
printfn $"{Convert.ToString(freezing, tp)}"
printfn $"{Convert.ToString(boiling, tp)}"
// The example displays output like the following:
//       -40.00 °C
//       273.15 K
//       100.00 °C
// </Snippet30>