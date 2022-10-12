//<snippet1>
let str = "abcdefg"
printfn $"1) The length of '{str}' is {str.Length}"
printfn $"""2) The length of '{"xyz"}' is {"xyz".Length}"""

let length = str.Length
printfn $"3) The length of '{str}' is {length}"

// This example displays the following output:
//    1) The length of 'abcdefg' is 7
//    2) The length of 'xyz' is 3
//    3) The length of 'abcdefg' is 7
//</snippet1>