module nclurienhancements

open System

let sampleConstructor () =
    //<snippet2>
    // Create an absolute Uri from a string.
    let absoluteUri = Uri "http://www.contoso.com/"

    // Create a relative Uri from a string.  allowRelative = true to allow for
    // creating a relative Uri.
    let relativeUri = Uri("/catalog/shownew.htm?date=today", UriKind.Relative)

    // Check whether the new Uri is absolute or relative.
    if not relativeUri.IsAbsoluteUri then
        printfn $"{relativeUri} is a relative Uri."

    // Create a new Uri from an absolute Uri and a relative Uri.
    let combinedUri = Uri(absoluteUri, relativeUri)
    printfn $"{combinedUri.AbsoluteUri}"
    //</snippet2>

// OriginalString
let sampleOriginalString () =
    //<snippet3>
    // Create a new Uri from a string address.
    let uriAddress = Uri "HTTP://www.ConToso.com:80//thick%20and%20thin.htm"

    // Write the new Uri to the console and note the difference in the two values.
    // ToString() gives the canonical version. OriginalString gives the original
    // string that was passed to the constructor.

    // The following outputs "http://www.contoso.com//thick and thin.htm".
    printfn $"{uriAddress.ToString()}"

    // The following outputs "HTTP://www.ConToso.com:80//thick%20and%20thin.htm".
    printfn $"{uriAddress.OriginalString}"
    //</snippet3>

// DNSSafeHost
let sampleDNSSafeHost () =
    //<snippet4>
    // Create new Uri using a string address.
    let address = Uri "http://[fe80::200:39ff:fe36:1a2d%254]/temp/example.htm"

    // Make the address DNS safe.

    // The following outputs "[fe80::200:39ff:fe36:1a2d]".
    printfn $"{address.Host}"

    // The following outputs "fe80::200:39ff:fe36:1a2d%254".
    printfn $"{address.DnsSafeHost}"
    //</snippet4>

// operator = and <>
let sampleOperatorEqual () =
    //<snippet5>
    // Create some Uris.
    let address1 = Uri "http://www.contoso.com/index.htm#search"
    let address2 = Uri "http://www.contoso.com/index.htm"
    let address3 = Uri "http://www.contoso.com/index.htm?date=today"

    // The first two are equal because the fragment is ignored.
    if address1 = address2 then
        printfn $"{address1} is equal to {address2}"

    // The second two are not equal.
    if address2 <> address3 then
        printfn $"{address2} is not equal to {address3}"
    //</snippet5>

// IsBaseOf
let sampleIsBaseOf () =
    //<snippet6>
    // Create a base Uri.
    let baseUri = Uri "http://www.contoso.com/"

    // Create a new Uri from a string.
    let uriAddress = Uri "http://www.contoso.com/index.htm?date=today"

    // Determine whether BaseUri is a base of UriAddress.
    if baseUri.IsBaseOf uriAddress then
        printfn $"{baseUri} is the base of {uriAddress}"
    //</snippet6>

// Constructor
sampleConstructor ()

// OriginalString
sampleOriginalString ()

// DNSSafeHost
sampleDNSSafeHost ()

// operator = and <>
sampleOperatorEqual ()

// IsBaseOf
sampleIsBaseOf ()