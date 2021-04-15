#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			// <snippet1>
			UriBuilder baseUri = new UriBuilder("http://www.contoso.com/default.aspx?Param1=7890");
			string queryToAppend = "param2=1234";

			if (baseUri.Query != null && baseUri.Query.Length > 1)
			    // Note: In .NET Core and .NET 5+, you can simplify by removing
				// the call to Substring(), which removes the leading "?" character.
				baseUri.Query = baseUri.Query.Substring(1) + "&" + queryToAppend; 
			else
				baseUri.Query = queryToAppend; 
			// </snippet1>
		}
	}
}
