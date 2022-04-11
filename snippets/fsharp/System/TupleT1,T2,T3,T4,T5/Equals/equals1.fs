module equals1

// <Snippet1>
open System

let temperatureInfos = 
    [| Tuple.Create(2, 97.9, 97.8, 98.0, 98.2)
       Tuple.Create(1, 98.6, 98.8, 98.8, 99.0)
       Tuple.Create(2, 98.6, 98.6, 98.6, 98.4)
       Tuple.Create(1, 98.4, 98.6, 99.0, 99.2)
       Tuple.Create(2, 98.6, 98.6, 98.6, 98.4)
       Tuple.Create(1, 98.6, 98.8, 98.8, 99.0) |]
// Compare each item with every other item for equality.
for ctr = 0 to temperatureInfos.Length - 1 do
    let temperatureInfo = temperatureInfos[ctr]
    for ctr2 = ctr + 1 to temperatureInfos.Length - 1 do
        printfn $"{temperatureInfo} = {temperatureInfos[ctr2]}: {temperatureInfo.Equals temperatureInfos[ctr2]}"
    printfn ""

// The example displays the following output:
//    (2, 97.9, 97.8, 98, 98.2) = (1, 98.6, 98.8, 98.8, 99): False
//    (2, 97.9, 97.8, 98, 98.2) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (2, 97.9, 97.8, 98, 98.2) = (1, 98.4, 98.6, 99, 99.2): False
//    (2, 97.9, 97.8, 98, 98.2) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (2, 97.9, 97.8, 98, 98.2) = (1, 98.6, 98.8, 98.8, 99): False
//    
//    (1, 98.6, 98.8, 98.8, 99) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (1, 98.6, 98.8, 98.8, 99) = (1, 98.4, 98.6, 99, 99.2): False
//    (1, 98.6, 98.8, 98.8, 99) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (1, 98.6, 98.8, 98.8, 99) = (1, 98.6, 98.8, 98.8, 99): True
//    
//    (2, 98.6, 98.6, 98.6, 98.4) = (1, 98.4, 98.6, 99, 99.2): False
//    (2, 98.6, 98.6, 98.6, 98.4) = (2, 98.6, 98.6, 98.6, 98.4): True
//    (2, 98.6, 98.6, 98.6, 98.4) = (1, 98.6, 98.8, 98.8, 99): False
//    
//    (1, 98.4, 98.6, 99, 99.2) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (1, 98.4, 98.6, 99, 99.2) = (1, 98.6, 98.8, 98.8, 99): False
//    
//    (2, 98.6, 98.6, 98.6, 98.4) = (1, 98.6, 98.8, 98.8, 99): False
// </Snippet1>