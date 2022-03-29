module lastindexof_example2.fs
// <Snippet2>
let strSource = 
    [| "<b>This is bold text</b>"; "<H1>This is large Text</H1>"
       "<b><i><font color=green>This has multiple tags</font></i></b>"
       "<b>This has <i>embedded</i> tags.</b>"
       "This line ends with a greater than symbol and should not be modified>" |]

// Strip HTML start and end tags from each string if they are present.
for s in strSource do
    printfn $"Before: {s}"
    let mutable item = s
    // Use EndsWith to find a tag at the end of the line.
    if item.Trim().EndsWith ">" then
        // Locate the opening tag.
        let endTagStartPosition = item.LastIndexOf "</"
        // Remove the identified section, if it is valid.
        if endTagStartPosition >= 0 then
            item <- item.Substring(0, endTagStartPosition)

        // Use StartsWith to find the opening tag.
        if item.Trim().StartsWith "<" then
            // Locate the end of opening tab.
            let openTagEndPosition = item.IndexOf ">"
            // Remove the identified section, if it is valid.
            if openTagEndPosition >= 0 then
                item <- item.Substring(openTagEndPosition + 1)
    // Display the trimmed string.
    printfn "After: {item}"
    printfn ""
// The example displays the following output:
//    Before: <b>This is bold text</b>
//    After: This is bold text
//
//    Before: <H1>This is large Text</H1>
//    After: This is large Text
//
//    Before: <b><i><font color=green>This has multiple tags</font></i></b>
//    After: <i><font color=green>This has multiple tags</font></i>
//
//    Before: <b>This has <i>embedded</i> tags.</b>
//    After: This has <i>embedded</i> tags.
//
//    Before: This line ends with a greater than symbol and should not be modified>
//    After: This line ends with a greater than symbol and should not be modified>
// </Snippet2>
