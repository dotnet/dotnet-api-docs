//<snippet1>
let str = "abc"
let tc = str.GetTypeCode()
printfn $"""The type code for '{str}' is {tc.ToString "D"}, which represents {tc.ToString "F"}."""
// This example produces the following results:
//     The type code for 'abc' is 18, which represents String.
//</snippet1>