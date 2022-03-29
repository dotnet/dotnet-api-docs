module format_paramarray1

// <Snippet10>
open System

type CityInfo =
  { Name: string
    Population: int
    Area: Decimal
    Year: int }

let showPopulationData city =
    let args: obj[] = [| city.Name; city.Year; city.Population; city.Area |]
    String.Format("{0} in {1}: Population {2:N0}, Area {3:N1} sq. feet", args)
    |> printfn "%s"

{ Name = "New York"; Population = 8175133; Area = 302.64m; Year = 2010 }
|> showPopulationData

 
{ Name = "Seattle"; Population = 608660; Area = 83.94m; Year = 2010 }      
|> showPopulationData 

// The example displays the following output:
//       New York in 2010: Population 8,175,133, Area 302.6 sq. feet
//       Seattle in 2010: Population 608,660, Area 83.9 sq. feet
// </Snippet10>