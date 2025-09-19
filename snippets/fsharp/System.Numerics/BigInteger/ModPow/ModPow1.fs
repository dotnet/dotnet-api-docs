// <Snippet1>
open System.Numerics;

let number = 10I;
let exponent = 3;
let modulus = 30I;
printfn $"({number}^{exponent}) Mod {modulus} = {BigInteger.ModPow(number, exponent, modulus)}"
// The example displays the following output:
//      (10^3) Mod 30 = 10
// </Snippet1>