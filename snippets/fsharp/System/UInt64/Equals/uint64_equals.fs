module uint64_equals

// <Snippet1>
let value1 = 50uL
let value2 = 50uL

// Display the values.
printfn $"value1:   Type: {value1.GetType().Name}   Value: {value1}"
printfn $"value2:   Type: {value2.GetType().Name}   Value: {value2}"

// Compare the two values.
printfn $"value1 and value2 are equal: {value1.Equals value2}"
// The example displays the following output:
//       value1:   Type: UInt64   Value: 50
//       value2:   Type: UInt64   Value: 50
//       value1 and value2 are equal: True
// </Snippet1>