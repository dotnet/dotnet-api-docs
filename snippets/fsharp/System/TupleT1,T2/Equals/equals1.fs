module equals1

// <Snippet1>
open System

let scores = 
    [| Tuple<string, Nullable<int>>("Dan", 90)
       Tuple<string, Nullable<int>>("Ernie", Nullable())
       Tuple<string, Nullable<int>>("Jill", 88)
       Tuple<string, Nullable<int>>("Ernie", Nullable()) 
       Tuple<string, Nullable<int>>("Nancy", 88)
       Tuple<string, Nullable<int>>("Dan", 90) |]

// Compare the Tuple objects
for ctr = 0 to scores.Length - 1 do
    for innerCtr = ctr + 1 to scores.Length - 1 do
        printfn $"{scores[ctr]} = {scores[innerCtr]}: {scores[ctr].Equals scores[innerCtr]}"
    printfn ""
// The example displays the following output:
//       (Dan, 90) = (Ernie, ): False
//       (Dan, 90) = (Jill, 88): False
//       (Dan, 90) = (Ernie, ): False
//       (Dan, 90) = (Nancy, 88): False
//       (Dan, 90) = (Dan, 90): True
//       
//       (Ernie, ) = (Jill, 88): False
//       (Ernie, ) = (Ernie, ): True
//       (Ernie, ) = (Nancy, 88): False
//       (Ernie, ) = (Dan, 90): False
//       
//       (Jill, 88) = (Ernie, ): False
//       (Jill, 88) = (Nancy, 88): False
//       (Jill, 88) = (Dan, 90): False
//       
//       (Ernie, ) = (Nancy, 88): False
//       (Ernie, ) = (Dan, 90): False
//       
//       (Nancy, 88) = (Dan, 90): False
// </Snippet1>