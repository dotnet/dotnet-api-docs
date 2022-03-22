open System


let convertHexToNegativeInteger () =
    // <Snippet1>
    // Create a hexadecimal value out of range of the Integer type.
    let value = Convert.ToString(int64 Int32.MaxValue + 1L, 16)
    // Convert it back to a number.
    try
        let number = Convert.ToInt32(value, 16)
        printfn $"0x{value} converts to {number}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to an integer."
    // </Snippet1>

let convertHexToInteger () =
    // <Snippet2>
    // Create a hexadecimal value out of range of the Integer type.
    let sourceNumber = int64 Int32.MaxValue + 1L
    let isNegative = sign sourceNumber = -1
    let value = Convert.ToString(sourceNumber, 16)
    try
        let targetNumber = Convert.ToInt32(value, 16)
        if not isNegative && targetNumber &&& 0x80000000 <> 0 then
            raise (OverflowException())
        else
        printfn $"0x{value} converts to {targetNumber}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to an integer."
    // Displays the following to the console:
    //    Unable to convert '0x80000000' to an integer.
    // </Snippet2>

let convertNegativeHexToByte () =
    // <Snippet3>
    // Create a hexadecimal value out of range of the Byte type.
    let value = SByte.MinValue.ToString "X"
    // Convert it back to a number.
    try
        let number = Convert.ToByte(value, 16)
        printfn $"0x{value} converts to {number}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to a byte."
    // </Snippet3>

let convertHexToByte () =
    // <Snippet4>
    // Create a negative hexadecimal value out of range of the Byte type.
    let sourceNumber = SByte.MinValue
    let isSigned = sign (sourceNumber.GetType().GetField("MinValue").GetValue null :?> int8) = -1
    let value = sourceNumber.ToString "X"
    try
        let targetNumber = Convert.ToByte(value, 16)
        if isSigned && targetNumber &&& 0x80uy <> 0uy then
            raise (OverflowException())
        else
            printfn $"0x{value} converts to {targetNumber}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to an unsigned byte."
    // Displays the following to the console:
    //    Unable to convert '0x80' to an unsigned byte.
    // </Snippet4>

let convertHexToNegativeShort () =
    // <Snippet5>
    // Create a hexadecimal value out of range of the Int16 type.
    let value = Convert.ToString(int Int16.MaxValue + 1, 16)
    // Convert it back to a number.
    try
        let number = Convert.ToInt16(value, 16)
        printfn $"0x{value} converts to {number}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to a 16-bit integer."
    // </Snippet5>

let convertHexToShort () =
    // <Snippet6>
    // Create a hexadecimal value out of range of the Short type.
    let sourceNumber = int Int16.MaxValue + 1
    let isNegative = sign sourceNumber = -1
    let value = Convert.ToString(sourceNumber, 16)
    try
        let targetNumber = Convert.ToInt16(value, 16)
        if not isNegative && targetNumber &&& 0x8000s <> 0s then
            raise (OverflowException())
        else
            printfn $"0x{value} converts to {targetNumber}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to a 16-bit integer."
    // Displays the following to the console:
    //    Unable to convert '0x8000' to a 16-bit integer.
    // </Snippet6>

let convertHexToNegativeLong () =
    // <Snippet7>
    // Create a hexadecimal value out of range of the long type.
    let value = UInt64.MaxValue.ToString "X"
    // Use Convert.ToInt64 to convert it back to a number.
    try
        let number = Convert.ToInt64(value, 16)
        printfn $"0x{value} converts to {number}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to a long integer."
    // </Snippet7>

let convertHexToLong () =
    // <Snippet8>
    // Create a negative hexadecimal value out of range of the Byte type.
    let sourceNumber = UInt64.MaxValue
    let isSigned = sign (Convert.ToDouble(sourceNumber.GetType().GetField("MinValue").GetValue null)) = -1
    let value = sourceNumber.ToString "X"
    try
        let targetNumber = Convert.ToInt64(value, 16)
        if not isSigned && targetNumber &&& 0x80000000L <> 0L then
            raise (OverflowException())
        else
            printfn $"0x{value} converts to {targetNumber}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to a long integer."
    // Displays the following to the console:
    //    Unable to convert '0xFFFFFFFFFFFFFFFF' to a long integer.
    // </Snippet8>

let convertHexToNegativeSByte () =
    // <Snippet9>
    // Create a hexadecimal value out of range of the SByte type.
    let value = Convert.ToString(Byte.MaxValue, 16)
    // Convert it back to a number.
    try
        let number = Convert.ToSByte(value, 16)
        printfn $"0x{value} converts to {number}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to a signed byte."
    // </Snippet9>

let convertHexToSByte () =
    // <Snippet10>
    // Create a hexadecimal value out of range of the SByte type.
    let sourceNumber = Byte.MaxValue
    let isSigned = sign (Convert.ToDouble(sourceNumber.GetType().GetField("MinValue").GetValue null)) = -1
    let value = Convert.ToString(sourceNumber, 16)
    try
        let targetNumber = Convert.ToSByte(value, 16)
        if not isSigned && targetNumber &&& 0x80y <> 0y then
            raise (OverflowException())
        else
        printfn $"0x{value} converts to {targetNumber}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to a signed byte."
    // Displays the following to the console:
    //    Unable to convert '0xff' to a signed byte.
    // </Snippet10>

let convertNegativeHexToUInt16 () =
    // <Snippet11>
    // Create a hexadecimal value out of range of the UInt16 type.
    let value = Convert.ToString(Int16.MinValue, 16)
    // Convert it back to a number.
    try
        let number = Convert.ToUInt16(value, 16)
        printfn $"0x{value} converts to {number}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to an unsigned short integer."
    // </Snippet11>

let convertHexToUInt16 () =
    // <Snippet12>
    // Create a negative hexadecimal value out of range of the UInt16 type.
    let sourceNumber = Int16.MinValue
    let isSigned = sign (sourceNumber.GetType().GetField("MinValue").GetValue null :?> int16) = -1
    let value = Convert.ToString(sourceNumber, 16)
    try
        let targetNumber = Convert.ToUInt16(value, 16)
        if isSigned && targetNumber &&& 0x8000us <> 0us then
            raise (OverflowException())
        else
            printfn $"0x{value} converts to {targetNumber}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to an unsigned short integer."
    // Displays the following to the console:
    //    Unable to convert '0x8000' to an unsigned short integer.
    // </Snippet12>

let convertNegativeHexToUInt32 () =
    // <Snippet13>
    // Create a hexadecimal value out of range of the UInt32 type.
    let value = Convert.ToString(Int32.MinValue, 16)
    // Convert it back to a number.
    try
        let number = Convert.ToUInt32(value, 16)
        printfn $"0x{value} converts to {number}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to an unsigned integer."
    // </Snippet13>

let convertHexToUInt32 () =
    // <Snippet14>
    // Create a negative hexadecimal value out of range of the UInt32 type.
    let sourceNumber = Int32.MinValue
    let isSigned = sign (sourceNumber.GetType().GetField("MinValue").GetValue null :?> int) = -1
    let value = Convert.ToString(sourceNumber, 16)
    try
        let targetNumber = Convert.ToUInt32(value, 16)
        if isSigned && targetNumber &&& 0x80000000u <> 0u then
            raise (OverflowException())
        else
            printfn $"0x{value} converts to {targetNumber}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to an unsigned integer."
    // Displays the following to the console:
    //    Unable to convert '0x80000000' to an unsigned integer.
    // </Snippet14>

let convertNegativeHexToUInt64 () =
    // <Snippet15>
    // Create a hexadecimal value out of range of the UInt64 type.
    let value = Convert.ToString(Int64.MinValue, 16)
    // Convert it back to a number.
    try
        let number = Convert.ToUInt64(value, 16)
        printfn $"0x{value} converts to {number}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to an unsigned long integer."
    // </Snippet15>

let convertHexToUInt64 () =
    // <Snippet16>
    // Create a negative hexadecimal value out of range of the UInt64 type.
    let sourceNumber = Int64.MinValue
    let isSigned = sign (sourceNumber.GetType().GetField("MinValue").GetValue null :?> int64) = -1
    let value = Convert.ToString(sourceNumber, 16)
    try
        let targetNumber = Convert.ToUInt64(value, 16)
        if isSigned && targetNumber &&& 0x8000000000000000uL <> 0uL then  
            raise (OverflowException())
        else
            printfn $"0x{value} converts to {targetNumber}."
    with :? OverflowException ->
        printfn $"Unable to convert '0x{value}' to an unsigned long integer."
    // Displays the following to the console:
    //    Unable to convert '0x8000000000000000' to an unsigned long integer.
    // </Snippet16>

convertHexToNegativeInteger ()
printfn ""
convertHexToInteger ()
printfn ""
convertNegativeHexToByte ()
printfn ""
convertHexToByte ()
printfn ""
convertHexToNegativeShort ()
printfn ""
convertHexToShort ()
printfn ""
convertHexToNegativeLong ()
printfn ""
convertHexToLong ()
printfn ""
convertHexToNegativeSByte ()
printfn ""
convertHexToSByte ()
printfn ""
convertNegativeHexToUInt16 ()
printfn ""
convertHexToUInt16 ()
printfn ""
convertNegativeHexToUInt32 ()
printfn ""
convertHexToUInt32 ()
printfn ""
convertNegativeHexToUInt64 ()
printfn ""
convertHexToUInt64 ()
