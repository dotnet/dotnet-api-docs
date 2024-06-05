module ToCharArray1
// <Snippet1>
let s = "AaBbCcDd"
let chars = s.ToCharArray()
printfn $"Original string: {s}"
printfn "Character array:"
for i = 0 to chars.Length - 1 do
    printfn $"   {i}: {chars[i]}"

// The example displays the following output:
//     Original string: AaBbCcDd
//     Character array:
//        0: A
//        1: a
//        2: B
//        3: b
//        4: C
//        5: c
//        6: D
//        7: d
// </Snippet1>