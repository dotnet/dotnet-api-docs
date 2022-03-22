module Chain2

type Page() =
    [<DefaultValue>]
    val mutable public URL: System.Uri
    [<DefaultValue>]
    val mutable public Title: string

type Pages() =
    let pages = Array.zeroCreate<Page> 10
    let mutable i = 0

    member _.CurrentPage
        with get () = pages[i]
        and set (value) =
            // Move all the page objects down to accommodate the new one.
            if i > pages.GetUpperBound 0 then
                for ndx = 1 to pages.GetUpperBound 0 do
                    pages[ndx - 1] <- pages[ndx]

            pages[i] <- value
            if i < pages.GetUpperBound 0 then
                i <- i + 1

    member _.PreviousPage =
        if i = 0 then
            if box pages[0] = null then
                Unchecked.defaultof<Page>
            else
                pages[0]
        else
            i <- i - 1
            pages[i + 1]

// <Snippet7>
let pages = Pages()
let current = pages.CurrentPage
if box current <> null then
    let title = current.Title
    printfn $"Current title: '{title}'"
else
    printfn "There is no page information in the cache."
// The example displays the following output:
//       There is no page information in the cache.
// </Snippet7>

