using SupermarketApp.Model;
using SupermarketApp.Model.BusinessLogicLayer;
using SupermarketApp.Model.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using System.Windows.Input;
using System.Linq;
using SupermarketApp.View;

namespace SupermarketApp.ViewModel
{
    internal class StocksManagerVM : BaseNotify
    {
        public StocksManagerVM()
        {
        }
        public StocksManagerVM(Theme myTheme)
        {
            MyTheme = myTheme;
            Init();
        }

        #region Properties and members

        readonly StocksBLL _stocksBLL = new StocksBLL();

        public ObservableCollection<Stock> Stocks { get; set; } = new ObservableCollection<Stock>();
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        private string ActiveOrInactive = " ";

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

        private Stock _selectedStock;
        public Stock SelectedStock
        {
            get => _selectedStock;
            set
            {
                _selectedStock = value;

                if (_selectedStock != null)
                {
                    DummyStock.Id = _selectedStock.Id;
                    DummyStock.Quantity = _selectedStock.Quantity;
                    Quantity = _selectedStock.Quantity.ToString();
                    DummyStock.Unit = _selectedStock.Unit;
                    DummyStock.SupplyDate = _selectedStock.SupplyDate;
                    DummyStock.ExpirationDate = _selectedStock.ExpirationDate;
                    DummyStock.PurchasePrice = _selectedStock.PurchasePrice;
                    PurchasePrice = _selectedStock.PurchasePrice.ToString();
                    DummyStock.SalePrice = _selectedStock.SalePrice;
                    DummyStock.VAT = _selectedStock.VAT;
                    VAT = _selectedStock.VAT.ToString();
                    DummyStock.Product = _selectedStock.Product;
                }

                NotifyPropertyChanged(nameof(SelectedStock));
            }
        }

        private Stock _dummyStock = new Stock();
        public Stock DummyStock
        {
            get => _dummyStock;
            set
            {
                _dummyStock = value;
                NotifyPropertyChanged(nameof(DummyStock));
            }
        }

        private string _quantity;
        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                NotifyPropertyChanged(nameof(Quantity));
            }
        }

        private string _purchasePrice;
        public string PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                _purchasePrice = value;
                NotifyPropertyChanged(nameof(PurchasePrice));
            }
        }

        private string _vat;
        public string VAT
        {
            get => _vat;
            set
            {
                _vat = value;
                NotifyPropertyChanged(nameof(VAT));
            }
        }

        #endregion

        #region Commands

        private ICommand _getActiveStocksCommand;
        public ICommand GetActiveStocksCommand
        {
            get
            {
                if (_getActiveStocksCommand == null)
                    _getActiveStocksCommand = new RelayCommand(GetActiveStocks);
                return _getActiveStocksCommand;
            }
        }
        private void GetActiveStocks(object parameter)
        {
            try
            {
                Clear();
                _stocksBLL.GetAllActiveStocks(Stocks);
                ActiveOrInactive = "Active";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _getInctiveStocksCommand;
        public ICommand GetInactiveStocksCommand
        {
            get
            {
                if (_getInctiveStocksCommand == null)
                    _getInctiveStocksCommand = new RelayCommand(GetInactiveStocks);
                return _getInctiveStocksCommand;
            }
        }
        private void GetInactiveStocks(object parameter)
        {
            try
            {
                Clear();
                _stocksBLL.GetAllInactiveStocks(Stocks);
                ActiveOrInactive = "Inactive";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                    _clearCommand = new RelayCommand(ClearFields);
                return _clearCommand;
            }
        }
        private void ClearFields(object parameter)
        {
            Clear();
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(AddStock);
                return _addCommand;
            }
        }
        private void AddStock(object parameter)
        {
            try
            {
                DummyStock.Quantity = int.Parse(Quantity);
                DummyStock.PurchasePrice = float.Parse(PurchasePrice);
                DummyStock.VAT = float.Parse(VAT);
                _stocksBLL.AddStock(DummyStock);
                MessageBox.Show("Stock added successfully!");
                if (ActiveOrInactive.Equals("Active"))
                    _stocksBLL.GetAllActiveStocks(Stocks);
                else if (ActiveOrInactive.Equals("Inactive"))
                    _stocksBLL.GetAllInactiveStocks(Stocks);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(DeleteStock, CanDelete);
                return _deleteCommand;
            }
        }
        private void DeleteStock(object parameter)
        {
            _stocksBLL.DeleteStock(SelectedStock);
            Stocks.Remove(SelectedStock);
        }

        private bool CanDelete(object parameter)
        {
            return SelectedStock != null && ActiveOrInactive.Equals("Active");
        }

        private ICommand _clearSupplyDateCommand;
        public ICommand ClearSupplyDateCommand
        {
            get
            {
                if (_clearSupplyDateCommand == null)
                    _clearSupplyDateCommand = new RelayCommand(ClearSupplyDate);
                return _clearSupplyDateCommand;
            }
        }
        private void ClearSupplyDate(object parameter)
        {
            DummyStock.SupplyDate = null;
        }

        private ICommand _clearExpirationDateCommand;
        public ICommand ClearExpirationDateCommand
        {
            get
            {
                if (_clearExpirationDateCommand == null)
                    _clearExpirationDateCommand = new RelayCommand(ClearExpirationDate);
                return _clearExpirationDateCommand;
            }
        }
        private void ClearExpirationDate(object parameter)
        {
            DummyStock.ExpirationDate = null;
        }

        private ICommand _modifyVATCommand;
        public ICommand ModifyVATCommand
        {
            get
            {
                if (_modifyVATCommand == null)
                    _modifyVATCommand = new RelayCommand(ModifyVAT);
                return _modifyVATCommand;
            }
        }
        private void ModifyVAT(object parameter)
        {
            try
            {
                if (SelectedStock == null)
                    throw new Exception("Select a stock first!");
                DialogBox dialogBox = new DialogBox("Specify VAT", "Select");
                dialogBox.ShowDialog();
                double vat = double.Parse(dialogBox.GetText());

                _stocksBLL.UpdateVAT(DummyStock, vat);

                Stock UpdatedStock = _stocksBLL.GetStock(DummyStock.Id);

                SelectedStock.SalePrice = UpdatedStock.SalePrice;
                SelectedStock.VAT = UpdatedStock.VAT;
                Clear();
                MessageBox.Show("Update successfully!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region Methods

        private void Clear()
        {
            SelectedStock = null;
            DummyStock.ResetStockProperties();
            Quantity = string.Empty;
            VAT = string.Empty;
            PurchasePrice = string.Empty;
        }

        private void Init()
        {
            try
            {
                ProductsBLL productsBLL = new ProductsBLL();
                ObservableCollection<Product> products = new ObservableCollection<Product>();
                productsBLL.GetAllActiveProducts(products);
                foreach (var item in products.OrderBy(item => item.Name).ThenBy(item => item.Barcode))
                {
                    Products.Add(item);
                };
            }
            catch (Exception)
            {
            }
        }

        #endregion

    }
}
