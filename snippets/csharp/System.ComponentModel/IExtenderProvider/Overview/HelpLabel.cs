// <snippet1>

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Microsoft.Samples.WinForms.Cs.HelpLabel;
//
// <doc>
// <desc>
// Help Label offers an extender property called
// "HelpText".  It monitors the active control
// and displays the help text for the active control.
// </desc>
// </doc>
//
[
ProvideProperty("HelpText", typeof(Control)),
Designer(typeof(HelpLabelDesigner))
]
public class HelpLabel : Control, IExtenderProvider
{
    /// <summary>
    ///    Required designer variable.
    /// </summary>
    Container components;
    readonly Hashtable helpTexts;
    Control activeControl;

    //
    // <doc>
    // <desc>
    //      Creates a new help label object.
    // </desc>
    // </doc>
    //
    public HelpLabel()
    {
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();

        helpTexts = [];
    }

    /// <summary>
    ///    Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent()
    {
        BackColor = SystemColors.Info;
        components = new Container();
        ForeColor = SystemColors.InfoText;
        TabStop = false;
    }

    //
    // <doc>
    // <desc>
    //      Overrides the text property of Control.  This label ignores
    //      the text property, so we add additional attributes here so the
    //      property does not show up in the properties window and is not
    //      persisted.
    // </desc>
    // </doc>
    //
    [
    Browsable(false),
    EditorBrowsable(EditorBrowsableState.Never),
    DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
    ]
    public override string Text
    {
        get => base.Text; set => base.Text = value;
    }

    //
    // <doc>
    // <desc>
    //      This implements the IExtenderProvider.CanExtend method.  The
    //      help label provides an extender property, and the design time
    //      framework will call this method once for each component to determine
    //      if we are interested in providing our extended properties for the
    //      component.  We return true here if the object is a control and is
    //      not a HelpLabel (since it would be silly to add this property to
    //      ourselves).
    // </desc>
    // </doc>
    //
    bool IExtenderProvider.CanExtend(object target) => target is Control and
            not HelpLabel;

    //
    // <doc>
    // <desc>
    //      This is the extended property for the HelpText property.  Extended
    //      properties are actual methods because they take an additional parameter
    //      that is the object or control to provide the property for.
    // </desc>
    // </doc>
    //
    [
    DefaultValue(""),
    ]
    public string GetHelpText(Control control)
    {
        string text = (string)helpTexts[control];
        text ??= string.Empty;
        return text;
    }

    //
    // <doc>
    // <desc>
    //      This is an event handler that responds to the OnControlEnter
    //      event.  We attach this to each control we are providing help
    //      text for.
    // </desc>
    // </doc>
    //
    void OnControlEnter(object sender, EventArgs e)
    {
        activeControl = (Control)sender;
        Invalidate();
    }

    //
    // <doc>
    // <desc>
    //      This is an event handler that responds to the OnControlLeave
    //      event.  We attach this to each control we are providing help
    //      text for.
    // </desc>
    // </doc>
    //
    void OnControlLeave(object sender, EventArgs e)
    {
        if (sender == activeControl)
        {
            activeControl = null;
            Invalidate();
        }
    }

    //
    // <doc>
    // <desc>
    //      This is the extended property for the HelpText property.
    // </desc>
    // </doc>
    //
    public void SetHelpText(Control control, string value)
    {
        value ??= string.Empty;

        if (value.Length == 0)
        {
            helpTexts.Remove(control);

            control.Enter -= OnControlEnter;
            control.Leave -= OnControlLeave;
        }
        else
        {
            helpTexts[control] = value;

            control.Enter += OnControlEnter;
            control.Leave += OnControlLeave;
        }

        if (control == activeControl)
        {
            Invalidate();
        }
    }

    //
    // <doc>
    // <desc>
    //      Overrides Control.OnPaint.  Here we draw our
    //      label.
    // </desc>
    // </doc>
    //
    protected override void OnPaint(PaintEventArgs pe)
    {
        // Let the base draw.  This will cover our back
        // color and set any image that the user may have
        // provided.
        //
        base.OnPaint(pe);

        // Draw a rectangle around our control.
        //
        Rectangle rect = ClientRectangle;

        Pen borderPen = new(ForeColor);
        pe.Graphics.DrawRectangle(borderPen, rect);
        borderPen.Dispose();

        // Finally, draw the text over the top of the
        // rectangle.
        //
        if (activeControl != null)
        {
            string text = (string)helpTexts[activeControl];
            if (!string.IsNullOrEmpty(text))
            {
                rect.Inflate(-2, -2);
                Brush brush = new SolidBrush(ForeColor);
                pe.Graphics.DrawString(text, Font, brush, rect);
                brush.Dispose();
            }
        }
    }

    // <doc>
    // <desc>
    //     Returns true if the backColor should be persisted in code gen.  We
    //      override this because we change the default back color.
    // </desc>
    // <retvalue>
    //     true if the backColor should be persisted.
    // </retvalue>
    // </doc>
    //
    public bool ShouldSerializeBackColor() => !BackColor.Equals(SystemColors.Info);

    // <doc>
    // <desc>
    //     Returns true if the foreColor should be persisted in code gen.  We
    //      override this because we change the default foreground color.
    // </desc>
    // <retvalue>
    //     true if the foreColor should be persisted.
    // </retvalue>
    // </doc>
    //
    public bool ShouldSerializeForeColor() => !ForeColor.Equals(SystemColors.InfoText);

    //<snippet2>
    //
    // <doc>
    // <desc>
    //      This is a designer for the HelpLabel.  This designer provides
    //      design time feedback for the label.  The help label responds
    //      to changes in the active control, but these events do not
    //      occur at design time.  In order to provide some usable feedback
    //      that the control is working the right way, this designer listens
    //      to selection change events and uses those events to trigger active
    //      control changes.
    // </desc>
    // </doc>
    //
    public class HelpLabelDesigner : ControlDesigner
    {
        bool trackSelection = true;

        /// <summary>
        /// This property is added to the control's set of properties in the method
        /// PreFilterProperties below.  Note that on designers, properties that are
        /// explicitly declared by TypeDescriptor.CreateProperty can be declared as
        /// private on the designer.  This helps to keep the designer's public
        /// object model clean.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        bool TrackSelection
        {
            get => trackSelection;
            set
            {
                trackSelection = value;
                if (trackSelection)
                {
                    ISelectionService ss = (ISelectionService)GetService(typeof(ISelectionService));
                    if (ss != null)
                    {
                        UpdateHelpLabelSelection(ss);
                    }
                }
                else
                {
                    HelpLabel helpLabel = (HelpLabel)Control;
                    if (helpLabel.activeControl != null)
                    {
                        helpLabel.activeControl = null;
                        helpLabel.Invalidate();
                    }
                }
            }
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerb[] verbs = [
                                                            new("Sample Verb", new EventHandler(OnSampleVerb))
                                                          ];
                return [.. verbs];
            }
        }

        //
        // <doc>
        // <desc>
        //      Overrides Dispose.  Here we remove our handler for the selection changed
        //      event.  With designers, it is critical that they clean up any events they
        //      have attached.  Otherwise, during the course of an editing session many
        //      designers may get created and never destroyed.
        // </desc>
        // </doc>
        //
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ISelectionService ss = (ISelectionService)GetService(typeof(ISelectionService));
                if (ss != null)
                {
                    ss.SelectionChanged -= OnSelectionChanged;
                }
            }

            base.Dispose(disposing);
        }

        //
        // <doc>
        // <desc>
        //       Overrides initialize.  Here we add an event handler to the selection service.
        //      Notice that we are very careful not to assume that the selection service is
        //      available.  It is entirely optional that a service is available and you should
        //      always degrade gracefully if a service could not be found.
        // </desc>
        // </doc>
        //
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            ISelectionService ss = (ISelectionService)GetService(typeof(ISelectionService));
            if (ss != null)
            {
                ss.SelectionChanged += OnSelectionChanged;
            }
        }

        void OnSampleVerb(object sender, EventArgs e) => MessageBox.Show("You have just invoked a sample verb.  Normally, this would do something interesting.");

        //
        // <doc>
        // <desc>
        //      Our handler for the selection change event.  Here we update the active control within
        //      the help label.
        // </desc>
        // </doc>
        //
        void OnSelectionChanged(object sender, EventArgs e)
        {
            if (trackSelection)
            {
                ISelectionService ss = (ISelectionService)sender;
                UpdateHelpLabelSelection(ss);
            }
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            // Always call base first in PreFilter* methods, and last in PostFilter*
            // methods.
            base.PreFilterProperties(properties);

            // We add a design-time property called "TrackSelection" that is used to track
            // the active selection.  If the user sets this to true (the default), then
            // we will listen to selection change events and update the control's active
            // control to point to the current primary selection.
            properties["TrackSelection"] = TypeDescriptor.CreateProperty(
                GetType(),        // the type this property is defined on
                "TrackSelection",    // the name of the property
                typeof(bool),        // the type of the property
                [CategoryAttribute.Design]);    // attributes
        }

        /// <summary>
        /// This is a helper method that, given a selection service, will update the active control
        /// of our help label with the currently active selection.
        /// </summary>
        /// <param name="ss"></param>
        void UpdateHelpLabelSelection(ISelectionService ss)
        {
            HelpLabel helpLabel = (HelpLabel)Control;
            if (ss.PrimarySelection is Control c)
            {
                helpLabel.activeControl = c;
                helpLabel.Invalidate();
            }
            else
            {
                if (helpLabel.activeControl != null)
                {
                    helpLabel.activeControl = null;
                    helpLabel.Invalidate();
                }
            }
        }
    }
    //</snippet2>
}

// </snippet1>
