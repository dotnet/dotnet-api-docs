module Race2

// <Snippet12>
open System.Collections.Concurrent
open System.Threading

type Continent =
    { Name: string
      Population: int
      Area: decimal }

let continents = ConcurrentBag<Continent>();
let mutable msg = ""

let names = 
    [ "Africa"; "Antarctica"; "Asia"
      "Australia"; "Europe"; "North America"
      "South America" ]

let gate = new CountdownEvent(names.Length)

let populateContinents obj = 
    let name = string obj
    lock msg (fun () -> 
        msg <- msg + $"Adding '{name}' to the list.\n" )

    // Sleep to simulate retrieving remaining data.
    let continent = 
        { Name = name
          Population = 0
          Area = 0M }
    Thread.Sleep 25
    continents.Add continent
    gate.Signal() |> ignore

// Populate the list.
for name in names do
    let th = Thread(ParameterizedThreadStart populateContinents)
    th.Start name

// Display the list.
gate.Wait();
printfn $"{msg}\n"

let arr = continents.ToArray();
for i = 0 to names.Length - 1 do
    let continent = arr[i]
    printfn $"{continent.Name}: Area: {continent.Population}, Population {continent.Area}"

// The example displays output like the following:
//       Adding 'Africa' to the list.
//       Adding 'Antarctica' to the list.
//       Adding 'Asia' to the list.
//       Adding 'Australia' to the list.
//       Adding 'Europe' to the list.
//       Adding 'North America' to the list.
//       Adding 'South America' to the list.
//
//
//       Africa: Area: 0, Population 0
//       Antarctica: Area: 0, Population 0
//       Asia: Area: 0, Population 0
//       Australia: Area: 0, Population 0
//       Europe: Area: 0, Population 0
//       North America: Area: 0, Population 0
//       South America: Area: 0, Population 0
// </Snippet12>
