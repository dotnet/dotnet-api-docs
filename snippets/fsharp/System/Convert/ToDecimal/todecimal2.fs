module todeci

// <Snippet10>
open System
open System.Globalization

type Temperature(temperature) =
    member _.Celsius = temperature

    member _.Kelvin =
        temperature + 273.15m

    member _.Fahrenheit =
        Math.Round(temperature * 9m / 5m + 32m, 2)

    override _.ToString() =
        $"{temperature:N2} °C"

    // IConvertible implementations.
    interface IConvertible with
        member _.GetTypeCode() =
            TypeCode.Object

        member _.ToBoolean(provider: IFormatProvider) =
            temperature <> 0M

        member _.ToByte(provider: IFormatProvider) =
            if uint8 temperature < Byte.MinValue || uint8 temperature > Byte.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Byte type.")
            else
            Decimal.ToByte temperature

        member _.ToChar(provider: IFormatProvider) =
            raise (InvalidCastException "Temperature to Char conversion is not supported.")

        member _.ToDateTime(provider: IFormatProvider) =
            raise (InvalidCastException "Temperature to DateTime conversion is not supported.")

        member _.ToDecimal(provider: IFormatProvider) =
            temperature

        member _.ToDouble(provider: IFormatProvider) =
            Decimal.ToDouble temperature

        member _.ToInt16(provider: IFormatProvider) =
            if int16 temperature < Int16.MinValue || int16 temperature > Int16.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Int16 type.")
            else
                Decimal.ToInt16 temperature

        member _.ToInt32(provider: IFormatProvider) =
            if int temperature < Int32.MinValue || int temperature > Int32.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Int32 type.")
            else
                Decimal.ToInt32 temperature

        member _.ToInt64(provider: IFormatProvider) =
            if int64 temperature < Int64.MinValue || int64 temperature > Int64.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Int64 type.")
            else
                Decimal.ToInt64 temperature

        member _.ToSByte(provider: IFormatProvider) =
            if int8 temperature < SByte.MinValue || int8 temperature > SByte.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the SByte type.")
            else
                Decimal.ToSByte temperature

        member _.ToSingle(provider: IFormatProvider) =
            Decimal.ToSingle temperature

        member _.ToString(provider: IFormatProvider) =
           temperature.ToString("N2", provider) + " °C"

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
                if typeof<Temperature>.Equals conversionType then
                    this
                else
                    raise (InvalidCastException $"Conversion to a {conversionType.Name} is not supported.")
            | TypeCode.SByte ->
                this.ToSByte null
            | TypeCode.Single ->
                this.ToSingle null
            | TypeCode.String ->
                this.ToString provider
            | TypeCode.UInt16 ->
                this.ToUInt16 null
            | TypeCode.UInt32 ->
                this.ToUInt32 null
            | TypeCode.UInt64 ->
                this.ToUInt64 null
            | _ ->
                raise (InvalidCastException $"Conversion to {conversionType.Name} is not supported.")

        member _.ToUInt16(provider: IFormatProvider) =
            if uint16 temperature < UInt16.MinValue || uint16 temperature > UInt16.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the UInt16 type.")
            else
                Decimal.ToUInt16 temperature

        member _.ToUInt32(provider: IFormatProvider) =
            if uint temperature < UInt32.MinValue || uint temperature > UInt32.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the UInt32 type.")
            else
                Decimal.ToUInt32 temperature

        member _.ToUInt64(provider: IFormatProvider) =
            if uint64 temperature < UInt64.MinValue || uint64 temperature > UInt64.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the UInt64 type.")
            else
                Decimal.ToUInt64 temperature
        // </Snippet10>

// <Snippet11>
let cold = Temperature -40
let freezing = Temperature 0
let boiling = Temperature 100

printfn $"{Convert.ToDecimal(cold, null)}"
printfn $"{Convert.ToDecimal(freezing, null)}"
printfn $"{Convert.ToDecimal(boiling, null)}"
// The example dosplays the following output:
//       -40
//       0
//       100
// </Snippet11>