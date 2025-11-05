module equalsobj

// <Snippet3>
open System.Numerics

let obj: obj[] = [| 0; 10; 100; BigInteger 1000; -10 |]

let bi =
    [| BigInteger.Zero
       BigInteger 10
       BigInteger 100
       BigInteger 1000
       BigInteger -10 |]

for ctr = 0 to bi.Length - 1 do
    printfn $"{bi.[ctr].Equals(obj.[ctr])}"
// The example displays the following output:
//       False
//       False
//       False
//       True
//       False
// </Snippet3>
