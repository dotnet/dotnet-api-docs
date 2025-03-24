module string.replace1

//<snippet1>
let str = "1 2 3 4 5 6 7 8 9"
printfn $"Original string: \"{str}\""
printfn $"CSV string:      \"{str.Replace(' ', ',')}\""

// This example produces the following output:
// Original string: "1 2 3 4 5 6 7 8 9"
// CSV string:      "1,2,3,4,5,6,7,8,9"
//</snippet1>