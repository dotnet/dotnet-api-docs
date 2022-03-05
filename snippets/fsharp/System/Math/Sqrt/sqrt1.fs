// <Snippet1>
open System

// Create a list containing the area of some cities.
let areas =
    [ "Sitka, Alaska", 2870.3
      "New York City", 302.6
      "Los Angeles", 468.7
      "Detroit", 138.8
      "Chicago", 227.1
      "San Diego", 325.2 ]

printfn "%-18s %14s} %2s\n" "City" "Area (mi.)" "Equivalent to a square with:"

for city, area in areas do
    printfn $"{city,-18} {area,14:N1} {Math.Round(Math.Sqrt(area), 2),14:N2} miles per side"

// The example displays the following output:
//    City                   Area (mi.)   Equivalent to a square with:
//
//    Sitka, Alaska             2,870.3          53.58 miles per side
//    New York City               302.6          17.40 miles per side
//    Los Angeles                 468.7          21.65 miles per side
//    Detroit                     138.8          11.78 miles per side
//    Chicago                     227.1          15.07 miles per side
//    San Diego                   325.2          18.03 miles per side
// </Snippet1>