module negative2

// <Snippet6>
open System
open System.Collections.Generic

let numbers = new List<int>()

let showValues startValue =
    // Create a collection with numeric values.
    if numbers.Count = 0 then
        numbers.AddRange [| 2..2..22 |]

    // Get the index of startValue.
    let startIndex = numbers.IndexOf startValue
    if startIndex < 0 then
        printfn $"Unable to find {startValue} in the collection."
    else
        // Display all numbers from startIndex on.
        printfn $"Displaying values greater than or equal to {startValue}:"
        for i = startIndex to numbers.Count - 1 do
            printf $"    {numbers[i]}"

let startValue =
    let args = Environment.GetCommandLineArgs()
    if args.Length < 2 then
        2
    else
        match Int32.TryParse args[1] with
        | true, v -> v
        | _ -> 2

showValues startValue

// The example displays the following output if the user supplies
// 7 as a command-line parameter:
//      Unable to find 7 in the collection.
// </Snippet6>