module equals_ex3

// <Snippet3>
open System
open System.Globalization
open System.Threading

let cultureNames = 
    [| "en-US"; "se-SE" |]
let strings1 = 
    [| "case"; "encyclopædia" 
       "encyclopædia"; "Archæology" |]
let strings2 = 
    [| "Case"; "encyclopaedia" 
       "encyclopedia"; "ARCHÆOLOGY" |]
let comparisons = 
    Enum.GetValues typeof<StringComparison> :?> StringComparison[]

for cultureName in cultureNames do
    Thread.CurrentThread.CurrentCulture <- CultureInfo.CreateSpecificCulture cultureName
    printfn $"Current Culture: {CultureInfo.CurrentCulture.Name}"
    for i = 0 to strings1.GetUpperBound 0 do
        for comparison in comparisons do
            printfn $"   {strings1[i]} = {strings2[i]} ({comparison}): {String.Equals(strings1[i], strings2[i], comparison)}"
        printfn ""         
    printfn ""
// The example displays the following output:
//    Current Culture: en-US
//       case = Case (CurrentCulture): False
//       case = Case (CurrentCultureIgnoreCase): True
//       case = Case (InvariantCulture): False
//       case = Case (InvariantCultureIgnoreCase): True
//       case = Case (Ordinal): False
//       case = Case (OrdinalIgnoreCase): True
//    
//       encyclopædia = encyclopaedia (CurrentCulture): True
//       encyclopædia = encyclopaedia (CurrentCultureIgnoreCase): True
//       encyclopædia = encyclopaedia (InvariantCulture): True
//       encyclopædia = encyclopaedia (InvariantCultureIgnoreCase): True
//       encyclopædia = encyclopaedia (Ordinal): False
//       encyclopædia = encyclopaedia (OrdinalIgnoreCase): False
//    
//       encyclopædia = encyclopedia (CurrentCulture): False
//       encyclopædia = encyclopedia (CurrentCultureIgnoreCase): False
//       encyclopædia = encyclopedia (InvariantCulture): False
//       encyclopædia = encyclopedia (InvariantCultureIgnoreCase): False
//       encyclopædia = encyclopedia (Ordinal): False
//       encyclopædia = encyclopedia (OrdinalIgnoreCase): False
//    
//       Archæology = ARCHÆOLOGY (CurrentCulture): False
//       Archæology = ARCHÆOLOGY (CurrentCultureIgnoreCase): True
//       Archæology = ARCHÆOLOGY (InvariantCulture): False
//       Archæology = ARCHÆOLOGY (InvariantCultureIgnoreCase): True
//       Archæology = ARCHÆOLOGY (Ordinal): False
//       Archæology = ARCHÆOLOGY (OrdinalIgnoreCase): True
//    
//    
//    Current Culture: se-SE
//       case = Case (CurrentCulture): False
//       case = Case (CurrentCultureIgnoreCase): True
//       case = Case (InvariantCulture): False
//       case = Case (InvariantCultureIgnoreCase): True
//       case = Case (Ordinal): False
//       case = Case (OrdinalIgnoreCase): True
//    
//       encyclopædia = encyclopaedia (CurrentCulture): False
//       encyclopædia = encyclopaedia (CurrentCultureIgnoreCase): False
//       encyclopædia = encyclopaedia (InvariantCulture): True
//       encyclopædia = encyclopaedia (InvariantCultureIgnoreCase): True
//       encyclopædia = encyclopaedia (Ordinal): False
//       encyclopædia = encyclopaedia (OrdinalIgnoreCase): False
//    
//       encyclopædia = encyclopedia (CurrentCulture): False
//       encyclopædia = encyclopedia (CurrentCultureIgnoreCase): False
//       encyclopædia = encyclopedia (InvariantCulture): False
//       encyclopædia = encyclopedia (InvariantCultureIgnoreCase): False
//       encyclopædia = encyclopedia (Ordinal): False
//       encyclopædia = encyclopedia (OrdinalIgnoreCase): False
//    
//       Archæology = ARCHÆOLOGY (CurrentCulture): False
//       Archæology = ARCHÆOLOGY (CurrentCultureIgnoreCase): True
//       Archæology = ARCHÆOLOGY (InvariantCulture): False
//       Archæology = ARCHÆOLOGY (InvariantCultureIgnoreCase): True
//       Archæology = ARCHÆOLOGY (Ordinal): False
//       Archæology = ARCHÆOLOGY (OrdinalIgnoreCase): True
// </Snippet3>