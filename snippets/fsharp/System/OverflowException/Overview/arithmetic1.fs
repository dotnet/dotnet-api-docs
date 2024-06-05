open System

// <Snippet2>
open Checked

let value = 241uy
try
    let newValue = int8 value
    printfn $"Converted the {value.GetType().Name} value {value} to the {newValue.GetType().Name} value {newValue}."
with :? OverflowException ->
    printfn $"Exception: {value} > {SByte.MaxValue}."
// The example displays the following output:
//       Exception: 241 > 127.
// </Snippet2>

let unchecked () =
    // <Snippet3>
    let value = 241uy
    try
        let newValue = int8 value
        printfn $"Converted the {value.GetType().Name} value {value} to the {newValue.GetType().Name} value {newValue}."
    with :? OverflowException ->
        printfn $"Exception: {value} > {SByte.MaxValue}."
    // The example displays the following output:
    //       Converted the Byte value 241 to the SByte value -15.
    // </Snippet3>

// <Snippet1>
open Checked

let v = 780000000
try
   // Square the original value.
   let square = v * v
   printfn $"{v} ^ 2 = {square}"
with :? OverflowException ->
    let square = float v ** 2
    printfn $"Exception: {square} > {Int32.MaxValue:E}."
// The example displays the following output:
//       Exception: 6.084E+17 > 2.147484E+009.
// </Snippet1>