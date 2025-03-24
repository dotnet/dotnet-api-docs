//<Snippet1>
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.Design;

namespace TypeCategoryTabExample
{
    // This component adds a TypeCategoryTab to the property browser 
    // that is available for any components in the current design mode document.
    [PropertyTabAttribute(typeof(TypeCategoryTab), PropertyTabScope.Document)]
    public class TypeCategoryTabComponent : System.ComponentModel.Component
    {           
        public TypeCategoryTabComponent()
        {
        }
    }

    // A TypeCategoryTab property tab lists properties by the 
    // category of the type of each property.
    public class TypeCategoryTab : PropertyTab
    {
        public TypeCategoryTab()
        {            
        }

        //<Snippet2>
        // Returns the properties of the specified component extended with 
        // a CategoryAttribute reflecting the name of the type of the property.
        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(object component, System.Attribute[] attributes)
        {
            PropertyDescriptorCollection props;
            if( attributes == null )
                props = TypeDescriptor.GetProperties(component);    
            else
                props = TypeDescriptor.GetProperties(component, attributes);    
            
            PropertyDescriptor[] propArray = new PropertyDescriptor[props.Count];            
            for(int i=0; i<props.Count; i++)           
            {                
                // Create a new PropertyDescriptor from the old one, with 
                // a CategoryAttribute matching the name of the type.
                propArray[i] = TypeDescriptor.CreateProperty(props[i].ComponentType, props[i], new CategoryAttribute(props[i].PropertyType.Name));
            }
            return new PropertyDescriptorCollection( propArray );
        }

        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(object component)
        {                     
            return this.GetProperties(component, null);
        }
        //</Snippet2>

        // Provides the name for the property tab.
        public override string TabName
        {
            get
            {
                return "Properties by Type";
            }
        }

        // Provides an image for the property tab.
        public override System.Drawing.Bitmap Bitmap
        {
            get
            {
                Bitmap bmp = new Bitmap(@"myproperty.bmp", true);
                return bmp;
            }
        }
    }
}
//</Snippet1>
