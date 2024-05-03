using SupermarketApp.ViewModel;

namespace SupermarketApp.Model
{
    internal class CashierSearchStockModel : BaseNotify
    {
        public CashierSearchStockModel()
        {
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
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
                NotifyPropertyChanged(nameof(ProducerName));
            }
        }

    }
}
