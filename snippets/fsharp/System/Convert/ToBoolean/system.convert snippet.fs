module Convert_snippet

open System

//<Snippet1>
let convertDoubleBool (doubleVal: float) =
    // Double to bool conversion cannot overflow.
    let boolVal = Convert.ToBoolean doubleVal
    printfn $"{doubleVal} as a Boolean is: {boolVal}."

    // bool to double conversion cannot overflow.
    let doubleVal = Convert.ToDouble boolVal
    printfn $"{boolVal} as a double is: {doubleVal}."
//</Snippet1>

//<Snippet2>
let convertDoubleByte (doubleVal: float) =
    // Double to byte conversion can overflow.
    try
        let byteVal = Convert.ToByte doubleVal
        printfn $"{doubleVal} as a byte is: {byteVal}."
        
        // Byte to double conversion cannot overflow.
        let doubleVal = Convert.ToDouble byteVal
        printfn $"{byteVal} as a double is: {doubleVal}."
    with :? OverflowException ->
        printfn "Overflow in double-to-byte conversion."

//</Snippet2>

//<Snippet3>
let convertDoubleInt (doubleVal: float) = 
    let intVal = 0
    // Double to int conversion can overflow.
    try
        let intVal = Convert.ToInt32 doubleVal
        printfn $"{doubleVal} as an int is: {intVal}"
    with :? OverflowException ->
        printfn "Overflow in double-to-int conversion."

    // Int to double conversion cannot overflow.
    let doubleVal = Convert.ToDouble intVal
    printfn $"{intVal} as a double is: {doubleVal}"
//</Snippet3>

//<Snippet5>
let convertDoubleDecimal (decimalVal: float) =
    // Decimal to double conversion cannot overflow.
    let doubleVal = 
        Convert.ToDouble decimalVal
    printfn $"{decimalVal} as a double is: {doubleVal}"

    // Conversion from double to decimal can overflow.
    try
        let decimalVal = Convert.ToDecimal doubleVal
        printfn $"{doubleVal} as a decimal is: {decimalVal}"
    with :? OverflowException ->
        printfn "Overflow in double-to-double conversion."
//</Snippet5>

//<Snippet6>
let covertDoubleFloat (doubleVal: float) =
    // Double to float conversion cannot overflow.
    let floatVal = Convert.ToSingle doubleVal
    printfn $"{doubleVal} as a float is {floatVal}"

    // Conversion from float to double cannot overflow.
    let doubleVal = Convert.ToDouble floatVal
    printfn $"{floatVal} as a double is: {doubleVal}"
//</Snippet6>

//<Snippet7>
let convertDoubleString (doubleVal: float) =
    // A conversion from Double to string cannot overflow.
    let stringVal = Convert.ToString doubleVal
    printfn $"{doubleVal} as a string is: {stringVal}"

    try
        let doubleVal = Convert.ToDouble stringVal
        printfn $"{stringVal} as a double is: {doubleVal}"
    with
    | :? OverflowException ->
        printfn "Conversion from string-to-double overflowed."
    | :? FormatException ->
        printfn "The string was not formatted as a double."
    | :? ArgumentException ->
        printfn "The string pointed to null."
//</Snippet7>

//<Snippet8>
let convertLongChar (longVal: int64) =
    let charVal = 'a'

    try
        let charVal = Convert.ToChar longVal
        printfn $"{longVal} as a char is {charVal}"
    with :? OverflowException ->
        printfn "Overflow in long-to-char conversion."

    // A conversion from Char to long cannot overflow.
    let longVal = Convert.ToInt64 charVal
    printfn $"{charVal} as an Int64 is {longVal}"
//</Snippet8>

//<Snippet9>
let convertLongByte (longVal: int64) =
    let byteVal = 0

    // A conversion from Long to byte can overflow.
    try
        let byteVal = Convert.ToByte longVal
        printfn $"{longVal} as a byte is {byteVal}"
    with :? OverflowException ->
        printfn "Overflow in long-to-byte conversion."

    // A conversion from Byte to long cannot overflow.
    let longVal = Convert.ToInt64 byteVal
    printfn $"{byteVal} as an Int64 is {longVal}"
//</Snippet9>

//<Snippet10>
let convertLongDecimal (longVal: int64) =
    // Long to decimal conversion cannot overflow.
    let decimalVal = Convert.ToDecimal longVal
    printfn $"{longVal} as a decimal is {decimalVal}"

    // Decimal to long conversion can overflow.
    try
        let longVal = Convert.ToInt64 decimalVal
        printfn $"{decimalVal} as a long is {longVal}"
    with :? OverflowException ->
        printfn "Overflow in decimal-to-long conversion."
//</Snippet10>

//<Snippet11>
let convertLongFloat (longVal: int64) =
    // A conversion from Long to float cannot overflow.
    let floatVal = Convert.ToSingle longVal
    printfn $"{longVal} as a float is {floatVal}"

    // A conversion from float to long can overflow.
    try
        let longVal = Convert.ToInt64 floatVal
        printfn $"{floatVal} as a long is {longVal}"
    with :? OverflowException ->
        printfn "Overflow in float-to-long conversion."
//</Snippet11>

//<Snippet12>
let convertStringBoolean (stringVal: string) =
    let boolVal = false

    try
        let boolVal = Convert.ToBoolean stringVal
        if boolVal then
            printfn "String was equal to System.Boolean.TrueString."
        else
            printfn "String was equal to System.Boolean.FalseString."
    with :? FormatException ->
        printfn "The string must equal System.Boolean.TrueString or System.Boolean.FalseString."

    // A conversion from bool to string will always succeed.
    let stringVal = Convert.ToString boolVal
    printfn $"{boolVal} as a string is {stringVal}"
//</Snippet12>

//<Snippet13>
let convertStringByte (stringVal: string) =
    let byteVal = 0

    try
        let byteVal = Convert.ToByte stringVal
        printfn $"{stringVal} as a byte is: {byteVal}"
    with
    | :? OverflowException ->
        printfn "Conversion from string to byte overflowed."
    | :? FormatException ->
        printfn "The string is not formatted as a byte."
    | :? ArgumentNullException ->
        printfn "The string is null."

    //The conversion from byte to string is always valid.
    let stringVal = Convert.ToString byteVal
    printfn $"{byteVal} as a string is {stringVal}"
//</Snippet13>

//<Snippet14>
let convertStringChar (stringVal: string) =
    let charVal = 'a'

    // A string must be one character long to convert to char.
    try
        let charVal = Convert.ToChar stringVal
        printfn $"{stringVal} as a char is {charVal}"
    with
    | :? FormatException ->
        printfn "The string is longer than one character."
    | :? ArgumentNullException ->
        printfn "The string is null."

    // A char to string conversion will always succeed.
    let stringVal = Convert.ToString charVal
    printfn $"The character as a string is {stringVal}"
//</Snippet14>

//<Snippet15>
let convertStringDecimal (stringVal: string) =
    let decimalVal = 0m

    try
        let decimalVal = Convert.ToDecimal(stringVal)
        printfn $"The string as a decimal is {decimalVal}."
    with
    | :? OverflowException ->
        printfn "The conversion from string to decimal overflowed."
    | :? FormatException ->
        printfn "The string is not formatted as a decimal."
    | :? ArgumentNullException ->
        printfn "The string is null."

    // Decimal to string conversion will not overflow.
    let stringVal = Convert.ToString decimalVal
    printfn $"The decimal as a string is {stringVal}."
//</Snippet15>

//<Snippet16>
let convertStringFloat (stringVal: string) =
    let floatVal = 0f

    try
        let floatVal = Convert.ToSingle stringVal
        printfn $"The string as a float is {floatVal}."
    with
    | :? OverflowException ->
        printfn "The conversion from string-to-float overflowed."
    | :? FormatException ->
        printfn "The string is not formatted as a float."
    | :? ArgumentNullException ->
        printfn "The string is null."

    // Float to string conversion will not overflow.
    let stringVal = Convert.ToString floatVal
    printfn $"The float as a string is {stringVal}."
//</Snippet16>

//<Snippet17>
let convertCharDecimal (charVal: char) =
    let decimalVal = 0m

    // Char to decimal conversion is not supported and will always
    // throw an InvalidCastException.
    try
        let decimalVal = Convert.ToDecimal charVal
        ()
    with :? InvalidCastException ->
        printfn "Char-to-Decimal conversion is not supported by the .NET Runtime."

    //Decimal to char conversion is also not supported.
    try
        let charVal = Convert.ToChar decimalVal
        ()
    with :? InvalidCastException ->
        printfn "Decimal-to-Char conversion is not supported by the .NET Runtime."
//</Snippet17>

//<Snippet18>
let convertByteDecimal (byteVal: byte) =
    // Byte to decimal conversion will not overflow.
    let decimalVal = Convert.ToDecimal byteVal
    printfn $"The byte as a decimal is {decimalVal}."

    // Decimal to byte conversion can overflow.
    try
        let byteVal = Convert.ToByte decimalVal
        printfn $"The Decimal as a byte is {byteVal}."
    with :? OverflowException ->
        printfn "The decimal value is too large for a byte."
//</Snippet18>

//<Snippet19>
let convertByteSingle (byteVal: byte) =
    // Byte to float conversion will not overflow.
    let floatVal = Convert.ToSingle byteVal
    printfn $"The byte as a float is {floatVal}."

    // Float to byte conversion can overflow.
    try
        let byteVal = Convert.ToByte floatVal
        printfn $"The float as a byte is {byteVal}."
    with :? OverflowException ->
        printfn "The float value is too large for a byte."
//</Snippet19>

//<Snippet20>
let convertBoolean () =
    let year        = 1979
    let month       = 7
    let day         = 28
    let hour        = 13
    let minute      = 26
    let second      = 15
    let millisecond = 53

    let dateTime = DateTime(year, month, day, hour, minute, second, millisecond)

    // System.InvalidCastException is always thrown.
    try
        let boolVal = Convert.ToBoolean dateTime
        ()
    with :? InvalidCastException ->
        printfn "Conversion from DateTime to Boolean is not supported by the .NET Runtime."
//</Snippet20>

