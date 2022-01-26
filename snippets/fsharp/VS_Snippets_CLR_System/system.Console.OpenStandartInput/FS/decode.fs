// System.Console.OpenStandartInput
// <Snippet1>
open System
open System.Text

let inputStream = Console.OpenStandardInput()
let bytes = Array.zeroCreate<byte> 100
Console.WriteLine "To decode, type or paste the UTF7 encoded string and press enter:"
Console.WriteLine "(Example: \"M+APw-nchen ist wundervoll\")"
let outputLength = inputStream.Read(bytes, 0, 100)
let chars = Encoding.UTF7.GetChars(bytes, 0, outputLength)
Console.WriteLine "Decoded string:"
Console.WriteLine(string chars)
// </Snippet1>