﻿module rightshift1

open System.Numerics

let rightShift () =
    // <Snippet47>
    let number = BigInteger.Parse "-9047321678449816249999312055"
    printfn $"Shifting {number} right by:"

    for ctr = 0 to 16 do
        let newNumber = number >>> ctr
        printfn $" {ctr, 2} bits: {newNumber, 35} {newNumber:X}"
    // The example displays the following output:
    //    Shifting -9047321678449816249999312055 right by:
    //      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
    //      1 bits:       -4523660839224908124999656028       F1621D8E86B783E9660FDDA4
    //      2 bits:       -2261830419612454062499828014        8B10EC7435BC1F4B307EED2
    //      3 bits:       -1130915209806227031249914007        C588763A1ADE0FA5983F769
    //      4 bits:        -565457604903113515624957004        E2C43B1D0D6F07D2CC1FBB4
    //      5 bits:        -282728802451556757812478502        F1621D8E86B783E9660FDDA
    //      6 bits:        -141364401225778378906239251         8B10EC7435BC1F4B307EED
    //      7 bits:         -70682200612889189453119626         C588763A1ADE0FA5983F76
    //      8 bits:         -35341100306444594726559813         E2C43B1D0D6F07D2CC1FBB
    //      9 bits:         -17670550153222297363279907         F1621D8E86B783E9660FDD
    //     10 bits:          -8835275076611148681639954          8B10EC7435BC1F4B307EE
    //     11 bits:          -4417637538305574340819977          C588763A1ADE0FA5983F7
    //     12 bits:          -2208818769152787170409989          E2C43B1D0D6F07D2CC1FB
    //     13 bits:          -1104409384576393585204995          F1621D8E86B783E9660FD
    //     14 bits:           -552204692288196792602498           8B10EC7435BC1F4B307E
    //     15 bits:           -276102346144098396301249           C588763A1ADE0FA5983F
    //     16 bits:           -138051173072049198150625           E2C43B1D0D6F07D2CC1F
    // </Snippet47>

let rightShiftManually () =
    // <Snippet48>
    let number = BigInteger.Parse "-9047321678449816249999312055"
    printfn $"Shifting {number} right by:"

    for ctr = 0 to 16 do
        let mutable newNumber = number / BigInteger.Pow(2, ctr)

        if newNumber * bigint ctr < 0 then
            newNumber <- newNumber - bigint 1

        printfn $" {ctr, 2} bits: {newNumber, 35} {newNumber:X}"
    // The example displays the following output:
    //      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
    //      1 bits:       -4523660839224908124999656028       F1621D8E86B783E9660FDDA4
    //      2 bits:       -2261830419612454062499828014        8B10EC7435BC1F4B307EED2
    //      3 bits:       -1130915209806227031249914007        C588763A1ADE0FA5983F769
    //      4 bits:        -565457604903113515624957004        E2C43B1D0D6F07D2CC1FBB4
    //      5 bits:        -282728802451556757812478502        F1621D8E86B783E9660FDDA
    //      6 bits:        -141364401225778378906239251         8B10EC7435BC1F4B307EED
    //      7 bits:         -70682200612889189453119626         C588763A1ADE0FA5983F76
    //      8 bits:         -35341100306444594726559813         E2C43B1D0D6F07D2CC1FBB
    //      9 bits:         -17670550153222297363279907         F1621D8E86B783E9660FDD
    //     10 bits:          -8835275076611148681639954          8B10EC7435BC1F4B307EE
    //     11 bits:          -4417637538305574340819977          C588763A1ADE0FA5983F7
    //     12 bits:          -2208818769152787170409989          E2C43B1D0D6F07D2CC1FB
    //     13 bits:          -1104409384576393585204995          F1621D8E86B783E9660FD
    //     14 bits:           -552204692288196792602498           8B10EC7435BC1F4B307E
    //     15 bits:           -276102346144098396301249           C588763A1ADE0FA5983F
    //     16 bits:           -138051173072049198150625           E2C43B1D0D6F07D2CC1F
    // </Snippet48>


rightShift ()
rightShiftManually ()
