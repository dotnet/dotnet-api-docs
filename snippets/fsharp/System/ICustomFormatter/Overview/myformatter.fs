// <Snippet1>
open System
open System.Globalization
open System.Numerics

type MyFormatter() =
    interface IFormatProvider with
        // IFormatProvider.GetFormat implementation.
        member this.GetFormat(formatType: Type) =
            // Determine whether custom formatting object is requested.
            if formatType = typeof<ICustomFormatter> then
                this
            else
                null

    interface ICustomFormatter with
        // Format number in binary (B), octal (O), or hexadecimal (H).
        member this.Format(format, arg: obj, formatProvider: IFormatProvider) =
            // Handle null or empty format string, string with precision specifier.
            let thisFmt =
                // Extract first character of format string (precision specifiers
                // are not supported).
                if String.IsNullOrEmpty format |> not then
                    if format.Length > 1 then 
                        format.Substring(0, 1) 
                    else 
                        format
                else
                    String.Empty

            // Get a byte array representing the numeric value.
            let bytes =
                match arg with
                | :? sbyte as arg ->
                    let byteString = arg.ToString "X2"
                    Some [| Byte.Parse(byteString, NumberStyles.HexNumber) |]
                | :? byte as arg ->
                    Some [| arg |]
                | :? int16 as arg ->
                    BitConverter.GetBytes arg
                    |> Some
                | :? int as arg ->
                    BitConverter.GetBytes arg
                    |> Some
                | :? int64 as arg ->
                    BitConverter.GetBytes arg
                    |> Some
                | :? uint16 as arg ->
                    BitConverter.GetBytes arg
                    |> Some
                | :? uint as arg ->
                    BitConverter.GetBytes arg
                    |> Some
                | :? uint64 as arg ->
                    BitConverter.GetBytes arg
                    |> Some
                | :? bigint as arg ->
                    arg.ToByteArray()
                    |> Some
                | _ ->
                    None
            let baseNumber =
                match thisFmt.ToUpper() with
                    // Binary formatting.
                    | "B" -> Some 2
                    | "O" -> Some 8
                    | "H" -> Some 16
                    // Handle unsupported format strings.
                    | _ -> None

            match bytes, baseNumber with
            | Some bytes, Some baseNumber ->
                // Return a formatted string.
                let mutable numericString = String.Empty
                for i = bytes.GetUpperBound 0 to bytes.GetLowerBound 0 do
                    let byteString = Convert.ToString(bytes[i], baseNumber)
                    let byteString =
                        match baseNumber with
                        | 2 ->
                            String('0', 8 - byteString.Length) + byteString
                        | 8 ->
                            String('0', 4 - byteString.Length) + byteString
                        // Base is 16.
                        | _ ->
                            String('0', 2 - byteString.Length) + byteString
                    numericString <- numericString + byteString + " "
                numericString.Trim()
            | _ ->
                try
                    this.HandleOtherFormats(format, arg)
                with :? FormatException as e ->
                    raise (FormatException($"The format of '{format}' is invalid.", e))
                    
    member private this.HandleOtherFormats(format, arg: obj) =
        // <Snippet3>
        match arg with
        | :? IFormattable as arg ->
            arg.ToString(format, CultureInfo.CurrentCulture)
        | null ->
            String.Empty
        | _ ->
            string arg
        // </Snippet3>
// </Snippet1>

// <Snippet2>
Console.WindowWidth <- 100

let byteValue = 124uy
// <Snippet4>
String.Format(MyFormatter(), "{0} (binary: {0:B}) (hex: {0:H})", byteValue)
|> printfn "%s"
// </Snippet4>

let intValue = 23045
String.Format(MyFormatter(), "{0} (binary: {0:B}) (hex: {0:H})", intValue)
|> printfn "%s"

let ulngValue = 31906574882uL
String.Format(MyFormatter(), "{0}\n   (binary: {0:B})\n   (hex: {0:H})", ulngValue)
|> printfn "%s"

let bigIntValue = BigInteger.Multiply(Int64.MaxValue, 2)
String.Format(MyFormatter(), "{0}\n   (binary: {0:B})\n   (hex: {0:H})", bigIntValue)
|> printfn "%s"

// The example displays the following output:
//    124 (binary: 01111100) (hex: 7c)
//    23045 (binary: 00000000 00000000 01011010 00000101) (hex: 00 00 5a 05)
//    31906574882
//       (binary: 00000000 00000000 00000000 00000111 01101101 11000111 10110010 00100010)
//       (hex: 00 00 00 07 6d c7 b2 22)
//    18446744073709551614
//       (binary: 00000000 11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111110)
//       (hex: 00 ff ff ff ff ff ff ff fe)
// </Snippet2>
