module remarks

open System

do
    //<Snippet2>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, true) = 0
    //</Snippet2>

    //<Snippet3>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0
    //</Snippet3>

    //<Snippet4>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, true) = 0
    //</Snippet4>

    //<Snippet5>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0
    //</Snippet5>

    //<Snippet6>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, true) = 0
    //</Snippet6>

    //<Snippet7>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0
    //</Snippet7>

    //<Snippet8>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, true) = 0
    //</Snippet8>

    //<Snippet9>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0
    //</Snippet9>

    //<Snippet10>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, true) = 0
    //</Snippet10>

    //<Snippet11>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0
    //</Snippet11>

    //<Snippet12>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, true) = 0
    //</Snippet12>

    //<Snippet13>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0
    //</Snippet13>

    //<Snippet14>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, true) = 0
    //</Snippet14>

    //<Snippet15>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0
    //</Snippet15>

    //<Snippet16>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, true) = 0
    //</Snippet16>

    //<Snippet17>
    let isFileURI path =
        String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0
    //</Snippet17>
    ()