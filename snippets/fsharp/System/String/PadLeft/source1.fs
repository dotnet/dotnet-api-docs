module source1

// <Snippet1>
let str = "forty-two"
let pad = '.'

printfn $"{str.PadLeft(15, pad)}"
printfn $"{str.PadLeft(2, pad)}"
// The example displays the following output:
//       ......forty-two
//       forty-two
// </Snippet1>