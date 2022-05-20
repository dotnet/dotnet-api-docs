// <Snippet2>
open System
open System.Globalization

let cultures= 
    [ CultureInfo.CreateSpecificCulture "en-US"
      CultureInfo.InvariantCulture
      CultureInfo.CreateSpecificCulture "tr-TR" ]

let chars = [| 'ä'; 'e'; 'E'; 'i'; 'I' |]

printfn "Character     en-US     Invariant     tr-TR"
for ch in chars do
    printf $"    {ch}"
    for culture in cultures do
        printf $"{Char.ToUpper(ch, culture),12}"
    printfn ""


// The example displays the following output:
//       Character     en-US     Invariant     tr-TR
//           ä           Ä           Ä           Ä
//           e           E           E           E
//           E           E           E           E
//           i           I           I           İ
//           I           I           I           I
// </Snippet2>