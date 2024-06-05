module tostring3

// <Snippet3>
let value = 217960834uL
let specifiers = 
    [| "G"; "C"; "D3"; "E2"; "e3"; "F" 
       "N"; "P"; "X"; "000000.0"; "#.0" 
       "00000000(0)**Zero**" |]
      
for specifier in specifiers do
    printfn $"{specifier}: {value.ToString specifier}"
// The example displays the following output:
//       G: 217960834
//       C: $217,960,834.00
//       D3: 217960834
//       E2: 2.18E+008
//       e3: 2.180e+008
//       F: 217960834.00
//       N: 217,960,834.00
//       P: 21,796,083,400.00 %
//       X: CFDD182
//       000000.0: 217960834.0
//       #.0: 217960834.0
//       00000000(0)**Zero**: 217960834
// </Snippet3>