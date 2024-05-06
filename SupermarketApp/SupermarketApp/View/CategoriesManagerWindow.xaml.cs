using SupermarketApp.Model;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for CategoriesManagerWindow.xaml
    /// </summary>
    public partial class CategoriesManagerWindow : Window
    {
        public CategoriesManagerWindow(Theme theme)
        {
            InitializeComponent();
            this.DataContext = new CategoriesManagerVM(theme);
        }
    }
}
