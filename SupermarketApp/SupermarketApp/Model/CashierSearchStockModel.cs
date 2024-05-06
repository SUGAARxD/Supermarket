using SupermarketApp.Model.BusinessLogicLayer;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SupermarketApp.Model
{
    internal class CashierSearchStockModel : BaseNotify
    {
        public CashierSearchStockModel()
        {
            ResetSuggestionsListboxesVisibility();
        }

        #region Properties and members

        private readonly ProductsBLL _productsBLL= new ProductsBLL();
        private readonly ProducersBLL _producersBLL = new ProducersBLL();
        private readonly CategoriesBLL _categoriesBLL= new CategoriesBLL();

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;

                UpdateSuggestions(_productsBLL.GetAllProductsName(), _productName);

                IsProductNameListBoxVisible = (string.IsNullOrEmpty(value) || Suggestions.Count() == 0) ? Visibility.Hidden : Visibility.Visible;
                IsProductBarcodeListBoxVisible = Visibility.Hidden;
                IsCategoryNameListBoxVisible = Visibility.Hidden;
                IsProducerNameListBoxVisible = Visibility.Hidden;

                NotifyPropertyChanged(nameof(ProductName));
            }
        }

        private string _productBarcode;
        public string ProductBarcode
        {
            get => _productBarcode;
            set
            {
                _productBarcode = value;

                UpdateSuggestions(_productsBLL.GetAllProductsBarcode(), _productBarcode);

                IsProductNameListBoxVisible = Visibility.Hidden;
                IsProductBarcodeListBoxVisible = (string.IsNullOrEmpty(value) || Suggestions.Count() == 0) ? Visibility.Hidden : Visibility.Visible;
                IsCategoryNameListBoxVisible = Visibility.Hidden;
                IsProducerNameListBoxVisible = Visibility.Hidden;

                NotifyPropertyChanged(nameof(ProductBarcode));
            }
        }

        private string _stockExpirationDate;
        public string StockExpirationDate
        {
            get => _stockExpirationDate;
            set
            {
                _stockExpirationDate = value;
                NotifyPropertyChanged(nameof(StockExpirationDate));
            }
        }

        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;

                UpdateSuggestions(_categoriesBLL.GetAllCategoriesName(), _categoryName);

                IsProductNameListBoxVisible = Visibility.Hidden;
                IsProductBarcodeListBoxVisible = Visibility.Hidden;
                IsCategoryNameListBoxVisible = (string.IsNullOrEmpty(value) || Suggestions.Count() == 0) ? Visibility.Hidden : Visibility.Visible;
                IsProducerNameListBoxVisible = Visibility.Hidden;

                NotifyPropertyChanged(nameof(CategoryName));
            }
        }

        private string _producerName;
        public string ProducerName
        {
            get => _producerName;
            set
            {
                _producerName = value;

                UpdateSuggestions(_producersBLL.GetAllProducersName(), _producerName);

                IsProductNameListBoxVisible = Visibility.Hidden;
                IsProductBarcodeListBoxVisible = Visibility.Hidden;
                IsCategoryNameListBoxVisible = Visibility.Hidden;
                IsProducerNameListBoxVisible = (string.IsNullOrEmpty(value) || Suggestions.Count() == 0) ? Visibility.Hidden : Visibility.Visible;

                NotifyPropertyChanged(nameof(ProducerName));
            }
        }
        public ObservableCollection<string> Suggestions { get; set; } = new ObservableCollection<string>();

        private Visibility _isProductNameListBoxVisible;
        public Visibility IsProductNameListBoxVisible
        {
            get => _isProductNameListBoxVisible;
            set
            {
                _isProductNameListBoxVisible = value;
                NotifyPropertyChanged(nameof(IsProductNameListBoxVisible));
            }
        }
        public string SelectedProductNameListBoxItem
        {
            get => null;
            set
            {
                _productName = value;
                NotifyPropertyChanged(nameof(ProductName));

                IsProductNameListBoxVisible = Visibility.Hidden;
            }
        }

        private Visibility _isProductBarcodeListBoxVisible;
        public Visibility IsProductBarcodeListBoxVisible
        {
            get => _isProductBarcodeListBoxVisible;
            set
            {
                _isProductBarcodeListBoxVisible = value;
                NotifyPropertyChanged(nameof(IsProductBarcodeListBoxVisible));
            }
        }
        public string SelectedProductBarcodeListBoxItem
        {
            get => null;
            set
            {
                _productBarcode = value;
                NotifyPropertyChanged(nameof(ProductBarcode));

                IsProductBarcodeListBoxVisible = Visibility.Hidden;
            }
        }

        private Visibility _isCategoryNameListBoxVisible;
        public Visibility IsCategoryNameListBoxVisible
        {
            get => _isCategoryNameListBoxVisible;
            set
            {
                _isCategoryNameListBoxVisible = value;
                NotifyPropertyChanged(nameof(IsCategoryNameListBoxVisible));
            }
        }
        public string SelectedCategoryNameListBoxItem
        {
            get => null;
            set
            {
                _categoryName = value;
                NotifyPropertyChanged(nameof(CategoryName));

                IsCategoryNameListBoxVisible = Visibility.Hidden;
            }
        }

        private Visibility _isProducerNameListBoxVisible;
        public Visibility IsProducerNameListBoxVisible
        {
            get => _isProducerNameListBoxVisible;
            set
            {
                _isProducerNameListBoxVisible = value;
                NotifyPropertyChanged(nameof(IsProducerNameListBoxVisible));
            }
        }
        public string SelectedProducerNameListBoxItem
        {
            get => null;
            set
            {
                _producerName = value;
                NotifyPropertyChanged(nameof(ProducerName));

                IsProducerNameListBoxVisible = Visibility.Hidden;
            }
        }

        #endregion

        #region Methods

        public bool IsOneFieldNotEmpty()
        {
            return !string.IsNullOrEmpty(ProductName)
                || !string.IsNullOrEmpty(ProductBarcode)
                || !string.IsNullOrEmpty(StockExpirationDate)
                || !string.IsNullOrEmpty(CategoryName)
                || !string.IsNullOrEmpty(ProducerName);
        }

        private void UpdateSuggestions(ObservableCollection<string> items, string match)
        {
            Suggestions.Clear();
            if (string.IsNullOrEmpty(match))
                return;

            items.Where(item => item.ToLower().Contains(match.ToLower()))
                 .ToList()
                 .ForEach(item =>
                 {
                     Suggestions.Add(item);
                 });
        }

        public void ResetSuggestionsListboxesVisibility()
        {
            IsProductNameListBoxVisible = Visibility.Hidden;
            IsProductBarcodeListBoxVisible = Visibility.Hidden;
            IsCategoryNameListBoxVisible = Visibility.Hidden;
            IsProducerNameListBoxVisible = Visibility.Hidden;
        }

        public void ResetFields()
        {
            ProductName = string.Empty;
            ProductBarcode = string.Empty;
            StockExpirationDate = string.Empty;
            CategoryName = string.Empty;
            ProducerName = string.Empty;
        }
        #endregion

    }
}
