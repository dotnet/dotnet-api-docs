module example1

// <Snippet3>
open System

let value = -16
let bytes = BitConverter.GetBytes value

// Convert bytes back to int.
let intValue = BitConverter.ToInt32(bytes, 0)
printfn $"""{value} = {intValue}: {if value.Equals intValue then "Round-trips" else "Does not round-trip"}"""

// Convert bytes to UInt32.
let uintValue = BitConverter.ToUInt32(bytes, 0)
printfn $"""{value} = {uintValue}: {if value.Equals uintValue then "Round-trips" else "Does not round-trip"}"""


// The example displays the following output:
//       -16 = -16: Round-trips
//       -16 = 4294967280: Does not round-trip
// </Snippet3>