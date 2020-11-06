using System;

namespace Split
{
    class Count
    {
        public static void ThreeArgs()
        {
            //<snippet1>
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();

            string[] subs = name.Split(null, 2);

            string firstName = subs[0];
            string lastName;
            if (subs.Length > 1)
            {
                lastName = subs[1];
            }

            // If the user enters "Alex Johnson III":
            // firstName = "Alex", lastName = "Johnson III"
            //</snippet1>
        }
    }
}
