module enumequals1

// <Snippet1>
type SledDog =
    | Unknown = 0
    | AlaskanMalamute = 1
    | Malamute = 1
    | Husky = 2
    | SiberianHusky = 2

type WorkDog =
    | Unknown = 0
    | Newfoundland = 1
    | GreatPyrennes = 2

let dog1 = SledDog.Malamute
let dog2 = SledDog.AlaskanMalamute
let dog3 = WorkDog.Newfoundland

printfn $"{dog1:F} ({dog1:D}) = {dog2:F} ({dog2:D}): {dog1.Equals dog2}"
printfn $"{dog1:F} ({dog1:D}) = {dog3:F} ({dog3:D}): {dog1.Equals dog3}"
// The example displays the following output:
//       Malamute (1) = Malamute (1): True
//       Malamute (1) = Newfoundland (1): False
// </Snippet1>