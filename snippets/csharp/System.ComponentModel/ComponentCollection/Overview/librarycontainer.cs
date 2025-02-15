using System;
using System.Collections;
using System.ComponentModel;

namespace InterfaceSample;

//<snippet1>
/// <summary>
/// The following example demonstrates the implementation of
/// ISite, IComponent, and IContainer for use in a simple library container.
///
/// This example uses the System, System.ComponentModel, and System.Collections
/// namespaces.
/// </summary>
//This code segment implements the ISite and IComponent interfaces.
//The implementation of the IContainer interface can be seen in the documentation 
//of IContainer.

//Implement the ISite interface.

// The ISBNSite class represents the ISBN name of the book component
class ISBNSite : ISite
{
    readonly IComponent m_curComponent;
    readonly IContainer m_curContainer;
    readonly bool m_bDesignMode;
    string m_ISBNCmpName;

    public ISBNSite(IContainer actvCntr, IComponent prntCmpnt)
    {
        m_curComponent = prntCmpnt;
        m_curContainer = actvCntr;
        m_bDesignMode = false;
        m_ISBNCmpName = null;
    }

    //Support the ISite interface.
    public virtual IComponent Component => m_curComponent;

    public virtual IContainer Container => m_curContainer;

    public virtual bool DesignMode => m_bDesignMode;

    public virtual string Name
    {
        get => m_ISBNCmpName;

        set => m_ISBNCmpName = value;
    }

    //Support the IServiceProvider interface.
    public virtual object GetService(Type serviceType) =>
        //This example does not use any service object.
        null;
}

// The BookComponent class represents the book component of the library container.

// This class implements the IComponent interface.

class BookComponent : IComponent
{
    public event EventHandler Disposed;
    ISite m_curISBNSite;

    public BookComponent(string Title, string Author)
    {
        m_curISBNSite = null;
        Disposed = null;
        this.Title = Title;
        this.Author = Author;
    }

    public string Title { get; }

    public string Author { get; }

    public virtual void Dispose() =>
        //There is nothing to clean.
        Disposed?.Invoke(this, EventArgs.Empty);

    public virtual ISite Site
    {
        get => m_curISBNSite; set => m_curISBNSite = value;
    }

    public override bool Equals(object cmp)
    {
        BookComponent cmpObj = (BookComponent)cmp;
        return Title.Equals(cmpObj.Title) && Author.Equals(cmpObj.Author);
    }

    public override int GetHashCode() => base.GetHashCode();
}
//</snippet1>
//<snippet2> 
//This code segment implements the IContainer interface.  The code segment 
//containing the implementation of ISite and IComponent can be found in the documentation
//for those interfaces.

//Implement the LibraryContainer using the IContainer interface.

class LibraryContainer : IContainer
{
    readonly ArrayList m_bookList = [];

    public virtual void Add(IComponent book) =>
        //The book will be added without creation of the ISite object.
        m_bookList.Add(book);

    public virtual void Add(IComponent book, string ISNDNNum)
    {
        for (int i = 0; i < m_bookList.Count; ++i)
        {
            IComponent curObj = (IComponent)m_bookList[i];
            if (curObj.Site != null)
            {
                if (curObj.Site.Name.Equals(ISNDNNum))
                {
                    throw new ArgumentException("The ISBN number already exists in the container");
                }
            }
        }

        book.Site = new ISBNSite(this, book) { Name = ISNDNNum };
        _ = m_bookList.Add(book);
    }

    public virtual void Remove(IComponent book)
    {
        for (int i = 0; i < m_bookList.Count; ++i)
        {
            if (book.Equals(m_bookList[i]))
            {
                m_bookList.RemoveAt(i);
                break;
            }
        }
    }

    public ComponentCollection Components
    {
        get
        {
            IComponent[] datalist = new BookComponent[m_bookList.Count];
            m_bookList.CopyTo(datalist);
            return new ComponentCollection(datalist);
        }
    }

    public virtual void Dispose()
    {
        for (int i = 0; i < m_bookList.Count; ++i)
        {
            IComponent curObj = (IComponent)m_bookList[i];
            curObj.Dispose();
        }

        m_bookList.Clear();
    }

    static void Main()
    {
        LibraryContainer cntrExmpl = new();

        try
        {
            BookComponent book1 = new("Wizard's First Rule", "Terry Gooodkind");
            cntrExmpl.Add(book1, "0812548051");
            BookComponent book2 = new("Stone of Tears", "Terry Gooodkind");
            cntrExmpl.Add(book2, "0812548094");
            BookComponent book3 = new("Blood of the Fold", "Terry Gooodkind");
            cntrExmpl.Add(book3, "0812551478");
            BookComponent book4 = new("The Soul of the Fire", "Terry Gooodkind");
            //This will generate exception because the ISBN already exists in the container.
            cntrExmpl.Add(book4, "0812551478");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Unable to add books: " + e.Message);
        }

        ComponentCollection datalist = cntrExmpl.Components;
        IEnumerator denum = datalist.GetEnumerator();

        while (denum.MoveNext())
        {
            BookComponent cmp = (BookComponent)denum.Current;
            Console.WriteLine("Book Title: " + cmp.Title);
            Console.WriteLine("Book Author: " + cmp.Author);
            Console.WriteLine("Book ISBN: " + cmp.Site.Name);
        }
    }
}
//</snippet2>
