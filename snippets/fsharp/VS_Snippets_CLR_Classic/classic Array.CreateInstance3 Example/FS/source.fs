// <Snippet1>
open System

let printValues (myArray: Array) =
    let mutable i = 0
    let cols = myArray.GetLength(myArray.Rank - 1)
    for item in myArray do
        if i < cols then
            i <- i + 1
        else
            printfn ""
            i <- 1;
        printf $"\t{item}"
    printfn ""

// Creates and initializes a multidimensional Array of type string.
let my4DArray = Array.CreateInstance( typeof<string>, [| 2..5 |] )

for i = my4DArray.GetLowerBound 0 to my4DArray.GetUpperBound 0 do
    for j = my4DArray.GetLowerBound 1 to my4DArray.GetUpperBound 1 do
        for k = my4DArray.GetLowerBound 2 to my4DArray.GetUpperBound 2 do
            for l = my4DArray.GetLowerBound 3 to my4DArray.GetUpperBound 3 do
                let myIndicesArray = [| i; j; k; l |]
                my4DArray.SetValue($"{i}{j}{k}{l}", myIndicesArray)

// Displays the values of the Array.
printfn "The four-dimensional Array contains the following values:"
printValues my4DArray 


// This code produces the following output.
//     The four-dimensional Array contains the following values:
//         0000    0001    0002    0003    0004
//         0010    0011    0012    0013    0014
//         0020    0021    0022    0023    0024
//         0030    0031    0032    0033    0034
//         0100    0101    0102    0103    0104
//         0110    0111    0112    0113    0114
//         0120    0121    0122    0123    0124
//         0130    0131    0132    0133    0134
//         0200    0201    0202    0203    0204
//         0210    0211    0212    0213    0214
//         0220    0221    0222    0223    0224
//         0230    0231    0232    0233    0234
//         1000    1001    1002    1003    1004
//         1010    1011    1012    1013    1014
//         1020    1021    1022    1023    1024
//         1030    1031    1032    1033    1034
//         1100    1101    1102    1103    1104
//         1110    1111    1112    1113    1114
//         1120    1121    1122    1123    1124
//         1130    1131    1132    1133    1134
//         1200    1201    1202    1203    1204
//         1210    1211    1212    1213    1214
//         1220    1221    1222    1223    1224
//         1230    1231    1232    1233    1234

// </Snippet1>
