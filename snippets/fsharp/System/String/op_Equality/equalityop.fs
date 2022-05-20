//<snippet1>
// Example for the String Equality operator.
printfn "This example of the String Equality operator\ngenerates the following output.\n"

let compareAndDisplay comparand =
    let lower = "abcd"
    printfn $"\"%s{lower}\" == \"%s{comparand}\" ?  {lower = comparand}"

compareAndDisplay "ijkl"
compareAndDisplay "ABCD"
compareAndDisplay "abcd"

(*
This example of the String Equality operator 
generates the following output.

"abcd" == "ijkl" ?  False
"abcd" == "ABCD" ?  False
"abcd" == "abcd" ?  True
*)
//</snippet1>