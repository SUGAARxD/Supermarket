using SupermarketApp.Model;
using SupermarketApp.ViewModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for StocksManagerWindow.xaml
    /// </summary>
    public partial class StocksManagerWindow : Window
    {
        public StocksManagerWindow(Theme theme)
        {
            InitializeComponent();
            this.DataContext = new StocksManagerVM(theme);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Show();
        }
    }
}
