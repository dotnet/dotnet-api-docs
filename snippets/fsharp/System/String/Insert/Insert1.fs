module Insert1.fs
// <Snippet1>
let original = "aaabbb"
printfn $"The original string: '{original}'"
let modified = original.Insert(3, " ")
printfn $"The modified string: '{modified}'"
// The example displays the following output:
//     The original string: 'aaabbb'
//     The modified string: 'aaa bbb'
// </Snippet1>
