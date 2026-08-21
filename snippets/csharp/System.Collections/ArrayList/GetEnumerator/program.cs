// <Snippet1>
using System;
using System.Collections;

ArrayList colors =
[
"red",
            "blue",
            "green",
            "yellow",
            "beige",
            "brown",
            "magenta",
            "purple",
        ];

IEnumerator e = colors.GetEnumerator();
while (e.MoveNext())
{
    object obj = e.Current;
    Console.WriteLine(obj);
}

Console.WriteLine();

IEnumerator e2 = colors.GetEnumerator(2, 4);
while (e2.MoveNext())
{
    object obj = e2.Current;
    Console.WriteLine(obj);
}

/* This code example produces
   the following ouput:
    red
    blue
    green
    yellow
    beige
    brown
    magenta
    purple

    green
    yellow
    beige
    brown
 */
// </Snippet1>
