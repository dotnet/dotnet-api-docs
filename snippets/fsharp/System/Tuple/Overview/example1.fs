module example1

open System

let ctor1 () =
    // <Snippet1>
    // Create a 7-tuple.
    let population = Tuple<string, int, int, int, int, int, int>(
                                "New York", 7891957, 7781984, 
                                7894862, 7071639, 7322564, 8008278)
    // Display the first and last elements.
    printfn $"Population of {population.Item1} in 2000: {population.Item7:N0}"
    // The example displays the following output:
    //       Population of New York in 2000: 8,008,278
    // </Snippet1>

let factory () =
    // <Snippet2>
    // Create a 7-tuple.
    let population = Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
    // Display the first and last elements.
    printfn $"Population of {population.Item1} in 2000: {population.Item7:N0}"
    // The example displays the following output:
    //       Population of New York in 2000: 8,008,278
    // </Snippet2>

ctor1 ()
factory ()