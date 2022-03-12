module GetTypeEx2

// <Snippet2>
let values: obj[] = 
    [| 12; 10653L; 12uy
       -5y; 16.3; "string" |]

for value in values do
    let t = value.GetType()
    if t.Equals typeof<byte> then
        printfn $"{value} is an unsigned byte."
    elif t.Equals typeof<sbyte> then
        printfn $"{value} is a signed byte."
    elif t.Equals typeof<int> then
        printfn $"{value} is a 32-bit integer."
    elif t.Equals typeof<int64> then
        printfn $"{value} is a 64-bit integer."
    elif t.Equals typeof<double> then
        printfn $"{value} is a double-precision floating point."
    else
        printfn $"'{value}' is another data type."

// The example displays the following output:
//    12 is a 32-bit integer.
//    10653 is a 32-bit integer.
//    12 is an unsigned byte.
//    -5 is a signed byte.
//    16.3 is a double-precision floating point.
//    'string' is another data type.
// </Snippet2>