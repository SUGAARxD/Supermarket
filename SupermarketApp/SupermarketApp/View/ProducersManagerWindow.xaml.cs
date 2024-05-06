using SupermarketApp.Model;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for ProducersManagerWindow.xaml
    /// </summary>
    public partial class ProducersManagerWindow : Window
    {
        public ProducersManagerWindow(Theme theme)
        {
            InitializeComponent();
            this.DataContext = new ProducersManagerVM(theme);
        }
    }
}
