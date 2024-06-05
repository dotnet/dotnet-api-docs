module IsControl1

// <Snippet1>
open System

let mutable charsWritten = 0

for i in 0x00..0xFFFF do
    let ch = Convert.ToChar i
    if Char.IsControl ch then
        printf $"\\U{i:X4}    "
        charsWritten <- charsWritten + 1
        if charsWritten % 6 = 0 then
            printfn ""

// The example displays the following output to the console:
//       \U0000    \U0001    \U0002    \U0003    \U0004    \U0005
//       \U0006    \U0007    \U0008    \U0009    \U000A    \U000B
//       \U000C    \U000D    \U000E    \U000F    \U0010    \U0011
//       \U0012    \U0013    \U0014    \U0015    \U0016    \U0017
//       \U0018    \U0019    \U001A    \U001B    \U001C    \U001D
//       \U001E    \U001F    \U007F    \U0080    \U0081    \U0082
//       \U0083    \U0084    \U0085    \U0086    \U0087    \U0088
//       \U0089    \U008A    \U008B    \U008C    \U008D    \U008E
//       \U008F    \U0090    \U0091    \U0092    \U0093    \U0094
//       \U0095    \U0096    \U0097    \U0098    \U0099    \U009A
//       \U009B    \U009C    \U009D    \U009E    \U009F
// </Snippet1>