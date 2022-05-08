open System

let sampleToString () =
    //<snippet7>
    // Create a new Uri from a string address.
    let uriAddress = Uri "HTTP://www.Contoso.com:80/thick%20and%20thin.htm"

    // Write the new Uri to the console and note the difference in the two values.
    // ToString() gives the canonical version.  OriginalString gives the orginal
    // string that was passed to the constructor.

    // The following outputs "http://www.contoso.com/thick and thin.htm".
    printfn $"{uriAddress.ToString()}"

    // The following outputs "HTTP://www.Contoso.com:80/thick%20and%20thin.htm".
    printfn $"{uriAddress.OriginalString}"
    //</snippet7>

let sampleEquals () =
    //<snippet8>
    // Create some Uris.
    let address1 = Uri "http://www.contoso.com/index.htm#search"
    let address2 = Uri "http://www.contoso.com/index.htm"
    if address1.Equals address2 then
        printfn "The two addresses are equal"
    else
        printfn "The two addresses are not equal"
    // Will output "The two addresses are equal"
    //</snippet8>

let getParts () =
    //<snippet4>
    // Create Uri
    let uriAddress = Uri "http://www.contoso.com/index.htm#search"
    printfn $"{uriAddress.Fragment}"
    printfn $"""Uri {if uriAddress.IsDefaultPort then "uses" else "does not use"} the default port """

    printfn $"The path of this Uri is {uriAddress.GetLeftPart UriPartial.Path}"
    printfn $"Hash code {uriAddress.GetHashCode()}"
    // The example displays output similar to the following:
    //        #search
    //        Uri uses the default port
    //        The path of this Uri is http://www.contoso.com/index.htm
    //        Hash code -988419291
    //</snippet4>
    //<snippet5>
    let uriAddress1 = Uri "http://www.contoso.com/title/index.htm"
    printfn $"The parts are {uriAddress1.Segments[0]}, {uriAddress1.Segments[1]}, {uriAddress1.Segments[2]}"
    //</snippet5>

    //<snippet6>
    let uriAddress2 = Uri "file://server/filename.ext"
    printfn $"{uriAddress2.LocalPath}"
    printfn $"""Uri {if uriAddress2.IsUnc then "is" else "is not"} a UNC path"""
    printfn $"""Uri {if uriAddress2.IsLoopback then "is" else "is not"} a local host"""
    printfn $"""Uri {if uriAddress2.IsFile then "is" else "is not"} a file"""
    // The example displays the following output:
    //    \\server\filename.ext
    //    Uri is a UNC path
    //    Uri is not a local host
    //    Uri is a file
    //</snippet6>

let hexConversions () =
    //<snippet1>
    let testChar = 'e'
    if Uri.IsHexDigit testChar then
        printfn $"'{testChar}' is the hexadecimal representation of {Uri.FromHex testChar}"
    else
        printfn $"'{testChar}' is not a hexadecimal character"

    let returnString = Uri.HexEscape testChar
    printfn $"The hexadecimal value of '{testChar}' is {returnString}"
    //</snippet1>

    //<snippet2>
    let testString = "%75"
    let mutable index = 0
    if Uri.IsHexEncoding(testString, index) then
        printfn $"The character is {Uri.HexUnescape(testString, &index)}"
    else
        printfn "The character is not hexadecimal encoded"
    //</snippet2>

// MakeRelative
let sampleMakeRelative () =
    //<snippet3>
    // Create a base Uri.
    let address1 = Uri "http://www.contoso.com/"

    // Create a new Uri from a string.
    let address2 = Uri "http://www.contoso.com/index.htm?date=today"

    // Determine the relative Uri.
    printfn $"The difference is {address1.MakeRelativeUri address2}"
    //</snippet3>

//CheckSchemeName
let sampleCheckSchemeName () =
    //<snippet9>
    let address1 = Uri "http://www.contoso.com/index.htm#search"
    printfn $"""address 1 {if Uri.CheckSchemeName address1.Scheme then " has" else " does not have"} a valid scheme name"""

    if address1.Scheme = Uri.UriSchemeHttp then
        printfn "Uri is HTTP type"

    printfn $"{address1.HostNameType}"
    //</snippet9>

    //<snippet10>
    let address2 = Uri "file://server/filename.ext"
    if address2.Scheme = Uri.UriSchemeFile then
        printfn "Uri is a file"
    //</snippet10>

    printfn $"{address2.HostNameType}"

    //<snippet11>
    let address3 = Uri "mailto:user@contoso.com?subject=uri"
    if address3.Scheme = Uri.UriSchemeMailto then
        printfn $"Uri is an email address"
    //</snippet11>

    //<snippet12>
    let address4 = Uri "news:123456@contoso.com"
    if address4.Scheme = Uri.UriSchemeNews then
        printfn $"Uri is an Internet news group"
    //</snippet12>

    //<snippet13>
    let address5 = Uri "nntp://news.contoso.com/123456@contoso.com"
    if address5.Scheme = Uri.UriSchemeNntp then
        printfn "Uri is nntp protocol"
    //</snippet13>

    //<snippet14>
    let address6 = Uri "gopher://example.contoso.com/"
    if address6.Scheme = Uri.UriSchemeGopher then
        printfn "Uri is Gopher protocol"
    //</snippet14>

    //<snippet15>
    let address7 = Uri "ftp://contoso/files/testfile.txt"
    if address7.Scheme = Uri.UriSchemeFtp then
        printfn "Uri is Ftp protocol"
    //</snippet15>

    //<snippet16>
    let address8 = Uri "https://example.contoso.com"
    if address8.Scheme = Uri.UriSchemeHttps then
        printfn "Uri is Https protocol."
    //</snippet16>

    //<snippet17>
    let address = "www.contoso.com"
    let uriString = $"{Uri.UriSchemeHttp}{Uri.SchemeDelimiter}{address}/"
#if OLDMETHOD
    match Uri.TryParse(uriString, false, false) with
    | true, result ->
        printfn $"{result} is a valid Uri"
    | _ ->
        printfn "Uri not created"
#endif
    let result = Uri uriString
    if result.IsWellFormedOriginalString() then
        printfn $"{uriString} is a well formed Uri"
    else
        printfn $"{uriString} is not a well formed Uri"
    //</snippet17>

let sampleUserInfo () =
    //<snippet18>
    let uriAddress = Uri "http://user:password@www.contoso.com/index.htm "
    printfn $"{uriAddress.UserInfo}"
    printfn $"""Fully Escaped {if uriAddress.UserEscaped then "yes" else "no"}"""
//</snippet18>

let unescapeUriWithPlusConversion () =
    //<snippet19>
    let DataString = Uri.UnescapeDataString ".NET+Framework"
    printfn $"Unescaped string: {DataString}"

    let PlusString = DataString.Replace('+',' ')
    printfn $"plus to space string: {PlusString}"
//</snippet19>

// Snippets 1 and 2
hexConversions ()

// snippet 7
sampleToString ()

// snippet 8
sampleEquals ()

// snippets 4, 5, and 6
getParts ()

// snippet 3
sampleMakeRelative ()

// snippets 9 - 17
sampleCheckSchemeName ()

// snippet 18
sampleUserInfo ()

// snippet 19
unescapeUriWithPlusConversion ()
