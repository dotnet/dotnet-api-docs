// <snippet10>
namespace DSMSample
{
    // <snippet11>
    public class SampleObject
    {
        public string StringProperty { get; set; }

        public int IntProperty { get; set; } = int.MinValue;

        public SampleObject Child { get; set; }
    }
    // </snippet11>

    // <snippet12>
    class Program
    {
        // <snippet13>
        static void Main()
        {
            // <snippet14>
            SampleObject root = new();

            SampleObject currentObject = root;

            for (int i = 0; i < 10; i++)
            {
                SampleObject o = new();

                currentObject.Child = o;

                currentObject = o;
            }
            // </snippet14>
        }
        // </snippet13>
    }
    // </snippet12>
}
// </snippet10>
