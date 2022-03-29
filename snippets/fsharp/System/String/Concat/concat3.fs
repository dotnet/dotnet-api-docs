module concat3

// <Snippet4>
// This example uses the F# Seq.filter function instead of Linq.
open System

type Animal =
  { Kind: string
    Order: string }
    override this.ToString() =
       this.Kind

let animals = ResizeArray()
animals.Add { Kind = "Squirrel"; Order = "Rodent" }
animals.Add { Kind = "Gray Wolf"; Order = "Carnivora" }
animals.Add { Kind = "Capybara"; Order = "Rodent" }

Seq.filter (fun animal -> animal.Order = "Rodent")
|> String.Concat
|> printfn "%s"
// The example displays the following output:
//      SquirrelCapybara
// </Snippet4>