module norm.fs
// <snippet1>
open System
open System.Text

let show title (s: string) =
    printf $"Characters in string %s{title} = "
    for x in s do
        printf $"{int16 x:X4} "
    printfn ""


[<EntryPoint>]
let main _ =
    // Character c; combining characters acute and cedilla; character 3/4
    let s1 = String [| '\u0063'; '\u0301'; '\u0327'; '\u00BE' |]
    let divider = String('-', 80)
    let divider = String.Concat(Environment.NewLine, divider, Environment.NewLine)

    show "s1" s1
    printfn "\nU+0063 = LATIN SMALL LETTER C"
    printfn "U+0301 = COMBINING ACUTE ACCENT"
    printfn "U+0327 = COMBINING CEDILLA"
    printfn "U+00BE = VULGAR FRACTION THREE QUARTERS"
    printfn $"{divider}"

    printfn $"A1) Is s1 normalized to the default form (Form C)?: {s1.IsNormalized()}"
    printfn $"A2) Is s1 normalized to Form C?:  {s1.IsNormalized NormalizationForm.FormC}"
    printfn $"A3) Is s1 normalized to Form D?:  {s1.IsNormalized NormalizationForm.FormD}"
    printfn $"A4) Is s1 normalized to Form KC?: {s1.IsNormalized NormalizationForm.FormKC}"
    printfn $"A5) Is s1 normalized to Form KD?: {s1.IsNormalized NormalizationForm.FormKD}"

    printfn $"{divider}"

    printfn "Set string s2 to each normalized form of string s1.\n"
    printfn "U+1E09 = LATIN SMALL LETTER C WITH CEDILLA AND ACUTE"
    printfn"U+0033 = DIGIT THREE"
    printfn"U+2044 = FRACTION SLASH"
    printfn"U+0034 = DIGIT FOUR"
    printfn $"{divider}"
 
    let s2 = s1.Normalize()
    printf "B1) Is s2 normalized to the default form (Form C)?: "
    printfn $"{s2.IsNormalized()}"
    show "s2" s2
    printfn ""

    let s2 = s1.Normalize NormalizationForm.FormC
    printf "B2) Is s2 normalized to Form C?: "
    printfn $"{s2.IsNormalized NormalizationForm.FormC}"
    show "s2" s2
    printfn ""

    let s2 = s1.Normalize NormalizationForm.FormD
    printf "B3) Is s2 normalized to Form D?: "
    printfn $"{s2.IsNormalized NormalizationForm.FormD}"
    show "s2" s2
    printfn ""

    let s2 = s1.Normalize(NormalizationForm.FormKC)
    printf "B4) Is s2 normalized to Form KC?: "
    printfn $"{s2.IsNormalized NormalizationForm.FormKC}"
    show "s2" s2
    printfn ""

    let s2 = s1.Normalize(NormalizationForm.FormKD)
    printf "B5) Is s2 normalized to Form KD?: "
    printfn $"{s2.IsNormalized NormalizationForm.FormKD}"
    show "s2" s2
    0

(*
This example produces the following results:

Characters in string s1 = 0063 0301 0327 00BE

U+0063 = LATIN SMALL LETTER C
U+0301 = COMBINING ACUTE ACCENT
U+0327 = COMBINING CEDILLA
U+00BE = VULGAR FRACTION THREE QUARTERS

--------------------------------------------------------------------------------

A1) Is s1 normalized to the default form (Form C)?: False
A2) Is s1 normalized to Form C?:  False
A3) Is s1 normalized to Form D?:  False
A4) Is s1 normalized to Form KC?: False
A5) Is s1 normalized to Form KD?: False

--------------------------------------------------------------------------------

Set string s2 to each normalized form of string s1.

U+1E09 = LATIN SMALL LETTER C WITH CEDILLA AND ACUTE
U+0033 = DIGIT THREE
U+2044 = FRACTION SLASH
U+0034 = DIGIT FOUR

--------------------------------------------------------------------------------

B1) Is s2 normalized to the default form (Form C)?: True
Characters in string s2 = 1E09 00BE

B2) Is s2 normalized to Form C?: True
Characters in string s2 = 1E09 00BE

B3) Is s2 normalized to Form D?: True
Characters in string s2 = 0063 0327 0301 00BE

B4) Is s2 normalized to Form KC?: True
Characters in string s2 = 1E09 0033 2044 0034

B5) Is s2 normalized to Form KD?: True
Characters in string s2 = 0063 0327 0301 0033 2044 0034

*)
//</snippet1>