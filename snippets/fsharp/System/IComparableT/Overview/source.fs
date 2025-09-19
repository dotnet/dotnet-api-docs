//<snippet1>
open System
open System.Collections.Generic

type Temperature(kelvins: double) =
    // The underlying temperature value.
    let mutable kelvins = kelvins

    do 
        if kelvins < 0. then
            invalidArg (nameof kelvins) "Temperature cannot be less than absolute zero."

    // Define the is greater than operator.
    static member op_GreaterThan (operand1: Temperature, operand2: Temperature) =
        operand1.CompareTo operand2 > 0

    // Define the is less than operator.
    static member op_LessThan (operand1: Temperature, operand2: Temperature) =
        operand1.CompareTo operand2 < 0

    // Define the is greater than or equal to operator.
    static member op_GreaterThanOrEqual (operand1: Temperature, operand2: Temperature) =
        operand1.CompareTo operand2 >= 0

    // Define the is less than or equal to operator.
    static member op_LessThanOrEqual (operand1: Temperature, operand2: Temperature) =
        operand1.CompareTo operand2 <= 0

    member _.Celsius =
        kelvins - 273.15

    member _.Kelvin
        with get () =
            kelvins
        and set (value) =
            if value < 0. then
                invalidArg (nameof value) "Temperature cannot be less than absolute zero."
            else
                kelvins <- value

    // Implement the generic CompareTo method with the Temperature
    // class as the Type parameter.
    member _.CompareTo(other: Temperature) =
        // If other is not a valid object reference, this instance is greater.
        match box other with
        | null -> 1
        | _ ->
            // The temperature comparison depends on the comparison of
            // the underlying Double values.
            kelvins.CompareTo(other.Kelvin)

    interface IComparable<Temperature> with
        member this.CompareTo(other) = this.CompareTo other

let temps = SortedList()

// Add entries to the sorted list, out of order.
temps.Add(Temperature 2017.15, "Boiling point of Lead")
temps.Add(Temperature 0., "Absolute zero")
temps.Add(Temperature 273.15, "Freezing point of water")
temps.Add(Temperature 5100.15, "Boiling point of Carbon")
temps.Add(Temperature 373.15, "Boiling point of water")
temps.Add(Temperature 600.65, "Melting point of Lead")

for kvp in temps do
    printfn $"{kvp.Value} is {kvp.Key.Celsius} degrees Celsius."

//  This example displays the following output:
//       Absolute zero is -273.15 degrees Celsius.
//       Freezing point of water is 0 degrees Celsius.
//       Boiling point of water is 100 degrees Celsius.
//       Melting point of Lead is 327.5 degrees Celsius.
//       Boiling point of Lead is 1744 degrees Celsius.
//       Boiling point of Carbon is 4827 degrees Celsius.
//</snippet1>