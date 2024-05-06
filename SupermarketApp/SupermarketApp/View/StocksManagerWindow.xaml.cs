using SupermarketApp.Model;
using SupermarketApp.ViewModel;
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
    }
}
