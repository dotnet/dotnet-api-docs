module stringjoin.fs
//<snippet1>
open System

let makeLine initVal multVal (sep: string) =
    let sArr = Array.zeroCreate<string> 10 

    for i = initVal to initVal + 9 do
        sArr[i - initVal] <- String.Format("{0,-3}", i * multVal)

    String.Join(sep, sArr)

printfn $"""{makeLine 0 5 ", "}"""
printfn $"""{makeLine 1 6 "  "}"""
printfn $"""{makeLine 9 9 ": "}"""
printfn $"""{makeLine 4 7 "< "}"""

// The example displays the following output:
//       0  , 5  , 10 , 15 , 20 , 25 , 30 , 35 , 40 , 45
//       6    12   18   24   30   36   42   48   54   60
//       81 : 90 : 99 : 108: 117: 126: 135: 144: 153: 162
//       28 < 35 < 42 < 49 < 56 < 63 < 70 < 77 < 84 < 91
// </snippet1>
