// <Snippet1>
type TestClass() = class end

let testClassInstance = TestClass()
// Get the type of myTestClassInstance.
let testType = testClassInstance.GetType()
// Get the IsPublic property of testClassInstance.
let isPublic = testType.IsPublic
printfn $"Is {testType.FullName} public? {isPublic}"
// The example displays the following output:
//        Is TestClass public? True
// </Snippet1>