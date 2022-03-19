module nan4

// <Snippet4>
open System

printfn $"NaN == NaN: {Single.NaN = Single.NaN}"
printfn $"NaN != NaN: {Single.NaN <> Single.NaN}"
printfn $"NaN.Equals(NaN): {Single.NaN.Equals Single.NaN}"
printfn $"! NaN.Equals(NaN): {not (Single.NaN.Equals Single.NaN)}"
printfn $"IsNaN: {Double.IsNaN Double.NaN}"

printfn $"\nNaN > NaN: {Single.NaN > Single.NaN}"
printfn $"NaN >= NaN: {Single.NaN >= Single.NaN}"
printfn $"NaN < NaN: {Single.NaN < Single.NaN}"
printfn $"NaN < 100.0: {Single.NaN < 100f}"
printfn $"NaN <= 100.0: {Single.NaN <= 100f}"
printfn $"NaN >= 100.0: {Single.NaN > 100f}"
printfn $"NaN.CompareTo(NaN): {Single.NaN.CompareTo Single.NaN}"
printfn $"NaN.CompareTo(100.0): {Single.NaN.CompareTo 100f}"
printfn $"(100.0).CompareTo(Single.NaN): {100f.CompareTo Single.NaN}"
// The example displays the following output:
//       NaN == NaN: False
//       NaN != NaN: True
//       NaN.Equals(NaN): True
//       ! NaN.Equals(NaN): False
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
//       (100.0).CompareTo(Single.NaN): 1
// </Snippet4>