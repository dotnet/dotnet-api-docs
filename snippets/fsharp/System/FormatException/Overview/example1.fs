module example1

// <Snippet1>
open System

type TemperatureScale =
    | Celsius = 0
    | Fahrenheit = 1
    | Kelvin = 2

let getCurrentTemperature () =
    let dat = DateTime.Now
    let temp = 20.6m
    let scale = TemperatureScale.Celsius
    String.Format("At {0:t} on {1:D}, the temperature is {2:F1} {3:G}", dat, temp, scale)

getCurrentTemperature ()
|> printfn "%s"

// The example displays output like the following:
//    Unhandled Exception: System.FormatException: Format specifier was invalid.
//       at System.Number.NumberToString(ValueStringBuilder& sb, NumberBuffer& number, Char format, Int32 nMaxDigits, NumberFormatInfo info)   
//       at System.Number.TryFormatDecimal(Decimal value, ReadOnlySpan`1 format, NumberFormatInfo info, Span`1 destination, Int32& charsWritten)
//       at System.Decimal.TryFormat(Span`1 destination, Int32& charsWritten, ReadOnlySpan`1 format, IFormatProvider provider)       
//       at System.Text.ValueStringBuilder.AppendFormatHelper(IFormatProvider provider, String format, ParamsArray args)
//       at System.String.FormatHelper(IFormatProvider provider, String format, ParamsArray args)
//       at System.String.Format(String format, Object arg0, Object arg1, Object arg2)
//       at Example.getCurrentTemperature()
//       at <StartupCode$fs>.$Example.main@()
// </Snippet1>