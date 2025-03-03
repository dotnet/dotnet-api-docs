// <snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ExpandableObjectDemo;

public partial class DemoControl : UserControl
{
    Container components;

    public DemoControl() => InitializeComponent();

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    // <snippet2>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Demo")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BorderAppearance Border { get; set; } = new();
    // </snippet2>

    void InitializeComponent()
    {
        components = new Container();
        AutoScaleMode = AutoScaleMode.Font;
    }
}

// <snippet3>
[TypeConverter(typeof(BorderAppearanceConverter))]
public class BorderAppearance
{
    int borderSizeValue = 1;
    Color borderColorValue = Color.Empty;

    [Browsable(true),
    NotifyParentProperty(true),
    EditorBrowsable(EditorBrowsableState.Always),
    DefaultValue(1)]
    public int BorderSize
    {
        get => borderSizeValue;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "BorderSize",
                    value,
                    "must be >= 0");
            }

            if (borderSizeValue != value)
            {
                borderSizeValue = value;
            }
        }
    }

    [Browsable(true)]
    [NotifyParentProperty(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(typeof(Color), "")]
    public Color BorderColor
    {
        get => borderColorValue;
        set
        {
            if (value.Equals(Color.Transparent))
            {
                throw new NotSupportedException("Transparent colors are not supported.");
            }

            if (borderColorValue != value)
            {
                borderColorValue = value;
            }
        }
    }
}
// </snippet3>

// <snippet4>
public class BorderAppearanceConverter : ExpandableObjectConverter
{
    // This override prevents the PropertyGrid from 
    // displaying the full type name in the value cell.
    public override object ConvertTo(
        ITypeDescriptorContext context,
        CultureInfo culture,
        object value,
        Type destinationType) => destinationType == typeof(string)
            ? ""
            : base.ConvertTo(
            context,
            culture,
            value,
            destinationType);
}
// </snippet4>
// </snippet1>
