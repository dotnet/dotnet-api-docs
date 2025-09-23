// <snippet1>
// <snippet2>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
// </snippet2>

public class Form1 : Form
{
    DemoControl demoControl1;

    readonly IContainer _components;

    public Form1() => InitializeComponent();

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
        {
            _components.Dispose();
        }
        base.Dispose(disposing);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    #region Windows Form Designer generated code

    void InitializeComponent()
    {
        demoControl1 = new DemoControl();
        SuspendLayout();
        // 
        // demoControl1
        // 
        demoControl1.AutoSize = true;
        demoControl1.BackColor = Color.Chartreuse;
        demoControl1.Location = new Point(0, 0);
        demoControl1.Name = "demoControl1";
        demoControl1.Size = new Size(232, 14);
        demoControl1.TabIndex = 0;
        demoControl1.Text = "This text was set by CreateComponentsCore.";
        // 
        // Form1
        // 
        ClientSize = new Size(492, 482);
        Controls.Add(demoControl1);
        Name = "Form1";
        Text = "r";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

}

// <snippet20>
// This control is derived from UserControl, with only a little
// added logic for the Toolbox interaction.
//
// All of the custom designer code is implemented in the
// DemoControlDesigner class.

// <snippet21>
[Designer(typeof(DemoControlDesigner))]
[ToolboxItem(typeof(DemoToolboxItem))]
public class DemoControl : Label
{
    // </snippet21>

    readonly IContainer _components;

    public DemoControl()
    {
        InitializeComponent();

        _ = MessageBox.Show("DemoControl", "Constructor");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
        {
            _components.Dispose();
        }
        base.Dispose(disposing);
    }

    void InitializeComponent() =>
        // 
        // DemoControl
        // 
        Name = "DemoControl";

    // <snippet22>
    // Toolbox items must be serializable.
    [Serializable]
    class DemoToolboxItem : ToolboxItem
    {
        // The add components dialog in VS looks for a public
        // ctor that takes a type.
        public DemoToolboxItem(Type toolType)
            : base(toolType)
        {
        }

        // And you must provide this special constructor for serialization.
        // If you add additional data to MyToolboxItem that you
        // want to serialize, you may override Deserialize and
        // Serialize methods to add that data.  
        DemoToolboxItem(SerializationInfo info, StreamingContext context) => Deserialize(info, context);

        // This implementation sets the new control's Text and 
        // AutoSize properties.
        protected override IComponent[] CreateComponentsCore(
            IDesignerHost host,
            IDictionary defaultValues)
        {
            IComponent[] comps = base.CreateComponentsCore(host, defaultValues);

            // The returned IComponent array contains a single 
            // component, which is an instance of DemoControl.
            ((DemoControl)comps[0]).Text = "This text was set by CreateComponentsCore.";
            ((DemoControl)comps[0]).AutoSize = true;

            return comps;
        }
    }
    // </snippet22>
}
// </snippet20>

// This class demonstrates a designer that attaches to various 
// services and changes the properties exposed by the control
// being designed.
public class DemoControlDesigner : ControlDesigner
{
    // This is the collection of DesignerActionLists that
    // defines the designer actions offered on the control. 
    DesignerActionListCollection actionLists;

    // This Timer is created when you select the Create Timer
    // designer action item.
    Timer createdTimer;

    // <snippet3>
    // These are the services which DemoControlDesigner will use.
    DesignerActionService actionService;
    DesignerActionUIService actionUiService;
    IComponentChangeService changeService;
    IDesignerEventService eventService;
    IDesignerHost host;
    IDesignerOptionService optionService;
    IEventBindingService eventBindingService;
    IExtenderListService listService;
    IReferenceService referenceService;
    ISelectionService selectionService;
    ITypeResolutionService typeResService;
    IComponentDiscoveryService componentDiscoveryService;
    IToolboxService toolboxService;
    UndoEngine undoEng;
    // </snippet3>

    public DemoControlDesigner() => MessageBox.Show("DemoControlDesigner", "Constructor");

    // <snippet4>
    // The Dispose method override is implemented so event handlers
    // can be removed. This prevents objects from lingering in 
    // memory beyond the desired lifespan.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (changeService != null)
            {
                // Unhook event handlers.
                changeService.ComponentChanged -=

                    ChangeService_ComponentChanged;

                changeService.ComponentAdded -=

                    ChangeService_ComponentAdded;

                changeService.ComponentRemoved -=

                    changeService_ComponentRemoved;
            }

            if (eventService != null)
            {
                eventService.ActiveDesignerChanged -=

                    eventService_ActiveDesignerChanged;
            }

            if (selectionService != null)
            {
                selectionService.SelectionChanged -=

                    selectionService_SelectionChanged;
            }
        }

        base.Dispose(disposing);
    }
    // </snippet4>

    // <snippet5>
    // This method initializes the designer.
    public override void Initialize(IComponent component)
    {
        base.Initialize(component);

        // Connect to various designer services.
        InitializeServices();

        // Set up the BackColor value that will be serialized.
        // This is the shadowed property on the designer.
        BackColor = Color.Chartreuse;

        // Set up the BackColor value that will be displayed.
        Control.BackColor = Color.AliceBlue;
    }
    // </snippet5>

    // <snippet6>
    // This method creates the DesignerActionList on demand, causing
    // designer actions to appear on the control being designed.
    public override DesignerActionListCollection ActionLists => actionLists ??= [new DemoActionList(Component),];
    // </snippet6>

    // <snippet7>
    // This utility method connects the designer to various
    // services it will use. 
    void InitializeServices()
    {
        // Acquire a reference to DesignerActionService.
        actionService =
            GetService(typeof(DesignerActionService))
            as DesignerActionService;

        // Acquire a reference to DesignerActionUIService.
        actionUiService =
            GetService(typeof(DesignerActionUIService))
            as DesignerActionUIService;

        // Acquire a reference to IComponentChangeService.
        changeService =
            GetService(typeof(IComponentChangeService))
            as IComponentChangeService;

        // <snippet14>
        // Hook the IComponentChangeService events.
        if (changeService != null)
        {
            changeService.ComponentChanged +=

                ChangeService_ComponentChanged;

            changeService.ComponentAdded +=

                ChangeService_ComponentAdded;

            changeService.ComponentRemoved +=

                changeService_ComponentRemoved;
        }
        // </snippet14>

        // Acquire a reference to ISelectionService.
        selectionService =
            GetService(typeof(ISelectionService))
            as ISelectionService;

        // Hook the SelectionChanged event.
        if (selectionService != null)
        {
            selectionService.SelectionChanged +=
                 selectionService_SelectionChanged;
        }

        // Acquire a reference to IDesignerEventService.
        eventService =
            GetService(typeof(IDesignerEventService))
            as IDesignerEventService;

        if (eventService != null)
        {
            eventService.ActiveDesignerChanged +=

                eventService_ActiveDesignerChanged;
        }

        // Acquire a reference to IDesignerHost.
        host =
            GetService(typeof(IDesignerHost))
            as IDesignerHost;

        // Acquire a reference to IDesignerOptionService.
        optionService =
            GetService(typeof(IDesignerOptionService))
            as IDesignerOptionService;

        // Acquire a reference to IEventBindingService.
        eventBindingService =
            GetService(typeof(IEventBindingService))
            as IEventBindingService;

        // Acquire a reference to IExtenderListService.
        listService =
            GetService(typeof(IExtenderListService))
            as IExtenderListService;

        // Acquire a reference to IReferenceService.
        referenceService =
            GetService(typeof(IReferenceService))
            as IReferenceService;

        // Acquire a reference to ITypeResolutionService.
        typeResService =
            GetService(typeof(ITypeResolutionService))
            as ITypeResolutionService;

        // Acquire a reference to IComponentDiscoveryService.
        componentDiscoveryService =
            GetService(typeof(IComponentDiscoveryService))
            as IComponentDiscoveryService;

        // Acquire a reference to IToolboxService.
        toolboxService =
            GetService(typeof(IToolboxService))
            as IToolboxService;

        // Acquire a reference to UndoEngine.
        undoEng =
            GetService(typeof(UndoEngine))
            as UndoEngine;

        if (undoEng != null)
        {
            _ = MessageBox.Show("UndoEngine");
        }
    }
    // </snippet7>

    // <snippet8>
    // This is the shadowed property on the designer.
    // This value will be serialized instead of the 
    // value of the control's property.
    public Color BackColor
    {
        get => (Color)ShadowProperties[nameof(BackColor)];
        set
        {
            if (changeService != null)
            {
                PropertyDescriptor backColorDesc =
                    TypeDescriptor.GetProperties(Control)["BackColor"];

                changeService.OnComponentChanging(
                    Control,
                    backColorDesc);

                ShadowProperties[nameof(BackColor)] = value;

                changeService.OnComponentChanged(
                    Control,
                    backColorDesc,
                    null,
                    null);
            }
        }
    }
    // </snippet8>

    // <snippet9>
    // This is the property added by the designer in the
    // PreFilterProperties method.
    bool Locked { get; }
    // </snippet9>

    // <snippet10>
    // The PreFilterProperties method is where you can add or remove
    // properties from the component being designed. 
    //
    // In this implementation, the Visible property is removed,
    // the BackColor property is shadowed by the designer, and
    // the a new property, called Locked, is added.
    protected override void PreFilterProperties(IDictionary properties)
    {
        // Always call the base PreFilterProperties implementation 
        // before you modify the properties collection.
        base.PreFilterProperties(properties);

        // Remove the visible property.
        properties.Remove("Visible");

        // Shadow the BackColor property.
        properties["BackColor"] = TypeDescriptor.CreateProperty(
            typeof(DemoControlDesigner),
            (PropertyDescriptor)properties["BackColor"],
            []);

        // Create the Locked property.
        properties["Locked"] = TypeDescriptor.CreateProperty(
                 typeof(DemoControlDesigner),
                 "Locked",
                 typeof(bool),
                 CategoryAttribute.Design,
                 DesignOnlyAttribute.Yes);
    }
    // </snippet10>

    // <snippet11>
    // The PostFilterProperties method is where you modify existing
    // properties. You must only use this method to modify existing 
    // items. Do not add or remove items here. Also, be sure to 
    // call base.PostFilterProperties(properties) after your filtering
    // logic.
    //
    // In this implementation, the Enabled property is hidden from
    // any PropertyGrid or Properties window. This is done by 
    // creating a copy of the existing PropertyDescriptor and
    // attaching two new Attributes: Browsable and EditorBrowsable.

    protected override void PostFilterProperties(IDictionary properties)
    {
        PropertyDescriptor pd =
            properties["Enabled"] as PropertyDescriptor;

        pd = TypeDescriptor.CreateProperty(
            pd.ComponentType,
            pd,
            [
                new BrowsableAttribute(false),
                new EditorBrowsableAttribute(EditorBrowsableState.Never)]);

        properties[pd.Name] = pd;

        // Always call the base PostFilterProperties implementation 
        // after you modify the properties collection.
        base.PostFilterProperties(properties);
    }
    // </snippet11>

    #region Event Handlers

    // <snippet12>
    void eventService_ActiveDesignerChanged(
        object sender,
        ActiveDesignerEventArgs e)
    {
        if (e.NewDesigner != null)
        {
            _ = MessageBox.Show(
                e.NewDesigner.ToString(),
                "ActiveDesignerChanged");
        }
    }

    // <snippet15>
    void ChangeService_ComponentChanged(
        object sender,
        ComponentChangedEventArgs e)
    {
        string msg = string.Format(
            "{0}, {1}", e.Component, e.Member);

        _ = MessageBox.Show(msg, "ComponentChanged");
    }

    void ChangeService_ComponentAdded(
        object sender,
        ComponentEventArgs e) => MessageBox.Show(
            e.Component.ToString(),
            "ComponentAdded");

    void changeService_ComponentRemoved(
        object sender,
        ComponentEventArgs e) => MessageBox.Show(
            e.Component.ToString(),
            "ComponentRemoved");
    // </snippet15>

    void selectionService_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (selectionService != null)
        {
            if (selectionService.PrimarySelection == Control)
            {
                _ = MessageBox.Show(
                    Control.ToString(),
                    "SelectionChanged");
            }
        }
    }
    // </snippet12>

    #endregion

    // <snippet13>
    // This class defines the designer actions that appear on the control
    // that is being designed.
    internal class DemoActionList :
          DesignerActionList
    {
        // Cache a reference to the designer host.
        readonly IDesignerHost host;

        // Cache a reference to the control.
        readonly DemoControl relatedControl;

        // Cache a reference to the designer.
        readonly DemoControlDesigner relatedDesigner;

        //The constructor associates the control 
        //with the designer action list.
        public DemoActionList(IComponent component)
            : base(component)
        {
            relatedControl = component as DemoControl;

            host =
                Component.Site.GetService(typeof(IDesignerHost))
                as IDesignerHost;

            IDesigner dcd = host.GetDesigner(Component);
            relatedDesigner = dcd as DemoControlDesigner;
        }

        // This method creates and populates the 
        // DesignerActionItemCollection which is used to 
        // display designer action items.
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items =
                [];

            // If the Timer component has not been created, show the
            // "Create Timer" DesignerAction item.
            //
            // If the Timer component exists, show the timer-related
            // options.

            if (relatedDesigner.createdTimer == null)
            {
                _ = items.Add(new DesignerActionMethodItem(
                    this,
                    "CreateTimer",
                    "Create Timer",
                    true));
            }
            else
            {
                _ = items.Add(new DesignerActionMethodItem(
                    this,
                    "ShowEventHandlerCode",
                    "Show Event Handler Code",
                    true));

                _ = items.Add(new DesignerActionMethodItem(
                    this,
                    "RemoveTimer",
                    "Remove Timer",
                    true));
            }

            _ = items.Add(new DesignerActionMethodItem(
               this,
               "GetExtenderProviders",
               "Get Extender Providers",
               true));

            _ = items.Add(new DesignerActionMethodItem(
              this,
              "GetDemoControlReferences",
              "Get DemoControl References",
              true));

            _ = items.Add(new DesignerActionMethodItem(
              this,
              "GetPathOfAssembly",
              "Get Path of Executing Assembly",
              true));

            _ = items.Add(new DesignerActionMethodItem(
              this,
              "GetComponentTypes",
              "Get ScrollableControl Types",
              true));

            _ = items.Add(new DesignerActionMethodItem(
                this,
                "GetToolboxCategories",
                "Get Toolbox Categories",
                true));

            _ = items.Add(new DesignerActionMethodItem(
                this,
                "SetBackColor",
                "Set Back Color",
                true));

            return items;
        }

        // <snippet17>
        // This method creates a Timer component using the 
        // IDesignerHost.CreateComponent method. It also 
        // creates an event handler for the Timer component's
        // tick event.
        void CreateTimer()
        {
            if (host != null)
            {
                if (relatedDesigner.createdTimer == null)
                {
                    // Create and configure the Timer object.
                    relatedDesigner.createdTimer =
                        host.CreateComponent(typeof(Timer)) as Timer;
                    Timer t = relatedDesigner.createdTimer;
                    t.Interval = 1000;
                    t.Enabled = true;

                    EventDescriptorCollection eventColl =
                        TypeDescriptor.GetEvents(t, []);

                    if (eventColl != null)
                    {
                        if (eventColl["Tick"] is EventDescriptor ed)
                        {
                            PropertyDescriptor epd =
                                relatedDesigner.eventBindingService.GetEventProperty(ed);

                            epd.SetValue(t, "timer_Tick");
                        }
                    }

                    relatedDesigner.actionUiService.Refresh(relatedControl);
                }
            }
        }
        // </snippet17>

        // <snippet18>
        // This method uses the IEventBindingService.ShowCode
        // method to start the Code Editor. It places the caret
        // in the timer_tick method created by the CreateTimer method.
        void ShowEventHandlerCode()
        {
            Timer t = relatedDesigner.createdTimer;

            if (t != null)
            {
                EventDescriptorCollection eventColl =
                    TypeDescriptor.GetEvents(t, []);
                if (eventColl != null && eventColl["Tick"] is EventDescriptor ed)
                {
                    _ = relatedDesigner.eventBindingService.ShowCode(t, ed);
                }
            }
        }
        // </snippet18>

        // <snippet19>
        // This method uses the IDesignerHost.DestroyComponent method
        // to remove the Timer component from the design environment.
        void RemoveTimer()
        {
            if (host != null)
            {
                if (relatedDesigner.createdTimer != null)
                {
                    host.DestroyComponent(
                        relatedDesigner.createdTimer);

                    relatedDesigner.createdTimer = null;

                    relatedDesigner.actionUiService.Refresh(
                        relatedControl);
                }
            }
        }
        // </snippet19>

        // <snippet16>
        // This method uses IExtenderListService.GetExtenderProviders
        // to enumerate all the extender providers and display them 
        // in a MessageBox.
        void GetExtenderProviders()
        {
            if (relatedDesigner.listService != null)
            {
                StringBuilder sb = new();

                IExtenderProvider[] providers =
                    relatedDesigner.listService.GetExtenderProviders();

                for (int i = 0; i < providers.Length; i++)
                {
                    _ = sb.Append(providers[i].ToString());
                    _ = sb.Append("\r\n");
                }

                _ = MessageBox.Show(
                    sb.ToString(),
                    "Extender Providers");
            }
        }
        // </snippet16>

        // This method uses the IReferenceService.GetReferences method
        // to enumerate all the instances of DemoControl on the 
        // design surface.
        void GetDemoControlReferences()
        {
            if (relatedDesigner.referenceService != null)
            {
                StringBuilder sb = new();

                object[] refs = relatedDesigner.referenceService.GetReferences(typeof(DemoControl));

                for (int i = 0; i < refs.Length; i++)
                {
                    _ = sb.Append(refs[i].ToString());
                    _ = sb.Append("\r\n");
                }

                _ = MessageBox.Show(
                    sb.ToString(),
                    "DemoControl References");
            }
        }

        // This method uses the ITypeResolutionService.GetPathOfAssembly
        // method to display the path of the executing assembly.
        void GetPathOfAssembly()
        {
            if (relatedDesigner.typeResService != null)
            {
                AssemblyName name =
                    Assembly.GetExecutingAssembly().GetName();

                _ = MessageBox.Show(
                    relatedDesigner.typeResService.GetPathOfAssembly(name),
                    "Path of executing assembly");
            }
        }

        // This method uses the IComponentDiscoveryService.GetComponentTypes 
        // method to find all the types that derive from 
        // ScrollableControl.
        void GetComponentTypes()
        {
            if (relatedDesigner.componentDiscoveryService != null)
            {
                ICollection components = relatedDesigner.componentDiscoveryService.GetComponentTypes(host, typeof(ScrollableControl));

                if (components != null)
                {
                    if (components.Count > 0)
                    {
                        StringBuilder sb = new();

                        IEnumerator e = components.GetEnumerator();

                        while (e.MoveNext())
                        {
                            _ = sb.Append(e.Current.ToString());
                            _ = sb.Append("\r\n");
                        }

                        _ = MessageBox.Show(
                            sb.ToString(),
                            "Controls derived from ScrollableControl");
                    }
                }
            }
        }

        // This method uses the IToolboxService.CategoryNames
        // method to enumerate all the categories that appear
        // in the Toolbox.
        void GetToolboxCategories()
        {
            if (relatedDesigner.toolboxService != null)
            {
                StringBuilder sb = new();

                CategoryNameCollection names = relatedDesigner.toolboxService.CategoryNames;

                foreach (string name in names)
                {
                    _ = sb.Append(name);
                    _ = sb.Append("\r\n");
                }

                _ = MessageBox.Show(sb.ToString(), "Toolbox Categories");
            }
        }

        // This method sets the shadowed BackColor property on the 
        // designer. This is the value that is serialized by the 
        // design environment.
        void SetBackColor()
        {
            ColorDialog d = new();
            if (d.ShowDialog() == DialogResult.OK)
            {
                relatedDesigner.BackColor = d.Color;
            }
        }
    }
    // </snippet13>
}
// </snippet1>
