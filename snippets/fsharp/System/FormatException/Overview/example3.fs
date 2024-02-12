module example3

open System

let n1 = 10
let n2 = 20
// <Snippet4>
let result = String.Format("{0} + {1} = {2}", n1, n2, n1 + n2)
// </Snippet4>
printfn $"{result}"

do
    // <Snippet3>
    let n1 = 10
    let n2 = 20
    String result = String.Format("{0 + {1] = {2}",
                                n1, n2, n1 + n2)
    // </Snippet3>
    |> ignore