module source1

// <Snippet1>
let str = "forty-two"
let pad = '.'

printfn $"{str.PadRight(15, pad)}"    // Displays "forty-two......".
printfn $"{str.PadRight(2, pad)}"    // Displays "forty-two".
// </Snippet1>