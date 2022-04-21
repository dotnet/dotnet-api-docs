module remarks

// <Snippet1>
let t = typeof<ResizeArray<string>>.GetMethod("ConvertAll").GetGenericArguments().[0].DeclaringType
// </Snippet1>
