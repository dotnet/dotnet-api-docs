// <snippet12>
using System;

public class IsSymbolSample {
	public static void Main() {
		string str = "non-symbolic characters";

		Console.WriteLine(char.IsSymbol('+'));		// Output: "True"
		Console.WriteLine(char.IsSymbol(str, 8));	// Output: "False"
	}
}
// </snippet12>
