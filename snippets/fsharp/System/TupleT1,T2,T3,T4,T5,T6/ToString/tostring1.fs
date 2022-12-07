// <Snippet1>
open System

// Get population data for New York City, 1960-2000.
let population = Tuple.Create("New York", 7781984, 7894862, 7071639, 7322564, 8008278)
printfn $"{population.ToString()}"
// The example displays the following output:
//    (New York, 7781984, 7894862, 7071639, 7322564, 8008278)
// </Snippet1>