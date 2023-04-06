module Lambda

// <Snippet4>
open System
open System.Globalization

let numericString = "-1,234"
let parser = Func<string, NumberStyles, IFormatProvider, int>(fun s sty p ->
     Int32.Parse(s, sty, p))
     
parser.Invoke(numericString,
              NumberStyles.Integer ||| NumberStyles.AllowThousands,
              CultureInfo.InvariantCulture)
|> printfn "%i"
// </Snippet4>