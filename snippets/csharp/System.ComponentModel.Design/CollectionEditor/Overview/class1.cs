using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace EditorAttributeExamples
{
    public class Class1 : System.ComponentModel.Component
    {
        // System.ComponentModel.Design.CollectionEditor EditorAttribute example.
        //<Snippet1>
        [EditorAttribute(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ICollection testCollection { get; set; }
        //</Snippet1>

        // System.Drawing.Design.FontEditor EditorAttribute example.
        //<Snippet2>
        [EditorAttribute(typeof(System.Drawing.Design.FontEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font testFont { get; set; }
        //</Snippet2>

        // System.Drawing.Design.ImageEditor EditorAttribute example.
        //<Snippet3>
        [EditorAttribute(typeof(System.Drawing.Design.ImageEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image testImage { get; set; }
        //</Snippet3>

        // System.Windows.Forms.Design.AnchorEditor EditorAttribute example.
        //<Snippet4>
        [EditorAttribute(typeof(System.Windows.Forms.Design.AnchorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public System.Windows.Forms.AnchorStyles testAnchor { get; set; }
        //</Snippet4>

        // System.Windows.Forms.Design.FileNameEditor EditorAttribute example.
        //<Snippet5>
        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string testFilename { get; set; }
        //</Snippet5>

        public Class1()
        {
            // Initialize collections for design-mode editor testing.
            testCollection = new int[] { 0, 2, 4, 6, 8, 12, 14 };
            testFont = new("Arial", 8);
            testAnchor = AnchorStyles.None;
            testFilename = string.Empty;
        }
    }
}
