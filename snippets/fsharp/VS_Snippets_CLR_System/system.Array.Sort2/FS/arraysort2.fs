// The following example shows how to sort two associated arrays
// where the first array contains the keys and the second array contains the values.
// Sorts are done using the default comparer and a custom comparer that reverses the sort order.

// <Snippet1>
open System
open System.Collections

type MyReverserClass() = 
    interface IComparer with
        member _.Compare(x, y) =
            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            CaseInsensitiveComparer().Compare(y, x)

let printKeysAndValues (myKeys: string []) (myValues: string []) =
    for i = 0 to myKeys.Length - 1 do
        printfn $"   {myKeys[i],-10}: {myValues[i]}"
    printfn ""

// Creates and initializes a new Array and a new custom comparer.
let myKeys = [| "red"; "GREEN"; "YELLOW"; "BLUE"; "purple"; "black"; "orange" |]
let myValues = [| "strawberries"; "PEARS"; "LIMES"; "BERRIES"; "grapes"; "olives"; "cantaloupe" |]
let myComparer = MyReverserClass()

// Displays the values of the Array.
printfn "The Array initially contains the following values:"
printKeysAndValues myKeys myValues 

// Sorts a section of the Array using the default comparer.
Array.Sort(myKeys, myValues, 1, 3)
printfn "After sorting a section of the Array using the default comparer:" 
printKeysAndValues myKeys myValues

// Sorts a section of the Array using the reverse case-insensitive comparer.
Array.Sort(myKeys, myValues, 1, 3, myComparer)
printfn "After sorting a section of the Array using the reverse case-insensitive comparer:"
printKeysAndValues myKeys myValues

// Sorts the entire Array using the default comparer.
Array.Sort(myKeys, myValues)
printfn "After sorting the entire Array using the default comparer:"
printKeysAndValues myKeys myValues

// Sorts the entire Array using the reverse case-insensitive comparer.
Array.Sort(myKeys, myValues, myComparer)
printfn "After sorting the entire Array using the reverse case-insensitive comparer:"
printKeysAndValues myKeys myValues


// This code produces the following output.
//     The Array initially contains the following values:
//        red       : strawberries
//        GREEN     : PEARS
//        YELLOW    : LIMES
//        BLUE      : BERRIES
//        purple    : grapes
//        black     : olives
//        orange    : cantaloupe
//     
//     After sorting a section of the Array using the default comparer:
//        red       : strawberries
//        BLUE      : BERRIES
//        GREEN     : PEARS
//        YELLOW    : LIMES
//        purple    : grapes
//        black     : olives
//        orange    : cantaloupe
//     
//     After sorting a section of the Array using the reverse case-insensitive comparer:
//        red       : strawberries
//        YELLOW    : LIMES
//        GREEN     : PEARS
//        BLUE      : BERRIES
//        purple    : grapes
//        black     : olives
//        orange    : cantaloupe
//     
//     After sorting the entire Array using the default comparer:
//        black     : olives
//        BLUE      : BERRIES
//        GREEN     : PEARS
//        orange    : cantaloupe
//        purple    : grapes
//        red       : strawberries
//        YELLOW    : LIMES
//     
//     After sorting the entire Array using the reverse case-insensitive comparer:
//        YELLOW    : LIMES
//        red       : strawberries
//        purple    : grapes
//        orange    : cantaloupe
//        GREEN     : PEARS
//        BLUE      : BERRIES
//        black     : olives

// </Snippet1>