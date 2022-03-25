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
    
    let s1 = ",ONE,,TWO,,,THREE,,"
    let s2 = "[stop]" +
             "ONE[stop][stop]" +
             "TWO[stop][stop][stop]" +
             "THREE[stop][stop]"
    let charSeparators = [| ',' |]
    let stringSeparators = [| "[stop]" |]
    // ------------------------------------------------------------------------------
    // Split a string delimited by characters.
    // ------------------------------------------------------------------------------
    printfn "1) Split a string delimited by characters:\n"

    // Display the original string and delimiter characters.
    printfn $"1a) The original string is \"{s1}\"."
    printfn $"The delimiter character is '{charSeparators[0]}'.\n"

    // Split a string delimited by characters and return all elements.
    printfn "1b) Split a string delimited by characters and return all elements:"
    let result = s1.Split(charSeparators, StringSplitOptions.None)
    show result

    // Split a string delimited by characters and return all non-empty elements.
    printfn "1c) Split a string delimited by characters and return all non-empty elements:"
    let result = s1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
    show result

    // Split the original string into the string and empty string before the
    // delimiter and the remainder of the original string after the delimiter.
    printfn "1d) Split a string delimited by characters and return 2 elements:"
    let result = s1.Split(charSeparators, 2, StringSplitOptions.None)
    show result

    // Split the original string into the string after the delimiter and the
    // remainder of the original string after the delimiter.
    printfn "1e) Split a string delimited by characters and return 2 non-empty elements:"
    let result = s1.Split(charSeparators, 2, StringSplitOptions.RemoveEmptyEntries)
    show result

    // ------------------------------------------------------------------------------
    // Split a string delimited by another string.
    // ------------------------------------------------------------------------------
    printfn "2) Split a string delimited by another string:\n"

    // Display the original string and delimiter string.
    printfn $"2a) The original string is \"{s2}\"."
    printfn $"The delimiter string is \"{stringSeparators[0]}\".\n"

    // Split a string delimited by another string and return all elements.
    printfn "2b) Split a string delimited by another string and return all elements:"
    let result = s2.Split(stringSeparators, StringSplitOptions.None)
    show result

    // Split the original string at the delimiter and return all non-empty elements.
    printfn "2c) Split a string delimited by another string and return all non-empty elements:"
    let result = s2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries)
    show result

    // Split the original string into the empty string before the
    // delimiter and the remainder of the original string after the delimiter.
    printfn "2d) Split a string delimited by another string and return 2 elements:"
    let result = s2.Split(stringSeparators, 2, StringSplitOptions.None)
    show result

    // Split the original string into the string after the delimiter and the
    // remainder of the original string after the delimiter.
    printfn "2e) Split a string delimited by another string and return 2 non-empty elements:"
    let result = s2.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries)
    show result

    (*
    This example produces the following results:

    1) Split a string delimited by characters:

    1a) The original string is ",ONE,,TWO,,,THREE,,".
    The delimiter character is ','.

    1b) Split a string delimited by characters and return all elements:
    The return value contains these 9 elements:
    <><ONE><><TWO><><><THREE><><>

    1c) Split a string delimited by characters and return all non-empty elements:
    The return value contains these 3 elements:
    <ONE><TWO><THREE>

    1d) Split a string delimited by characters and return 2 elements:
    The return value contains these 2 elements:
    <><ONE,,TWO,,,THREE,,>

    1e) Split a string delimited by characters and return 2 non-empty elements:
    The return value contains these 2 elements:
    <ONE><TWO,,,THREE,,>

    2) Split a string delimited by another string:

    2a) The original string is "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]".
    The delimiter string is "[stop]".

    2b) Split a string delimited by another string and return all elements:
    The return value contains these 9 elements:
    <><ONE><><TWO><><><THREE><><>

    2c) Split a string delimited by another string and return all non-empty elements:
    The return value contains these 3 elements:
    <ONE><TWO><THREE>

    2d) Split a string delimited by another string and return 2 elements:
    The return value contains these 2 elements:
    <><ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]>

    2e) Split a string delimited by another string and return 2 non-empty elements:
    The return value contains these 2 elements:
    <ONE><TWO[stop][stop][stop]THREE[stop][stop]>

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