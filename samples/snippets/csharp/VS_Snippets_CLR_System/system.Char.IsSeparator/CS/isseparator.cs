// <snippet10>
using System;

public class IsSeparatorSample {
	public static void Main() {
		string str = "twain1 twain2";

		Console.WriteLine(char.IsSeparator('a'));		// Output: "False"
		Console.WriteLine(char.IsSeparator(str, 6));	// Output: "True"
	}
}
// </snippet10>
