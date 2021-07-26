// <snippet8>
using System;

public class IsNumberSample {
	public static void Main() {
		string str = "non-numeric";

		Console.WriteLine(char.IsNumber('8'));		// Output: "True"
		Console.WriteLine(char.IsNumber(str, 3));	// Output: "False"
	}
}
// </snippet8>
