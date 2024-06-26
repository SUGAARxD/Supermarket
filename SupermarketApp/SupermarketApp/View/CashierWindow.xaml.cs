﻿using SupermarketApp.Model;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.ComponentModel;
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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (this.DataContext is CashierVM viewModel)
            {
                viewModel.OnWindowClosing();
            }
        }

    }
}
