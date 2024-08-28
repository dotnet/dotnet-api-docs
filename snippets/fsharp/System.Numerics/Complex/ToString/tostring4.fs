﻿module tostring4
// <Snippet4>
open System.Globalization
open System.Numerics

let c =
    [ Complex(17.3, 14.1)
      Complex(-18.9, 147.2)
      Complex(13.472, -18.115)
      Complex(-11.154, -17.002) ]

let cultures = [ CultureInfo "en-US"; CultureInfo "fr-FR" ]
let formats = [ "F2"; "N2"; "G5" ]

for c1 in c do
    for format in formats do
        for culture in cultures do
            printf $"{format} format string: {c1.ToString(format, culture)} ({culture.Name})    "

        printfn ""

    printfn ""
// The example displays the following output:
//    F2 format string:   (17.30, 14.10) (en-US)    (17,30, 14,10) (fr-FR)
//    N2 format string:   (17.30, 14.10) (en-US)    (17,30, 14,10) (fr-FR)
//    G5 format string:   (17.3, 14.1) (en-US)    (17,3, 14,1) (fr-FR)
//
//    F2 format string:   (-18.90, 147.20) (en-US)    (-18,90, 147,20) (fr-FR)
//    N2 format string:   (-18.90, 147.20) (en-US)    (-18,90, 147,20) (fr-FR)
//    G5 format string:   (-18.9, 147.2) (en-US)    (-18,9, 147,2) (fr-FR)
//
//    F2 format string:   (13.47, -18.12) (en-US)    (13,47, -18,12) (fr-FR)
//    N2 format string:   (13.47, -18.12) (en-US)    (13,47, -18,12) (fr-FR)
//    G5 format string:   (13.472, -18.115) (en-US)    (13,472, -18,115) (fr-FR)
//
//    F2 format string:   (-11.15, -17.00) (en-US)    (-11,15, -17,00) (fr-FR)
//    N2 format string:   (-11.15, -17.00) (en-US)    (-11,15, -17,00) (fr-FR)
//    G5 format string:   (-11.154, -17.002) (en-US)    (-11,154, -17,002) (fr-FR)
// </Snippet4>
