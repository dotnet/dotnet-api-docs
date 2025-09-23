module example1

// <Snippet1>
open System
open System.Numerics

[<Struct; CustomComparison; StructuralEquality>]
type StarInfo =
    // Define fields
    val Name: string
    val Distance: BigInteger

    // Define constructors.
    new(name, lightYears) =
        { Name = name
          // Calculate distance in miles from light years.
          Distance = lightYears * 5.88e12 |> bigint }

    new(name, distance) = { Name = name; Distance = distance }

    // Display name of star and its distance in parentheses.
    override this.ToString() =
        $"{this.Name, -10} ({this.Distance:N0})"

    interface IComparable<StarInfo> with
        // Compare StarInfo objects by their distance from Earth.
        member this.CompareTo(other: StarInfo) = this.Distance.CompareTo(other.Distance)
// </Snippet1>

// <Snippet2>
let stars = ResizeArray()

let star1 = StarInfo("Sirius", 8.6)
stars.Add(star1)
let star2 = StarInfo("Rigel", 1400.)
stars.Add(star2)
let star3 = StarInfo("Castor", 49.)
stars.Add(star3)
let star4 = StarInfo("Antares", 520.)
stars.Add(star4)

stars.Sort()

for star in stars do
    printfn $"{star}"

// The example displays the following output:
//       Sirius     (50,568,000,000,000)
//       Castor     (288,120,000,000,000)
//       Antares    (3,057,600,000,000,000)
//       Rigel      (8,232,000,000,000,000)
// </Snippet2>
