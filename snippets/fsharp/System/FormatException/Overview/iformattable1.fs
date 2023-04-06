module ifromattable1

// <Snippet7>
let price = 169.32m
printfn $"The cost is {price:Q2}."
// The example displays the following output:
//    Unhandled Exception: System.FormatException: Format specifier was invalid.
//       at System.Number.NumberToString(ValueStringBuilder& sb, NumberBuffer& number, Char format, Int32 nMaxDigits, NumberFormatInfo info)
//       at System.Number.TryFormatDecimal(Decimal value, ReadOnlySpan`1 format, NumberFormatInfo info, Span`1 destination, Int32& charsWritten)
//       at System.Decimal.TryFormat(Span`1 destination, Int32& charsWritten, ReadOnlySpan`1 format, IFormatProvider provider)
//       at System.Text.ValueStringBuilder.AppendFormatHelper(IFormatProvider provider, String format, ParamsArray args)
//       at System.String.FormatHelper(IFormatProvider provider, String format, ParamsArray args)
//       at Microsoft.FSharp.Core.PrintfImpl.InterpolandToString@917.Invoke(Object vobj)
//       at Microsoft.FSharp.Core.PrintfImpl.PrintfEnv`3.RunSteps(Object[] args, Type[] argTys, Step[] steps)
//       at Microsoft.FSharp.Core.PrintfModule.gprintf[a,TState,TResidue,TResult,TPrinter](FSharpFunc`2 envf, PrintfFormat`4 format)
//       at <StartupCode$fs>.$Example.main@()
// </Snippet7>