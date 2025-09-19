module customernumberformatter1
// <Snippet1>
open System
open System.Text

type Customer(name: string, number: int) =
    member _.Name = name
    member _.CustomerNumber = number

type CustomerNumberFormatter() =
    interface IFormatProvider with
        member this.GetFormat(formatType) =
            if formatType = typeof<ICustomFormatter> then this else null

    interface ICustomFormatter with
        member _.Format(_, arg, _) =
            match arg with
            | :? int as i ->
                let custNumber = i.ToString "D10"
                $"{custNumber.Substring(0, 4)}-{custNumber.Substring(4, 3)}-{custNumber.Substring(7, 3)}"
            | _ -> null

let customer = Customer("A Plus Software", 903654)
let sb = StringBuilder()

sb.AppendFormat(CustomerNumberFormatter(), "{0}: {1}", customer.CustomerNumber, customer.Name)
|> ignore

printfn $"{sb}"

// The example displays the following output:
//      0000-903-654: A Plus Software
// </Snippet1>
