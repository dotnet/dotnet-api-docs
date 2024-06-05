// <Snippet2>
open System
open System.Globalization

// Declare private constructor so Temperature so only Parse method can create a new instance
type Temperature private () =

    let mutable m_value = 0.

    member _.Value
        with get () = m_value
        and private set (value) = m_value <- value

    member _.Celsius
        with get() = (m_value - 32.) / 1.8
        and private set (value) = m_value <- value * 1.8 + 32.

    member _.Fahrenheit =
        m_value

    // Parses the temperature from a string. Temperature scale is
    // indicated by 'F (for Fahrenheit) or 'C (for Celsius) at the end
    // of the string.
    static member Parse(s: string, styles: NumberStyles, provider: IFormatProvider) =
        let temp = new Temperature()

        if s.TrimEnd(null).EndsWith "'F" then
            temp.Value <- Double.Parse(s.Remove(s.LastIndexOf(char 39), 2), styles, provider)
        else
            if s.TrimEnd(null).EndsWith "'C" then
                temp.Celsius <- Double.Parse(s.Remove(s.LastIndexOf(char 39), 2), styles, provider)
            else
                temp.Value <- Double.Parse(s, styles, provider)
        temp

[<EntryPoint>]
let main _ =
    let value = "25,3'C"
    let styles = NumberStyles.Float
    let provider = CultureInfo.CreateSpecificCulture "fr-FR"
    let temp = Temperature.Parse(value, styles, provider)
    printfn $"{temp.Fahrenheit} degrees Fahrenheit equals {temp.Celsius} degrees Celsius."

    let value = " (40) 'C"
    let styles = NumberStyles.AllowLeadingWhite ||| NumberStyles.AllowTrailingWhite ||| NumberStyles.AllowParentheses
    let provider = NumberFormatInfo.InvariantInfo
    let temp = Temperature.Parse(value, styles, provider)
    printfn $"{temp.Fahrenheit} degrees Fahrenheit equals {temp.Celsius} degrees Celsius."

    let value = "5,778E03'C"      // Approximate surface temperature of the Sun
    let styles = NumberStyles.AllowDecimalPoint ||| NumberStyles.AllowThousands ||| NumberStyles.AllowExponent
    let provider = CultureInfo.CreateSpecificCulture "en-GB"
    let temp = Temperature.Parse(value, styles, provider)
    printfn $"{temp.Fahrenheit:N} degrees Fahrenheit equals {temp.Celsius:N} degrees Celsius."

    0
// </Snippet2>