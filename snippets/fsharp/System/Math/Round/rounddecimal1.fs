module rounddecimal1

//  <Snippet6>
open System

for value in 4.2m .. 0.1m .. 4.8m do
    printfn $"{value} --> {Math.Round value}"
// The example displays the following output:
//       4.2 --> 4
//       4.3 --> 4
//       4.4 --> 4
//       4.5 --> 4
//       4.6 --> 5
//       4.7 --> 5
//       4.8 --> 5
// </Snippet6>