module singlesample

open System

[<EntryPoint>]
let main _ =
    //<snippet1> 
    let s = 4.55f
    //</snippet1>

    //<snippet2> 
    printfn $"A Single is of type {s.GetType()}."
    //</snippet2>

    //<snippet3> 
    let mutable finished = false
    while not finished do
        printf "Enter a real number: "
        let inp = stdin.ReadLine()
        try
            let s = Single.Parse inp
            printfn $"You entered {s}."
            finished <- true
        with 
        | :? FormatException ->
            printfn "You did not enter a number."
        | e ->
            printfn "An exception occurred while parsing your response: {e}"
    //</snippet3>

    //<snippet4> 
    if s > Single.MaxValue then
        printfn "Your number is larger than a Single."
    //</snippet4>

    //<snippet5> 
    if s < Single.MinValue then
        printfn "Your number is smaller than a Single."
    //</snippet5>

    //<snippet6> 
    printfn $"Epsilon, or the permittivity of a vacuum, has value {Single.Epsilon}"
    //</snippet6>

    //<snippet7> 
    let zero = 0f

    // This condition will return false.
    if 0f / zero = Single.NaN then
        printfn "0 / 0 can be tested with Single.NaN."
    else
        printfn "0 / 0 cannot be tested with Single.NaN use Single.IsNan() instead."
    //</snippet7>

    //<snippet8> 
    // This will return true.
    if Single.IsNaN(0f / zero) then
        printfn "Single.IsNan() can determine whether a value is not-a-number."
    //</snippet8>

    //<snippet9> 
    // This will equal Infinity.
    printfn $"10.0 minus NegativeInfinity equals {10f - Single.NegativeInfinity}."
    //</snippet9>

    //<snippet10> 
    // This will equal Infinity.
    printfn $"PositiveInfinity plus 10.0 equals {Single.PositiveInfinity + 10f}."
    //</snippet10>

    //<snippet11> 
    // This will return "true".
    printfn $"IsInfinity(3.0F / 0) == %b{Single.IsInfinity(3f / 0f)}."
    //</snippet11>

    //<snippet12> 
    // This will return true.
    printfn $"IsPositiveInfinity(4.0F / 0) == {Single.IsPositiveInfinity(4f / 0f)}."
    //</snippet12>

    //<snippet13> 
    // This will return true.
    printfn $"IsNegativeInfinity(-5.0F / 0) == {Single.IsNegativeInfinity(-5f / 0f)}."
    //</snippet13>

    //<snippet14>
    let a = 500f
    //</snippet14>

    //<snippet15> 
    // The variables point to the same objects.
    let mutable obj1: obj = a
    let obj2: obj = obj1

    if Single.ReferenceEquals(obj1, obj2) then
        printfn "The variables point to the same Single object."
    else
        printfn "The variables point to different Single objects."
    //</snippet15>

    //<snippet16> 
    let obj1 = single 450

    if a.CompareTo obj1 < 0 then
        printfn $"{a} is less than {obj1}."

    if a.CompareTo obj1 > 0 then
        printfn $"{a} is greater than {obj1}."

    if a.CompareTo obj1 = 0 then
        printfn $"{a} equals {obj1}."
    //</snippet16>

    //<snippet17> 
    let obj1 = single 500
    if a.Equals obj1 then
        printfn "The value type and reference type values are equal."
    //</snippet17>
    0