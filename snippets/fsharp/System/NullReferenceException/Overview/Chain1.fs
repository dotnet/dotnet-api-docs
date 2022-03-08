module Chain1

// <Snippet6>
open System

type Page() =
    [<DefaultValue>]
    val mutable public URL: Uri
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

let pages = Pages()
if String.IsNullOrEmpty pages.CurrentPage.Title |> not then
    let title = pages.CurrentPage.Title
    printfn $"Current title: '{title}'"


// The example displays the following output:
//    Unhandled Exception:
//       System.NullReferenceException: Object reference not set to an instance of an object.
//       at <StartupCode$fs>.main()
// </Snippet6>