module stringconcat1

// <Snippet1>
open System

// Create two empty test classes.
type Test1() = class end

type Test2() = class end

// Create a group of objects.
let t1 = new Test1()
let t2 = new Test2()
let i = 16
let s = "Demonstration"

// Place the objects in an array.
let o: obj[] = [| t1; i; t2; s |]

// Concatenate the objects together as a string. To do this,
// the ToString method of each of the objects is called.
printfn $"{String.Concat o}"

// The example displays the following output:
//       Test116Test2Demonstration
// </Snippet1>