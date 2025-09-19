module Provider

// <Snippet2>
open System
open System.Globalization

type AcctNumberFormat() =
    let [<Literal>] ACCT_LENGTH = 12

    interface IFormatProvider with
        member this.GetFormat(formatType: Type) =
            if formatType = typeof<ICustomFormatter> then
                this
            else
                null

    interface ICustomFormatter with
        member this.Format(fmt: string, arg: obj, formatProvider: IFormatProvider) =
            // Provide default formatting if arg is not an Int64.
            // Provide default formatting for unsupported format strings.
            let ufmt = fmt.ToUpper CultureInfo.InvariantCulture
            if arg.GetType() = typeof<Int64> && (ufmt = "H" || ufmt = "I") then
                // Convert argument to a string.
                let result = string arg

                let result =
                    // If account number is less than 12 characters, pad with leading zeroes.
                    if result.Length < ACCT_LENGTH then
                        result.PadLeft(ACCT_LENGTH, '0')
                    else result
                
                let result =
                    // If account number is more than 12 characters, truncate to 12 characters.
                    if result.Length > ACCT_LENGTH then
                        result.Substring(0, ACCT_LENGTH)
                    else result

                // Integer-only format.
                if ufmt = "I" then 
                    result
                // Add hyphens for H format specifier.
                else // Hyphenated format.
                    result.Substring(0, 5) + "-" + result.Substring(5, 3) + "-" + result.Substring(8)
            else
                try
                    this.HandleOtherFormats(fmt, arg)
                with :? FormatException as e ->
                    raise (FormatException($"The format of '{fmt}' is invalid.", e))
            
    member _.HandleOtherFormats(format: string, arg: obj) =
        match arg with
        | :? IFormattable as arg ->
            arg.ToString(format, CultureInfo.CurrentCulture)
        | null -> 
            string arg
        | _ -> 
            String.Empty
// </Snippet2>


// <Snippet1>
open System
open System.Globalization

type DaysOfWeek = Monday = 1 | Tuesday = 2

[<EntryPoint>]
let main _ =
    let acctNumber = 104254567890L
    let balance = 16.34
    let wday = DaysOfWeek.Monday

    let output = 
        String.Format(AcctNumberFormat(), 
                      "On {2}, the balance of account {0:H} was {1:C2}.", 
                      acctNumber, balance, wday)
    printfn $"{output}"

    let wday = DaysOfWeek.Tuesday
    let output = 
        String.Format(AcctNumberFormat(),
                      "On {2}, the balance of account {0:I} was {1:C2}.",
                      acctNumber, balance, wday)
    printfn $"{output}"
    0

// The example displays the following output:
//       On Monday, the balance of account 10425-456-7890 was $16.34.
//       On Tuesday, the balance of account 104254567890 was $16.34.
// </Snippet1>

