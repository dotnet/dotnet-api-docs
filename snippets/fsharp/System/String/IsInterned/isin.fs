module isin.fs
//<snippet1>
// Sample for String.IsInterned(String)
open System
open System.Text
open System.Runtime.CompilerServices

// In the .NET Framework 2.0 the following attribute declaration allows you to
// avoid the use of the interning when you use NGEN.exe to compile an assembly
// to the native image cache.
[<assembly: CompilationRelaxations(CompilationRelaxations.NoStringInterning)>]
do ()

let test sequence str =
    printf $"%d{sequence}) The string, '"
    let strInterned = String.IsInterned str
    if isNull strInterned then
        printfn $"{str}', is not interned."
    else
        printfn $"{strInterned}', is interned."

// String str1 is known at compile time, and is automatically interned.
let str1 = "abcd"

// Constructed string, str2, is not explicitly or automatically interned.
let str2 = StringBuilder().Append("wx").Append("yz").ToString()
printfn ""
test 1 str1
test 2 str2


//This example produces the following results:

//1) The string, 'abcd', is interned.
//2) The string, 'wxyz', is not interned.

//If you use NGEN.exe to compile the assembly to the native image cache, this
//example produces the following results:

//1) The string, 'abcd', is not interned.
//2) The string, 'wxyz', is not interned.

//</snippet1>
