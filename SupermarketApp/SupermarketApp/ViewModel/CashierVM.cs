using SupermarketApp.Model;
using SupermarketApp.Model.BusinessLogicLayer;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    internal class CashierVM : BaseNotify
    {
        public CashierVM()
        {

        }

        public CashierVM(Theme myTheme)
        {
            MyTheme = myTheme;
            ProductsList = new ObservableCollection<StockReceipt>();
        }

        #region Properties and members
        
        public ObservableCollection<StockReceipt> ProductsList { get; set; }
        
        private readonly StocksBLL _stocksBLL = new StocksBLL();

        private Receipt _receipt;
        public Receipt Receipt
        {
            get => _receipt;
            set
            {
                _receipt = value;
                NotifyPropertyChanged(nameof(Receipt));
            }
        }

        private Theme _myTheme;
        public Theme MyTheme
        {
            get => _myTheme;
            set
            {
                _myTheme = value;
                NotifyPropertyChanged(nameof(MyTheme));
            }
        }

        private CashierSearchStockModel _cashierSearchStock = new CashierSearchStockModel();
        public CashierSearchStockModel CashierSearchStock
        {
            get => _cashierSearchStock;
            set
            {
                _cashierSearchStock = value;
                NotifyPropertyChanged(nameof(CashierSearchStock));
            }
        }

        private Stock _searchedStock;
        public Stock SearchedStock
        {
            get => _searchedStock;
            set
            {
                _searchedStock = value;
                NotifyPropertyChanged(nameof(SearchedStock));
            }
        }

        #endregion

        #region Commands

        private ICommand _goBackCommand;
        public ICommand GoBackCommand
        {
            get
            {
                if (_goBackCommand == null)
                    _goBackCommand = new RelayCommand(GoBackToLoginWindow);
                return _goBackCommand;
            }
        }
        private void GoBackToLoginWindow(object parameter)
        {
            LoginWindow loginWindow = new LoginWindow(_myTheme);
            loginWindow.Show();

            Application.Current.Windows.OfType<CashierWindow>().FirstOrDefault().Close();

        }

        private ICommand _searchStockCommand;
        public ICommand SearchStockCommand
        {
            get
            {
                if (_searchStockCommand == null)
                    _searchStockCommand = new RelayCommand(SearchStock);
                return _searchStockCommand;
            }
        }
        private void SearchStock(object parameter)
        {
            try 
            {
                SearchedStock = _stocksBLL.GetStock(CashierSearchStock);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _clearDateCommand;
        public ICommand _ClearDateCommand
        {
            get
            {
                if (_clearDateCommand == null)
                    _clearDateCommand = new RelayCommand(ClearDate);
                return _clearDateCommand;
            }
        }
        private void ClearDate(object parameter)
        {
            CashierSearchStock.StockExpirationDate = null;
        }

        #endregion

    }
}
