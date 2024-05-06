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
        public string Unit { get; set; }
        public string SupplyDate { get; set; }
        public string ExpirationDate { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
        public float VAT { get; set; }
        public Product Product { get; set; }

        #endregion

    }
}
