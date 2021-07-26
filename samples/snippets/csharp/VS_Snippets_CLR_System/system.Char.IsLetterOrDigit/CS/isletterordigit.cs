// <snippet6>
using System;

public class IsLetterOrDigitSample {
	public static void Main() {
		string str = "newline:\n";

		Console.WriteLine(char.IsLetterOrDigit('8'));		// Output: "True"
		Console.WriteLine(char.IsLetterOrDigit(str, 8));	// Output: "False", because it's a newline
	}
}
// </snippet6>
