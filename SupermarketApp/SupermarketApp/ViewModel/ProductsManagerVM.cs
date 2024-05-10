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
            _producersBLL.GetAllActiveProducers(Producers);
            Producers.Insert(0, new Producer { Id = -1, Name = "", Country = "" });
            _categoriesBLL.GetAllActiveCategories(Categories);
            Categories.Insert(0, new Category { Id = -1, Name = "" });
        }

        #region Properties and members

        readonly ProductsBLL _productsBLL = new ProductsBLL();
        readonly ProducersBLL _producersBLL = new ProducersBLL();
        readonly CategoriesBLL _categoriesBLL = new CategoriesBLL();

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

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;

                if (_selectedProduct != null)
                {
                    DummyProduct.Id = _selectedProduct.Id;
                    DummyProduct.Name = _selectedProduct.Name;
                    DummyProduct.Barcode = _selectedProduct.Barcode;
                    DummyProduct.Category = new Category
                    {
                        Id = _selectedProduct.Category.Id,
                        Name = _selectedProduct.Category.Name
                    };
                    DummyProduct.Producer = new Producer
                    {
                        Id = _selectedProduct.Producer.Id,
                        Name = _selectedProduct.Producer.Name,
                        Country = _selectedProduct.Producer.Country
                    };
                }

                NotifyPropertyChanged(nameof(SelectedProduct));
            }
        }

        private Product _dummyProduct = new Product();
        public Product DummyProduct
        {
            get => _dummyProduct;
            set
            {
                _dummyProduct = value;
                NotifyPropertyChanged(nameof(DummyProduct));
            }
        }

        public ObservableCollection<Producer> Producers { get; set; } = new ObservableCollection<Producer>();
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

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
                Clear();
                _productsBLL.GetAllActiveProducts(Products);
                ActiveOrInactive = "Active";
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
                Clear();
                _productsBLL.GetAllInactiveProducts(Products);
                ActiveOrInactive = "Inactive";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _modifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                if (_modifyCommand == null)
                    _modifyCommand = new RelayCommand(Modify, CanModify);
                return _modifyCommand;
            }
        }
        private void Modify(object parameter)
        {
            try
            {
                _productsBLL.UpdateProduct(DummyProduct);
                SelectedProduct.Name = DummyProduct.Name;
                SelectedProduct.Barcode = DummyProduct.Barcode;
                SelectedProduct.Category = DummyProduct.Category;
                SelectedProduct.Producer = DummyProduct.Producer;
                Clear();
                MessageBox.Show("Update successfully!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool CanModify(object parameter)
        {
            return SelectedProduct != null
                && (SelectedProduct.Name != DummyProduct.Name
                || SelectedProduct.Barcode != DummyProduct.Barcode
                || SelectedProduct.Category.Id != DummyProduct.Category.Id
                || SelectedProduct.Producer.Id != DummyProduct.Producer.Id);
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
                    _addCommand = new RelayCommand(AddProduct);
                return _addCommand;
            }
        }
        private void AddProduct(object parameter)
        {
            try
            {
                _productsBLL.AddProduct(DummyProduct);
                MessageBox.Show("Product added successfully!");
                if (ActiveOrInactive.Equals("Active"))
                    _productsBLL.GetAllActiveProducts(Products);
                else if (ActiveOrInactive.Equals("Inactive"))
                    _productsBLL.GetAllInactiveProducts(Products);
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
                    _deleteCommand = new RelayCommand(DeleteProduct, CanDelete);
                return _deleteCommand;
            }
        }
        private void DeleteProduct(object parameter)
        {
            _productsBLL.DeleteProduct(SelectedProduct);
            Products.Remove(SelectedProduct);
        }

        private bool CanDelete(object parameter)
        {
            return SelectedProduct != null && ActiveOrInactive.Equals("Active");
        }

        #endregion

        #region Methods

        private void Clear()
        {
            SelectedProduct = null;
            DummyProduct.Name = "";
            DummyProduct.Barcode = "";
            DummyProduct.Category = null;
            DummyProduct.Producer = null;
            DummyProduct.Id = -1;

        }

        #endregion

    }
}
