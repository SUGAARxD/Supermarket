using SupermarketApp.Model;
using SupermarketApp.Model.BusinessLogicLayer;
using SupermarketApp.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel 
{
    internal class ProductsManagerVM : BaseNotify
    {
        public ProductsManagerVM()
        {
        }
        public ProductsManagerVM(Theme myTheme)
        {
            MyTheme = myTheme;
        }

        #region Properties and members

        ProductsBLL _productsBLL = new ProductsBLL();

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

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

        private Product _selectedProduct;
        public Product SelectedProduct
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

        private ICommand _getActiveProductsCommand;
        public ICommand GetActiveProductsCommand
        {
            get
            {
                if (_getActiveProductsCommand == null)
                    _getActiveProductsCommand = new RelayCommand(GetActiveProducts);
                return _getActiveProductsCommand;
            }
        }
        private void GetActiveProducts(object parameter)
        {
            try
            {
                _productsBLL.GetAllActiveProducts(Products);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _getInctiveProductsCommand;
        public ICommand GetInactiveProductsCommand
        {
            get
            {
                if (_getInctiveProductsCommand == null)
                    _getInctiveProductsCommand = new RelayCommand(GetInactiveProducts);
                return _getInctiveProductsCommand;
            }
        }
        private void GetInactiveProducts(object parameter)
        {
            try
            {
                _productsBLL.GetAllInactiveProducts(Products);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

    }
}
