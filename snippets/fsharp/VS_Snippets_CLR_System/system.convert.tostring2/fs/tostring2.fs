open System

let convertByte () =
//<snippet9>
    let bases = [2; 8; 10; 16]
    let numbers = [ Byte.MinValue; 12uy; 103uy; Byte.MaxValue ]

    for baseValue in bases do
        printfn "Base %i conversion:" baseValue
        for number in numbers do
            printfn "   % -5i  -->  0x%s" number (Convert.ToString (number, baseValue))
    // The example displays the following output:
    //     Base 2 conversion:
    //         0     -->  0x0
    //         12    -->  0x1100
    //         103   -->  0x1100111
    //         255   -->  0x11111111
    //     Base 8 conversion:
    //         0     -->  0x0
    //         12    -->  0x14
    //         103   -->  0x147
    //         255   -->  0x377
    //     Base 10 conversion:
    //         0     -->  0x0
    //         12    -->  0x12
    //         103   -->  0x103
    //         255   -->  0x255
    //     Base 16 conversion:
    //         0     -->  0x0
    //         12    -->  0xc
    //         103   -->  0x67
    //         255   -->  0xff
//</snippet9>

let convertShort () =
//<snippet10>
    let bases = [2; 8; 10; 16]
    let numbers = [ Int16.MinValue; -13621s; -18s; 12s; 19142s; Int16.MaxValue ]

    for baseValue in bases do
        printfn "Base %i conversion:" baseValue
        for number in numbers do
            printfn "   % -8i  -->  0x%s" number (Convert.ToString (number, baseValue))
    // The example displays the following output:
    //     Base 2 conversion:
    //        -32768    -->  0x1000000000000000
    //        -13621    -->  0x1100101011001011
    //        -18       -->  0x1111111111101110
    //         12       -->  0x1100
    //         19142    -->  0x100101011000110
    //         32767    -->  0x111111111111111
    //     Base 8 conversion:
    //        -32768    -->  0x100000
    //        -13621    -->  0x145313
    //        -18       -->  0x177756
    //         12       -->  0x14
    //         19142    -->  0x45306
    //         32767    -->  0x77777
    //     Base 10 conversion:
    //        -32768    -->  0x-32768
    //        -13621    -->  0x-13621
    //        -18       -->  0x-18
    //         12       -->  0x12
    //         19142    -->  0x19142
    //         32767    -->  0x32767
    //     Base 16 conversion:
    //        -32768    -->  0x8000
    //        -13621    -->  0xcacb
    //        -18       -->  0xffee
    //         12       -->  0xc
    //         19142    -->  0x4ac6
    //         32767    -->  0x7fff
//</snippet10>

let convertInt () =
//<snippet11>
    let bases = [2; 8; 10; 16]
    let numbers = [ Int32.MinValue; -19327543; -13621; -18; 12; 19142; Int32.MaxValue ]

    for baseValue in bases do
        printfn "Base %i conversion:" baseValue
        for number in numbers do
            printfn "   % -15i  -->  0x%s" number (Convert.ToString (number, baseValue))
    // The example displays the following output:
    //     Base 2 conversion:
    //        -2147483648      -->  0x10000000000000000000000000000000
    //        -19327543        -->  0x11111110110110010001010111001001
    //        -13621           -->  0x11111111111111111100101011001011
    //        -18              -->  0x11111111111111111111111111101110
    //         12              -->  0x1100
    //         19142           -->  0x100101011000110
    //         2147483647      -->  0x1111111111111111111111111111111
    //     Base 8 conversion:
    //        -2147483648      -->  0x20000000000
    //        -19327543        -->  0x37666212711
    //        -13621           -->  0x37777745313
    //        -18              -->  0x37777777756
    //         12              -->  0x14
    //         19142           -->  0x45306
    //         2147483647      -->  0x17777777777
    //     Base 10 conversion:
    //        -2147483648      -->  0x-2147483648
    //        -19327543        -->  0x-19327543
    //        -13621           -->  0x-13621
    //        -18              -->  0x-18
    //         12              -->  0x12
    //         19142           -->  0x19142
    //         2147483647      -->  0x2147483647
    //     Base 16 conversion:
    //        -2147483648      -->  0x80000000
    //        -19327543        -->  0xfed915c9
    //        -13621           -->  0xffffcacb
    //        -18              -->  0xffffffee
    //         12              -->  0xc
    //         19142           -->  0x4ac6
    //         2147483647      -->  0x7fffffff
//</snippet11>

let convertLong () =
//<snippet12>
    let bases = [2; 8; 10; 16]
    let numbers = [ Int64.MinValue; -193275430L; -13621L; -18L; 12L; 1914206117L; Int64.MaxValue ]

    for baseValue in bases do
        printfn "Base %i conversion:" baseValue
        for number in numbers do
            printfn "   % -23i  -->  0x%s" number (Convert.ToString (number, baseValue))
    // The example displays the following output:
    //     Base 2 conversion:
    //        -9223372036854775808     -->  0x1000000000000000000000000000000000000000000000000000000000000000
    //        -193275430               -->  0x1111111111111111111111111111111111110100011110101101100111011010
    //        -13621                   -->  0x1111111111111111111111111111111111111111111111111100101011001011
    //        -18                      -->  0x1111111111111111111111111111111111111111111111111111111111101110
    //         12                      -->  0x1100
    //         1914206117              -->  0x1110010000110000111011110100101
    //         9223372036854775807     -->  0x111111111111111111111111111111111111111111111111111111111111111
    //     Base 8 conversion:
    //        -9223372036854775808     -->  0x1000000000000000000000
    //        -193275430               -->  0x1777777777776436554732
    //        -13621                   -->  0x1777777777777777745313
    //        -18                      -->  0x1777777777777777777756
    //         12                      -->  0x14
    //         1914206117              -->  0x16206073645
    //         9223372036854775807     -->  0x777777777777777777777
    //     Base 10 conversion:
    //        -9223372036854775808     -->  0x-9223372036854775808
    //        -193275430               -->  0x-193275430
    //        -13621                   -->  0x-13621
    //        -18                      -->  0x-18
    //         12                      -->  0x12
    //         1914206117              -->  0x1914206117
    //         9223372036854775807     -->  0x9223372036854775807
    //     Base 16 conversion:
    //        -9223372036854775808     -->  0x8000000000000000
    //        -193275430               -->  0xfffffffff47ad9da
    //        -13621                   -->  0xffffffffffffcacb
    //        -18                      -->  0xffffffffffffffee
    //         12                      -->  0xc
    //         1914206117              -->  0x721877a5
    //         9223372036854775807     -->  0x7fffffffffffffff
//</snippet12>


[<EntryPoint>]
let main argv = 
    convertByte ()
    printfn "-----"
    convertShort ()
    printfn "-----"
    convertInt ()
    printfn "-----"
    convertLong ()
    0
