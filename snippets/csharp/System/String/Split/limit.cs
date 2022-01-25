using System;

namespace Split
{
    class Limit
    {
        public static void ThreeArgs()
        {
            //<snippet1>
            string name = "Alex Johnson III";

            string[] subs = name.Split(null, 2);

            string firstName = subs[0];
            string lastName;
            if (subs.Length > 1)
            {
                lastName = subs[1];
            }

            // firstName = "Alex"
            // lastName = "Johnson III"
            //</snippet1>
        }
    }
}
