module stringendswith

//<snippet1>
let rec stripEndTags item =
    let mutable item: string = item
    let mutable found = false

    // try to find a tag at the end of the line using EndsWith
    if item.Trim().EndsWith ">" then
        // now search for the opening tag...
        let lastLocation = item.LastIndexOf "</"

        // remove the identified section, if it is a valid region
        if lastLocation >= 0 then
            found <- true
            item <- item.Substring(0, lastLocation)

    if found then
        stripEndTags item
    else 
        item

// process an input file that contains html tags.
// this sample checks for multiple tags at the end of the line, rather than simply
// removing the last one.
// note: HTML markup tags always end in a greater than symbol (>).

let strSource = 
    [| "<b>This is bold text</b>"; "<H1>This is large Text</H1>"
       "<b><i><font color=green>This has multiple tags</font></i></b>"
       "<b>This has <i>embedded</i> tags.</b>"
       "This line simply ends with a greater than symbol, it should not be modified>" |]

printfn "The following lists the items before the ends have been stripped:"
printfn "-----------------------------------------------------------------"

// print out the initial array of strings
for s in strSource do
    printfn $"{s}"

printfn "\nThe following lists the items after the ends have been stripped:"
printfn "----------------------------------------------------------------"

// print out the array of strings
for s in strSource do
    printfn $"{stripEndTags s}"

// The example displays the following output:
//    The following lists the items before the ends have been stripped:
//    -----------------------------------------------------------------
//    <b>This is bold text</b>
//    <H1>This is large Text</H1>
//    <b><i><font color=green>This has multiple tags</font></i></b>
//    <b>This has <i>embedded</i> tags.</b>
//    This line simply ends with a greater than symbol, it should not be modified>
//
//    The following lists the items after the ends have been stripped:
//    ----------------------------------------------------------------
//    <b>This is bold text
//    <H1>This is large Text
//    <b><i><font color=green>This has multiple tags
//    <b>This has <i>embedded</i> tags.
//    This line simply ends with a greater than symbol, it should not be modified>
//</snippet1>