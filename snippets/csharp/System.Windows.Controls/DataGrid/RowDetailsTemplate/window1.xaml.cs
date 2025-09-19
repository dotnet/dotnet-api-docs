using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AdventureWorksLT2008Entities advenWorksEntities = new AdventureWorksLT2008Entities();
            
            ObjectQuery<Customer> customers = advenWorksEntities.Customers;

            var query =
            from customer in customers
            orderby customer.CompanyName
            select new { 
                customer.LastName, 
                customer.FirstName, 
                customer.CompanyName, 
                customer.Title, 
                customer.EmailAddress, 
                customer.Phone, 
                customer.SalesPerson };

            dataGrid1.ItemsSource = query.ToList();
        }
    }
}
