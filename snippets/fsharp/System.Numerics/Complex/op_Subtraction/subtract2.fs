module subtract2
// <Snippet2>
let c1 = System.Numerics.Complex(6.7, -1.3)
let c2 = System.Numerics.Complex(1.4, 3.8)
let result = c1 - c2
printfn $"{c1}; - {c2}; = {result}"
// The example displays the following output:
//       (6.7, -1.3); - (1.4, 3.8); = (5.3, -5.1)
// </Snippet2>
