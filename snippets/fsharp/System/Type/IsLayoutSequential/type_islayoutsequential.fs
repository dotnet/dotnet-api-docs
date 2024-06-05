// <Snippet1>
open System.Runtime.InteropServices

type MyTypeSequential1 = struct end

[<StructLayoutAttribute(LayoutKind.Sequential)>]
type MyTypeSequential2 = struct end

try
    // Create an instance of myTypeSeq1.
    let myObj1 = MyTypeSequential1()
    let myTypeObj1 = myObj1.GetType()
    // Check for and display the SequentialLayout attribute.
    printfn $"\nThe object myObj1 has IsLayoutSequential: {myTypeObj1.IsLayoutSequential}."
    // Create an instance of 'myTypeSeq2' class.
    let myObj2 = MyTypeSequential2()
    let myTypeObj2 = myObj2.GetType()
    // Check for and display the SequentialLayout attribute.
    printfn $"\nThe object myObj2 has IsLayoutSequential: {myTypeObj2.IsLayoutSequential}."
with e ->
    printfn $"\nAn exception occurred: {e.Message}"
// </Snippet1>