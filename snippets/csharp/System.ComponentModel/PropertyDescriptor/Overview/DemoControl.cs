// <snippet100>
using System.ComponentModel;
using System.Windows.Forms;

namespace ReadOnlyPropertyDescriptorTest
{
    [Designer(typeof(DemoControlDesigner))]
    public class DemoControl : Control
    {
        public DemoControl()
        {
        }
    }
}
// </snippet100>
