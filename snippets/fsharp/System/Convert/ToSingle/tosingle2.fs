module tosingle2

// <Snippet14>
open System

type Temperature(temperature: float32) =
    member _.Celsius =
        temperature

    member _.Kelvin =
        temperature + 273.15f

    member _.Fahrenheit =
        MathF.Round(temperature * 9f / 5f + 32f, 2)

    override _.ToString() =
        $"{temperature:N2} °C"

    // IConvertible implementations.
    interface IConvertible with

        member _.GetTypeCode() =
            TypeCode.Object

        member _.ToBoolean(provider: IFormatProvider) =
            temperature <> 0f

        member _.ToByte(provider: IFormatProvider) =
            if temperature < float32 Byte.MinValue || temperature > float32 Byte.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Byte type.")
            else
                Convert.ToByte temperature

        member _.ToChar(provider: IFormatProvider) =
            raise (InvalidCastException "Temperature to Char conversion is not supported.")

        member _.ToDateTime(provider: IFormatProvider) =
            raise (InvalidCastException "Temperature to DateTime conversion is not supported.")

        member _.ToDecimal(provider: IFormatProvider) =
            Convert.ToDecimal temperature

        member _.ToDouble(provider: IFormatProvider) =
            Convert.ToDouble temperature

        member _.ToInt16(provider: IFormatProvider) =
            if temperature < float32 Int16.MinValue || temperature > float32 Int16.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Int16 type.")
            else
                Convert.ToInt16 temperature

        member _.ToInt32(provider: IFormatProvider) =
            if temperature < float32 Int32.MinValue || temperature > float32 Int32.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Int32 type.")
            else
                Convert.ToInt32 temperature

        member _.ToInt64(provider: IFormatProvider) =
            if float32 temperature < float32 Int64.MinValue || temperature > float32 Int64.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Int64 type.")
            else
                Convert.ToInt64 temperature

        member _.ToSByte(provider: IFormatProvider) =
            if temperature < float32 SByte.MinValue || temperature > float32 SByte.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the SByte type.")
            else
                Convert.ToSByte temperature

        member _.ToSingle(provider: IFormatProvider) =
            temperature

        override _.ToString(provider: IFormatProvider) =
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
            if temperature < float32 UInt16.MinValue || temperature > float32 UInt16.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the UInt16 type.")
            else
                Convert.ToUInt16 temperature

        member _.ToUInt32(provider: IFormatProvider) =
            if temperature < float32 UInt32.MinValue || temperature > float32 UInt32.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the UInt32 type.")
            else
                Convert.ToUInt32 temperature

        member _.ToUInt64(provider: IFormatProvider) =
            if temperature < float32 UInt64.MinValue || temperature > float32 UInt64.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the UInt64 type.")
            else
                Convert.ToUInt64 temperature
// </Snippet14>

// <Snippet15>
let cold = Temperature -40f
let freezing = Temperature 0f
let boiling = Temperature 100f

printfn $"{Convert.ToInt32(cold, null)}"
printfn $"{Convert.ToInt32(freezing, null)}"
printfn $"{Convert.ToDouble(boiling, null)}"
// The example dosplays the following output:
//       -40
//       0
//       100
// </Snippet15>