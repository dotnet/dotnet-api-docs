// <Snippet1>
// Declare an interface.
type myIFace = interface end

type MyIsInterface = class end

try
    // Get the IsInterface attribute for myIFace.
    let myBool1 = typeof<myIFace>.IsInterface
    //Display the IsInterface attribute for myIFace.
    printfn $"Is the specified type an interface? {myBool1}."
    // Get the attribute IsInterface for MyIsInterface.
    let myBool2 = typeof<MyIsInterface>.IsInterface
    //Display the IsInterface attribute for MyIsInterface.
    printfn $"Is the specified type an interface? {myBool2}."
with e ->
    printfn $"\nAn exception occurred: {e.Message}."
(* The example produces the following output:

Is the specified type an interface? True.
Is the specified type an interface? False.
*)
// </Snippet1>