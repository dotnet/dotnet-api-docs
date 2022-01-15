module overlap1

open System

let copyUp () =
    // <Snippet3>
    let intSize = 4
    let arr = [| 2; 4; 6; 8; 10; 12; 14; 16; 18; 20 |]
    Buffer.BlockCopy(arr, 0 * intSize, arr, 3 * intSize, 4 * intSize)
    for value in arr do
        printf $"{value}  "

    // The example displays the following output:
    //       2  4  6  2  4  6  8  16  18  20
    // </Snippet3>

let copyDown () =
    // <Snippet4>
    let intSize = 4
    let arr = [| 2; 4; 6; 8; 10; 12; 14; 16; 18; 20 |]
    Buffer.BlockCopy(arr, 3 * intSize, arr, 0 * intSize, 4 * intSize)
    for value in arr do
        printf $"{value}  "

    // The example displays the following output:
    //       8  10  12  14  10  12  14  16  18  20
    // </Snippet4>

copyUp ()
printfn ""
copyDown ()