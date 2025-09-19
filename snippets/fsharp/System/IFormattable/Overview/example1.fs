// <Snippet1>
open System
open System.Globalization

type Temperature(temperature: decimal) =
    do 
        if temperature < -273.15M then
            raise (ArgumentOutOfRangeException $"{temperature} is less than absolute zero.")

    member _.Celsius =
        temperature

    member _.Fahrenheit =
        temperature * 9M / 5M + 32M

    member _.Kelvin =
        temperature + 273.15m

    override this.ToString() =
        this.ToString("G", CultureInfo.CurrentCulture)

    member this.ToString(format) =
        this.ToString(format, CultureInfo.CurrentCulture)

    member this.ToString(format, provider: IFormatProvider) =
        let format =
            if String.IsNullOrEmpty format then "G"
            else format

        let provider =
            if isNull provider then 
                CultureInfo.CurrentCulture :> IFormatProvider
            else provider

        match format.ToUpperInvariant() with
        | "G" | "C" ->
            temperature.ToString("F2", provider) + " °C"
        | "F" ->
            this.Fahrenheit.ToString("F2", provider) + " °F"
        | "K" ->
            this.Kelvin.ToString("F2", provider) + " K"
        | _ ->
            raise (FormatException $"The {format} format string is not supported.")

    interface IFormattable with
        member this.ToString(format, provider) = this.ToString(format, provider)

// </Snippet1>

// <Snippet2>
open System
open System.Globalization

[<EntryPoint>]
let main _ =
    // Use composite formatting with format string in the format item.
    let temp1 = Temperature 0
    Console.WriteLine("{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)\n", temp1)

    // Use composite formatting with a format provider.
    let temp1 = Temperature -40
    String.Format(CultureInfo.CurrentCulture, "{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)", temp1)
    |> printfn "%s"
    String.Format(CultureInfo "fr-FR", "{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)\n", temp1)
    |> printfn "%s"

    // Call ToString method with format string.
    let temp1 = Temperature 32
    Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)\n",
                      temp1.ToString "C", temp1.ToString "K", temp1.ToString "F")

    // Call ToString with format string and format provider
    let temp1 = Temperature 100      
    let current = NumberFormatInfo.CurrentInfo
    let nl = CultureInfo "nl-NL"
    Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)",
                      temp1.ToString("C", current), temp1.ToString("K", current), temp1.ToString("F", current))
    Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)",
                      temp1.ToString("C", nl), temp1.ToString("K", nl), temp1.ToString("F", nl))
    0

// The example displays the following output:
//    0.00 °C (Celsius) = 273.15 K (Kelvin) = 32.00 °F (Fahrenheit)
//
//    -40.00 °C (Celsius) = 233.15 K (Kelvin) = -40.00 °F (Fahrenheit)
//    -40,00 °C (Celsius) = 233,15 K (Kelvin) = -40,00 °F (Fahrenheit)
//
//    32.00 °C (Celsius) = 305.15 K (Kelvin) = 89.60 °F (Fahrenheit)
//
//    100.00 °C (Celsius) = 373.15 K (Kelvin) = 212.00 °F (Fahrenheit)
//    100,00 °C (Celsius) = 373,15 K (Kelvin) = 212,00 °F (Fahrenheit)
// </Snippet2>