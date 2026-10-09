// <Snippet3>
using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] planets = { "Mercury", "Venus",
                "Earth", "Mars", "Jupiter",
                "Saturn", "Uranus", "Neptune" };

            Console.WriteLine($"One or more planets begin with 'M': {Array.Exists(planets, element => element.StartsWith("M"))}");

            Console.WriteLine($"One or more planets begin with 'T': {Array.Exists(planets, element => element.StartsWith("T"))}");

            Console.WriteLine($"Is Pluto one of the planets? {Array.Exists(planets, element => element == "Pluto")}");
        }
    }
}
// The example displays the following output:
//       One or more planets begin with 'M': True
//       One or more planets begin with 'T': False
//       Is Pluto one of the planets? False
// </Snippet3>
