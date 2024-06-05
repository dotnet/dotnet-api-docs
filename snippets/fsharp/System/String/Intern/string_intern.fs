module string_intern.fs
//<snippet1>
// Sample for String.Intern(String)
open System
open System.Text

let s1 = "MyTest"
let s2 = StringBuilder().Append("My").Append("Test").ToString()
let s3 = String.Intern s2
printfn $"s1 = {s1}"
printfn $"s2 = {s2}"
printfn $"s3 = {s3}"
printfn $"Is s2 the same reference as s1?: {s2 :> obj = s1 :> obj}"
printfn $"Is s3 the same reference as s1?: {s3 :> obj = s1 :> obj}"
(*
This example produces the following results:
s1 = MyTest
s2 = MyTest
s3 = MyTest
Is s2 the same reference as s1?: False
Is s3 the same reference as s1?: True
*)
//</snippet1>
