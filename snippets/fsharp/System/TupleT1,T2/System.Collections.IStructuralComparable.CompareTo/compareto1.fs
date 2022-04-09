module compareto1

// <Snippet1>
open System

let scores = 
    [| Tuple<string, Nullable<int>>("Jack", 78)
       Tuple<string, Nullable<int>>("Abbey", 92) 
       Tuple<string, Nullable<int>>("Dave", 88)
       Tuple<string, Nullable<int>>("Sam", 91) 
       Tuple<string, Nullable<int>>("Ed", Nullable())
       Tuple<string, Nullable<int>>("Penelope", 82)
       Tuple<string, Nullable<int>>("Linda", 99)
       Tuple<string, Nullable<int>>("Judith", 84) |]

printfn "The values in unsorted order:"
for score in scores do
    printfn $"{score}"

printfn ""

Array.Sort scores

printfn "The values in sorted order:"
for score in scores do
    printfn $"{score}"
// The example displays the following output
//       The values in unsorted order:
//       (Jack, 78)
//       (Abbey, 92)
//       (Dave, 88)
//       (Sam, 91)
//       (Ed, )
//       (Penelope, 82)
//       (Linda, 99)
//       (Judith, 84)
//       
//       The values in sorted order:
//       (Abbey, 92)
//       (Dave, 88)
//       (Ed, )
//       (Jack, 78)
//       (Judith, 84)
//       (Linda, 99)
//       (Penelope, 82)
//       (Sam, 91)
// </Snippet1>