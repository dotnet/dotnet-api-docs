module getnames1

// <Snippet1>
open System

type SignMagnitude =
   | Negative = -1
   | Zero = 0
   | Positive = 1

for name in Enum.GetNames typeof<SignMagnitude> do
    let p = Enum.Parse(typeof<SignMagnitude>, name)
    printfn $"{p,3:D}     0x{p:X}     {name}"

// The example displays the following output:
//         0     0x00000000     Zero
//         1     0x00000001     Positive
//        -1     0xFFFFFFFF     Negative
// </Snippet1>