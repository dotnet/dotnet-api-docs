//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace IDesignerExample
{	
    // A DesignerAttribute associates the example IDesigner with an example control.
    [DesignerAttribute(typeof(ExampleIDesigner))]
    public class TestControl : UserControl
    {				
        public TestControl()
        {	
        }
    }

    public class ExampleIDesigner : IDesigner
    {
        // Local reference to the designer's component.
        private IComponent _component;
        // Public accessor to the designer's component.
        public IComponent Component => _component;

        public ExampleIDesigner()
        {            
        }

        public void Initialize(IComponent component)
        {
            // This method is called after a designer for a component is created,
            // and stores a reference to the designer's component.
            _component = component;
        }        
        
        // This method peforms the 'default' action for the designer. The default action 
        // for a basic IDesigner implementation is invoked when the designer's component 
        // is double-clicked. By default, a component associated with a basic IDesigner 
        // implementation is displayed in the design-mode component tray.
        public void DoDefaultAction()
        {
            // Shows a message box indicating that the default action for the designer was invoked.
            MessageBox.Show("The DoDefaultAction method of an IDesigner implementation was invoked.", "Information");
        }

        // Returns a collection of designer verb menu items to show in the 
        // shortcut menu for the designer's component.
        public DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection verbs = new();
                DesignerVerb dv1 = new("Display Component Name", ShowComponentName);
                verbs.Add(dv1);
                return verbs;
            }
        }

        // Event handler for displaying a message box showing the designer's component's name.
        private void ShowComponentName(object sender, EventArgs e)
        {
            if (Component != null)
            {
                MessageBox.Show(Component.Site.Name, "Designer Component's Name");
            }
        }

        // Provides an opportunity to release resources before object destruction.
        public void Dispose()
        {        
        }
    }
}
//</Snippet1>
