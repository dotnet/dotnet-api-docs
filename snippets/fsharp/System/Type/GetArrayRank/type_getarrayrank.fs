// <Snippet1>
open System

try
    let myArray = Array3D.zeroCreate 2 2 3
    myArray[0, 0, 0] <- 12
    myArray[0, 0, 1] <- 2
    myArray[0, 0, 2] <- 35

    myArray[0, 1, 0] <- 300
    myArray[0, 1, 1] <- 78
    myArray[0, 1, 2] <- 33
    
    myArray[1, 0, 0] <- 92
    myArray[1, 0, 1] <- 42
    myArray[1, 0, 2] <- 135
    
    myArray[1, 1, 0] <- 30
    myArray[1, 1, 1] <- 7
    myArray[1, 1, 2] <- 3
    let myType = myArray.GetType()

    printfn "Contents of myArray: {{{12,2,35},{300,78,33}},{{92,42,135},{30,7,3}}}"
    printfn $"myArray has {myType.GetArrayRank()} dimensions."
with 
| :? NotSupportedException as e ->
    printfn "NotSupportedException raised."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
| e ->
    printfn "Exception raised."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
// </Snippet1>