using SupermarketApp.Model;
using SupermarketApp.ViewModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for ProductsManagerWindow.xaml
    /// </summary>
    public partial class ProductsManagerWindow : Window
    {
        public ProductsManagerWindow(Theme theme)
        {
            InitializeComponent();
            this.DataContext = new ProductsManagerVM(theme);
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Show();
        }
    }
}
