module join6.fs
// <Snippet2>
open System

let getPrimes maxPrime =
    let values = Array.CreateInstance(typeof<int>, [| maxPrime - 1 |], [| 2 |])
    // Use Sieve of Eratosthenes to determine prime numbers.
    for i = values.GetLowerBound 0 to values.GetUpperBound 0 |> float |> sqrt |> ceil |> int do
        if values.GetValue i <> 1 then
            for multiplier = i to maxPrime / 2 do
                if i * multiplier <= maxPrime then
                    values.SetValue(1, i * multiplier)

    let primes = ResizeArray()
    for i = values.GetLowerBound 0 to values.GetUpperBound 0 do
        if values.GetValue i :?> int = 0 then
            primes.Add i
    primes

let maxPrime = 100
let primes = getPrimes maxPrime
printfn $"Primes less than {maxPrime}:"
printfn $"""   {String.Join(" ", primes)}"""
// The example displays the following output:
//    Primes less than 100:
//       2 3 5 7 11 13 17 19 23 29 31 37 41 43 47 53 59 61 67 71 73 79 83 89 97
// </Snippet2>
