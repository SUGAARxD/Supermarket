using SupermarketApp.Model;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for UsersManagerWindow.xaml
    /// </summary>
    public partial class UsersManagerWindow : Window
    {
        public UsersManagerWindow(Theme theme, User user)
        {
            InitializeComponent();
            this.DataContext = new UsersManagerVM(theme, user);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Show();
        }
    }
}
