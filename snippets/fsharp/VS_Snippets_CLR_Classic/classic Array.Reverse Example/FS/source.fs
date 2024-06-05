// <Snippet1>
open System

let printIndexAndValues (arr: 'a []) =
    for i = arr.GetLowerBound 0 to arr.GetUpperBound 0 do
        printfn $"\t[{i}]:\t{arr[i]}"

// Creates and initializes a new Array.
let myArray = 
    [| "The"; "quick"; "brown"; "fox"
       "jumps"; "over"; "the"; "lazy"; "dog" |]

// Displays the values of the Array.
printfn "The Array initially contains the following values:" 
printIndexAndValues myArray 

// Reverses the sort of the values of the Array.
Array.Reverse myArray 

// Displays the values of the Array.
printfn "After reversing:"
printIndexAndValues myArray 

(*
 This code produces the following output.

 The Array initially contains the following values:
     [0]:    The
     [1]:    quick
     [2]:    brown
     [3]:    fox
     [4]:    jumps
     [5]:    over
     [6]:    the
     [7]:    lazy
     [8]:    dog
 After reversing:
     [0]:    dog
     [1]:    lazy
     [2]:    the
     [3]:    over
     [4]:    jumps
     [5]:    fox
     [6]:    brown
     [7]:    quick
     [8]:    The
 *)
// </Snippet1>