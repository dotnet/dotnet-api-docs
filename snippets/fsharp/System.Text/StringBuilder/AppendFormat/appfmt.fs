module appfmt
// This example demonstrates the StringBuilder.AppendFormat method
//<snippet1>
open System.Text
open System.Globalization

let sb = StringBuilder()

let show (sbs: StringBuilder) =
    printfn $"{sbs}"
    sb.Length <- 0

let var1 = 111
let var2 = 2.22f
let var3 = "abcd"
let var4: obj[] = [| 3; 4.4; 'X' |]

printfn "StringBuilder.AppendFormat method:"
sb.AppendFormat("1) {0}", var1) |> ignore
show sb
sb.AppendFormat("2) {0}, {1}", var1, var2) |> ignore
show sb
sb.AppendFormat("3) {0}, {1}, {2}", var1, var2, var3) |> ignore
show sb
sb.AppendFormat("4) {0}, {1}, {2}", var4) |> ignore
show sb
let ci = CultureInfo("es-ES", true)
sb.AppendFormat(ci, "5) {0}", var2) |> ignore
show sb

// This example produces the following results:
//       StringBuilder.AppendFormat method:
//       1) 111
//       2) 111, 2.22
//       3) 111, 2.22, abcd
//       4) 3, 4.4, X
//       5) 2,22
//</snippet1>
