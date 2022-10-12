module stringstartswith.fs
//<snippet1>
let rec stripStartTags (item: string) =
    // Determine whether a tag begins the string.
    if item.Trim().StartsWith "<" then
        // Find the closing tag.
        let lastLocation = item.IndexOf ">"
        // Remove the tag.
        let item = 
            if lastLocation >= 0 then
                item.Substring( lastLocation + 1 )
            else 
                item

        // Remove any additional starting tags.
        stripStartTags item
    else
        item

let strSource = 
    [| "<b>This is bold text</b>"; "<H1>This is large Text</H1>"
       "<b><i><font color=green>This has multiple tags</font></i></b>"
       "<b>This has <i>embedded</i> tags.</b>"
       "<This line simply begins with a lesser than symbol, it should not be modified" |]

// Display the initial string array.
printfn "The original strings:"
printfn "---------------------"
for s in strSource do
    printfn $"{s}"
printfn ""

printfn "Strings after starting tags have been stripped:"
printfn "-----------------------------------------------"

// Display the strings with starting tags removed.
for s in strSource do
    printfn $"{stripStartTags s}"

// The example displays the following output:
//    The original strings:
//    ---------------------
//    <b>This is bold text</b>
//    <H1>This is large Text</H1>
//    <b><i><font color = green>This has multiple tags</font></i></b>
//    <b>This has <i>embedded</i> tags.</b>
//    <This line simply begins with a lesser than symbol, it should not be modified
//
//    Strings after starting tags have been stripped:
//    -----------------------------------------------
//    This is bold text</b>
//    This is large Text</H1>
//    This has multiple tags</font></i></b>
//    This has <i>embedded</i> tags.</b>
//    <This line simply begins with a lesser than symbol, it should not be modified
//</snippet1>
