module Tosbyte2

// <Snippet14>
open System
open System.Globalization

type SignBit =
   | Negative = -1
   | Zero = 0
   | Positive = 1

[<Struct>]
type ByteString =
    val mutable private byteString: string

    val mutable Sign : SignBit

    member this.Value
        with get () = this.byteString
        and set (value: string) =
            if value.Trim().Length > 2 then
                invalidArg "value" "The string representation of a byte cannot have more than two characters."
            this.byteString <- value

    // IConvertible implementations.
    interface IConvertible with
        member _.GetTypeCode() = 
            TypeCode.Object

        member this.ToBoolean(provider: IFormatProvider) =
            this.Sign <> SignBit.Zero

        member this.ToByte(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{Convert.ToSByte(this.byteString, 16)} is out of range of the Byte type.")
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)

        member this.ToChar(provider: IFormatProvider) =
        
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{Convert.ToSByte(this.byteString, 16)} is out of range of the Char type.")
            else
                let byteValue = Byte.Parse(this.byteString, NumberStyles.HexNumber)
                Convert.ToChar byteValue

        member _.ToDateTime(provider: IFormatProvider) =    
            raise (InvalidCastException "ByteString to DateTime conversion is not supported.")

        member this.ToDecimal(provider: IFormatProvider) =    
            if this.Sign = SignBit.Negative then
                SByte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToDecimal
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToDecimal

        member this.ToDouble(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                SByte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToDouble
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToDouble

        member this.ToInt16(provider: IFormatProvider) =    
            if this.Sign = SignBit.Negative then
                SByte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToInt16
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToInt16

        member this.ToInt32(provider: IFormatProvider) =    
            if this.Sign = SignBit.Negative then
                SByte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToInt32
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToInt32

        member this.ToInt64(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                SByte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToInt64
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToInt64

        member this.ToSByte(provider: IFormatProvider) =    
            try
                SByte.Parse(this.byteString, NumberStyles.HexNumber)
            with :? OverflowException as e ->
                raise (OverflowException($"{Byte.Parse(this.byteString, NumberStyles.HexNumber)} is outside the range of the SByte type.", e) )

        member this.ToSingle(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                SByte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToSingle
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToSingle

        member this.ToString(provider: IFormatProvider) =
            "0x" + this.byteString

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
                raise (OverflowException $"{SByte.Parse(this.byteString, NumberStyles.HexNumber)} is outside the range of the UInt16 type." )
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToUInt16

        member this.ToUInt32(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{SByte.Parse(this.byteString, NumberStyles.HexNumber)} is outside the range of the UInt32 type.")
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToUInt32
    
        member this.ToUInt64(provider: IFormatProvider) =
            if this.Sign = SignBit.Negative then
                raise (OverflowException $"{SByte.Parse(this.byteString, NumberStyles.HexNumber)} is outside the range of the UInt32 type.")
            else
                Byte.Parse(this.byteString, NumberStyles.HexNumber)
                |> Convert.ToUInt64
// </Snippet14>

// <Snippet15>
let positiveByte = 120y
let negativeByte = -101y

let mutable positiveString = ByteString()
positiveString.Sign <- sign positiveByte |> enum
positiveString.Value <- positiveByte.ToString "X2"

let mutable negativeString = ByteString()
negativeString.Sign <- sign negativeByte |> enum
negativeString.Value <- negativeByte.ToString "X2"

try
    printfn $"'{positiveString.Value}' converts to {Convert.ToSByte positiveString}."
with :? OverflowException ->
    printfn $"0x{positiveString.Value} is outside the range of the Byte type."

try
    printfn $"'{negativeString.Value}' converts to {Convert.ToSByte negativeString}."
with :? OverflowException ->
    printfn $"0x{negativeString.Value} is outside the range of the Byte type."

// The example displays the following output:
//       '78' converts to 120.
//       '9B' converts to -101.
// </Snippet15>