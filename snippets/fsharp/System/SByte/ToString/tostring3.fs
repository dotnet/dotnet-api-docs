module tostring3

// <Snippet3>
open System.Globalization

// Define a custom NumberFormatInfo object with "~" as its negative sign.
let nfi = NumberFormatInfo(NegativeSign = "~")

// Initialize an array of SByte values.
let bytes = [| -122y; 17y; 124y |]

// Display the formatted result using the custom provider.
printfn "Using the custom NumberFormatInfo object:"
for value in bytes do
    printfn $"{value.ToString nfi}"

printfn ""
      
// Display the formatted result using the invariant culture.
printfn "Using the invariant culture:"
for value in bytes do
   printfn $"{value.ToString NumberFormatInfo.InvariantInfo}"
// The example displays the following output:
//       Using the custom NumberFormatInfo object:
//       ~122
//       17
//       124
//       
//       Using the invariant culture:
//       -122
//       17
//       124
// </Snippet3>