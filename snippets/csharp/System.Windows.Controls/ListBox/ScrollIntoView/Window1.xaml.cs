﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ListBox_Index
{
    public partial class Window1 : Window
    {
        public List<string> ScrollIntoViewItems { get; }

        public Window1()
        {
            this.DataContext = this;
            ScrollIntoViewItems = new List<string>(Enumerable.Range(0, 20).Select(i => $"Item {i}"));

            InitializeComponent();
        }

        //<SnippetListBoxSelectAll>
        private void SelectAll(object sender, RoutedEventArgs e)
        {
            lb.SelectAll();
        }
        //</SnippetListBoxSelectAll>

        //<SnippetListBoxUnselectAll>
        private void UnselectAll(object sender, RoutedEventArgs e)
        {
            lb.UnselectAll();
        }
        //</SnippetListBoxUnselectAll>

        //<SnippetListBoxSelectedItems>
        private void SelectedItems(object sender, RoutedEventArgs e)
        {
            if (lb.SelectedItem != null)
            {
                label1.Content = "Has " + (lb.SelectedItems.Count.ToString()) + " item(s) selected.";
            }
        }
        //</SnippetListBoxSelectedItems>

        //<SnippetListBoxItemsEventSelected>   
        private void OnSelected(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = e.Source as ListBoxItem;

            if (lbi != null)
            {
                label1.Content = lbi.Content.ToString() + " is selected.";
            }
        }
        //</SnippetListBoxItemsEventSelected>

        //<SnippetListBoxItemsEventUnselected>
        private void OnUnselected(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = e.Source as ListBoxItem;

            if (lbi != null)
            {
                label1.Content = lbi.Content.ToString() + " is unselected.";
            }
        }
        //</SnippetListBoxItemsEventUnselected>

        //<SnippetListBoxItemsIsSelected2>
        private void SelectedItem(object sender, RoutedEventArgs e)
        {
            if (item1.IsSelected == true)
            {
                label2.Content = "IsSelected.";
            }
        }
        //</SnippetListBoxItemsIsSelected2>

        //<SnippetListBoxScrollIntoView>
        private void ScrollIntoView(object sender, RoutedEventArgs e)
        {
            var index = cbScrollIntoView.SelectedIndex;
            var item = lbScrollIntoView.Items.GetItemAt(index);
            lbScrollIntoView.ScrollIntoView(item);
        }
        //</SnippetListBoxScrollIntoView>
    }
}