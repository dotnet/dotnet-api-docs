// <snippet3>
using System;

public class IsControlSample {
	public static void Main() {
		string str = "sample string";

		Console.WriteLine(char.IsControl('\t'));	// Output: "True"
		Console.WriteLine(char.IsControl(str, 7));	// Output: "False"
	}
}
// </snippet3>
