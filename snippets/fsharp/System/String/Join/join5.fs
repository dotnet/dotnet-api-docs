module join5.fs
// <Snippet5>
// This example uses F#'s Seq.filter function instead of Linq.
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
String.Join(" ", animals |> Seq.filter (fun animal -> animal.Order = "Rodent"))
|> printfn "%s"
// The example displays the following output:
//      Squirrel Capybara
// </Snippet5>
