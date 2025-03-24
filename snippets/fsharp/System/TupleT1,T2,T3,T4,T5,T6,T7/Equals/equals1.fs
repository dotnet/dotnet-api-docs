module equals1

// <Snippet1>
open System

// Get population data for New York City and Los Angeles, 1960-2000.
let urbanPopulations =
    [| Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
       Tuple.Create("Los Angeles", 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
       Tuple.Create("New York City", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
       Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278) |]
// Compare each tuple with every other tuple for equality.
for ctr = 0 to urbanPopulations.Length - 2 do
    let urbanPopulation = urbanPopulations[ctr]
    printfn $"{urbanPopulation} = "
    for innerCtr = ctr + 1 to urbanPopulations.Length - 1 do
        printfn $"   {urbanPopulations[innerCtr]}: {urbanPopulation.Equals urbanPopulations[innerCtr]}"
    printfn ""
// The example displays the following output:
//    (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278) =
//       (Los Angeles, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820): False
//       (New York City, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): False
//       (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): True
//    
//    (Los Angeles, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820) =
//       (New York City, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): False
//       (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): False
//    
//    (New York City, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278) =
//       (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278): False
// </Snippet1>