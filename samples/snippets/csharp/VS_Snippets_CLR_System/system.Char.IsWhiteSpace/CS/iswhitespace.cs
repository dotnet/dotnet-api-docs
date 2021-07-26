// <snippet14>
using System;

public class IsWhiteSpaceSample {
	public static void Main() {
		string str = "black matter";

		Console.WriteLine(char.IsWhiteSpace('A'));		// Output: "False"
		Console.WriteLine(char.IsWhiteSpace(str, 5));	// Output: "True"
	}
}
// </snippet14>
