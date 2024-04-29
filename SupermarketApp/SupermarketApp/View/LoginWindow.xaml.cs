using SupermarketApp.Model;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        public LoginWindow(Theme theme = null)
        {
            InitializeComponent();
            this.DataContext = new LoginVM(theme);
        }
    }
}
