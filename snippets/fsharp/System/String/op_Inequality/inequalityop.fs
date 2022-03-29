module inequalityop.fs
//<snippet1>
// Example for the String Inequality operator.
printfn "This example of the String Inequality operator\ngenerates the following output.\n"

let compareAndDisplay comparand =
    let lower = "abcd"
    printfn $"\"%s{lower}\" <> \"%s{comparand}\" ?  {lower <> comparand}"

compareAndDisplay "ijkl"
compareAndDisplay "ABCD"
compareAndDisplay "abcd"

(*
This example of the String Inequality operator
generates the following output.

"abcd" <> "ijkl" ?  True
"abcd" <> "ABCD" ?  True
"abcd" <> "abcd" ?  False
*)
//</snippet1>
