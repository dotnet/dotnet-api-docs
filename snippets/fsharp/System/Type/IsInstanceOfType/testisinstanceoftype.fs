//<Snippet1>
open System

type IExample = interface end

type BaseClass() = interface IExample

type DerivedClass() = inherit BaseClass()

let interfaceType = typeof<IExample>
let base1 = BaseClass()
let base1Type = base1.GetType()
let derived1 = DerivedClass()
let derived1Type = derived1.GetType()
let arr = Array.zeroCreate<int> 11

printfn $"Is int[] an instance of the Array class? {typeof<Array>.IsInstanceOfType arr}."
printfn $"Is base1 an instance of BaseClass? {base1Type.IsInstanceOfType base1}."
printfn $"Is derived1 an instance of BaseClass? {base1Type.IsInstanceOfType derived1}."
printfn $"Is base1 an instance of IExample? {interfaceType.IsInstanceOfType base1}."
printfn $"Is derived1 an instance of IExample? {interfaceType.IsInstanceOfType derived1}."
// The example displays the following output:
//    Is int[] an instance of the Array class? True.
//    Is base1 an instance of BaseClass? True.
//    Is derived1 an instance of BaseClass? True.
//    Is base1 an instance of IExample? True.
//    Is derived1 an instance of IExample? True.
//</Snippet1>