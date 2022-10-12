module touint16_3

// <Snippet16>
open System
open System.Globalization
open System.Text.RegularExpressions

type SignBit =
    | Negative = -1
    | Zero = 0
    | Positive = 1

[<Struct>]
type HexString =
    val mutable private hexString: string

    val mutable Sign: SignBit

    member this.Value
        with get () = this.hexString
        and set (value: string) =
            if value.Trim().Length > 4 then
                invalidArg "value" "The string representation of a 16 bit integer cannot have more than four characters."
            elif Regex.IsMatch(value, "([0-9,A-F]){1,4}", RegexOptions.IgnoreCase) |> not then
                invalidArg "value" "The hexadecimal representation of a 16-bit integer contains invalid characters."
            else
                this.hexString <- value

    interface IConvertible with
        // IConvertible implementations.
        member _.GetTypeCode() =
            TypeCode.Object

        member this.ToBoolean(provider: IFormatProvider) =
            this.Sign <> SignBit.Zero

        member this.ToByte(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{Convert.ToInt16(this.hexString, 16)} is out of range of the Byte type.")
            else
                try
                    Convert.ToByte(UInt16.Parse(this.hexString, NumberStyles.HexNumber))
                with :? OverflowException as e ->
                    raise (OverflowException($"{Convert.ToUInt16(this.hexString, 16)} is out of range of the UInt16 type.", e) )

        member this.ToChar(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{Convert.ToInt16(this.hexString, 16)} is out of range of the Char type.")

            let codePoint = UInt16.Parse(this.hexString, NumberStyles.HexNumber)
            Convert.ToChar codePoint

        member _.ToDateTime(provider: IFormatProvider) =
            raise (InvalidCastException "Hexadecimal to DateTime conversion is not supported.")

        member this.ToDecimal(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                let hexValue = Int16.Parse(this.hexString, NumberStyles.HexNumber)
                Convert.ToDecimal hexValue
            else
                let hexValue = UInt16.Parse(this.hexString, NumberStyles.HexNumber)
                Convert.ToDecimal hexValue

        member this.ToDouble(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Convert.ToDouble(Int16.Parse(this.hexString, NumberStyles.HexNumber))
            else
                Convert.ToDouble(UInt16.Parse(this.hexString, NumberStyles.HexNumber))

        member this.ToInt16(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Int16.Parse(this.hexString, NumberStyles.HexNumber)
            else
                try
                    Convert.ToInt16(UInt16.Parse(this.hexString, NumberStyles.HexNumber))
                with :? OverflowException as e ->
                    raise (OverflowException($"{Convert.ToUInt16(this.hexString, 16)} is out of range of the Int16 type.", e) )

        member this.ToInt32(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Convert.ToInt32(Int16.Parse(this.hexString, NumberStyles.HexNumber))
            else
                Convert.ToInt32(UInt16.Parse(this.hexString, NumberStyles.HexNumber))

        member this.ToInt64(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Convert.ToInt64(Int16.Parse(this.hexString, NumberStyles.HexNumber))
            else
                Int64.Parse(this.hexString, NumberStyles.HexNumber)

        member this.ToSByte(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                try
                    Convert.ToSByte(Int16.Parse(this.hexString, NumberStyles.HexNumber))
                with :? OverflowException as e ->
                    raise (OverflowException($"{Int16.Parse(this.hexString, NumberStyles.HexNumber)} is outside the range of the SByte type.", e))
            else
                try
                    Convert.ToSByte(UInt16.Parse(this.hexString, NumberStyles.HexNumber))
                with :? OverflowException as e ->
                    raise (OverflowException($"{UInt16.Parse(this.hexString, NumberStyles.HexNumber)} is outside the range of the SByte type.", e) )

        member this.ToSingle(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Convert.ToSingle(Int16.Parse(this.hexString, NumberStyles.HexNumber))
            else
                Convert.ToSingle(UInt16.Parse(this.hexString, NumberStyles.HexNumber))

        member this.ToString(provider: IFormatProvider) =
            "0x" + this.hexString

        member this.ToType(conversionType: Type, provider: IFormatProvider) =
            let this = this :> IConvertible
            match Type.GetTypeCode conversionType with
            | TypeCode.Boolean ->
                this.ToBoolean null
            | TypeCode.Byte ->
                this.ToByte null
            | TypeCode.Char ->
                this.ToChar null
            | TypeCode.DateTime ->
                this.ToDateTime null
            | TypeCode.Decimal->
                this.ToDecimal null
            | TypeCode.Double ->
                this.ToDouble null
            | TypeCode.Int16 ->
                this.ToInt16 null
            | TypeCode.Int32 ->
                this.ToInt32 null
            | TypeCode.Int64 ->
                this.ToInt64 null
            | TypeCode.Object ->
                if typeof<HexString>.Equals conversionType then
                    this
                else
                    raise (InvalidCastException $"Conversion to a {conversionType.Name} is not supported.")
            | TypeCode.SByte ->
                this.ToSByte null
            | TypeCode.Single ->
                this.ToSingle null
            | TypeCode.String ->
                this.ToString null
            | TypeCode.UInt16 ->
                this.ToUInt16 null
            | TypeCode.UInt32 ->
                this.ToUInt32 null
            | TypeCode.UInt64 ->
                this.ToUInt64 null
            | _ ->
                raise (InvalidCastException $"Conversion to {conversionType.Name} is not supported.")

        member this.ToUInt16(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{Int16.Parse(this.hexString, NumberStyles.HexNumber)} is outside the range of the UInt16 type.")
            else
                UInt16.Parse(this.hexString, NumberStyles.HexNumber)

        member this.ToUInt32(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{Int16.Parse(this.hexString, NumberStyles.HexNumber)} is outside the range of the UInt32 type.")
            else
                Convert.ToUInt32(this.hexString, 16)

        member this.ToUInt64(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{Int64.Parse(this.hexString, NumberStyles.HexNumber)} is outside the range of the UInt64 type.")
            else
                Convert.ToUInt64(this.hexString, 16)
        // </Snippet16>

// <Snippet17>
let positiveValue = 32000us
let negativeValue = -1s

let mutable positiveString = HexString()
positiveString.Sign <- Math.Sign positiveValue |> enum
positiveString.Value <- positiveValue.ToString "X2"

let mutable negativeString = HexString()
negativeString.Sign <- sign negativeValue |> enum
negativeString.Value <- negativeValue.ToString "X2"

try
    printfn $"0x{positiveString.Value} converts to {Convert.ToUInt16 positiveString}."
with :? OverflowException ->
    printfn $"{Int16.Parse(negativeString.Value, NumberStyles.HexNumber)} is outside the range of the UInt16 type."

try
    printfn $"0x{negativeString.Value} converts to {Convert.ToUInt16 negativeString}."
with :? OverflowException ->
    printfn $"{Int16.Parse(negativeString.Value, NumberStyles.HexNumber)} is outside the range of the UInt16 type."
// The example displays the following output:
//       0x7D00 converts to 32000.
//       -1 is outside the range of the UInt16 type.
// </Snippet17>