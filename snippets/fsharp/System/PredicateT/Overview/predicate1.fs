module predicate1

// <Snippet3>
open System

type HockeyTeam =
    { Name: string
      Founded: int }

let rnd = Random()
let teams = ResizeArray()
teams.AddRange 
    [| { Name = "Detroit Red Wings"; Founded = 1926 }
       { Name = "Chicago Blackhawks"; Founded = 1926 }
       { Name = "San Jose Sharks"; Founded = 1991 }
       { Name = "Montreal Canadiens"; Founded = 1909 }
       { Name = "St. Louis Blues"; Founded = 1967 }|]

let years = [| 1920; 1930; 1980; 2000 |]
let foundedBeforeYear = years[rnd.Next(0, years.Length)]
printfn $"Teams founded before {foundedBeforeYear}:"
for team in teams.FindAll(fun x -> x.Founded <= foundedBeforeYear) do
    printfn $"{team.Name}: {team.Founded}"
// The example displays output similar to the following:
//       Teams founded before 1930:
//       Detroit Red Wings: 1926
//       Chicago Blackhawks: 1926
//       Montreal Canadiens: 1909
// </Snippet3>