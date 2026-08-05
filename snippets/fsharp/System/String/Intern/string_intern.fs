module string_intern.fs
//<snippet1>
// Sample for String.Intern(String)
open System
open System.Text

let s1 = StringBuilder().Append("My").Append("Test").ToString()
let s2 = StringBuilder().Append("My").Append("Test").ToString()
printfn $"s1 = {s1}"
printfn $"s2 = {s2}"
printfn $"Are s1 and s2 equal in value? {s1 = s2}"
printfn $"Are s1 and s2 the same reference? {Object.ReferenceEquals(s1, s2)}"

let i1 = String.Intern s1
let i2 = String.Intern s2
printfn "After interning:"
printfn $"  Are i1 and i2 equal in value? {i1 = i2}"
printfn $"  Are i1 and i2 the same reference? {Object.ReferenceEquals(i1, i2)}"
(*
This example produces the following results:
s1 = MyTest
s2 = MyTest
Are s1 and s2 equal in value? True
Are s1 and s2 the same reference? False
After interning:
  Are i1 and i2 equal in value? True
  Are i1 and i2 the same reference? True
*)
//</snippet1>
