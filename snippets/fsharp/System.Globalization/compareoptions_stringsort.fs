open System
open System.Collections.Generic
open System.Globalization

let sortAndDisplay (unsorted: List<string>) (options: CompareOptions) =
    let words = new List<string>(unsorted)
    let comparer = CultureInfo.InvariantCulture.CompareInfo
    words.Sort((fun str1 str2 -> comparer.Compare(str1, str2, options)))
    for word in words do
        printfn "%s" word

[<EntryPoint>]
let main argv =
    let wordList = new List<string>(
        ["cant"; "bill's"; "coop"; "cannot"; "billet"; "can't"; "con"; "bills"; "co-op"])

    printfn "Before sorting:"
    for word in wordList do
        printfn "%s" word

    printfn "\nAfter sorting with CompareOptions.None:"
    sortAndDisplay wordList CompareOptions.None

    printfn "\nAfter sorting with CompareOptions.StringSort:"
    sortAndDisplay wordList CompareOptions.StringSort

    0 // return an integer exit code

(*
CompareOptions.None and CompareOptions.StringSort provide identical ordering by default
in .NET 5 and later, but in prior versions, the output will be the following:

Before sorting:
cant
bill's
coop
cannot
billet
can't
con
bills
co-op

After sorting with CompareOptions.None:
billet
bills
bill's
cannot
cant
can't
con
coop
co-op

After sorting with CompareOptions.StringSort:
bill's
billet
bills
can't
cannot
cant
co-op
con
coop
*)
