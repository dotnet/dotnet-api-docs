module getvalues1

// <Snippet1>
open System

type SignMagnitude =
    | Negative = -1
    | Zero = 0
    | Positive = 1

for value in Enum.GetValues typeof<SignMagnitude> do
    printfn $"{value :?> int,3}     0x{value :?> int:X8}     {value :?> SignMagnitude}"
// The example displays the following output:
//         0     0x00000000     Zero
//         1     0x00000001     Positive
//        -1     0xFFFFFFFF     Negative
// </Snippet1>