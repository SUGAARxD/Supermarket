using SupermarketApp.ViewModel;

namespace SupermarketApp.Model.EntityLayer
{
    internal class Stock : BaseNotify
    {

        #region Properties and members

        public int Id { get; set; }
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                NotifyPropertyChanged(nameof(Quantity));
            }
        }

        private string _unit;
        public string Unit
        {
            get => _unit;
            set
            {
                _unit = value;
                NotifyPropertyChanged(nameof(Unit));
            }
        }

        private string _supplyDate;
        public string SupplyDate
        {
            get => _supplyDate;
            set
            {
                _supplyDate = value;
                NotifyPropertyChanged(nameof(SupplyDate));
            }
        }

        private string _expirationDate;
        public string ExpirationDate
        {
            get => _expirationDate;
            set
            {
                _expirationDate = value;
                NotifyPropertyChanged(nameof(ExpirationDate));
            }
        }

        private float _purchasePrice;
        public float PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                _purchasePrice = value;
                NotifyPropertyChanged(nameof(PurchasePrice));
            }
        }

        private float _salePrice;
        public float SalePrice
        {
            get => _salePrice;
            set
            {
                _salePrice = value;
                NotifyPropertyChanged(nameof(SalePrice));
            }
        }

        private float _vat;
        public float VAT
        {
            get => _vat;
            set
            {
                _vat = value;
                NotifyPropertyChanged(nameof(VAT));
            }
        }

        private Product _product;
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                NotifyPropertyChanged(nameof(Product));
            }
        }

        #endregion

        #region Methods

        public void ResetStockProperties()
        {
            Id = -1;
            Quantity = 0;
            Unit = string.Empty;
            SupplyDate = string.Empty;
            ExpirationDate = string.Empty;
            PurchasePrice = 0;
            SalePrice = 0;
            VAT = 0;
            Product = null;
        }

        #endregion

    }
}
