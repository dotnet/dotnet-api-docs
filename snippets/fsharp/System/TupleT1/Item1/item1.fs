// <Snippet1>
open System

let tuple1 = Tuple.Create -1.23445e-32
// Display information about this singleton.
let tuple1Type = tuple1.GetType()
printfn "First 1-Tuple:"
printfn $"   Type: {tuple1Type.Name}"
printfn $"   Generic Parameter Type: {tuple1Type.GetGenericArguments()[0]}" 
printfn $"   Component Value: {tuple1.Item1}"
printfn $"   Component Value Type: {tuple1.Item1.GetType().Name}\n"

let tuple2 = Tuple.Create(bigint 1.83789322281780983781356676e103)
// Display information about this singleton.
let tuple2Type = tuple2.GetType()
printfn "Second 1-Tuple:"
printfn $"   Type: {tuple2Type.Name}"
printfn $"   Generic Parameter Type: {tuple2Type.GetGenericArguments()[0]}" 
printfn $"   Component Value: {tuple2.Item1}"
printfn $"   Component Value Type: {tuple2.Item1.GetType().Name}"
// The example displays the following output:
//       First 1-Tuple:
//          Type: Tuple`1
//          Generic Parameter Type: System.Double
//          Component Value: -1.23445E-32
//          Component Value Type: Double
//       
//       Second 1-Tuple:
//          Type: Tuple`1
//          Generic Parameter Type: System.Numerics.BigInteger
//          Component Value: 1.8378932228178098168858909492E+103
//          Component Value Type: BigInteger
// </Snippet1>