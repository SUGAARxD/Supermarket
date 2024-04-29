using SupermarketApp.Model;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        public CashierWindow(Theme myTheme)
        {
            InitializeComponent();
            this.DataContext = new CashierVM(myTheme);
        }
    }
}
