// <Snippet1>
open System.Numerics

let complex1 = Complex(17.34, 12.87)
let complex2 = Complex(8.76, 5.19)

printfn $"{complex1} + {complex2} = {complex1 + complex2}"
printfn $"{complex1} - {complex2} = {complex1 - complex2}"
printfn $"{complex1} * {complex2} = {complex1 * complex2}"
printfn $"{complex1} / {complex2} = {complex1 / complex2}"
// The example displays the following output:
//    (17.34, 12.87) + (8.76, 5.19) = (26.1, 18.06)
//    (17.34, 12.87) - (8.76, 5.19) = (8.58, 7.68)
//    (17.34, 12.87) * (8.76, 5.19) = (85.1031, 202.7358)
//    (17.34, 12.87) / (8.76, 5.19) = (2.10944241403558, 0.219405693054265)
// </Snippet1>
