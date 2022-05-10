module tostring4

// <Snippet4>
open System.Globalization

// Define cultures whose formatting conventions are to be used.
let cultures =
    [| CultureInfo.CreateSpecificCulture "en-US" 
       CultureInfo.CreateSpecificCulture "fr-FR" 
       CultureInfo.CreateSpecificCulture "es-ES" |]
let specifiers = 
    [| "G"; "C"; "D4"; "E2"; "F"; "N"; "P"; "X2" |] 
let value = 2222402

for specifier in specifiers do
    for culture in cultures do
        printfn $"{specifier,2} format using {culture.Name} culture: {value.ToString(specifier, culture), 18}"
    printfn ""
// The example displays the following output:
//        G format using en-US culture:            2222402
//        G format using fr-FR culture:            2222402
//        G format using es-ES culture:            2222402
//       
//        C format using en-US culture:      $2,222,402.00
//        C format using fr-FR culture:     2 222 402,00 €
//        C format using es-ES culture:     2.222.402,00 €
//       
//       D4 format using en-US culture:            2222402
//       D4 format using fr-FR culture:            2222402
//       D4 format using es-ES culture:            2222402
//       
//       E2 format using en-US culture:          2.22E+006
//       E2 format using fr-FR culture:          2,22E+006
//       E2 format using es-ES culture:          2,22E+006
//       
//        F format using en-US culture:         2222402.00
//        F format using fr-FR culture:         2222402,00
//        F format using es-ES culture:         2222402,00
//       
//        N format using en-US culture:       2,222,402.00
//        N format using fr-FR culture:       2 222 402,00
//        N format using es-ES culture:       2.222.402,00
//       
//        P format using en-US culture:   222,240,200.00 %
//        P format using fr-FR culture:   222 240 200,00 %
//        P format using es-ES culture:   222.240.200,00 %
//       
//       X2 format using en-US culture:             21E942
//       X2 format using fr-FR culture:             21E942
//       X2 format using es-ES culture:             21E942
// </Snippet4>