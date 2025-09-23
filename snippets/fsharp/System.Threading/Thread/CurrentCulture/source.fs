// <Snippet1>
open System.Threading
open System.Windows.Forms

type UICulture() =
    inherit Form()

    do
        // Set the user interface to display in the
        // same culture as that set in Control Panel.
        Thread.CurrentThread.CurrentUICulture <- Thread.CurrentThread.CurrentCulture

// Add additional code.

new UICulture() |> Application.Run
// </Snippet1>
