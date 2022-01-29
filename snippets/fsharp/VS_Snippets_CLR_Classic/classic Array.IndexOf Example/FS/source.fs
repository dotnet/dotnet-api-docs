open System

[<EntryPoint>]
let main _ =
    // <Snippet1>
    // Create a string array with 3 elements having the same value.
    let strings = 
        [| "the"; "quick"; "brown"; "fox"; "jumps"; "over"
           "the"; "lazy"; "dog"; "in"; "the"; "barn" |]

    // Display the elements of the array.
    printfn "The array contains the following values:"
    for i = strings.GetLowerBound 0 to strings.GetUpperBound 0 do
        printfn $"   [{i,2}]: {strings[i]}"

    // Search for the first occurrence of the duplicated value.
    let searchString = "the"
    let index = Array.IndexOf(strings, searchString)
    printfn $"The first occurrence of \"{searchString}\" is at index {index}."

    // Search for the first occurrence of the duplicated value in the last section of the array.
    let index = Array.IndexOf(strings, searchString, 4)
    printfn $"The first occurrence of \"{searchString}\" between index 4 and the end is at index {index}."

    // Search for the first occurrence of the duplicated value in a section of the array.
    let position = index + 1
    let index = Array.IndexOf(strings, searchString, position, strings.GetUpperBound 0 - position + 1)
    printfn $"The first occurrence of \"{searchString}\" between index {position} and index {strings.GetUpperBound 0} is at index {index}."

    // The example displays the following output:
    //    The array contains the following values:
    //       [ 0]: the
    //       [ 1]: quick
    //       [ 2]: brown
    //       [ 3]: fox
    //       [ 4]: jumps
    //       [ 5]: over
    //       [ 6]: the
    //       [ 7]: lazy
    //       [ 8]: dog
    //       [ 9]: in
    //       [10]: the
    //       [11]: barn
    //    The first occurrence of "the" is at index 0.
    //    The first occurrence of "the" between index 4 and the end is at index 6.
    //    The first occurrence of "the" between index 7 and index 11 is at index 10.
    // </Snippet1>
    0