module qa1

// <Snippet5>
open System

let rnd = Random()
let numbers = Array.zeroCreate<int> 4
let mutable total = 0
for i = 0 to 2 do
    let number = rnd.Next 1001
    numbers[i] <- number
    total <- total + number
numbers[3] <- total
Console.WriteLine("{0} + {1} + {2} = {3}", numbers)

// The example displays the following output:
//    Unhandled Exception:
//    System.FormatException:
//       Index (zero based) must be greater than or equal to zero and less than the size of the argument list.
//       at System.Text.StringBuilder.AppendFormat(IFormatProvider provider, String format, Object[] args)
//       at System.IO.TextWriter.WriteLine(String format, Object arg0)
//       at System.IO.TextWriter.SyncTextWriter.WriteLine(String format, Object arg0)
//       at <StartupCode$fs>.$Example.main@()
// </Snippet5>