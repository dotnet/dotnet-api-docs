module tostring2

// <Snippet2>
open System.Globalization

let getName (ci: CultureInfo) =
    if ci.Equals CultureInfo.InvariantCulture then
        "Invariant"
    else
        ci.Name         

// Define an array of CultureInfo objects.
let ci = 
    [| CultureInfo "en-US" 
       CultureInfo "fr-FR"
       CultureInfo.InvariantCulture |]

let value = 1870924u

printfn $"  {getName ci[0],12}   {getName ci[1],12}   {getName ci[3],12}"
printfn $"  {value.ToString ci[0],12}   {value.ToString ci[1],12}   {value.ToString ci[2],12}"
// The example displays the following output:
//             en-US          fr-FR      Invariant
//           1870924        1870924        1870924
// </Snippet2>