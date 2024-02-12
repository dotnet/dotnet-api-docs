// <Snippet1>
open System

// Create tuples containing population data for New York, Chicago, 
// and Los Angeles, 1960-2000.
let cities =
    [| Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
       Tuple.Create("Los Angeles", 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
       Tuple.Create("Chicago", 3620962, 3550904, 3366957, 3005072, 2783726, 2896016) |]

// Display tuple data in table.
let header = "Population in"
printfn $"""{"City",-12} {String('-',(66 - header.Length) / 2) + header + String('-', (66 - header.Length) / 2),66}""" 
printfn "%24s%11s%11s%11s%11s%11s\n" "1950" "1960" "1970" "1980" "1990" "2000"         

for city in cities do
    printfn $"{city.Item1,-12} {city.Item2,11:N0}{city.Item3,11:N0}{city.Item4,11:N0}{city.Item5,11:N0}{city.Item6,11:N0}{city.Item7,11:N0}"
// The example displays the following output:
//   City          --------------------------Population in--------------------------
//                       1950       1960       1970       1980       1990       2000
//
//   New York       7,891,957  7,781,984  7,894,862  7,071,639  7,322,564  8,008,278
//   Los Angeles    1,970,358  2,479,015  2,816,061  2,966,850  3,485,398  3,694,820
//   Chicago        3,620,962  3,550,904  3,366,957  3,005,072  2,783,726  2,896,016
// </Snippet1>