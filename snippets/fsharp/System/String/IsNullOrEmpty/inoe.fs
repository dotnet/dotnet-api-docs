namespace IsNullOrEmpty
open System

module Inoe =

    //<Snippet1>
    let test (s: string): string =
        if String.IsNullOrEmpty(s)
        then "is null or empty"
        else $"(\"{s}\") is neither null nor empty"

    let s1 = "abcd"
    let s2 = ""
    let s3 = null

    printfn "String s1 %s" (test s1)
    printfn "String s2 %s" (test s2)
    printfn "String s2 %s" (test s3)

    // The example displays the following output:
    //       String s1 ("abcd") is neither null nor empty.
    //       String s2 is null or empty.
    //       String s3 is null or empty.
    //</Snippet1>
