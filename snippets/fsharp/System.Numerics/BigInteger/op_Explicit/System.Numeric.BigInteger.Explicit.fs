module explicit

open System
open System.Numerics

// <Snippet1>
// BigInteger to Byte conversion.
let goodByte = BigInteger.One
let badByte = bigint 256

// Successful conversion using cast operator.
let byteFromBigInteger = byte goodByte
printfn $"{byteFromBigInteger}"

// Handle conversion that should result in overflow.
try
    let byteFromBigInteger = byte badByte
    printfn $"{byteFromBigInteger}"
with :? OverflowException as e ->
    printfn $"Unable to convert {badByte}:\n   {e.Message}"
// </Snippet1>

// <Snippet2>
// BigInteger to Decimal conversion.
let goodDecimal = 761652543
let badDecimal = bigint Decimal.MaxValue + BigInteger.One

// Successful conversion using cast operator.
let decimalFromBigInteger = decimal goodDecimal
printfn $"{decimalFromBigInteger}"

// Handle conversion that should result in overflow.
try
    let decimalFromBigInteger = decimal badDecimal
    printfn $"{decimalFromBigInteger}"
with :? OverflowException as e ->
    printfn $"Unable to convert {badDecimal}:\n   {e.Message}"
// </Snippet2>

do
    // <Snippet3>
    // BigInteger to Double conversion.
    let goodDouble = bigint 102.43e22
    let badDouble = bigint Double.MaxValue * bigint 2

    // successful conversion using cast operator.
    let doubleFromBigInteger = double goodDouble
    printfn $"{doubleFromBigInteger}"

    // Convert an out-of-bounds BigInteger value to a Double.
    let doubleFromBigInteger = double badDouble
    printfn $"{doubleFromBigInteger}"
    // </Snippet3>

// <Snippet4>
// BigInteger to Int16 conversion.
let goodShort = bigint 20000
let badShort = bigint 33000

// Successful conversion using cast operator.
let shortFromBigInteger = int16 goodShort
printfn $"{shortFromBigInteger}"

// Handle conversion that should result in overflow.
try
    let shortFromBigInteger = int16 badShort
    printfn $"{shortFromBigInteger}"
with :? OverflowException as e ->
    printfn $"Unable to convert {badShort}:\n   {e.Message}"
// </Snippet4>

// <Snippet5>
// BigInteger to Int32 conversion.
let goodInteger = bigint 200000
let badInteger = bigint 65000000000L

// Successful conversion using cast operator.
let integerFromBigInteger = int goodInteger
printfn $"{integerFromBigInteger}"

// Handle conversion that should result in overflow.
try
    let integerFromBigInteger = int badInteger
    printfn $"{integerFromBigInteger}"
with :? OverflowException as e ->
    printfn $"Unable to convert {badInteger}:\n   {e.Message}"
// </Snippet5>

// <Snippet6>
// BigInteger to Int64 conversion.
let goodLong = 2000000000
let badLong = BigInteger.Pow(goodLong, 3)

// Successful conversion using cast operator.
let longFromBigInteger = int64 goodLong
printfn $"{longFromBigInteger}"

// Handle conversion that should result in overflow.
try
    let longFromBigInteger = int64 badLong
    printfn $"{longFromBigInteger}"
with :? OverflowException as e ->
    printfn $"Unable to convert {badLong}:\n   {e.Message}"
// </Snippet6>

// <Snippet7>
// BigInteger to SByte conversion.
let goodSByte = BigInteger.MinusOne
let badSByte = bigint -130

// Successful conversion using cast operator.
let sByteFromBigInteger = sbyte goodSByte
printfn $"{sByteFromBigInteger}"

// Handle conversion that should result in overflow.
try
    let sByteFromBigInteger = sbyte badSByte
    printfn $"{sByteFromBigInteger}"
with :? OverflowException as e ->
    printfn $"Unable to convert {badSByte}:\n   {e.Message}"
// </Snippet7>

do
    // <Snippet8>
    // BigInteger to Single conversion.
    let goodSingle = bigint 102.43e22F
    let badSingle = bigint Single.MaxValue * bigint 2

    // Successful conversion using cast operator.
    let singleFromBigInteger = float32 goodSingle
    printfn $"{singleFromBigInteger}"

    // Convert an out-of-bounds BigInteger value to a Single.
    let singleFromBigInteger = float32 badSingle
    printfn $"{singleFromBigInteger}"
    // </Snippet8>

// <Snippet9>
// BigInteger to UInt16 conversion.
let goodUShort = bigint 20000
let badUShort = bigint 66000

// Successful conversion using cast operator.
let uShortFromBigInteger = uint16 goodUShort
printfn $"{uShortFromBigInteger}"

// Handle conversion that should result in overflow.
try
    let uShortFromBigInteger = uint16 badUShort
    printfn $"{uShortFromBigInteger}"
with :? OverflowException as e ->
    printfn $"Unable to convert {badSByte}:\n   {e.Message}"

// </Snippet9>

// <Snippet10>
// BigInteger to UInt32 conversion.
let goodUInteger = bigint 200000
let badUInteger = bigint 65000000000L

// Successful conversion using cast operator.
let uIntegerFromBigInteger = uint goodInteger
printfn $"{uIntegerFromBigInteger}"

// Handle conversion that should result in overflow.
try
    let uIntegerFromBigInteger = uint badUInteger
    printfn $"{uIntegerFromBigInteger}"
with :? OverflowException as e ->
    printfn $"Unable to convert {badUInteger}:\n   {e.Message}"

// </Snippet10>

// <Snippet11>
// BigInteger to UInt64 conversion.
let goodULong = bigint 2000000000
let badULong = BigInteger.Pow(goodULong, 3)

// Successful conversion using cast operator.
let uLongFromBigInteger = uint64 goodULong
printfn $"{uLongFromBigInteger}"

// Handle conversion that should result in overflow.
try
    let uLongFromBigInteger = uint64 badULong
    printfn $"{uLongFromBigInteger}"
with :? OverflowException as e ->
    printfn $"Unable to convert {badULong}:\n   {e.Message}"
// </Snippet11>

do
    // <Snippet12>
    // BigInteger to Decimal conversion.
    //
    // Assign a decimal to a BigInteger
    let decimalValue = 31043639504.621m
    let hugeValueFromDecimal = bigint decimalValue
    let hugeValueFromDecimal = BigInteger.Pow(hugeValueFromDecimal, 2)
    // Convert the value back to a Decimal if it's in range
    if hugeValueFromDecimal <= bigint Decimal.MaxValue then
        let decimalValue = decimal hugeValueFromDecimal
        printfn $"The decimal value is {decimalValue}"
    else
        printfn $"Unable to convert {hugeValueFromDecimal} to a Decimal"
    // </Snippet12>

do
    // <Snippet13>
    // BigInteger to Double conversion.
    //
    // Assign a Double to a BigInteger
    let doubleValue = 3104363950465.621984
    let hugeValueFromDouble = bigint doubleValue
    let hugeValueFromDouble = BigInteger.Pow(hugeValueFromDouble, 3)
    // Convert the value back to a Decimal if it's in range
    if hugeValueFromDouble <= bigint Double.MaxValue then
        let doubleValue = double hugeValueFromDouble
        printfn $"The value of the Double is {doubleValue}"
    else
        printfn $"Unable to convert {hugeValueFromDouble} to a Double"
    // </Snippet13>

do
    // <Snippet14>
    // BigInteger to float conversion.
    //
    // Assign a float to a BigInteger
    let singleValue = 3104363950465.621984F
    let hugeValueFromSingle = bigint singleValue
    let hugeValueFromSingle = BigInteger.Pow(hugeValueFromSingle, 2)
    // Convert the value back to a Single if it//s in range
    if hugeValueFromSingle <= bigint Single.MaxValue then
        let singleValue = float32 hugeValueFromSingle
        printfn $"The value of the float is {singleValue}"
    else
        printfn $"Unable to convert {hugeValueFromSingle} to a float"
    // </Snippet14>
