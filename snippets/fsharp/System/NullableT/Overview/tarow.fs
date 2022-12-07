//<snippet1>
open System

// Define the "titleAuthor" table of the Microsoft "pubs" database.

type titleAuthor =
  struct
    // Author ID format ###-##-####
    val mutable au_id: string
    // Title ID format AA####
    val mutable title_id: string
    // Author ORD is nullable.
    val mutable au_ord: Nullable<int16>
    // Royalty Percent is nullable.
    val mutable royaltyper: Nullable<int>
  end

// Display the values of the titleAuthor array elements.
let display dspTitle (dspAllTitleAuthors: #seq<titleAuthor>) =
    printfn $"*** {dspTitle} ***"
    for dspTA in dspAllTitleAuthors do
        printfn $"Author ID ... {dspTA.au_id}"
        printfn $"Title ID .... {dspTA.title_id}"
        printfn $"Author ORD .. {dspTA.au_ord.GetValueOrDefault -1s}"
        printfn $"Royalty %% ... {dspTA.royaltyper.GetValueOrDefault -1}\n"

// Declare and initialize the titleAuthor array.
let ta = Array.zeroCreate<titleAuthor> 3
ta[0].au_id <- "712-32-1176"
ta[0].title_id <- "PS3333"
ta[0].au_ord <- Nullable 1s
ta[0].royaltyper <- Nullable 100

ta[1].au_id <- "213-46-8915"
ta[1].title_id <- "BU1032"
ta[1].au_ord <- Nullable()
ta[1].royaltyper <- Nullable()

ta[2].au_id <- "672-71-3249"
ta[2].title_id <- "TC7777"
ta[2].au_ord <- Nullable()
ta[2].royaltyper <- Nullable 40

// Display the values of the titleAuthor array elements, and
// display a legend.
display "Title Authors Table" ta
printfn "Legend:"
printfn "An Author ORD of -1 means no value is defined."
printfn "A Royalty %% of 0 means no value is defined."

// The example displays the following output:
//     *** Title Authors Table ***
//     Author ID ... 712-32-1176
//     Title ID .... PS3333
//     Author ORD .. 1
//     Royalty % ... 100
//
//     Author ID ... 213-46-8915
//     Title ID .... BU1032
//     Author ORD .. -1
//     Royalty % ... 0
//
//     Author ID ... 672-71-3249
//     Title ID .... TC7777
//     Author ORD .. -1
//     Royalty % ... 40
//
//     Legend:
//     An Author ORD of -1 means no value is defined.
//     A Royalty % of 0 means no value is defined.
//</snippet1>