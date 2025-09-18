//<SnippetData>
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace IEditableCollectionViewAddItemExample;

// LibraryItem implements INotifyPropertyChanged so that the 
// application is notified when a property changes.  It 
// implements IEditableObject so that pending changes can be discarded.
public class LibraryItem : INotifyPropertyChanged, IEditableObject
{
    struct ItemData
    {
        internal string Title;
        internal string CallNumber;
        internal DateTime DueDate;
    }

    ItemData copyData;
    ItemData currentData;

    public LibraryItem(string title, string callNum, DateTime dueDate)
    {
        Title = title;
        CallNumber = callNum;
        DueDate = dueDate;
    }

    public override string ToString() => string.Format("{0}, {1:c}, {2:D}", Title, CallNumber, DueDate);

    public string Title
    {
        get => currentData.Title;
        set
        {
            if (currentData.Title != value)
            {
                currentData.Title = value;
                NotifyPropertyChanged("Title");
            }
        }
    }

    public string CallNumber
    {
        get => currentData.CallNumber;
        set
        {
            if (currentData.CallNumber != value)
            {
                currentData.CallNumber = value;
                NotifyPropertyChanged("CallNumber");
            }
        }
    }

    public DateTime DueDate
    {
        get => currentData.DueDate;
        set
        {
            if (value != currentData.DueDate)
            {
                currentData.DueDate = value;
                NotifyPropertyChanged("DueDate");
            }
        }
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(string info) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));

    #endregion

    #region IEditableObject Members

    public virtual void BeginEdit() => copyData = currentData;

    public virtual void CancelEdit()
    {
        currentData = copyData;
        NotifyPropertyChanged("");
    }

    public virtual void EndEdit() => copyData = new ItemData();

    #endregion

}

public class MusicCD : LibraryItem
{
    struct MusicData
    {
        internal int SongNumber;
        internal string Artist;
    }

    MusicData copyData;
    MusicData currentData;

    public MusicCD(string title, string artist, int songNum, string callNum, DateTime dueDate)
        : base(title, callNum, dueDate)
    {
        currentData.SongNumber = songNum;
        currentData.Artist = artist;
    }

    public string Artist
    {
        get => currentData.Artist;
        set
        {
            if (value != currentData.Artist)
            {
                currentData.Artist = value;
                NotifyPropertyChanged("Artist");
            }
        }
    }

    public int NumberOfTracks
    {
        get => currentData.SongNumber;
        set
        {
            if (value != currentData.SongNumber)
            {
                currentData.SongNumber = value;
                NotifyPropertyChanged("NumberOfTracks");
            }
        }
    }

    public override void BeginEdit()
    {
        base.BeginEdit();
        copyData = currentData;
    }

    public override void CancelEdit()
    {
        base.CancelEdit();
        currentData = copyData;
    }

    public override void EndEdit()
    {
        base.EndEdit();
        copyData = new MusicData();
    }

    public override string ToString() => string.Format(
            "Album: {0}\nArtist: {1}\nTracks: {2}\nDue Date: {3:d}\nCall Number: {4}",
            Title, Artist, NumberOfTracks, DueDate, CallNumber);
}

public class Book : LibraryItem
{
    struct BookData
    {
        internal string Author;
        internal string Genre;
    }

    BookData currentData;
    BookData copyData;

    public Book(string title, string author, string genre, string callnum, DateTime dueDate)
        : base(title, callnum, dueDate)
    {
        Author = author;
        Genre = genre;
    }

    public string Author
    {
        get => currentData.Author;
        set
        {
            if (value != currentData.Author)
            {
                currentData.Author = value;
                NotifyPropertyChanged("Author");
            }
        }
    }

    public string Genre
    {
        get => currentData.Genre;
        set
        {
            if (value != currentData.Genre)
            {
                currentData.Genre = value;
                NotifyPropertyChanged("Genre");
            }
        }
    }

    public override void BeginEdit()
    {
        base.BeginEdit();
        copyData = currentData;
    }

    public override void CancelEdit()
    {
        base.CancelEdit();
        currentData = copyData;
    }

    public override void EndEdit()
    {
        base.EndEdit();
        copyData = new BookData();
    }

    public override string ToString() => string.Format(
            "Title: {0}\nAuthor: {1}\nGenre: {2}\nDue Date: {3:d}\nCall Number: {4}",
            Title, Author, Genre, DueDate, CallNumber);
}

public class MovieDVD : LibraryItem
{
    struct MovieData
    {
        internal TimeSpan Length;
        internal string Director;
        internal string Genre;
    }

    MovieData currentData;
    MovieData copyData;

    public MovieDVD(string title, string director, string genre, TimeSpan length, string callnum, DateTime dueDate)
        : base(title, callnum, dueDate)
    {
        Director = director;
        Length = length;
        Genre = genre;
    }

    public TimeSpan Length
    {
        get => currentData.Length;
        set
        {
            if (value != currentData.Length)
            {
                currentData.Length = value;
                NotifyPropertyChanged("Length");
            }
        }
    }

    public string Director
    {
        get => currentData.Director;
        set
        {
            if (value != currentData.Director)
            {
                currentData.Director = value;
                NotifyPropertyChanged("Director");
            }
        }
    }

    public string Genre
    {
        get => currentData.Genre;
        set
        {
            if (value != currentData.Genre)
            {
                currentData.Genre = value;
                NotifyPropertyChanged("Genre");
            }
        }
    }

    public override void BeginEdit()
    {
        base.BeginEdit();
        copyData = currentData;
    }

    public override void CancelEdit()
    {
        base.CancelEdit();
        currentData = copyData;
    }

    public override void EndEdit()
    {
        base.EndEdit();
        copyData = new MovieData();
    }

    public override string ToString() => string.Format("Title: {0}\nDirector: {1}\nGenre: {2}\nLength: {3}\nDue Date: {4:d}\nCall Number: {5}",
            Title, Director, Genre, Length, DueDate, CallNumber);
}

public class LibraryCatalog : ObservableCollection<LibraryItem>
{
    public LibraryCatalog()
    {
        Add(new MusicCD("A Programmers Plight", "Jon Orton",
            12, "CD.OrtPro", new DateTime(2010, 3, 24)));

        Add(new Book("Cooking with Thyme", "Eliot J. Graff",
            "Home Economics", "HE.GraThy", new DateTime(2010, 2, 26)));

        Add(new MovieDVD("Terror of the Testers", "Molly Dempsey",
            "Horror", new TimeSpan(1, 27, 19), "DVD.DemTer",
            new DateTime(2010, 2, 1)));

        Add(new MusicCD("The Best of Jim Hance", "Jim Hance",
            15, "CD.HanBes", new DateTime(2010, 1, 31)));

        Add(new Book("Victor and the VB Vehicle", "Tommy Hortono",
            "YA Fiction", "YA.HorVic", new DateTime(2010, 3, 1)));
    }
}
//</SnippetData>
