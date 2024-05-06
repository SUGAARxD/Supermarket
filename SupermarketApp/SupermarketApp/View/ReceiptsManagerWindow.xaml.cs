using SupermarketApp.Model;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for ReceiptsManagerWindow.xaml
    /// </summary>
    public partial class ReceiptsManagerWindow : Window
    {
        public ReceiptsManagerWindow(Theme theme)
        {
            InitializeComponent();
            this.DataContext = new ReceiptsManagerVM(theme);
        }
    }
}
