module startnew3
// <Snippet3>
open System
open System.Threading.Tasks

let main =
    task {
        let tasks = ResizeArray()
        let rnd = Random()
        let lockObj = obj ()

        let words6 =
            [ "reason"
              "editor"
              "rioter"
              "rental"
              "senior"
              "regain"
              "ordain"
              "rained" ]

        for word6 in words6 do
            let t =
                new Task(
                    (fun word ->
                        let chars = (string word).ToCharArray()
                        let order = Array.zeroCreate<double> chars.Length

                        lock lockObj (fun () ->
                            for i = 0 to order.Length - 1 do
                                order[i] <- rnd.NextDouble())

                        Array.Sort(order, chars)
                        printfn $"{word} --> {new String(chars)}"),
                    word6
                )

            t.Start()
            tasks.Add t

        do! tasks.ToArray() |> Task.WhenAll
    }

main.Wait()

// The example displays output like the following:
//    regain --> irnaeg
//    ordain --> rioadn
//    reason --> soearn
//    rained --> rinade
//    rioter --> itrore
//    senior --> norise
//    rental --> atnerl
//    editor --> oteird
// </Snippet3>
