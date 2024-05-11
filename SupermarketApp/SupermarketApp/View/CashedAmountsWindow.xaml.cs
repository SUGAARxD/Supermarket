using SupermarketApp.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SupermarketApp.View
{
    /// <summary>
    /// Interaction logic for CashedAmountsWindow.xaml
    /// </summary>
    public partial class CashedAmountsWindow : Window
    {
        public CashedAmountsWindow(ObservableCollection<Tuple<string, double>> cashedAmounts)
        {
            InitializeComponent();
            this.DataContext = new CashedAmountsVM(cashedAmounts);
        }
    }
}
