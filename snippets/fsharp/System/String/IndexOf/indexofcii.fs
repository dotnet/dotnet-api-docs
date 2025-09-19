module indexofcii.fs
//<snippet1>
// Example for the String.IndexOf( char, int, int ) method.
open System

let br1 =
    "0----+----1----+----2----+----3----+----" +
    "4----+----5----+----6----+----7"
let br2 =
    "0123456789012345678901234567890123456789" +
    "0123456789012345678901234567890"
let str =
    "ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi " +
    "ABCDEFGHI abcdefghi ABCDEFGHI"

printfn "This example of String.IndexOf( char, int, int )\ngenerates the following output."
printfn $"{Environment.NewLine}{br1}{Environment.NewLine}{br2}{Environment.NewLine}{str}{Environment.NewLine}"

let findAllChar (target: char) (searched: string) =
    printf $"The character '{target}' occurs at position(s): "

    let mutable hitCount = 0
    let mutable startIndex = -1
    let mutable broken = false
    // Search for all occurrences of the target.
    while not broken do
        startIndex <- searched.IndexOf(target, startIndex + 1, searched.Length - startIndex - 1)

        // Exit the loop if the target is not found.
        if startIndex < 0 then
            broken <- true
        else

        printf $"{startIndex}, "
        hitCount <- hitCount + 1

    printfn $"occurrences: {hitCount}"

findAllChar 'A' str
findAllChar 'a' str
findAllChar 'I' str
findAllChar 'i' str
findAllChar '@' str
findAllChar ' ' str


(*
This example of String.IndexOf( char, int, int )
generates the following output.

0----+----1----+----2----+----3----+----4----+----5----+----6----+----7
01234567890123456789012345678901234567890123456789012345678901234567890
ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi ABCDEFGHI

The character 'A' occurs at position(s): 0, 20, 40, 60, occurrences: 4
The character 'a' occurs at position(s): 10, 30, 50, occurrences: 3
The character 'I' occurs at position(s): 8, 28, 48, 68, occurrences: 4
The character 'i' occurs at position(s): 18, 38, 58, occurrences: 3
The character '@' occurs at position(s): occurrences: 0
The character ' ' occurs at position(s): 9, 19, 29, 39, 49, 59, occurrences: 6
*)
//</snippet1>
