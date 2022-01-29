// <Snippet1>
open System

type CityInfo =
    { City: string
      Country: string
      Population: int }

    static member CompareByName city1 city2 =
        String.Compare(city1.City, city2.City)

    static member CompareByPopulation city1 city2 =
        city1.Population.CompareTo city2.Population 

    static member CompareByNames city1 city2 =
        String.Compare(city1.Country + city1.City, city2.Country + city2.City)

let display cities =
    printfn $"""{"City",-20} {"Country",-25} {"Population",10}"""
    for city in cities do
        printfn $"{city.City,-20} {city.Country,-25} {city.Population,10:N0}"
    printfn ""

let NYC = { City = "New York City"; Country = "United States of America"; Population = 8175133 }
let Det = { City = "Detroit"; Country = "United States of America"; Population = 713777 }
let Paris = { City = "Paris"; Country = "France"; Population = 2193031 }
let cities = [| NYC; Det; Paris |]
// Display ordered array.
display cities

// Sort array by city name.
Array.Sort(cities, CityInfo.CompareByName)
display cities

// Sort array by population.
Array.Sort(cities, CityInfo.CompareByPopulation);
display cities

// Sort array by country + city name.
Array.Sort(cities, CityInfo.CompareByNames);
display cities


// The example displays the following output:
//     City                 Country                   Population
//     New York City        United States of America   8,175,133
//     Detroit              United States of America     713,777
//     Paris                France                     2,193,031
//
//     City                 Country                   Population
//     Detroit              United States of America     713,777
//     New York City        United States of America   8,175,133
//     Paris                France                     2,193,031
//
//     City                 Country                   Population
//     Detroit              United States of America     713,777
//     Paris                France                     2,193,031
//     New York City        United States of America   8,175,133
//
//     City                 Country                   Population
//     Paris                France                     2,193,031
//     Detroit              United States of America     713,777
//     New York City        United States of America   8,175,133
// </Snippet1>