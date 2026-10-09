using System.ComponentModel.Composition;

namespace ClassLibrary1
{
    //<snippet2>
    [Export]
    public class Test1
    {
        public string data { get; } = "The data!";
    }
    //</snippet2>
}
