// <snippet2>
open System.IO

let di1 = DirectoryInfo @"\\tempshare\tempdir"
let di2 = DirectoryInfo "tempdir"
let di3 = DirectoryInfo @"x:\tempdir"
let di4 = DirectoryInfo @"c:\"

printfn $"The root path of '{di1.FullName}' is '{di1.Root}'"
printfn $"The root path of '{di2.FullName}' is '{di2.Root}'"
printfn $"The root path of '{di3.FullName}' is '{di3.Root}'"
printfn $"The root path of '{di4.FullName}' is '{di4.Root}'"
(*
This code produces output similar to the following:

The root path of '\\tempshare\tempdir' is '\\tempshare\tempdir'
The root path of 'c:\Projects\ConsoleApplication1\ConsoleApplication1\bin\Debug\tempdir' is 'c:\'
The root path of 'x:\tempdir' is 'x:\'
The root path of 'c:\' is 'c:\'
Press any key to continue . . .

*)
// </snippet2>