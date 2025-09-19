module tobyte3

// <Snippet12>
open System
open System.Globalization

type SignBit =
   | Negative = -1
   | Zero = 0
   | Positive = 1

[<Struct>]
type ByteString =
    val mutable private value: string
    
    val mutable Sign : SignBit
    member this.Value
        with get () = this.value
        and set (value: string) =
            if value.Trim().Length > 2 then
                invalidArg "value" "The string representation of a byte cannot have more than two characters"
            else
                this.value <- value 

    // IConvertible implementations.
    interface IConvertible with
        member _.GetTypeCode() =
            TypeCode.Object

        member this.ToBoolean(provider: IFormatProvider) =
            this.Sign <> SignBit.Zero

        member this.ToByte(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{Convert.ToSByte(this.value, 16)} is out of range of the Byte type.")
            else
                Byte.Parse(this.value, NumberStyles.HexNumber)

        member this.ToChar(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{Convert.ToSByte(this.value, 16)} is out of range of the Char type.")
            else
                let byteValue = Byte.Parse(this.value, NumberStyles.HexNumber)
                Convert.ToChar byteValue

        member _.ToDateTime(provider: IFormatProvider) =
            raise (InvalidCastException "ByteString to DateTime conversion is not supported.")

        member this.ToDecimal(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                let byteValue = SByte.Parse(this.Value, NumberStyles.HexNumber)
                Convert.ToDecimal byteValue
            else
                let byteValue = Byte.Parse(this.Value, NumberStyles.HexNumber)
                Convert.ToDecimal byteValue

        member this.ToDouble(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Convert.ToDouble(SByte.Parse(this.value, NumberStyles.HexNumber))
            else
                Convert.ToDouble(Byte.Parse(this.value, NumberStyles.HexNumber))

        member this.ToInt16(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Convert.ToInt16(SByte.Parse(this.value, NumberStyles.HexNumber))
            else
                Convert.ToInt16(Byte.Parse(this.value, NumberStyles.HexNumber))

        member this.ToInt32(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Convert.ToInt32(SByte.Parse(this.value, NumberStyles.HexNumber))
            else
                Convert.ToInt32(Byte.Parse(this.value, NumberStyles.HexNumber))

        member this.ToInt64(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Convert.ToInt64(SByte.Parse(this.value, NumberStyles.HexNumber))
            else
                Convert.ToInt64(Byte.Parse(this.value, NumberStyles.HexNumber))

        member this.ToSByte(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                try
                    Convert.ToSByte(Byte.Parse(this.value, NumberStyles.HexNumber))
                with :? OverflowException as e ->
                    raise (OverflowException($"{Byte.Parse(this.value, NumberStyles.HexNumber)} is outside the range of the SByte type.", e))
            else
                SByte.Parse(this.value, NumberStyles.HexNumber)

        member this.ToSingle(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                Convert.ToSingle(SByte.Parse(this.value, NumberStyles.HexNumber))
            else
                Convert.ToSingle(Byte.Parse(this.value, NumberStyles.HexNumber))

        member this.ToString(provider: IFormatProvider) =
            "0x" + this.value

        member this.ToType(conversionType: Type, provider: IFormatProvider): obj =
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
            | TypeCode.Decimal ->
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
                if typeof<ByteString>.Equals conversionType then
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
                raise (OverflowException $"{SByte.Parse(this.value, NumberStyles.HexNumber)} is outside the range of the UInt16 type.")
            else
                Convert.ToUInt16(Byte.Parse(this.value, NumberStyles.HexNumber))

        member this.ToUInt32(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{SByte.Parse(this.value, NumberStyles.HexNumber)} is outside the range of the UInt32 type.")
            else
                Convert.ToUInt32(Byte.Parse(this.value, NumberStyles.HexNumber))

        member this.ToUInt64(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{SByte.Parse(this.value, NumberStyles.HexNumber)} is outside the range of the UInt64 type.")
            else
                Convert.ToUInt64(Byte.Parse(this.value, NumberStyles.HexNumber))
// </Snippet12>

// <Snippet13>
let positiveByte = 216uy
let negativeByte = -101y

let mutable positiveString = ByteString()
positiveString.Sign <- Math.Sign positiveByte |> enum
positiveString.Value <- positiveByte.ToString "X2"

let mutable negativeString = ByteString()
negativeString.Sign <- Math.Sign negativeByte |> enum
negativeString.Value <- negativeByte.ToString "X2"

try
    printfn $"'{positiveString.Value}' converts to {Convert.ToByte positiveString}."
with :? OverflowException ->
    printfn $"0x{positiveString.Value} is outside the range of the Byte type."

try
    printfn $"'{negativeString.Value}' converts to {Convert.ToByte negativeString}."
with :? OverflowException ->
    printfn $"0x{negativeString.Value} is outside the range of the Byte type."

// The example displays the following output:
//       'D8' converts to 216.
//       0x9B is outside the range of the Byte type.
// </Snippet13>