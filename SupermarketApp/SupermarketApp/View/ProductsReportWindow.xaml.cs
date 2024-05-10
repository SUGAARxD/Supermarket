using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for ProductsReportWindow.xaml
    /// </summary>
    public partial class ProductsReportWindow : Window
    {
        public ProductsReportWindow(ObservableCollection<Product> products)
        {
            InitializeComponent();
            this.DataContext = new ProductsReportVM(products);
        }
    }
}
