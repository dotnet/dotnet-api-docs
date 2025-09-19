// <snippet1>
open System

/// Class that implements IConvertible
type Complex(x, y) =

    member _.GetDoubleValue() = 
        x ** 2. + y ** 2.
        |> sqrt

    interface IConvertible with
        member _.GetTypeCode() = 
            TypeCode.Object

        member _.ToBoolean(provider: IFormatProvider) =
            (x <> 0.) || (y <> 0.)

        member this.ToByte(provider: IFormatProvider) =
            Convert.ToByte(this.GetDoubleValue())

        member this.ToChar(provider: IFormatProvider) =
            Convert.ToChar(this.GetDoubleValue())

        member this.ToDateTime(provider: IFormatProvider) =
            Convert.ToDateTime(this.GetDoubleValue())

        member this.ToDecimal(provider: IFormatProvider) =
            Convert.ToDecimal(this.GetDoubleValue())

        member this.ToDouble(provider: IFormatProvider) =
            this.GetDoubleValue()

        member this.ToInt16(provider: IFormatProvider) =
            Convert.ToInt16(this.GetDoubleValue())

        member this.ToInt32(provider: IFormatProvider) =
            Convert.ToInt32(this.GetDoubleValue())

        member this.ToInt64(provider: IFormatProvider) =
            Convert.ToInt64(this.GetDoubleValue())

        member this.ToSByte(provider: IFormatProvider) =
            Convert.ToSByte(this.GetDoubleValue())

        member this.ToSingle(provider: IFormatProvider) =
            Convert.ToSingle(this.GetDoubleValue())

        member _.ToString(provider: IFormatProvider) =
            $"( {x} , {y} )"

        member this.ToType(conversionType: Type, provider: IFormatProvider) =
            Convert.ChangeType(this.GetDoubleValue(), conversionType)

        member this.ToUInt16(provider: IFormatProvider) =
            Convert.ToUInt16(this.GetDoubleValue())

        member this.ToUInt32(provider: IFormatProvider) =
            Convert.ToUInt32(this.GetDoubleValue())

        member this.ToUInt64(provider: IFormatProvider) =
            Convert.ToUInt64(this.GetDoubleValue())

// <snippet2>
let writeObjectInfo (testObject: obj) = 
    let typeCode = Type.GetTypeCode(testObject.GetType())
    match typeCode with
    | TypeCode.Boolean ->
        printfn $"Boolean: {testObject}"
    | TypeCode.Double ->
        printfn "Double: {testObject}"
    | _ ->
        printfn $"{typeCode}: {testObject}"
// </snippet2>

let testComplex = Complex(4, 7)

writeObjectInfo testComplex
writeObjectInfo(Convert.ToBoolean(testComplex))
writeObjectInfo(Convert.ToDecimal(testComplex))
writeObjectInfo(Convert.ToString(testComplex))

(*
This code example produces the following results:

Object: ConsoleApplication2.Complex
Boolean: True
Decimal: 8.06225774829855
String: ( 4 , 7 )

*)
// </snippet1>
