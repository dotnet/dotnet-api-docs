using System;

namespace Split
{
    class Basic
    {
        public static void Basic1()
        {
            //<snippet1>
            string s = "Today\tI'm going to school";
            string[] subs = s.Split(' ', '\t');

            foreach (var sub in subs)
            {
                Console.WriteLine($"Substring: {sub}");
            }

            // This example produces the following output:
            //
            // Substring: Today
            // Substring: I'm
            // Substring: going
            // Substring: to
            // Substring: school
            //</snippet1>
        }
    }
}
