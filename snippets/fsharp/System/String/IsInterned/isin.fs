module isin.fs
//<snippet1>
// Sample for String.IsInterned(String)
open System
open System.Text

// Constructed strings are not automatically interned.
let s1 = StringBuilder().Append("My").Append("Test").ToString()
let s2 = StringBuilder().Append("My").Append("Test").ToString()

// Neither string is in the intern pool yet.
printfn $"Is s1 interned? {String.IsInterned(s1) <> null}"
printfn $"Is s2 interned? {String.IsInterned(s2) <> null}"

// Intern s1 explicitly.
let i1 = String.Intern(s1)

// Now s2 can be found in the intern pool.
let i2 = String.IsInterned(s2)

printfn $"Is s2 interned after interning s1? {i2 <> null}"
printfn $"Are i1 and i2 the same reference? {Object.ReferenceEquals(i1, i2)}"

// This example produces the following results:
//
// Is s1 interned? False
// Is s2 interned? False
// Is s2 interned after interning s1? True
// Are i1 and i2 the same reference? True

//</snippet1>
