//<Snippet1>
open System
open System.Collections

// Define the types of averaging available in the class
// implementing IConvertible.
type AverageType =
    | None = 0s
    | GeometricMean = 1s
    | ArithmeticMean = 2s
    | Median = 3s

// Pass an instance of this class to methods that require an
// IFormatProvider. The class instance determines the type of
// average to calculate.
[<AllowNullLiteral>]
type AverageInfo(avgType: AverageType) =
    // Use this property to set or get the type of averaging.
    member val TypeOfAverage = avgType with get, set 
    
    interface IFormatProvider with
        // This method returns a reference to the containing object
        // if an object of AverageInfo type is requested.
        member this.GetFormat(argType: Type) =
            if argType = typeof<AverageInfo> then
                this
            else
                null

// This class encapsulates an array of double values and implements
// the IConvertible interface. Most of the IConvertible methods
// an average of the array elements in one of three types:
// arithmetic mean, geometric mean, or median.
type DataSet([<ParamArray>] values: double[]) =
    let data = ResizeArray values
    let defaultProvider =
        AverageInfo AverageType.ArithmeticMean

    // Add additional values with this method.
    member _.Add(value: double) =
        data.Add value
        data.Count

    // Get, set, and add values with this indexer property.
    member _.Item
        with get (index) =
            if index >= 0 && index < data.Count then
                data[index]
            else
                raise (InvalidOperationException "[DataSet.get] Index out of range.")
        and set index value =
            if index >= 0 && index < data.Count then
                data[index] <- value
            elif index = data.Count then
                data.Add value
            else
                raise (InvalidOperationException "[DataSet.set] Index out of range.")

    // This property returns the number of elements in the object.
    member _.Count =
        data.Count

    // This method calculates the average of the object's elements.
    member _.Average(avgType: AverageType) =
        if data.Count = 0 then
            0.0
        else
            match avgType with
            | AverageType.GeometricMean ->
                let sumProd =
                    Seq.reduce ( * ) data
                
                // This calculation will not fail with negative
                // elements.
                (sign sumProd |> float) * Math.Pow(abs sumProd, 1.0 / (float data.Count))

            | AverageType.ArithmeticMean ->
                Seq.average data

            | AverageType.Median ->
                if data.Count % 2 = 0 then
                    (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2.0
                else
                    data[ data.Count / 2]
            | _ ->
                0.0

    // Get the AverageInfo object from the caller's format provider,
    // or use the local default.
    member _.GetAverageInfo(provider: IFormatProvider) =
        let avgInfo =
            if provider <> null then
                provider.GetFormat typeof<AverageInfo> :?> AverageInfo
            else 
                null

        if avgInfo = null then
            defaultProvider
        else
            avgInfo

    // Calculate the average and limit the range.
    member this.CalcNLimitAverage(min: double, max: double, provider: IFormatProvider) =
        // Get the format provider and calculate the average.
        let avgInfo = this.GetAverageInfo provider
        let avg = this.Average avgInfo.TypeOfAverage

        // Limit the range, based on the minimum and maximum values
        // for the type.
        if avg > max then max elif avg < min then min else avg

    // The following elements are required by IConvertible.
    interface IConvertible with
        // None of these conversion functions throw exceptions. When
        // the data is out of range for the type, the appropriate
        // MinValue or MaxValue is used.
        member _.GetTypeCode() =
            TypeCode.Object

        member this.ToBoolean(provider: IFormatProvider) =
            // ToBoolean is false if the dataset is empty.
            if data.Count <= 0 then
                false

            // For median averaging, ToBoolean is true if any
            // non-discarded elements are nonzero.
            elif AverageType.Median = this.GetAverageInfo(provider).TypeOfAverage then
                if data.Count % 2 = 0 then
                    (data[data.Count / 2] <> 0.0 || data[data.Count / 2 - 1] <> 0.0)
                else
                    data[data.Count / 2] <> 0.0

            // For arithmetic or geometric mean averaging, ToBoolean is
            // true if any element of the dataset is nonzero.
            else
                Seq.exists (fun x -> x <> 0.0) data

        member this.ToByte(provider: IFormatProvider) =
            Convert.ToByte(this.CalcNLimitAverage(float Byte.MinValue, float Byte.MaxValue, provider) )

        member this.ToChar(provider: IFormatProvider) =
            Convert.ToChar(Convert.ToUInt16(this.CalcNLimitAverage(float Char.MinValue, float Char.MaxValue, provider) ) )

        // Convert to DateTime by adding the calculated average as
        // seconds to the current date and time. A valid DateTime is
        // always returned.
        member this.ToDateTime(provider: IFormatProvider) =
            let seconds = this.Average(this.GetAverageInfo(provider).TypeOfAverage)
            try
                DateTime.Now.AddSeconds seconds
            with :? ArgumentOutOfRangeException ->
                if seconds < 0.0 then DateTime.MinValue else DateTime.MaxValue

        member this.ToDecimal(provider: IFormatProvider) =
            // The Double conversion rounds Decimal.MinValue and
            // Decimal.MaxValue to invalid Decimal values, so the
            // following limits must be used.
            Convert.ToDecimal(this.CalcNLimitAverage(-79228162514264330000000000000.0, 79228162514264330000000000000.0, provider) )

        member this.ToDouble(provider: IFormatProvider) =
            this.Average(this.GetAverageInfo(provider).TypeOfAverage)

        member this.ToInt16(provider: IFormatProvider) =
            Convert.ToInt16(this.CalcNLimitAverage(float Int16.MinValue, float Int16.MaxValue, provider) )

        member this.ToInt32(provider: IFormatProvider) =
            Convert.ToInt32(this.CalcNLimitAverage(Int32.MinValue, Int32.MaxValue, provider) )

        member this.ToInt64(provider: IFormatProvider) =
            // The Double conversion rounds Int64.MinValue and
            // Int64.MaxValue to invalid Int64 values, so the following
            // limits must be used.
            Convert.ToInt64(this.CalcNLimitAverage(-9223372036854775000., 9223372036854775000., provider) )

        member this.ToSByte(provider: IFormatProvider) =
            Convert.ToSByte(this.CalcNLimitAverage(float SByte.MinValue, float SByte.MaxValue, provider) )

        member this.ToSingle(provider: IFormatProvider) =
            Convert.ToSingle(this.CalcNLimitAverage(float Single.MinValue, float Single.MaxValue, provider) )

        member this.ToUInt16(provider: IFormatProvider) =
            Convert.ToUInt16(this.CalcNLimitAverage(float UInt16.MinValue, float UInt16.MaxValue, provider) )

        member this.ToUInt32(provider: IFormatProvider) =
            Convert.ToUInt32(this.CalcNLimitAverage(float UInt32.MinValue, float UInt32.MaxValue, provider) )

        member this.ToUInt64(provider: IFormatProvider) =
            // The Double conversion rounds UInt64.MaxValue to an invalid
            // UInt64 value, so the following limit must be used.
            Convert.ToUInt64(this.CalcNLimitAverage(0, 18446744073709550000.0, provider) )

        member this.ToType(conversionType: Type, provider: IFormatProvider) =
            Convert.ChangeType(this.Average(this.GetAverageInfo(provider).TypeOfAverage), conversionType)

        member this.ToString(provider: IFormatProvider) =
            let avgType = this.GetAverageInfo(provider).TypeOfAverage
            $"( {avgType}: {this.Average avgType:G10} )"                

// Display a DataSet with three different format providers.
let displayDataSet (ds: DataSet) =
    let fmt obj1 obj2 obj3 obj4 = printfn $"{obj1,-12}{obj2,20}{obj3,20}{obj4,20}"
    let median = AverageInfo AverageType.Median
    let geMean =
        AverageInfo AverageType.GeometricMean

    // Display the dataset elements.
    if ds.Count > 0 then
        printf $"\nDataSet: [{ds[0]}"
        for i = 1 to ds.Count - 1 do
            printf $", {ds[i]}"
        printfn "]\n"

    fmt "Convert." "Default" "Geometric Mean" "Median"
    fmt "--------" "-------" "--------------" "------"
    fmt "ToBoolean"
        (Convert.ToBoolean(ds, null))
        (Convert.ToBoolean(ds, geMean))
        (Convert.ToBoolean(ds, median))
    fmt "ToByte"
        (Convert.ToByte(ds, null))
        (Convert.ToByte(ds, geMean))
        (Convert.ToByte(ds, median))
    fmt "ToChar"
        (Convert.ToChar(ds, null))
        (Convert.ToChar(ds, geMean))
        (Convert.ToChar(ds, median))
    printfn $"""{"ToDateTime",-12}{Convert.ToDateTime(ds, null).ToString "20:yyyy-MM-dd HH:mm:ss"}{Convert.ToDateTime(ds, geMean).ToString "20:yyyy-MM-dd HH:mm:ss"}{Convert.ToDateTime(ds, median).ToString "20:yyyy-MM-dd HH:mm:ss"}"""

    fmt "ToDecimal"
        (Convert.ToDecimal(ds, null))
        (Convert.ToDecimal(ds, geMean))
        (Convert.ToDecimal(ds, median))
    fmt "ToDouble"
        (Convert.ToDouble(ds, null))
        (Convert.ToDouble(ds, geMean))
        (Convert.ToDouble(ds, median))
    fmt "ToInt16"
        (Convert.ToInt16(ds, null))
        (Convert.ToInt16(ds, geMean))
        (Convert.ToInt16(ds, median))
    fmt "ToInt32"
        (Convert.ToInt32(ds, null))
        (Convert.ToInt32(ds, geMean))
        (Convert.ToInt32(ds, median))
    fmt "ToInt64"
        (Convert.ToInt64(ds, null))
        (Convert.ToInt64(ds, geMean))
        (Convert.ToInt64(ds, median))
    fmt "ToSByte"
        (Convert.ToSByte(ds, null))
        (Convert.ToSByte(ds, geMean))
        (Convert.ToSByte(ds, median))
    fmt "ToSingle"
        (Convert.ToSingle(ds, null))
        (Convert.ToSingle(ds, geMean))
        (Convert.ToSingle(ds, median))
    fmt "ToUInt16"
        (Convert.ToUInt16(ds, null))
        (Convert.ToUInt16(ds, geMean))
        (Convert.ToUInt16(ds, median))
    fmt "ToUInt32"
        (Convert.ToUInt32(ds, null))
        (Convert.ToUInt32(ds, geMean))
        (Convert.ToUInt32(ds, median))
    fmt "ToUInt64"
        (Convert.ToUInt64(ds, null))
        (Convert.ToUInt64(ds, geMean))
        (Convert.ToUInt64(ds, median))

printfn
    """This example of the Convert.To<Type>( object, IFormatprovider) methods 
generates the following output. The example displays the values 
returned by the methods, using several IFormatProvider objects.
"""

let ds1 = DataSet(10.5, 22.2, 45.9, 88.7, 156.05, 297.6)
displayDataSet ds1

let ds2 = DataSet(359999.95, 425000, 499999.5, 775000, 1695000)
displayDataSet ds2

// This example of the Convert.To<Type>( object, IFormatprovider) methods
// generates the following output. The example displays the values
// returned by the methods, using several IFormatProvider objects.
//
// DataSet: [10.5, 22.2, 45.9, 88.7, 156.05, 297.6]
//
// Convert.                 Default      Geometric Mean              Median
// --------                 -------      --------------              ------
// ToBoolean                   True                True                True
// ToByte                       103                  59                  67
// ToChar                         g                   ;                   C
// ToDateTime   2003-05-13 15:04:12 2003-05-13 15:03:28 2003-05-13 15:03:35
// ToDecimal       103.491666666667    59.4332135445164                67.3
// ToDouble        103.491666666667    59.4332135445164                67.3
// ToInt16                      103                  59                  67
// ToInt32                      103                  59                  67
// ToInt64                      103                  59                  67
// ToSByte                      103                  59                  67
// ToSingle                103.4917            59.43321                67.3
// ToUInt16                     103                  59                  67
// ToUInt32                     103                  59                  67
// ToUInt64                     103                  59                  67
//
// DataSet: [359999.95, 425000, 499999.5, 775000, 1695000]
//
// Convert.                 Default      Geometric Mean              Median
// --------                 -------      --------------              ------
// ToBoolean                   True                True                True
// ToByte                       255                 255                 255
// ToChar                         ?                   ?                   ?
// ToDateTime   2003-05-22 07:39:08 2003-05-20 22:28:45 2003-05-19 09:55:48
// ToDecimal              750999.89    631577.237188435            499999.5
// ToDouble               750999.89    631577.237188435            499999.5
// ToInt16                    32767               32767               32767
// ToInt32                   751000              631577              500000
// ToInt64                   751000              631577              500000
// ToSByte                      127                 127                 127
// ToSingle                750999.9            631577.3            499999.5
// ToUInt16                   65535               65535               65535
// ToUInt32                  751000              631577              500000
// ToUInt64                  751000              631577              500000
//</Snippet1>