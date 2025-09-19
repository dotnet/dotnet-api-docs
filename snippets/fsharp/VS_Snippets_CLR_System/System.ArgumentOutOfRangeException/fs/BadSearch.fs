module BadSearch

// <Snippet6>
open System

module StringSearcher =
    let findEquals (s: string) value =
        s.Equals(value, StringComparison.InvariantCulture)

let list = ResizeArray<string>()
list.AddRange [ "A"; "B"; "C" ]
// Get the index of the element whose value is "Z".
let index = list.FindIndex(StringSearcher.findEquals "Z")
try 
    printfn $"Index {index} contains '{list[index]}'"
with 
| :? ArgumentOutOfRangeException as e ->
    printfn $"{e.Message}" 

// The example displays the following output:
//   Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
// </Snippet6>

module Example2 =
    let test () =
        let list = new ResizeArray<string>();
        list.AddRange [ "A"; "B"; "C" ]
        // <Snippet7>
        // Get the index of the element whose value is "Z".
        let index = list.FindIndex(StringSearcher.findEquals "Z")
        if index >= 0 then
            printfn $"'Z' is found at index {list[index]}"
        // </Snippet7>