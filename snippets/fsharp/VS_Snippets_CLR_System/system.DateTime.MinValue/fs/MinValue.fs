open System

// <Snippet1>
// Define an uninitialized date.
let date1 = DateTime()
printf $"{date1}"
if date1.Equals DateTime.MinValue then
    printfn $"  (Equals Date.MinValue)"
// The example displays the following output:
//    1/1/0001 12:00:00 AM  (Equals Date.MinValue)
// </Snippet1>

// <Snippet2>
// Attempt to assign an out-of-range value to a DateTime constructor.
let numberOfTicks = Int64.MaxValue

// Validate the value.
if numberOfTicks >= DateTime.MinValue.Ticks &&
   numberOfTicks <= DateTime.MaxValue.Ticks then
    let validDate = DateTime numberOfTicks
    ()
elif numberOfTicks < DateTime.MinValue.Ticks then
    printfn $"{numberOfTicks:N0} is less than {DateTime.MinValue.Ticks:N0} ticks."
else
    printfn $"{numberOfTicks:N0} is greater than {DateTime.MaxValue.Ticks:N0} ticks."
// The example displays the following output:
//   9,223,372,036,854,775,807 is greater than 3,155,378,975,999,999,999 ticks.
// </Snippet2>