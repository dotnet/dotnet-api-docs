module doublesample

open System

//<snippet1>
let d = 4.55
//</snippet1>

//<snippet2>
printfn $"A double is of type {d.GetType()}."
//</snippet2>

//<snippet3>
let mutable completed = false
while not completed do
    printf "Enter a real number: "
    let inp = stdin.ReadLine()
    try
        let d = Double.Parse inp
        printfn $"You entered {d}."
        completed <- true
    with
    | :? FormatException ->
        printfn "You did not enter a number."
    | :? ArgumentNullException ->
        printfn "You did not supply any input."
    | :? OverflowException ->
         printfn $"The value you entered, {inp}, is out of range."
//</snippet3>

//<snippet4>
if d > Double.MaxValue then
   printfn $"Your number is bigger than a double."
//</snippet4>

//<snippet5>
if d < Double.MinValue then
    printfn "Your number is smaller than a double."
//</snippet5>

//<snippet6>
printfn $"Epsilon, or the permittivity of a vacuum, has value {Double.Epsilon}"
//</snippet6>

//<snippet7>
let zero = 0.

// This condition will return false.
if 0. / zero = Double.NaN then
    printfn "0 / 0 can be tested with Double.NaN."
else
    printfn "0 / 0 cannot be tested with Double.NaN use Double.IsNan() instead."
//</snippet7>

//<snippet8>
// This will return true.
if Double.IsNaN(0. / zero) then
    printfn "Double.IsNan() can determine whether a value is not-a-number."
//</snippet8>

//<snippet9>
// This will equal Infinity.
printfn $"10.0 minus NegativeInfinity equals {10.0 - Double.NegativeInfinity}."
//</snippet9>

//<snippet10>
// This will equal Infinity.
printfn $"PositiveInfinity plus 10.0 equals {Double.PositiveInfinity + 10.}."
//</snippet10>

//<snippet11>
// This will return "true".
printfn $"IsInfinity(3.0 / 0) = %b{Double.IsInfinity(3. / 0.)}."
//</snippet11>

//<snippet12>
// This will return "true".
printfn $"IsPositiveInfinity(4.0 / 0) = %b{Double.IsPositiveInfinity(4. / 0.)}."
//</snippet12>

//<snippet13>
// This will return "true".
printfn $"IsNegativeInfinity(-5.0 / 0) = {Double.IsNegativeInfinity(-5. / 0.)}."
//</snippet13>


let a = 500.
//<snippet16>
let obj1 = double 450 |> box
    
if a.CompareTo obj1 < 0 then
    printfn $"{a} is less than {obj1}."

if a.CompareTo obj1 > 0 then
    printfn $"{a} is greater than {obj1}."

if a.CompareTo obj1 = 0 then
    printfn $"{a} equals {obj1}."
//</snippet16>