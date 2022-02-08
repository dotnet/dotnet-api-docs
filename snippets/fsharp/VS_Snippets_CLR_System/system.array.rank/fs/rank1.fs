// <Snippet1>
let array1 = Array.zeroCreate<int> 10
let array2 = Array2D.zeroCreate<int> 10 3
let array3 = Array.zeroCreate<int[]> 10

printfn $"{array1}: {array1.Rank} dimension(s)"

printfn $"{array2}: {array2.Rank} dimension(s)"

printfn $"{array3}: {array3.Rank} dimension(s)"

// The example displays the following output:
//       System.Int32[]: 1 dimension(s)
//       System.Int32[,]: 2 dimension(s)
//       System.Int32[][]: 1 dimension(s)
// </Snippet1>