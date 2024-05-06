using SupermarketApp.Model;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for AdministrationWindow.xaml
    /// </summary>
    public partial class AdministrationWindow : Window
    {
        public AdministrationWindow(Theme myTheme, User user)
        {
            InitializeComponent();
            this.DataContext = new AdministrationVM(myTheme, user);
        }

    }
}
