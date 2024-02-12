module Array4

// <Snippet11>
let values = Array.zeroCreate<int> 10
for i = 0 to 9 do
    values[i] <- i * 2

for value in values do
    printfn $"{value}"
// The example displays the following output:
//    0
//    2
//    4
//    6
//    8
//    10
//    12
//    14
//    16
//    18
// </Snippet11>