//<snippet1>
using System.ComponentModel;

namespace EditorBrowsableDemo
{
    public class Class1
    {
        public Class1() { }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Age
        {
            get; set;
        }

        public int Height
        {
            get; set;
        }
    }
}
//</snippet1>
