using System.ComponentModel.Design;

namespace ActiveDesignerEventArgsExample
{
    class Class1
    {
        //<Snippet1>
        public ActiveDesignerEventArgs CreateActiveDesignerEventArgs(IDesignerHost losingFocus, IDesignerHost gainingFocus)
        {
            ActiveDesignerEventArgs e = new ActiveDesignerEventArgs(losingFocus, gainingFocus);
            return e;
        }
        //</Snippet1>
    }
}
