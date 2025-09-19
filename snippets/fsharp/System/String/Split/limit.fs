module limit

//<snippet1>
let name = "Alex Johnson III"

let subs = name.Split(null, 2)

let firstName = subs[0]
let lastName =
    if subs.Length > 1 then
        subs[1]
    else
        ""

// firstName = "Alex"
// lastName = "Johnson III"
//</snippet1>