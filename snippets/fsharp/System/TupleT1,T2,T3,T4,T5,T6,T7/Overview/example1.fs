// <Snippet1>
open System

let computePopulationChange (data: Tuple<string, int, int, int, int, int, int>) =  
    Tuple.Create(data.Item1, 
                 double (data.Item3 - data.Item2) / double data.Item2, 
                 double (data.Item4 - data.Item3) / double data.Item3, 
                 double (data.Item5 - data.Item4) / double data.Item4, 
                 double (data.Item6 - data.Item5) / double data.Item5,
                 double (data.Item7 - data.Item6) / double data.Item6,
                 double (data.Item7 - data.Item2) / double data.Item2)

// Get population data for New York City, 1950-2000.
let population = 
    Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
let rate = computePopulationChange population
// Display results.
printfn $"Population Change, {population.Item1}, 1950-2000\n"
printfn $"""Year      {"Population",10} {"Annual Rate",9}"""
printfn $"""1950      {population.Item2,10:N0} {"NA",11}"""
printfn $"1960      {population.Item3,10:N0} {rate.Item2 / 10.,11:P2}"
printfn $"1970      {population.Item4,10:N0} {rate.Item3 / 10.,11:P2}" 
printfn $"1980      {population.Item5,10:N0} {rate.Item4 / 10.,11:P2}" 
printfn $"1990      {population.Item6,10:N0} {rate.Item5 / 10.,11:P2}" 
printfn $"2000      {population.Item7,10:N0} {rate.Item6 / 10.,11:P2}" 
printfn $"""1950-2000 {"",10:N0} {rate.Item7 / 50.,11:P2}"""

// The example displays the following output:
//       Population Change, New York, 1950-2000
//       
//       Year      Population Annual Rate
//       1950       7,891,957          NA
//       1960       7,781,984     -0.14 %
//       1970       7,894,862      0.15 %
//       1980       7,071,639     -1.04 %
//       1990       7,322,564      0.35 %
//       2000       8,008,278      0.94 %
//       1950-2000                 0.03 %
// </Snippet1>