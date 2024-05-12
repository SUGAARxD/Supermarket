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

        public CashierVM(Theme myTheme, User cashier)
        {
            MyTheme = myTheme;
            ReceiptNumber = "####";
            _cashier = cashier;
        }

        #region Properties and members
        
        public ObservableCollection<StockReceipt> ProductsList { get; set; } = new ObservableCollection<StockReceipt>();

        private readonly StocksBLL _stocksBLL = new StocksBLL();
        private readonly ReceiptsBLL _receiptsBLL = new ReceiptsBLL();

        private User _cashier;

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

        private string _receiptNumber;
        public string ReceiptNumber
        {
            get => _receiptNumber;
            set
            {
                _receiptNumber = value;
                NotifyPropertyChanged(nameof(ReceiptNumber));
            }
        }

        private StockReceipt _selectedProduct;
        public StockReceipt SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                NotifyPropertyChanged(nameof(SelectedProduct));
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
                SearchedStock = null;
                CashierSearchStock.ResetSuggestionsListboxesVisibility();
                if (CashierSearchStock.IsOneFieldNotEmpty())
                    SearchedStock = _stocksBLL.GetFirstSearchedStock(CashierSearchStock);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _clearCommandd;
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommandd == null)
                    _clearCommandd = new RelayCommand(Clear);
                return _clearCommandd;
            }
        }
        private void Clear(object parameter)
        {
            SearchedStock = null;
            CashierSearchStock.ResetSuggestionsListboxesVisibility();
            CashierSearchStock.ResetFields();
        }

        private ICommand _clearDateCommand;
        public ICommand ClearDateCommand
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

        private ICommand _newReceiptCommand;
        public ICommand NewReceiptCommand
        {
            get
            {
                if (_newReceiptCommand == null)
                    _newReceiptCommand = new RelayCommand(CreateNewReceipt, CanCreateNewReceipt);
                return _newReceiptCommand;
            }
        }
        private void CreateNewReceipt(object parameter)
        {
            try
            {
                Receipt = _receiptsBLL.CreateNewReceipt(_cashier);
                ReceiptNumber = Receipt.Id.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private bool CanCreateNewReceipt(object parameter)
        {
            return Receipt == null;
        }

        private ICommand _dropReceiptCommand;
        public ICommand DropReceiptCommand
        {
            get
            {
                if (_dropReceiptCommand == null)
                    _dropReceiptCommand = new RelayCommand(DropCurrentReceipt, CanDropCurrentReceipt);
                return _dropReceiptCommand;
            }
        }
        private void DropCurrentReceipt(object parameter)
        {
            _receiptsBLL.DropReceipt(Receipt);
            Receipt = null;
            ReceiptNumber = "####";
            foreach (var item in ProductsList)
            {
                if (item.Stock.Quantity == 0)
                    _stocksBLL.ActivateStock(item.Stock);
                _stocksBLL.UpdateStockQuantity(item.Stock, item.Stock.Quantity + item.Quantity);
            }
            ProductsList.Clear();
            SearchedStock = null;
        }

        private bool CanDropCurrentReceipt(object parameter)
        {
            return Receipt != null;
        }

        private ICommand _emitReceiptCommand;
        public ICommand EmitReceiptCommand
        {
            get
            {
                if (_emitReceiptCommand == null)
                    _emitReceiptCommand = new RelayCommand(EmitCurrentReceipt, CanEmitCurrentReceipt);
                return _emitReceiptCommand;
            }
        }
        private void EmitCurrentReceipt(object parameter)
        {
            _receiptsBLL.UpdateReceiptTotal(Receipt);
            Receipt = null;
            ReceiptNumber = "####";
            foreach (var item in ProductsList)
            {
                _receiptsBLL.AddReceiptProduct(item);
            }
            ProductsList.Clear();
            SearchedStock = null;
            CashierSearchStock.ResetFields();
            MessageBox.Show("Receipt emitted!");
        }
        private bool CanEmitCurrentReceipt(object parameter)
        {
            return ProductsList.Count > 0;
        }

        private ICommand _addProductCommand;
        public ICommand AddProductCommand
        {
            get
            {
                if (_addProductCommand == null)
                    _addProductCommand = new RelayCommand(AddProductToReceipt);
                return _addProductCommand;
            }
        }
        private void AddProductToReceipt(object parameter)
        {
            if (Receipt == null)
            {
                MessageBox.Show("Create a receipt first!");
                return;
            }
            if (SearchedStock == null)
            {
                MessageBox.Show("Specify what product to add first!");
                return;
            }

            DialogBox dialogBox = new DialogBox("Specify quantity", "Select");
            dialogBox.ShowDialog();
            string quantityString = dialogBox.GetText();

            int quantity = 0;

            if (int.TryParse(quantityString, out quantity))
            {

                if (quantity > SearchedStock.Quantity)
                {
                    MessageBox.Show("Stock levels are insufficient!");
                    return;
                }

                foreach (var item in ProductsList)
                {
                    if (item.Stock.Id == SearchedStock.Id)
                    {
                        if (item.Quantity + quantity <= 0)
                        {
                            if (item.Stock.Quantity == 0)
                                _stocksBLL.ActivateStock(item.Stock);

                            _stocksBLL.UpdateStockQuantity(SearchedStock, SearchedStock.Quantity + item.Quantity);
                            Receipt.Total -= item.Subtotal;
                            Receipt.Total = (float)Math.Round(Receipt.Total, 2);
                            ProductsList.Remove(item);
                        }
                        else
                        {
                            _stocksBLL.UpdateStockQuantity(SearchedStock, SearchedStock.Quantity - quantity);
                            Receipt.Total -= item.Subtotal;
                            item.Quantity += quantity;
                            item.Subtotal = (float)Math.Round(item.Stock.SalePrice * item.Quantity, 2);
                            Receipt.Total += item.Subtotal;
                            Receipt.Total = (float)Math.Round(Receipt.Total, 2);
                            if (SearchedStock.Quantity == 0)
                                SearchedStock = null;
                        }
                        return;
                    }
                }

                if (quantity <= 0)
                {
                    MessageBox.Show("Please add a valid quantity( > 0 ) when adding a new product to the receipt!");
                    return;
                }

                _stocksBLL.UpdateStockQuantity(SearchedStock, SearchedStock.Quantity - quantity);

                StockReceipt stockReceipt = new StockReceipt();
                stockReceipt.Receipt = Receipt;
                stockReceipt.Stock = SearchedStock;
                stockReceipt.Quantity = quantity;
                stockReceipt.Subtotal = (float)Math.Round(SearchedStock.SalePrice * stockReceipt.Quantity, 2);
                Receipt.Total += stockReceipt.Subtotal;
                Receipt.Total = (float)Math.Round(Receipt.Total, 2);
                ProductsList.Add(stockReceipt);
                if (SearchedStock.Quantity == 0)
                    SearchedStock = null;
            }
            else
            {
                MessageBox.Show("Invalid characters!");
            }

        }

        private ICommand _removeProductCommand;
        public ICommand RemoveProductCommand
        {
            get
            {
                if (_removeProductCommand == null)
                    _removeProductCommand = new RelayCommand(RemoveProductFromReceipt);
                return _removeProductCommand;
            }
        }
        private void RemoveProductFromReceipt(object parameter)
        {
            if (SelectedProduct != null)
            {
                foreach (var item in ProductsList)
                {
                    if (item == SelectedProduct)
                    {
                        if (item.Stock.Quantity == 0)
                            _stocksBLL.ActivateStock(item.Stock);

                        _stocksBLL.UpdateStockQuantity(item.Stock, item.Stock.Quantity + item.Quantity);
                        if (SearchedStock != null && SearchedStock.Id == item.Stock.Id)
                        {
                            SearchedStock.Quantity = SearchedStock.Quantity + item.Quantity;
                        }
                        Receipt.Total -= item.Subtotal;
                        ProductsList.Remove(item);
                        MessageBox.Show("Removed successfully!");
                        SelectedProduct = null;
                        return;
                    }
                }
            }
        }
        public void OnWindowClosing()
        {
            if (Receipt != null)
            {
                _receiptsBLL.DropReceipt(Receipt);
                foreach (var item in ProductsList)
                {
                    if (item.Stock.Quantity == 0)
                        _stocksBLL.ActivateStock(item.Stock);
                    _stocksBLL.UpdateStockQuantity(item.Stock, item.Stock.Quantity + item.Quantity);
                }
            }
        }

        #endregion

    }
}
