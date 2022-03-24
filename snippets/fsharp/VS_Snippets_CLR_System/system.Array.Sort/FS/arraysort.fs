// The following example shows how to sort the values in an array using the default comparer
// and a custom comparer that reverses the sort order.

// <Snippet1>
open System
open System.Collections

type ReverseComparer() =
    interface IComparer with
        member _.Compare(x, y) =
            // Call CaseInsensitiveComparer.Compare with the parameters reversed.
            CaseInsensitiveComparer().Compare(y, x)

let displayValues (arr: string []) = 
    for i = 0 to arr.Length - 1 do
        printfn $"   [{i}] : {arr[i]}"
    printfn ""

// Create and initialize a new array.
let words = 
    [| "The"; "QUICK"; "BROWN"; "FOX"; "jumps"
       "over"; "the"; "lazy"; "dog" |]

// Instantiate the reverse comparer.
let revComparer = ReverseComparer()

// Display the values of the array.
printfn "The original order of elements in the array:" 
displayValues words

// Sort a section of the array using the default comparer.
Array.Sort(words, 1, 3)
printfn "After sorting elements 1-3 by using the default comparer:"
displayValues words

// Sort a section of the array using the reverse case-insensitive comparer.
Array.Sort(words, 1, 3, revComparer)
printfn "After sorting elements 1-3 by using the reverse case-insensitive comparer:"
displayValues words

// Sort the entire array using the default comparer.
Array.Sort words
printfn "After sorting the entire array by using the default comparer:"
displayValues words

// Sort the entire array by using the reverse case-insensitive comparer.
Array.Sort(words, revComparer)
printfn "After sorting the entire array using the reverse case-insensitive comparer:"
displayValues words

// The example displays the following output:
//    The original order of elements in the array:
//       [0] : The
//       [1] : QUICK
//       [2] : BROWN
//       [3] : FOX
//       [4] : jumps
//       [5] : over
//       [6] : the
//       [7] : lazy
//       [8] : dog
//
//    After sorting elements 1-3 by using the default comparer:
//       [0] : The
//       [1] : BROWN
//       [2] : FOX
//       [3] : QUICK
//       [4] : jumps
//       [5] : over
//       [6] : the
//       [7] : lazy
//       [8] : dog
//
//    After sorting elements 1-3 by using the reverse case-insensitive comparer:
//       [0] : The
//       [1] : QUICK
//       [2] : FOX
//       [3] : BROWN
//       [4] : jumps
//       [5] : over
//       [6] : the
//       [7] : lazy
//       [8] : dog
//
//    After sorting the entire array by using the default comparer:
//       [0] : BROWN
//       [1] : dog
//       [2] : FOX
//       [3] : jumps
//       [4] : lazy
//       [5] : over
//       [6] : QUICK
//       [7] : the
//       [8] : The
//
//    After sorting the entire array using the reverse case-insensitive comparer:
//       [0] : the
//       [1] : The
//       [2] : QUICK
//       [3] : over
//       [4] : lazy
//       [5] : jumps
//       [6] : FOX
//       [7] : dog
//       [8] : BROWN
// </Snippet1>