using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace EditingCollectionsSnippets;

/// <summary>
/// Interaction logic for Window1.xaml
/// </summary>
public partial class Window1 : Window
{
    public Window1() => InitializeComponent();

    void edit_Click(object sender, RoutedEventArgs e)
    {
        if (itemsControl.SelectedItem == null)
        {
            _ = MessageBox.Show("No item is selected");
            return;
        }

        //<SnippetEditItem>
        IEditableCollectionView editableCollectionView =
                    itemsControl.Items;

        // Create a window that prompts the user to edit an item.
        ChangeItemWindow win = new();
        editableCollectionView.EditItem(itemsControl.SelectedItem);
        win.DataContext = itemsControl.SelectedItem;

        // If the user submits the new item, commit the changes.
        // If the user cancels the edits, discard the changes. 
        if ((bool)win.ShowDialog())
        {
            editableCollectionView.CommitEdit();
        }
        else
        {
            //<SnippetCancelEdit>
            // If the objects in the collection can discard pending 
            // changes, calling IEditableCollectionView.CancelEdit
            // will revert the changes. Otherwise, you must provide
            // your own logic to revert the changes in the object.

            if (!editableCollectionView.CanCancelEdit)
            {
                // Provide logic to revert changes.
            }

            editableCollectionView.CancelEdit();
            //</SnippetCancelEdit>
        }
        //</SnippetEditItem>
    }

    void add_Click(object sender, RoutedEventArgs e)
    {
        //<SnippetAddItem>
        IEditableCollectionView editableCollectionView =
            itemsControl.Items;

        if (!editableCollectionView.CanAddNew)
        {
            _ = MessageBox.Show("You cannot add items to the list.");
            return;
        }

        // Create a window that prompts the user to enter a new
        // item to sell.
        ChangeItemWindow win = new()
        {
            //Create a new item to be added to the collection.
            DataContext = editableCollectionView.AddNew()
        };

        // If the user submits the new item, commit the new
        // object to the collection.  If the user cancels 
        // adding the new item, discard the new item.
        if ((bool)win.ShowDialog())
        {
            editableCollectionView.CommitNew();
        }
        else
        {
            editableCollectionView.CancelNew();
        }

        //</SnippetAddItem>
    }

    void remove_Click(object sender, RoutedEventArgs e)
    {
        if (itemsControl.SelectedItem is not PurchaseItem item)
        {
            _ = MessageBox.Show("No Item is selected");
            return;
        }

        //<SnippetRemoveItem>
        IEditableCollectionView editableCollectionView =
                itemsControl.Items;

        if (!editableCollectionView.CanRemove)
        {
            _ = MessageBox.Show("You cannot remove items from the list.");
            return;
        }

        if (MessageBox.Show("Are you sure you want to remove " + item.Description,
                            "Remove Item", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            editableCollectionView.Remove(itemsControl.SelectedItem);
        }
        //</SnippetRemoveItem>
    }
}

public class PurchaseItem : IEditableObject, INotifyPropertyChanged
{
    struct ItemData
    {
        internal string Description;
        internal double Price;
        internal DateTime OfferExpires;
    }
    ItemData copyData;
    ItemData currentData;

    public PurchaseItem()
        : this("New item", 0, DateTime.Now)
    {
    }

    public PurchaseItem(string desc, double price, DateTime endDate)
    {
        Description = desc;
        Price = price;
        OfferExpires = endDate;
    }

    public override string ToString() => string.Format("{0}, {1:c}, {2:D}", Description, Price, OfferExpires);

    public string Description
    {
        get => currentData.Description;
        set
        {
            if (currentData.Description != value)
            {
                currentData.Description = value;
                NotifyPropertyChanged("Description");
            }
        }
    }

    public double Price
    {
        get => currentData.Price;
        set
        {
            if (currentData.Price != value)
            {
                currentData.Price = value;
                NotifyPropertyChanged("Price");
            }
        }
    }

    public DateTime OfferExpires
    {
        get => currentData.OfferExpires;
        set
        {
            if (value != currentData.OfferExpires)
            {
                currentData.OfferExpires = value;
                NotifyPropertyChanged("OfferExpires");
            }
        }
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    void NotifyPropertyChanged(string info) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));

    #endregion

    #region IEditableObject Members

    public void BeginEdit() => copyData = currentData;

    public void CancelEdit()
    {
        currentData = copyData;
        NotifyPropertyChanged("");
    }

    public void EndEdit() => copyData = new ItemData();

    #endregion

}

public class ItemsForSale : ObservableCollection<PurchaseItem>
{
    public ItemsForSale() : base(
[
            new("Snowboard and bindings", 120, new DateTime(2009, 1, 1)),
            new ("Snowboard and bindings", 120, new DateTime(2009, 1, 1)),
            new ("Inside C#, second edition", 10, new DateTime(2009, 2, 2)),
            new ("Laptop - only 1 year old", 499.99, new DateTime(2009, 2, 28)),
            new ("Set of 6 chairs", 120, new DateTime(2009, 2, 28)),
            new ("My DVD Collection", 15, new DateTime(2009, 1, 1)),
            new ("TV Drama Series", 39.985, new DateTime(2009, 1, 1)),
            new ("Squash racket", 60, new DateTime(2009, 2, 28))
         ])
    { }
}
