//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

/* This sample demonstrates a designer that adds menu commands
    to the design-time shortcut menu for a component.

    To test this sample, build the code for the component as a class library, 
    add the resulting component to the toolbox, open a form in design mode, 
    and drag the component from the toolbox onto the form. 

    The component should appear in the component tray beneath the form. 
    Right-click the component.  The verbs should appear in the shortcut menu.
*/

namespace CSDesignerVerb
{
    // Associate MyDesigner with this component type using a DesignerAttribute
    [Designer(typeof(MyDesigner))]
    public class Component1 : Component
    {
    }

    // This is a designer class which provides designer verb menu commands for 
    // the associated component. This code is called by the design environment at design-time.
    internal class MyDesigner : ComponentDesigner
    {
        private DesignerVerbCollection _verbs;

        // DesignerVerbCollection is overridden from ComponentDesigner
        public override DesignerVerbCollection Verbs
        {
            get 
            {
                if (_verbs == null)
                {
                    // Create and initialize the collection of verbs.
                    _verbs = new DesignerVerbCollection
                    {
                        new("First Designer Verb", OnFirstItemSelected),
                        new("Second Designer Verb", OnSecondItemSelected)
                    };
                }
                return _verbs;
            }
        }

        MyDesigner() 
        {
        }

        private void OnFirstItemSelected(object sender, EventArgs args) 
        {
            // Display a message.
            MessageBox.Show("The first designer verb was invoked.");
        }

        private void OnSecondItemSelected(object sender, EventArgs args) 
        {
            // Display a message.
            MessageBox.Show("The second designer verb was invoked.");
        }
    }
}
//</Snippet1>