//<Snippet1>
open System

let scores = 
    [| Tuple<string, Nullable<int>>("Abbey", 92) 
       Tuple<string, Nullable<int>>("Dave", 88)
       Tuple<string, Nullable<int>>("Ed", Nullable())
       Tuple<string, Nullable<int>>("Jack", 78)
       Tuple<string, Nullable<int>>("Linda", 99)
       Tuple<string, Nullable<int>>("Judith", 84)
       Tuple<string, Nullable<int>>("Penelope", 82)
       Tuple<string, Nullable<int>>("Sam", 91) |]
for score in scores do
    printfn $"{score.ToString()}"
// The example displays the following output:
//       (Abbey, 92)
//       (Dave, 88)
//       (Ed, )
//       (Jack, 78)
//       (Linda, 99)
//       (Judith, 84)
//       (Penelope, 82)
//       (Sam, 91)
// </Snippet1>