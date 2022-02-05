module roundtripex1

// <Snippet5>
open System
open System.Globalization

// <SnippetRoundTrip>
printfn "Attempting to round-trip a Double with 'R':"
let initialValue = 0.6822871999174
let valueString = initialValue.ToString("R", CultureInfo.InvariantCulture)
let roundTripped = Double.Parse(valueString, CultureInfo.InvariantCulture)
printfn $"{initialValue:R} = {roundTripped:R}: {initialValue.Equals roundTripped}\n"

printfn "Attempting to round-trip a Double with 'G17':"
let valueString17 = initialValue.ToString("G17", CultureInfo.InvariantCulture)
let roundTripped17 = Double.Parse(valueString17, CultureInfo.InvariantCulture)
printfn $"{initialValue:R} = {roundTripped17:R}: {initialValue.Equals roundTripped17}\n"
// If compiled to an application that targets anycpu or x64 and run on an x64 system,
// the example displays the following output:
//       Attempting to round-trip a Double with 'R':
//       0.6822871999174 = 0.68228719991740006: False
//
//       Attempting to round-trip a Double with 'G17':
//       0.6822871999174 = 0.6822871999174: True
// </SnippetRoundTrip>
// </Snippet5>