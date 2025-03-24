module multiply1
// <Snippet1>
open System.Numerics

let number1 = Complex(8.3, 17.5)
let numbers = [ Complex(1.4, 6.3); Complex(-2.7, 1.8); Complex(3.1, -2.1) ]

for number2 in numbers do
    printfn $"{number1} x {number2} = {Complex.Multiply(number1, number2)}"
// The example displays the following output:
//       (8.3, 17.5) x (1.4, 6.3) = (-98.63, 76.79)
//       (8.3, 17.5) x (-2.7, 1.8) = (-53.91, -32.31)
//       (8.3, 17.5) x (3.1, -2.1) = (62.48, 36.82)
// </Snippet1>
