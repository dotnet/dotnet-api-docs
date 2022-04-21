// <Snippet1>
open System
open System.Collections

let types = 
    [ typeof<String>; typeof<int[]>
      typeof<ArrayList>; typeof<Array>
      typeof<ResizeArray<string>>
      typeof<seq<char>> ]
for t in types do
    printfn $"""{t.Name + ":",-15} IsArray = {t.IsArray}"""
// The example displays the following output:
//       String:         IsArray = False
//       Int32[]:        IsArray = True
//       ArrayList:      IsArray = False
//       Array:          IsArray = False
//       List`1:         IsArray = False
//       IEnumerable`1:  IsArray = False
// </Snippet1>