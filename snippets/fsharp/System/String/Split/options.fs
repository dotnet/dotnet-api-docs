open System
do
    //<snippet1>
    // This example demonstrates the String.Split() methods that use
    // the StringSplitOptions enumeration.

    // Display the array of separated strings using a local function
    let show  (entries: string[]) =
        printfn $"The return value contains these {entries.Length} elements:"
        for entry in entries do
            printf $"<{entry}>"
        printf "\n\n"

    // Example 1: Split a string delimited by characters
    printfn "1) Split a string delimited by characters:\n"

    let s1 = ",ONE,, TWO,, , THREE,,"
    let charSeparators = [| ',' |]

    printfn $"The original string is: \"{s1}\"."
    printfn $"The delimiter character is: '{charSeparators[0]}'.\n"

    // Split the string and return all elements
    printfn "1a) Return all elements:"
    let result = s1.Split(charSeparators, StringSplitOptions.None)
    show result

    // Split the string and return all elements with whitespace trimmed
    printfn "1b) Return all elements with whitespace trimmed:"
    let result = s1.Split(charSeparators, StringSplitOptions.TrimEntries)
    show result

    // Split the string and return all non-empty elements
    printfn "1c) Return all non-empty elements:"
    let result = s1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
    show result

    // Split the string and return all non-whitespace elements with whitespace trimmed
    printfn "1d) Return all non-whitespace elements with whitespace trimmed:"
    let result = s1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
    show result


    // Split the string into only two elements, keeping the remainder in the last match
    printfn "1e) Split into only two elements:"
    let result = s1.Split(charSeparators, 2, StringSplitOptions.None)
    show result

    // Split the string into only two elements with whitespace trimmed, keeping the remainder in the last match
    printfn "1f) Split into only two elements with whitespace trimmed:"
    let result = s1.Split(charSeparators, 2, StringSplitOptions.TrimEntries)
    show result

    // Split the string into only two non-empty elements, keeping the remainder in the last match
    printfn "1g) Split into only two non-empty elements:"
    let result = s1.Split(charSeparators, 2, StringSplitOptions.RemoveEmptyEntries)
    show result

    // Split the string into only two non-whitespace elements with whitespace trimmed, keeping the remainder in the last match
    printfn "1h) Split into only two non-whitespace elements with whitespace trimmed:"
    let result = s1.Split(charSeparators, 2, StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
    show result


    // Example 2: Split a string delimited by another string
    printfn "2) Split a string delimited by another string:\n"

    let s2 = "[stop]" +
                "ONE[stop] [stop]" +
                "TWO  [stop][stop]  [stop]" +
                "THREE[stop][stop]  "
    let stringSeparators = [| "[stop]" |]

    printfn $"The original string is: \"{s2}\"."
    printfn $"The delimiter string is: \"{stringSeparators[0]}\".\n"

    // Split the string and return all elements
    printfn "2a) Return all elements:"
    let result = s2.Split(stringSeparators, StringSplitOptions.None)
    show result

    // Split the string and return all elements with whitespace trimmed
    printfn "2b) Return all elements with whitespace trimmed:"
    let result = s2.Split(stringSeparators, StringSplitOptions.TrimEntries)
    show result

    // Split the string and return all non-empty elements
    printfn "2c) Return all non-empty elements:"
    let result = s2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries)
    show result

    // Split the string and return all non-whitespace elements with whitespace trimmed
    printfn "2d) Return all non-whitespace elements with whitespace trimmed:"
    let result = s2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
    show result


    // Split the string into only two elements, keeping the remainder in the last match
    printfn "2e) Split into only two elements:"
    let result = s2.Split(stringSeparators, 2, StringSplitOptions.None)
    show result

    // Split the string into only two elements with whitespace trimmed, keeping the remainder in the last match
    printfn "2f) Split into only two elements with whitespace trimmed:"
    let result = s2.Split(stringSeparators, 2, StringSplitOptions.TrimEntries)
    show result

    // Split the string into only two non-empty elements, keeping the remainder in the last match
    printfn "2g) Split into only two non-empty elements:"
    let result = s2.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries)
    show result

    // Split the string into only two non-whitespace elements with whitespace trimmed, keeping the remainder in the last match
    printfn "2h) Split into only two non-whitespace elements with whitespace trimmed:"
    let result = s2.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
    show result

    (*
    This example produces the following results:

    1) Split a string delimited by characters:

    The original string is: ",ONE,, TWO,, , THREE,,".
    The delimiter character is: ','.

    1a) Return all elements:
    The return value contains these 9 elements:
    <><ONE><>< TWO><>< >< THREE><><>

    1b) Return all elements with whitespace trimmed:
    The return value contains these 9 elements:
    <><ONE><><TWO><><><THREE><><>

    1c) Return all non-empty elements:
    The return value contains these 4 elements:
    <ONE>< TWO>< >< THREE>

    1d) Return all non-whitespace elements with whitespace trimmed:
    The return value contains these 3 elements:
    <ONE><TWO><THREE>

    1e) Split into only two elements:
    The return value contains these 2 elements:
    <><ONE,, TWO,, , THREE,,>

    1f) Split into only two elements with whitespace trimmed:
    The return value contains these 2 elements:
    <><ONE,, TWO,, , THREE,,>

    1g) Split into only two non-empty elements:
    The return value contains these 2 elements:
    <ONE>< TWO,, , THREE,,>

    1h) Split into only two non-whitespace elements with whitespace trimmed:
    The return value contains these 2 elements:
    <ONE><TWO,, , THREE,,>

    2) Split a string delimited by another string:

    The original string is: "[stop]ONE[stop] [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]  ".
    The delimiter string is: "[stop]".

    2a) Return all elements:
    The return value contains these 9 elements:
    <><ONE>< ><TWO  ><><  ><THREE><><  >

    2b) Return all elements with whitespace trimmed:
    The return value contains these 9 elements:
    <><ONE><><TWO><><><THREE><><>

    2c) Return all non-empty elements:
    The return value contains these 6 elements:
    <ONE>< ><TWO  ><  ><THREE><  >

    2d) Return all non-whitespace elements with whitespace trimmed:
    The return value contains these 3 elements:
    <ONE><TWO><THREE>

    2e) Split into only two elements:
    The return value contains these 2 elements:
    <><ONE[stop] [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]  >

    2f) Split into only two elements with whitespace trimmed:
    The return value contains these 2 elements:
    <><ONE[stop] [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]>

    2g) Split into only two non-empty elements:
    The return value contains these 2 elements:
    <ONE>< [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]  >

    2h) Split into only two non-whitespace elements with whitespace trimmed:
    The return value contains these 2 elements:
    <ONE><TWO  [stop][stop]  [stop]THREE[stop][stop]>

    *)
    //</snippet1>

do
    // <Snippet2>
    let source = "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]"
    let stringSeparators = [| "[stop]" |]

    // Display the original string and delimiter string.
    printfn $"Splitting the string:\n   \"{source}\".\n"
    printfn $"Using the delimiter string:\n   \"{stringSeparators[0]}\"\n"

    // Split a string delimited by another string and return all elements.
    let result = source.Split(stringSeparators, StringSplitOptions.None)
    printfn $"Result including all elements ({result.Length} elements):"
    printf "   "
    for s in result do
        printf $"""'{if String.IsNullOrEmpty s then "<>" else s}' """
    printfn "\n"

    // Split delimited by another string and return all non-empty elements.
    let result = source.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries)
    Console.WriteLine($"Result including non-empty elements ({result.Length} elements):")
    printf "   "
    for s in result do
        printf $"""'{if String.IsNullOrEmpty s then "<>" else s}' """
    printfn ""

    // The example displays the following output:
    //    Splitting the string:
    //       "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]".
    //
    //    Using the delimiter string:
    //       "[stop]"
    //
    //    let result including all elements (9 elements):
    //       '<>' 'ONE' '<>' 'TWO' '<>' '<>' 'THREE' '<>' '<>'
    //
    //    let result including non-empty elements (3 elements):
    //       'ONE' 'TWO' 'THREE'
    // </Snippet2>

do
    // <Snippet3>
    let separators = [| ","; "."; "!"; "?"; ""; ":"; " " |]
    let value = "The handsome, energetic, young dog was playing with his smaller, more lethargic litter mate."
    let words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries)
    for word in words do
        printfn $"${word}"

    // The example displays the following output:
    //       The
    //       handsome
    //       energetic
    //       young
    //       dog
    //       was
    //       playing
    //       with
    //       his
    //       smaller
    //       more
    //       lethargic
    //       litter
    //       mate
    // </Snippet3>
