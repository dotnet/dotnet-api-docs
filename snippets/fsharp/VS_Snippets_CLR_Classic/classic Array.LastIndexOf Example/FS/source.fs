open System

[<EntryPoint>]
let main _ =
   // <Snippet1>
   let printIndexAndValues (arr: 'a []) =
      for i = arr.GetLowerBound 0 to arr.GetUpperBound 0 do
         printfn $"\t[{i}]:\t{arr[i]}"

   // Creates and initializes a new Array with three elements of the same value.
   let myArray = 
      [| "the"; "quick"; "brown"; "fox"
         "jumps"; "over"; "the"; "lazy"
         "dog"; "in"; "the"; "barn" |]

   // Displays the values of the Array.
   printfn "The Array contains the following values:"
   printIndexAndValues myArray

   // Searches for the last occurrence of the duplicated value.
   let myString = "the"
   let myIndex = Array.LastIndexOf(myArray, myString)
   printfn $"The last occurrence of \"{myString}\" is at index {myIndex}."

   // Searches for the last occurrence of the duplicated value in the first section of the Array.
   let myIndex = Array.LastIndexOf(myArray, myString, 8)
   printfn $"The last occurrence of \"{myString}\" between the start and index 8 is at index {myIndex}."

   // Searches for the last occurrence of the duplicated value in a section of the Array.
   // Note that the start index is greater than the end index because the search is done backward.
   let myIndex = Array.LastIndexOf( myArray, myString, 10, 6 )
   printfn $"The last occurrence of \"{myString}\" between index 5 and index 10 is at index {myIndex}."


   //      This code produces the following output.
   //
   //      The Array contains the following values:
   //         [0]:    the
   //         [1]:    quick
   //         [2]:    brown
   //         [3]:    fox
   //         [4]:    jumps
   //         [5]:    over
   //         [6]:    the
   //         [7]:    lazy
   //         [8]:    dog
   //         [9]:    in
   //         [10]:    the
   //         [11]:    barn
   //      The last occurrence of "the" is at index 10.
   //      The last occurrence of "the" between the start and index 8 is at index 6.
   //      The last occurrence of "the" between index 5 and index 10 is at index 10.

   // </Snippet1>
   0