open System

let useCharEnumerator() =
    // <Snippet1>
    let title = "A Tale of Two Cities"
    let chEnum = title.GetEnumerator()

    printfn $"The length of the string is {title.Length} characters:"

    let mutable outputLine1 = ""
    let mutable outputLine2 = ""
    let mutable outputLine3 = ""
    let mutable i = 1

    while chEnum.MoveNext() do
        outputLine1 <- outputLine1 + if i < 10 || i % 10 <> 0 then "  " else $"{i / 10} "
        outputLine2 <- outputLine2 + $"{i % 10} ";
        outputLine3 <- outputLine3 + $"{chEnum.Current} "
        i <- i + 1

    printfn "%s" outputLine1
    printfn "%s" outputLine2
    printfn "%s" outputLine3

    // The example displays the following output to the console:
    //       The length of the string is 20 characters:
    //                         1                   2
    //       1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
    //       A   T a l e   o f   T w o   C i t i e s
    // </Snippet1>

let useForEach () =
    // <Snippet2>
    let title = "A Tale of Two Cities"
    let chEnum = title.GetEnumerator()

    printfn $"The length of the string is {title.Length} characters:"

    let mutable outputLine1 = ""
    let mutable outputLine2 = ""
    let mutable outputLine3 = ""
    let mutable i = 1

    for ch in title do
        outputLine1 <- outputLine1 + if i < 10 || i % 10 <> 0 then "  " else $"{i / 10} "
        outputLine2 <- outputLine2 + $"{i % 10} ";
        outputLine3 <- outputLine3 + $"{ch} "
        i <- i + 1

    printfn "%s" outputLine1
    printfn "%s" outputLine2
    printfn "%s" outputLine3

    // The example displays the following output to the console:
    //       The length of the string is 20 characters:
    //                         1                   2
    //       1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
    //       A   T a l e   o f   T w o   C i t i e s
    // </Snippet2>

useCharEnumerator ()
printfn "-----"
useForEach ()