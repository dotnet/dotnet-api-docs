module equalsExample1

open System
open System.Numerics

let equalsLong () =
    // <Snippet1>
    let byteValue = 16uy
    let bigIntValue = BigInteger byteValue

    printfn
        $"{bigIntValue.GetType().Name} {bigIntValue} = {byteValue.GetType().Name} {byteValue} : {bigIntValue.Equals(byteValue)}"

    let sbyteValue = -16y
    let bigIntValue = BigInteger sbyteValue

    printfn
        $"{bigIntValue.GetType().Name} {bigIntValue} = {sbyteValue.GetType().Name} {sbyteValue} : {bigIntValue.Equals(sbyteValue)}"

    let shortValue = 1233s
    let bigIntValue = BigInteger shortValue

    printfn
        $"{bigIntValue.GetType().Name} {bigIntValue} = {shortValue.GetType().Name} {shortValue} : {bigIntValue.Equals(shortValue)}"

    let ushortValue = 64000us
    let bigIntValue = BigInteger ushortValue

    printfn
        $"{bigIntValue.GetType().Name} {bigIntValue} = {ushortValue.GetType().Name} {ushortValue} : {bigIntValue.Equals(ushortValue)}"

    let intValue = -1603854
    let bigIntValue = BigInteger intValue

    printfn
        $"{bigIntValue.GetType().Name} {bigIntValue} = {intValue.GetType().Name} {intValue} : {bigIntValue.Equals(intValue)}"

    let uintValue = 1223300u
    let bigIntValue = BigInteger uintValue

    printfn
        $"{bigIntValue.GetType().Name} {bigIntValue} = {uintValue.GetType().Name} {uintValue} : {bigIntValue.Equals(uintValue)}"

    let longValue = -123822229012L
    let bigIntValue = BigInteger longValue

    printfn
        $"{bigIntValue.GetType().Name} {bigIntValue} = {longValue.GetType().Name} {longValue} : {bigIntValue.Equals(longValue)}"
    // The example displays the following output:
    //    BigInteger 16 = Byte 16 : True
    //    BigInteger -16 = SByte -16 : True
    //    BigInteger 1233 = Int16 1233 : True
    //    BigInteger 64000 = UInt16 64000 : True
    //    BigInteger -1603854 = Int32 -1603854 : True
    //    BigInteger 1223300 = UInt32 1223300 : True
    //    BigInteger -123822229012 = Int64 -123822229012 : True
    // </Snippet1>

let equalsBigInteger () =
    // <Snippet2>
    let LIGHT_YEAR = 5878625373183L

    let altairDistance = 17I * bigint LIGHT_YEAR
    let epsilonIndiDistance = 12I * bigint LIGHT_YEAR
    let ursaeMajoris47Distance = 46I * bigint LIGHT_YEAR
    let tauCetiDistance = 12L * LIGHT_YEAR
    let procyon2Distance = 12uL * uint64 LIGHT_YEAR
    let wolf424ABDistance = 14L * LIGHT_YEAR

    printfn "Approx. equal distances from Epsilon Indi to:"
    printfn $"   Altair: {epsilonIndiDistance.Equals(altairDistance)}"
    printfn $"   Ursae Majoris 47: {epsilonIndiDistance.Equals(ursaeMajoris47Distance)}"
    printfn $"   TauCeti: {epsilonIndiDistance.Equals(tauCetiDistance)}"
    printfn $"   Procyon 2: {epsilonIndiDistance.Equals(procyon2Distance)}"
    printfn $"   Wolf 424 AB: {epsilonIndiDistance.Equals(wolf424ABDistance)}"
    // The example displays the following output:
    //    Approx. equal distances from Epsilon Indi to:
    //       Altair: False
    //       Ursae Majoris 47: False
    //       TauCeti: True
    //       Procyon 2: True
    //       Wolf 424 AB: False
    // </Snippet2>
equalsLong ()
equalsBigInteger ()
