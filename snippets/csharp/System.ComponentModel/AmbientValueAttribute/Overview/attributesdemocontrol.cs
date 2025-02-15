// <snippet1>
// <snippet2>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Globzn = System.Globalization;
// </snippet2>

// This sample demonstrates the use of various attributes for
// authoring a control. 
namespace AttributesDemoControlLibrary;

// This is the event handler delegate for the ThresholdExceeded event.
public delegate void ThresholdExceededEventHandler(ThresholdExceededEventArgs e);

// <snippet3>
// <snippet20>
// This control demonstrates a simple logging capability. 
[ComplexBindingProperties("DataSource", "DataMember")]
[DefaultBindingProperty("TitleText")]
[DefaultEvent("ThresholdExceeded")]
[DefaultProperty("Threshold")]
[HelpKeyword(typeof(UserControl))]
[ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design")]
public class AttributesDemoControl : UserControl
{
    // </snippet20>

    // The default fore color value for DataGridView cells that
    // contain values that exceed the threshold.
    static readonly Color defaultAlertForeColorValue = Color.White;

    // The default back color value for DataGridView cells that
    // contain values that exceed the threshold.
    static readonly Color defaultAlertBackColorValue = Color.Red;

    // The ambient color value.
    static readonly Color ambientColorValue = Color.Empty;

    // The fore color value for DataGridView cells that
    // contain values that exceed the threshold.
    Color alertForeColorValue = defaultAlertForeColorValue;

    // The back color value for DataGridView cells that
    // contain values that exceed the threshold.
    Color alertBackColorValue = defaultAlertBackColorValue;

    // Child controls that comprise this UserControl.
    TableLayoutPanel tableLayoutPanel1;
    DataGridView dataGridView1;
    Label label1;

    // Required for designer support.
    readonly IContainer _components;

    // Default constructor.
    public AttributesDemoControl() => InitializeComponent();

    // <snippet21>
    [Category("Appearance")]
    [Description("The title of the log data.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Localizable(true)]
    [HelpKeyword("AttributesDemoControlLibrary.AttributesDemoControl.TitleText")]
    public string TitleText
    {
        get => label1.Text;

        set => label1.Text = value;
    }
    // </snippet21>

    // <snippet22>
    // The inherited Text property is hidden at design time and 
    // raises an exception at run time. This enforces a requirement
    // that client code uses the TitleText property instead.
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }
    // </snippet22>

    // <snippet23>
    [AmbientValue(typeof(Color), "Empty")]
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "White")]
    [Description("The color used for painting alert text.")]
    public Color AlertForeColor
    {
        get =>
            alertForeColorValue == Color.Empty &&
            Parent != null
                ? Parent.ForeColor
                : alertForeColorValue;

        set => alertForeColorValue = value;
    }

    // This method is used by designers to enable resetting the
    // property to its default value.
    public void ResetAlertForeColor() => AlertForeColor = defaultAlertForeColorValue;

    // This method indicates to designers whether the property
    // value is different from the ambient value, in which case
    // the designer should persist the value.
    bool ShouldSerializeAlertForeColor() =>
        alertForeColorValue != ambientColorValue;
    // </snippet23>

    // <snippet24>
    [AmbientValue(typeof(Color), "Empty")]
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Red")]
    [Description("The background color for painting alert text.")]
    public Color AlertBackColor
    {
        get =>
            alertBackColorValue == Color.Empty &&
            Parent != null
              ? Parent.BackColor
              : alertBackColorValue;

        set => alertBackColorValue = value;
    }

    // This method is used by designers to enable resetting the
    // property to its default value.
    public void ResetAlertBackColor() =>
        AlertBackColor = defaultAlertBackColorValue;

    // This method indicates to designers whether the property
    // value is different from the ambient value, in which case
    // the designer should persist the value.
    bool ShouldSerializeAlertBackColor() => alertBackColorValue != ambientColorValue;
    // </snippet24>

    // <snippet25>
    [Category("Data")]
    [Description("Indicates the source of data for the control.")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [AttributeProvider(typeof(IListSource))]
    public object DataSource
    {
        get => dataGridView1.DataSource;

        set => dataGridView1.DataSource = value;
    }
    // </snippet25>

    // <snippet26>
    [Category("Data")]
    [Description("Indicates a sub-list of the data source to show in the control.")]
    public string DataMember
    {
        get => dataGridView1.DataMember;

        set => dataGridView1.DataMember = value;
    }
    // </snippet26>

    // <snippet27>
    // This property would normally have its BrowsableAttribute 
    // set to false, but this code demonstrates using 
    // ReadOnlyAttribute, so BrowsableAttribute is true to show 
    // it in any attached PropertyGrid control.
    [Browsable(true)]
    [Category("Behavior")]
    [Description("The timestamp of the latest entry.")]
    [ReadOnly(true)]
    public DateTime CurrentLogTime
    {
        get
        {
            int lastRowIndex =
                dataGridView1.Rows.GetLastRow(
                DataGridViewElementStates.Visible);

            if (lastRowIndex > -1)
            {
                DataGridViewRow lastRow = dataGridView1.Rows[lastRowIndex];
                DataGridViewCell lastCell = lastRow.Cells["EntryTime"];
                return (DateTime)lastCell.Value;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        set
        {
        }
    }
    // </snippet27>

    // <snippet28>
    [Category("Behavior")]
    [Description("The value above which the ThresholdExceeded event will be raised.")]
    public object Threshold { get; set; }
    // </snippet28>

    // <snippet29>
    // This property exists only to demonstrate the 
    // PasswordPropertyText attribute. When this control 
    // is attached to a PropertyGrid control, the returned 
    // string will be displayed with obscuring characters
    // such as asterisks. This property has no other effect.
    [Category("Security")]
    [Description("Demonstrates PasswordPropertyTextAttribute.")]
    [PasswordPropertyText(true)]
    public string Password => "This is a demo password.";
    // </snippet29>

    // <snippet30>
    // This property exists only to demonstrate the 
    // DisplayName attribute. When this control 
    // is attached to a PropertyGrid control, the
    // property will appear as "RenamedProperty"
    // instead of "MisnamedProperty".
    [Description("Demonstrates DisplayNameAttribute.")]
    [DisplayName("RenamedProperty")]
    public bool MisnamedProperty => true;
    // </snippet30>

    // This is the declaration for the ThresholdExceeded event.
    public event ThresholdExceededEventHandler ThresholdExceeded;

    #region Implementation

    // <snippet31>
    // This is the event handler for the DataGridView control's 
    // CellFormatting event. Handling this event allows the 
    // AttributesDemoControl to examine the incoming log entries
    // from the data source as they arrive.
    //
    // If the cell for which this event is raised holds the
    // log entry's timestamp, the cell value is formatted with 
    // the full date/time pattern. 
    // 
    // Otherwise, the cell's value is assumed to hold the log 
    // entry value. If the value exceeds the threshold value, 
    // the cell is painted with the colors specified by the
    // AlertForeColor and AlertBackColor properties, after which
    // the ThresholdExceeded is raised. For this comparison to 
    // succeed, the log entry's type must implement the IComparable 
    // interface.
    void dataGridView1_CellFormatting(
        object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        try
        {
            if (e.Value != null)
            {
                if (e.Value is DateTime)
                {
                    // Display the log entry time with the 
                    // full date/time pattern (long time).
                    e.CellStyle.Format = "F";
                }
                else
                {
                    // Scroll to the most recent entry.
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    DataGridViewCell cell = row.Cells[e.ColumnIndex];
                    dataGridView1.FirstDisplayedCell = cell;

                    if (Threshold != null)
                    {
                        // Get the type of the log entry.
                        object val = e.Value;
                        Type paramType = val.GetType();

                        // Compare the log entry value to the threshold value.
                        // Use reflection to call the CompareTo method on the
                        // template parameter's type. 
                        int compareVal = (int)paramType.InvokeMember(
                            "CompareTo",
                            BindingFlags.Default | BindingFlags.InvokeMethod,
                            null,
                            e.Value,
                            [Threshold],
                            Globzn.CultureInfo.InvariantCulture);

                        // If the log entry value exceeds the threshold value,
                        // set the cell's fore color and back color properties
                        // and raise the ThresholdExceeded event.
                        if (compareVal > 0)
                        {
                            e.CellStyle.BackColor = alertBackColorValue;
                            e.CellStyle.ForeColor = alertForeColorValue;

                            ThresholdExceededEventArgs teea =
                                new(
                                Threshold,
                                e.Value);
                            ThresholdExceeded(teea);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex.Message);
        }
    }
    // </snippet31>

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
        {
            _components.Dispose();
        }
        base.Dispose(disposing);
    }

    void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new();
        tableLayoutPanel1 = new TableLayoutPanel();
        dataGridView1 = new DataGridView();
        label1 = new Label();
        tableLayoutPanel1.SuspendLayout();
        ((ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.AutoSize = true;
        tableLayoutPanel1.ColumnCount = 1;
        _ = tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
        _ = tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
        tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
        tableLayoutPanel1.Controls.Add(label1, 0, 0);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(10, 10);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.Padding = new Padding(10);
        tableLayoutPanel1.RowCount = 2;
        _ = tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        _ = tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
        _ = tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.Size = new Size(425, 424);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToOrderColumns = true;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Control;
        dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
        dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dataGridView1.ColumnHeadersHeight = 4;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(13, 57);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.Size = new Size(399, 354);
        dataGridView1.TabIndex = 1;
        dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = SystemColors.Control;
        label1.Dock = DockStyle.Fill;
        label1.Location = new Point(13, 13);
        label1.Name = "label1";
        label1.Size = new Size(399, 38);
        label1.TabIndex = 2;
        label1.Text = "label1";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // AttributesDemoControl
        // 
        Controls.Add(tableLayoutPanel1);
        Name = "AttributesDemoControl";
        Padding = new Padding(10);
        Size = new Size(445, 444);
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ((ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
// </snippet3>

// <snippet4>
// This is the EventArgs class for the ThresholdExceeded event.
public class ThresholdExceededEventArgs : EventArgs
{
    public ThresholdExceededEventArgs(
        object thresholdValue,
        object exceedingValue)
    {
        ThresholdValue = thresholdValue;
        ExceedingValue = exceedingValue;
    }

    public object ThresholdValue { get; }

    public object ExceedingValue { get; }
}
// </snippet4>

// <snippet5>
// This class encapsulates a log entry. It is a parameterized 
// type (also known as a template class). The parameter type T
// defines the type of data being logged. For threshold detection
// to work, this type must implement the IComparable interface.
[TypeConverter("LogEntryTypeConverter")]
public class LogEntry<T> where T : IComparable
{
    public LogEntry(
        T value,
        DateTime time)
    {
        Entry = value;
        EntryTime = time;
    }

    public T Entry { get; }

    public DateTime EntryTime { get; }

    // <snippet6>
    // This is the TypeConverter for the LogEntry class.
    public class LogEntryTypeConverter : TypeConverter
    {
        // <snippet7>
        public override bool CanConvertFrom(
            ITypeDescriptorContext context,
            Type sourceType) =>
            sourceType == typeof(string) ||
            base.CanConvertFrom(context, sourceType);
        // </snippet7>

        // <snippet8>
        public override object ConvertFrom(
            ITypeDescriptorContext context,
            Globzn.CultureInfo culture,
            object value)
        {
            if (value is string valstr)
            {
                string[] v = valstr.Split(['|']);

                Type paramType = typeof(T);
                T entryValue = (T)paramType.InvokeMember(
                    "Parse",
                    BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                    null,
                    null,
                    [v[0]],
                    culture);

                return new LogEntry<T>(
                    entryValue,
                    DateTime.Parse(v[2]));
            }

            return base.ConvertFrom(context, culture, value);
        }
        // </snippet8>

        // <snippet9>
        public override object ConvertTo(
            ITypeDescriptorContext context,
            Globzn.CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                LogEntry<T> le = value as LogEntry<T>;

                string stringRepresentation =
                    string.Format("{0} | {1}",
                    le.Entry,
                    le.EntryTime);

                return stringRepresentation;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
        // </snippet9>
    }
    // </snippet6>
}
// </snippet5>
// </snippet1>
