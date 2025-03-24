// <Snippet1>
open System
open System.Collections

type Temperature() =
    // The temperature value
    let mutable temperatureF = 0.

    interface IComparable with
        member _.CompareTo(obj) =
            match obj with 
            | null -> 1
            | :? Temperature as other -> 
                temperatureF.CompareTo other.Fahrenheit
            | _ ->
                invalidArg (nameof obj) "Object is not a Temperature"

    member _.Fahrenheit 
        with get () =
            temperatureF
        and set (value) = 
            temperatureF <- value

    member _.Celsius
        with get () =
            (temperatureF - 32.) * (5. / 9.)
        and set (value) =
            temperatureF <- (value * 9. / 5.) + 32.

let temperatures = ResizeArray()

// Initialize random number generator.
let rnd = Random()

// Generate 10 temperatures between 0 and 100 randomly.
for _ = 1 to 10 do
    let degrees = rnd.Next(0, 100)
    let temp = Temperature(Fahrenheit=degrees)
    temperatures.Add temp

// Sort ResizeArray.
temperatures.Sort()

for temp in temperatures do
    printfn $"{temp.Fahrenheit}"

// The example displays the following output to the console (individual
// values may vary because they are randomly generated):
//       2
//       7
//       16
//       17
//       31
//       37
//       58
//       66
//       72
//       95
// </Snippet1>