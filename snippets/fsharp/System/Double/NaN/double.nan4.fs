module double.nan4

// <Snippet4>
open System

printfn $"NaN = NaN: {Double.NaN = Double.NaN}"
printfn $"NaN <> NaN: {Double.NaN <> Double.NaN}"
printfn $"NaN.Equals(NaN): {Double.NaN.Equals Double.NaN}"
printfn $"not (NaN.Equals NaN): {not (Double.NaN.Equals Double.NaN)}"
printfn $"IsNaN: {Double.IsNaN Double.NaN}"

printfn $"\nNaN > NaN: {Double.NaN > Double.NaN}"
printfn $"NaN >= NaN: {Double.NaN >= Double.NaN}"
printfn $"NaN < NaN: {Double.NaN < Double.NaN}"
printfn $"NaN < 100.0: {Double.NaN < 100.0}"
printfn $"NaN <= 100.0: {Double.NaN <= 100.0}"
printfn $"NaN >= 100.0: {Double.NaN > 100.0}"
printfn $"NaN.CompareTo(NaN): {Double.NaN.CompareTo Double.NaN}"
printfn $"NaN.CompareTo(100.0): {Double.NaN.CompareTo 100.0}"
printfn $"(100.0).CompareTo(Double.NaN): {(100.0).CompareTo Double.NaN}"
// The example displays the following output:
//       NaN = NaN: False
//       NaN <> NaN: True
//       NaN.Equals(NaN): True
//       not (NaN.Equals NaN): False
//       IsNaN: True
//
//       NaN > NaN: False
//       NaN >= NaN: False
//       NaN < NaN: False
//       NaN < 100.0: False
//       NaN <= 100.0: False
//       NaN >= 100.0: False
//       NaN.CompareTo(NaN): 0
//       NaN.CompareTo(100.0): -1
//       (100.0).CompareTo(Double.NaN): 1
// </Snippet4>
