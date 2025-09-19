module OOR2

// <Snippet8>
open System

let list = ResizeArray<string>()
list.AddRange [ "A"; "B"; "C" ] 
try
    // Display the elements in the list by index.
    for i = 0 to list.Count do
        printfn $"Index {i}: {list[i]}"
with 
| :? ArgumentOutOfRangeException as e ->
    printfn $"{e.Message}" 
      
// The example displays the following output:
//   Index 0: A
//   Index 1: B
//   Index 2: C
//   Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
// </Snippet8>

module Example2 =
    let test () =
        let list = ResizeArray<string>()
        list.AddRange [ "A"; "B"; "C" ] 
        // <Snippet9>
        // Display the elements in the list by index.
        for i = 0 to list.Count - 1 do
            printfn $"Index {i}: {list[i]}"
        // </Snippet9>
