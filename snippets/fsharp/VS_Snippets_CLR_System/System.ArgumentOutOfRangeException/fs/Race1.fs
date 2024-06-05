module Race1

// <Snippet11>
open System.Threading

type Continent =
    { Name: string
      Population: int
      Area: decimal }

let continents = ResizeArray<Continent>()
let mutable msg = ""

let names = 
    [ "Africa"; "Antarctica"; "Asia"
      "Australia"; "Europe"; "North America"
      "South America" ]

let populateContinents obj = 
    let name = string obj
    msg <- msg + $"Adding '{name}' to the list.\n"
    // Sleep to simulate retrieving data.
    Thread.Sleep 50
    let continent = 
        { Name = name
          Population = 0
          Area = 0M }
    continents.Add continent
      
// Populate the list.
for name in names do
    let th = Thread(ParameterizedThreadStart populateContinents)
    th.Start name
      
printfn $"{msg}\n"

// Display the list.
for i = 0 to names.Length - 1 do
    let continent = continents[i]
    printfn $"{continent.Name}: Area: {continent.Population}, Population {continent.Area}"

// The example displays output like the following:
//    Unhandled Exception: System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
//       at System.Collections.Generic.List`1.get_Item(Int32 index)
//       at <StartupCode$argumentoutofrangeexception>.$Race1.main@()
// </Snippet11>
