module tostring7

// <Snippet27>
open System
open System.Globalization

// Create a NumberFormatInfo object and set its NegativeSigns
// property to use for integer formatting.
let provider = NumberFormatInfo()
provider.NegativeSign <- "minus "

let values = [| -20; 0; 100 |]

printfn $"""{CultureInfo.CurrentCulture.Name,-8} --> {"Value",10} {"Custom",10}\n"""
                    
for value in values do
    printfn $"{value,-8} --> {Convert.ToString value,10} {Convert.ToString(value, provider),10}"
// The example displays output like the following:
//       Value    -->      en-US     Custom
//
//       -20      -->        -20   minus 20
//       0        -->          0          0
//       100      -->        100        100
// </Snippet27>
