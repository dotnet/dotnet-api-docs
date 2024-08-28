module operator1

open System
open System.Numerics

let bitwiseAnd () =
    // <Snippet1>
    let number1 = BigInteger.Add(Int64.MaxValue, Int32.MaxValue)
    let number2 = BigInteger.Pow(Byte.MaxValue, 10)
    let result = number1 &&& number2
    // </Snippet1>
    ()

let bitwiseOr () =
    // <Snippet2>
    let number1 = BigInteger.Parse("10343901200000000000")
    let number2 = Byte.MaxValue
    let result = number1 ||| number2
    // </Snippet2>
    ()

let decrement () =
    // <Snippet3>
    let number1 = BigInteger.Pow(Int32.MaxValue, 2)
    let number1 = BigInteger.Subtract(number1, BigInteger.One)
    // </Snippet3>
    ()

let equalsInt641 () =
    // <Snippet4>
    let bigNumber = BigInteger.Pow(2, 63)
    let number = Int64.MaxValue

    if bigint number = bigNumber then
        // Do something...
    // </Snippet4>
        ()

    ()

let equalsInt642 () =
    // <Snippet5>
    let bigNumber = BigInteger.Pow(2, 63)
    let number = Int64.MaxValue

    if bigNumber = number then
        // Do something...
    // </Snippet5>
        ()

    ()

let equalsUInt641 () =
    // <Snippet6>
    let bigNumber = BigInteger.Pow(2, 63) - BigInteger.One
    let uNumber = uint64 Int64.MaxValue &&& 0x7FFFFFFFFFFFFFFFuL

    if bigNumber = uNumber then
        // Do something...
    // </Snippet6>
        ()

    ()

let equalsUInt642 () =
    // <Snippet7>
    let bigNumber = BigInteger.Pow(2, 63) - BigInteger.One
    let uNumber = uint64 Int64.MaxValue &&& 0x7FFFFFFFFFFFFFFFuL

    if bigint uNumber = bigNumber then
        // Do something...
    // </Snippet7>
        ()

    ()

let bitwiseXOr () =
    // <Snippet8>
    let number1 = BigInteger.Pow(2, 127)
    let number2 = BigInteger.Multiply(163, 124)
    let result = number1 ^^^ number2
    // </Snippet8>
    Console.WriteLine("XOR: " + result.ToString())

let greaterThan64B () =
    // <Snippet9>
    let bigNumber = BigInteger.Pow(Int32.MaxValue, 4)
    let number = Int64.MaxValue

    if bigint number > bigNumber then
        // Do something;
    // </Snippet9>
        ()

    ()
// Snipppet10: calling op_GreaterThan(Int64, BigInteger) directly is
// not supported.

let greaterThanB64 () =
    // <Snippet11>
    let bigNumber = BigInteger.Pow(Int32.MaxValue, 4)
    let number = Int64.MaxValue

    if bigNumber > number then
        // Do something;
    // </Snippet11>
        ()

    ()
// Snipppet12: calling op_GreaterThan(BigInteger, Int64) directly is
// not supported.

let greaterThanBU64 () =
    // <Snippet13>
    let bigNumber = BigInteger.Pow(Int32.MaxValue, 2)
    let number = UInt64.MaxValue

    if bigNumber > number then
        // Do something
    // </Snippet13>
        ()

    ()

let greaterThanU64B () =
    // <Snippet15>
    let bigNumber = BigInteger.Pow(Int32.MaxValue, 2)
    let number = UInt64.MaxValue

    if bigint number > bigNumber then
        // Do something
    // </Snippet15>
        ()

    ()

let greaterThanOrEqual64B () =
    // <Snippet17>
    let bigNumber = BigInteger.Pow(Int32.MaxValue, 4)
    let number = Int64.MaxValue

    if bigint number >= bigNumber then
        // Do something;
    // </Snippet17>
        ()

    ()

let greaterThanOrEqualB64 () =
    // <Snippet19>
    let bigNumber = BigInteger.Pow(Int32.MaxValue, 4)
    let number = Int64.MaxValue

    if bigNumber >= number then
        // Do something;
    // </Snippet19>
        ()

    ()

let greaterThanOrEqualBU64 () =
    // <Snippet21>
    let bigNumber = BigInteger.Pow(Int32.MaxValue, 2)
    let number = UInt64.MaxValue

    if bigNumber >= number then
        // Do something
    // </Snippet21>
        ()

    ()

let greaterThanOrEqualU64B () =
    // <Snippet23>
    let bigNumber = BigInteger.Pow(Int32.MaxValue, 2)
    let number = UInt64.MaxValue

    if bigint number >= bigNumber then
        // Do something
    // </Snippet23>
        ()

    ()

let inequality64B () =
    // <Snippet25>
    let bigNumber = BigInteger.Pow(2, 63)
    let number = Int64.MaxValue

    if bigint number <> bigNumber then
        // Do something...
    // </Snippet25>
        ()

    ()

let inequalityB64 () =
    // <Snippet26>
    let bigNumber = BigInteger.Pow(2, 63)
    let number = Int64.MaxValue

    if bigNumber <> number then
        // Do something...
    // </Snippet26>
        ()

    ()

let inequalityBU64 () =
    // <Snippet27>
    let bigNumber = BigInteger.Pow(2, 63) - BigInteger.One
    let uNumber = uint64 Int64.MaxValue &&& 0x7FFFFFFFFFFFFFFFuL

    if bigNumber <> uNumber then
        // Do something...
    // </Snippet27>
        ()

    ()

let inequalityU64B () =
    // <Snippet28>
    let bigNumber = BigInteger.Pow(2, 63) - BigInteger.One
    let uNumber = uint64 Int64.MaxValue &&& 0x7FFFFFFFFFFFFFFFuL

    if bigint uNumber <> bigNumber then
        // Do something...
    // </Snippet28>
        ()

    ()

let leftShift () =
    // <Snippet29>
    let number = BigInteger.Parse "-9047321678449816249999312055"
    printfn $"Shifting {number} left by:"

    for ctr = 0 to 16 do
        let newNumber = number <<< ctr
        printfn $" {ctr, 2} bits: {newNumber, 35} {newNumber:X}"
// The example displays the following output:
//    Shifting -9047321678449816249999312055 left by:
//      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
//      1 bits:      -18094643356899632499998624110       C588763A1ADE0FA5983F7692
//      2 bits:      -36189286713799264999997248220       8B10EC7435BC1F4B307EED24
//      3 bits:      -72378573427598529999994496440      F1621D8E86B783E9660FDDA48
//      4 bits: -1.4475714685519705999998899288E+29      E2C43B1D0D6F07D2CC1FBB490
//      5 bits: -2.8951429371039411999997798576E+29      C588763A1ADE0FA5983F76920
//      6 bits: -5.7902858742078823999995597152E+29      8B10EC7435BC1F4B307EED240
//      7 bits:  -1.158057174841576479999911943E+30     F1621D8E86B783E9660FDDA480
//      8 bits: -2.3161143496831529599998238861E+30     E2C43B1D0D6F07D2CC1FBB4900
//      9 bits: -4.6322286993663059199996477722E+30     C588763A1ADE0FA5983F769200
//     10 bits: -9.2644573987326118399992955443E+30     8B10EC7435BC1F4B307EED2400
//     11 bits: -1.8528914797465223679998591089E+31    F1621D8E86B783E9660FDDA4800
//     12 bits: -3.7057829594930447359997182177E+31    E2C43B1D0D6F07D2CC1FBB49000
//     13 bits: -7.4115659189860894719994364355E+31    C588763A1ADE0FA5983F7692000
//     14 bits: -1.4823131837972178943998872871E+32    8B10EC7435BC1F4B307EED24000
//     15 bits: -2.9646263675944357887997745742E+32   F1621D8E86B783E9660FDDA48000
//     16 bits: -5.9292527351888715775995491484E+32   E2C43B1D0D6F07D2CC1FBB490000
// </Snippet29>

let leftShiftManually () =
    // <Snippet30>
    let number = BigInteger.Parse "-9047321678449816249999312055"
    printfn $"Shifting {number} left by:"

    for ctr = 0 to 16 do
        let newNumber = number * BigInteger.Pow(2, ctr)
        printfn $" {ctr, 2} bits: {newNumber, 35} {newNumber:X}"
// The example displays the following output:
//    Shifting -9047321678449816249999312055 left by:
//      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
//      1 bits:      -18094643356899632499998624110       C588763A1ADE0FA5983F7692
//      2 bits:      -36189286713799264999997248220       8B10EC7435BC1F4B307EED24
//      3 bits:      -72378573427598529999994496440      F1621D8E86B783E9660FDDA48
//      4 bits: -1.4475714685519705999998899288E+29      E2C43B1D0D6F07D2CC1FBB490
//      5 bits: -2.8951429371039411999997798576E+29      C588763A1ADE0FA5983F76920
//      6 bits: -5.7902858742078823999995597152E+29      8B10EC7435BC1F4B307EED240
//      7 bits:  -1.158057174841576479999911943E+30     F1621D8E86B783E9660FDDA480
//      8 bits: -2.3161143496831529599998238861E+30     E2C43B1D0D6F07D2CC1FBB4900
//      9 bits: -4.6322286993663059199996477722E+30     C588763A1ADE0FA5983F769200
//     10 bits: -9.2644573987326118399992955443E+30     8B10EC7435BC1F4B307EED2400
//     11 bits: -1.8528914797465223679998591089E+31    F1621D8E86B783E9660FDDA4800
//     12 bits: -3.7057829594930447359997182177E+31    E2C43B1D0D6F07D2CC1FBB49000
//     13 bits: -7.4115659189860894719994364355E+31    C588763A1ADE0FA5983F7692000
//     14 bits: -1.4823131837972178943998872871E+32    8B10EC7435BC1F4B307EED24000
//     15 bits: -2.9646263675944357887997745742E+32   F1621D8E86B783E9660FDDA48000
//     16 bits: -5.9292527351888715775995491484E+32   E2C43B1D0D6F07D2CC1FBB490000
// </Snippet30>

let lessThan64B () =
    // <Snippet31>
    let number = BigInteger.Parse "9801324316220166912"

    if bigint Int64.MaxValue < number then
        // Do something.
        ()
    else
        // Do something else.
        ()
    // </Snippet31>

let lessThanB64 () =
    // <Snippet33>
    let number = BigInteger.Parse "9801324316220166912"

    if number < Int64.MaxValue then
        // Do something.
        ()
    else
        // Do something else.
        ()
    // </Snippet33>

let lessThanBU64 () =
    // <Snippet35>
    let number = BigInteger.Parse "19801324316220166912"

    if number < UInt64.MaxValue then
        // Do something.
        ()
    else
        // Do something else.
        ()
    // </Snippet35>

let lessThanU64B () =
    // <Snippet37>
    let number = BigInteger.Parse "9801324316220166912"

    if bigint UInt64.MaxValue < number then
        // Do something.
        ()
    else
        // Do something else.
        ()
    // </Snippet37>

let lessThanOrEqual64B () =
    // <Snippet39>
    let number = BigInteger.Parse "9801324316220166912"

    if bigint Int64.MaxValue <= number then
        // Do something.
        ()
    else
        // Do something else.
        ()
    // </Snippet39>

let lessThanOrEqualB64 () =
    // <Snippet41>
    let number = BigInteger.Parse "9801324316220166912"

    if number <= Int64.MaxValue then
        // Do something.
        ()
    else
        // Do something else.
        ()
    // </Snippet41>

let lessThanOrEqualBU64 () =
    // <Snippet43>
    let number = BigInteger.Parse "19801324316220166912"

    if number <= UInt64.MaxValue then
        // Do something.
        ()
    else
        // Do something else.
        ()
    // </Snippet43>

let lessThanOrEqualU64B () =
    // <Snippet45>
    let number = BigInteger.Parse "9801324316220166912"

    if bigint UInt64.MaxValue <= number then
        // Do something.
        ()
    else
        // Do something else.
        ()
    // </Snippet45>

bitwiseAnd ()
bitwiseOr ()
decrement ()
equalsInt641 ()
equalsInt642 ()
equalsUInt641 ()
equalsUInt642 ()
bitwiseXOr ()
greaterThan64B ()
greaterThanB64 ()
greaterThanBU64 ()
greaterThanU64B ()
greaterThanOrEqual64B ()
greaterThanOrEqualB64 ()
greaterThanOrEqualBU64 ()
greaterThanOrEqualU64B ()
inequality64B ()
inequalityB64 ()
inequalityBU64 ()
inequalityU64B ()
leftShift ()
leftShiftManually ()
lessThan64B ()
lessThanB64 ()
lessThanBU64 ()
lessThanU64B ()
lessThanOrEqual64B ()
lessThanOrEqualB64 ()
lessThanOrEqualBU64 ()
lessThanOrEqualU64B ()
