module processstartstatic

open System
open System.Diagnostics

// Opens the Internet Explorer application.
let openApplication (myFavoritesPath: string) =
    // Start Internet Explorer. Defaults to the home page.
    Process.Start "IExplore.exe" |> ignore

    // Display the contents of the favorites folder in the browser.
    Process.Start myFavoritesPath |> ignore

// Opens urls and .html documents using Internet Explorer.
let openWithArguments () =
    // url's are not considered documents. They can only be opened
    // by passing them as arguments.
    Process.Start("IExplore.exe", "www.northwindtraders.com") |> ignore

    // Start a Web page using a browser associated with .html and .asp files.
    Process.Start("IExplore.exe", @"C:\myPath\myFile.htm") |> ignore
    Process.Start("IExplore.exe", @"C:\myPath\myFile.asp") |> ignore

// Uses the ProcessStartInfo class to start new processes,
// both in a minimized mode.
let openWithStartInfo () =
    let startInfo = ProcessStartInfo "IExplore.exe"
    startInfo.WindowStyle <- ProcessWindowStyle.Minimized

    Process.Start startInfo |> ignore

    startInfo.Arguments <- "www.northwindtraders.com"

    Process.Start startInfo |> ignore

// Get the path that stores favorite links.
let myFavoritesPath = Environment.GetFolderPath Environment.SpecialFolder.Favorites

openApplication myFavoritesPath
openWithArguments ()
openWithStartInfo ()
