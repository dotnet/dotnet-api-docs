module example2

// <Snippet2>
open System

type TemperatureScale =
    | Celsius = 0
    | Fahrenheit = 1
    | Kelvin = 2

let getCurrentTemperature () =
    let dat = DateTime.Now
    let temp = 20.6m
    let scale = TemperatureScale.Celsius
    String.Format("At {0:t} on {0:D}, the temperature is {1:F1} {2:G}", dat, temp, scale)

getCurrentTemperature ()
|> printfn "%s"

// The example displays output like the following:
//    At 10:40 AM on Wednesday, June 04, 2014, the temperature is 20.6 Celsius
// </Snippet2>