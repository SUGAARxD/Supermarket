using SupermarketApp.Model;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        public CashierWindow(Theme myTheme, User cashier)
        {
            InitializeComponent();
            this.DataContext = new CashierVM(myTheme, cashier);
        }
    }
}
