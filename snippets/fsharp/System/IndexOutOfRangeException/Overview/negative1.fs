module negative1

// <Snippet5>
open System

let numbers = ResizeArray()

let showValues startValue =
    // Create a collection with numeric values.
    if numbers.Count = 0 then
        numbers.AddRange [| 2..2..22 |]

    // Get the index of a startValue.
    printfn $"Displaying values greater than or equal to {startValue}:"
    let startIndex = numbers.IndexOf startValue
    
    // Display all numbers from startIndex on.
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
//    Displaying values greater than or equal to 7:
//
//    Unhandled Exception: System.ArgumentOutOfRangeException:
//    Index was out of range. Must be non-negative and less than the size of the collection.
//    Parameter name: index
//       at System.Collections.Generic.List`1.get_Item(Int32 index)
//       at Example.ShowValues(Int32 startValue)
//       at <StartupCode$fs>.main@()
// </Snippet5>