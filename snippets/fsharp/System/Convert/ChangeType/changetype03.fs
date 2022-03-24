module changetype03

// <Snippet3>
open System
open System.Globalization

type Temperature(temperature: decimal) = 

    member _.Celsius = temperature

    member _.Kelvin =
        temperature + 273.15m

    member _.Fahrenheit =
        Math.Round(decimal (temperature * 9m / 5m + 32m), 2)

    override _.ToString() =
        temperature.ToString "N2" + "°C"

    // IConvertible implementations.
    interface IConvertible with
        member _.GetTypeCode() =
            TypeCode.Object

        member _.ToBoolean(provider: IFormatProvider) =
            temperature <> 0M

        member _.ToByte(provider: IFormatProvider) =
            if temperature < decimal Byte.MinValue || temperature > decimal Byte.MaxValue then
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
            if temperature < decimal Int16.MinValue || temperature > decimal Int16.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Int16 type.")
            else
                Decimal.ToInt16 temperature

        member _.ToInt32(provider: IFormatProvider) =
            if temperature < decimal Int32.MinValue || temperature > decimal Int32.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Int32 type.")
            else
                Decimal.ToInt32 temperature

        member _.ToInt64(provider: IFormatProvider) =
            if temperature < decimal Int64.MinValue || temperature > decimal Int64.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the Int64 type.")
            else
                Decimal.ToInt64 temperature

        member _.ToSByte(provider: IFormatProvider) =
            if temperature < decimal SByte.MinValue || temperature > decimal SByte.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the SByte type.")
            else
                Decimal.ToSByte temperature

        member _.ToSingle(provider: IFormatProvider) =
            Decimal.ToSingle temperature

        member _.ToString(provider: IFormatProvider) =
            temperature.ToString("N2", provider) + "°C"

        member this.ToType(conversionType: Type, provider: IFormatProvider) =
            let this = this :> IConvertible
            match Type.GetTypeCode conversionType with
            | TypeCode.Boolean->
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
            | TypeCode.UInt32->
                this.ToUInt32 null
            | TypeCode.UInt64->
                this.ToUInt64 null
            | _ ->
                raise (InvalidCastException $"Conversion to {conversionType.Name} is not supported.")

        member _.ToUInt16(provider: IFormatProvider) =
            if temperature < decimal UInt16.MinValue || temperature > decimal UInt16.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the UInt16 type.")
            else
                Decimal.ToUInt16 temperature

        member _.ToUInt32(provider: IFormatProvider) =
            if temperature < decimal UInt32.MinValue || temperature > decimal UInt32.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the UInt32 type.")
            else
                Decimal.ToUInt32 temperature

        member _.ToUInt64(provider: IFormatProvider) =
            if temperature < decimal UInt64.MinValue || temperature > decimal UInt64.MaxValue then
                raise (OverflowException $"{temperature} is out of range of the UInt64 type.")
            else
                Decimal.ToUInt64 temperature
// </Snippet3>

// <Snippet4>
let cool = Temperature 5
let targetTypes = 
    [ typeof<SByte>; typeof<Int16>; typeof<Int32>
      typeof<Int64>; typeof<Byte>; typeof<UInt16>
      typeof<UInt32>; typeof<UInt64>; typeof<Decimal>;
      typeof<Single>; typeof<Double>; typeof<String>; ]

let provider = CultureInfo "fr-FR"

for targetType in targetTypes do
    try
        let value = Convert.ChangeType(cool, targetType, provider)
        printfn $"Converted {cool.GetType().Name} {cool} to {targetType.Name} {value}."
    with
    | :? InvalidCastException ->
        printfn $"Unsupported {cool.GetType().Name} --> {targetType.Name} conversion."
    | :? OverflowException ->
        printfn $"{cool} is out of range of the {targetType.Name} type."

// The example dosplays the following output:
//       Converted Temperature 5.00°C to SByte 5.
//       Converted Temperature 5.00°C to Int16 5.
//       Converted Temperature 5.00°C to Int32 5.
//       Converted Temperature 5.00°C to Int64 5.
//       Converted Temperature 5.00°C to Byte 5.
//       Converted Temperature 5.00°C to UInt16 5.
//       Converted Temperature 5.00°C to UInt32 5.
//       Converted Temperature 5.00°C to UInt64 5.
//       Converted Temperature 5.00°C to Decimal 5.
//       Converted Temperature 5.00°C to Single 5.
//       Converted Temperature 5.00°C to Double 5.
//       Converted Temperature 5.00°C to String 5,00°C.
// </Snippet4>