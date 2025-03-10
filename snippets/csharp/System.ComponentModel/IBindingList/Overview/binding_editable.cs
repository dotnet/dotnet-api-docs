using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IBindingList_Doc;

/// <summary>
/// Summary description for Form1.
/// </summary>
public class Form1 : Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    readonly Container _components;

    public Form1() =>
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();//// TODO: Add any constructor code after InitializeComponent call//

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _components?.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent()
    {
        //
        // Form1
        //
        ClientSize = new Size(292, 273);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() => Application.Run(new Form1());

    void Form1_Load(object sender, EventArgs e)
    {
    }
}

// sample for IEditableObject
//<snippet1>
public class Customer : IEditableObject
{
    struct CustomerData
    {
        internal string id;
        internal string firstName;
        internal string lastName;
    }

    CustomerData custData;
    CustomerData backupData;
    bool inTxn;

    // Implements IEditableObject
    void IEditableObject.BeginEdit()
    {
        Console.WriteLine("Start BeginEdit");
        if (!inTxn)
        {
            backupData = custData;
            inTxn = true;
            Console.WriteLine("BeginEdit - " + backupData.lastName);
        }
        Console.WriteLine("End BeginEdit");
    }

    void IEditableObject.CancelEdit()
    {
        Console.WriteLine("Start CancelEdit");
        if (inTxn)
        {
            custData = backupData;
            inTxn = false;
            Console.WriteLine("CancelEdit - " + custData.lastName);
        }
        Console.WriteLine("End CancelEdit");
    }

    void IEditableObject.EndEdit()
    {
        Console.WriteLine("Start EndEdit" + custData.id + custData.lastName);
        if (inTxn)
        {
            backupData = new CustomerData();
            inTxn = false;
            Console.WriteLine("Done EndEdit - " + custData.id + custData.lastName);
        }
        Console.WriteLine("End EndEdit");
    }

    public Customer(string ID) : base() => custData = new CustomerData
    {
        id = ID,
        firstName = "",
        lastName = ""
    };

    public string ID => custData.id;

    public string FirstName
    {
        get => custData.firstName;
        set
        {
            custData.firstName = value;
            OnCustomerChanged();
        }
    }

    public string LastName
    {
        get => custData.lastName;
        set
        {
            custData.lastName = value;
            OnCustomerChanged();
        }
    }

    internal CustomersList Parent { get; set; }

    void OnCustomerChanged()
    {
        if (!inTxn && Parent != null)
        {
            Parent.CustomerChanged(this);
        }
    }

    public override string ToString()
    {
        StringWriter sb = new();
        sb.Write(FirstName);
        sb.Write(" ");
        sb.Write(LastName);
        return sb.ToString();
    }
}
//</snippet1>
// end of Customer class - sample for IEditableObject

// sample for IBindingList
//<snippet2>
public class CustomersList : CollectionBase, IBindingList
{
    readonly ListChangedEventArgs resetEvent = new(ListChangedType.Reset, -1);
    ListChangedEventHandler onListChanged;

    public void LoadCustomers()
    {
        IList l = this;
        _ = l.Add(ReadCustomer1());
        _ = l.Add(ReadCustomer2());
        OnListChanged(resetEvent);
    }

    public Customer this[int index]
    {
        get => (Customer)List[index]; set => List[index] = value;
    }

    public int Add(Customer value) => List.Add(value);

    public Customer AddNew() => (Customer)((IBindingList)this).AddNew();

    public void Remove(Customer value) => List.Remove(value);

    protected virtual void OnListChanged(ListChangedEventArgs ev) => onListChanged?.Invoke(this, ev);

    protected override void OnClear()
    {
        foreach (Customer c in List)
        {
            c.Parent = null;
        }
    }

    protected override void OnClearComplete() => OnListChanged(resetEvent);

    protected override void OnInsertComplete(int index, object value)
    {
        Customer c = (Customer)value;
        c.Parent = this;
        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    protected override void OnRemoveComplete(int index, object value)
    {
        Customer c = (Customer)value;
        c.Parent = this;
        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
    }

    protected override void OnSetComplete(int index, object oldValue, object newValue)
    {
        if (oldValue != newValue)
        {
            Customer oldcust = (Customer)oldValue;
            Customer newcust = (Customer)newValue;

            oldcust.Parent = null;
            newcust.Parent = this;

            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
        }
    }

    // Called by Customer when it changes.
    internal void CustomerChanged(Customer cust)
    {
        int index = List.IndexOf(cust);

        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
    }

    // Implements IBindingList.
    bool IBindingList.AllowEdit => true;

    bool IBindingList.AllowNew => true;

    bool IBindingList.AllowRemove => true;

    bool IBindingList.SupportsChangeNotification => true;

    bool IBindingList.SupportsSearching => false;

    bool IBindingList.SupportsSorting => false;

    // Events.
    public event ListChangedEventHandler ListChanged
    {
        add => onListChanged += value; remove => onListChanged -= value;
    }

    // Methods.
    object IBindingList.AddNew()
    {
        Customer c = new(Count.ToString());
        _ = List.Add(c);
        return c;
    }

    // Unsupported properties.
    bool IBindingList.IsSorted => throw new NotSupportedException();

    ListSortDirection IBindingList.SortDirection => throw new NotSupportedException();

    PropertyDescriptor IBindingList.SortProperty => throw new NotSupportedException();

    // Unsupported Methods.
    void IBindingList.AddIndex(PropertyDescriptor property) => throw new NotSupportedException();

    void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction) => throw new NotSupportedException();

    int IBindingList.Find(PropertyDescriptor property, object key) => throw new NotSupportedException();

    void IBindingList.RemoveIndex(PropertyDescriptor property) => throw new NotSupportedException();

    void IBindingList.RemoveSort() => throw new NotSupportedException();

    // Worker functions to populate the list with data.
    static Customer ReadCustomer1() => new("536-45-1245")
    {
        FirstName = "Jo",
        LastName = "Brown"
    };

    static Customer ReadCustomer2()
    {
        Customer cust = new("246-12-5645")
        {
            FirstName = "Robert",
            LastName = "Brown"
        };
        return cust;
    }
}

//</snippet2>
