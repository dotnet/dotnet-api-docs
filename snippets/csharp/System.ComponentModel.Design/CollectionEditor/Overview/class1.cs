using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace EditorExamples
{
    public class Class1 : Component
    {
        // System.ComponentModel.Design.CollectionEditor Editor example.
        //<Snippet1>
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ICollection testCollection { get; set; }
        //</Snippet1>

        // FontEditor Editor example.
        //<Snippet2>
        [Editor(typeof(FontEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font testFont { get; set; }
        //</Snippet2>

        // ImageEditor Editor example.
        //<Snippet3>
        [Editor(typeof(ImageEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image testImage { get; set; }
        //</Snippet3>

        // System.Windows.Forms.Design.AnchorEditor Editor example.
        //<Snippet4>
        [Editor(typeof(System.Windows.Forms.Design.AnchorEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public AnchorStyles testAnchor { get; set; }
        //</Snippet4>

        // System.Windows.Forms.Design.FileNameEditor Editor example.
        //<Snippet5>
        [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(UITypeEditor))]
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
