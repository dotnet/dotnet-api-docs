using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SDKSample
{
    /// <summary>
    /// NumberListItem. This is the class that encapsulates each item
    /// in the numberlist.  The NLValue property is the property
    /// that is bound to by UI elements in the XAML markup.
    /// </summary>
    //<Snippet1>
    public class NumberListItem : INotifyPropertyChanged
    {
        private int _nlValue;

        public int NLValue
        {
            get
            {
                return _nlValue;
            }

            set
            {
                if (_nlValue != value)
                {
                    _nlValue = value;
                    OnPropertyChanged(nameof(NLValue));
                }
            }
        }

        // The following event and method support property-changed events.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }
    //</Snippet1>

    /// <summary>
    /// NumberList. In addition to serving as the datasource for the
    /// binding in this program, this class also exposes the methods
    /// through which a change to the list content can be initiated.
    /// </summary>
    //<Snippet3>
    public class NumberList : ObservableCollection<NumberListItem>
    {
        public NumberList()
            : base()
        {
            Add(new());
            Add(new());
            Add(new());
        }

        public void SetOdd()
        {
            // Each of these NLValue assignments causes an OnPropertyChanged event.
            for (int i = 0; i < Count; ++i)
            {
                NumberListItem nli = (NumberListItem)this[i];
                nli.NLValue = 2 * i + 1;
            }
        }

        public void SetEven()
        {
            // Each of these NLValue assignments causes an OnPropertyChanged event.
            for (int i = 0; i < Count; ++i)
            {
                NumberListItem nli = (NumberListItem)this[i];
                nli.NLValue = 2 * (i + 1);
            }
        }
        public void Snip()
        {
            //<SnippetBlockReentrancy>
            using (BlockReentrancy())
            {
                // OnCollectionChanged call.
            }
            //</SnippetBlockReentrancy>
        }
    }
    //</Snippet3>
}
