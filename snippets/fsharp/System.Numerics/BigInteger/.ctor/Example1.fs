module example1

open System
open System.Numerics

let createSimpleArray () =
    // <Snippet1>
    let bytes = [| 5uy; 4uy; 3uy; 2uy; 1uy |]
    let number = new BigInteger(bytes)
    printfn $"The value of number is {number} (or 0x{number:x})."
    // The example displays the following output:
    //    The value of number is 4328719365 (or 0x102030405).
    // </Snippet1>

let roundtripValue () =
    // <Snippet2>
    // Instantiate BigInteger values.
    let positiveValue = BigInteger.Parse "4713143110832790377889"
    let negativeValue = BigInteger.Add(-Int64.MaxValue, -60000)

    // Create two byte arrays.
    let positiveBytes = positiveValue.ToByteArray()
    let negativeBytes = negativeValue.ToByteArray()

    // Instantiate new BigInteger from negativeBytes array.
    printf $"Converted {negativeValue:N0} to the byte array "

    for byteValue in negativeBytes do
        printf $"0x{byteValue:x2} "

    printfn ""
    let negativeValue2 = bigint negativeBytes
    printfn $"Converted the byte array to {negativeValue2:N0}"
    printfn ""

    // Instantiate new BigInteger from positiveBytes array.
    printf $"Converted {positiveValue:N0} to the byte array "

    for byteValue in positiveBytes do
        printf $"0x{byteValue:x2} "

    printfn ""
    let positiveValue2 = new BigInteger(positiveBytes)
    printfn $"Converted the byte array to {positiveValue2:N0}"
    printfn ""
    // The example displays the following output:
    //    Converted -9,223,372,036,854,835,807 to the byte array A1 15 FF FF FF FF FF 7F FF
    //    Converted the byte array to -9,223,372,036,854,835,807
    //
    //    Converted 4,713,143,110,832,790,377,889 to the byte array A1 15 FF FF FF FF FF 7F FF 00
    //    Converted the byte array to 4,713,143,110,832,790,377,889
    // </Snippet2>

let ensureSign () =
    // <Snippet3>
    let originalNumber = UInt64.MaxValue
    let mutable bytes = BitConverter.GetBytes originalNumber

    if originalNumber > 0uL && (bytes[bytes.Length - 1] &&& 0x80uy) > 0uy then
        let temp = Array.zeroCreate bytes.Length

        Array.Copy(bytes, temp, bytes.Length)
        bytes <- Array.zeroCreate (temp.Length + 1)
        Array.Copy(temp, bytes, temp.Length)

    let newNumber = bigint bytes
    printfn $"Converted the UInt64 value {originalNumber:N0} to {newNumber:N0}."
    // The example displays the following output:
    //    Converted the UInt64 value 18,446,744,073,709,551,615 to 18,446,744,073,709,551,615.
    // </Snippet3>

createSimpleArray ()
roundtripValue ()
ensureSign ()
