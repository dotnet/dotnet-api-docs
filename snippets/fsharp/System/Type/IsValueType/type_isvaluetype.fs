// <Snippet1>
// Declare an enum type.
type NumEnum = One = 1 | Two = 2

let testEnum = NumEnum.One
// Get the type of testEnum.
let t = testEnum.GetType()
// Get the IsValueType property of the testEnum variable.
let flag = t.IsValueType
printfn $"{t.FullName} is a value type: {flag}"
// The example displays the following output:
//        NumEnum is a value type: True
// </Snippet1>