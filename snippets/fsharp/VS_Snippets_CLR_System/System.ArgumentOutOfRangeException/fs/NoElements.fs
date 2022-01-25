module NoElements

// <Snippet4>
open System


let list = ResizeArray<string>()
printfn $"Number of items: {list.Count}"
try
    printfn $"The first item: '{list[0]}'"
with 
| :? ArgumentOutOfRangeException as e ->
    printfn $"{e.Message}"

// The example displays the following output:
//   Number of items: 0
//   Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
// </Snippet4>

module Example2 = 
    let test () =
        let list = ResizeArray<string>()
        printfn $"Number of items: {list.Count}"
        // <Snippet5>
        if list.Count > 0 then
            printfn $"The first item: '{list[0]}'"
        // </Snippet5>
