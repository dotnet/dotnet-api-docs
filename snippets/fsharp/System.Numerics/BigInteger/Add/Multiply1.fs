open System;
open System.Numerics;


let multiply () =
    // <Snippet1>
    let number = BigInteger.Multiply(Int64.MaxValue, 3);
    // </Snippet1>
    ()

let add () =
    // <Snippet2>
    let number = BigInteger.Add(Int64.MaxValue, Int32.MaxValue);
    // </Snippet2>
    ()

let subtract () =
    // <Snippet3>
    let number = BigInteger.Subtract(Int64.MinValue, Int64.MaxValue);
    // </Snippet3>
    ()

let negate () =
    // <Snippet4>
    let number = BigInteger.Negate Int64.MinValue
    // </Snippet4>
    ()

multiply();
add();
subtract();
negate();