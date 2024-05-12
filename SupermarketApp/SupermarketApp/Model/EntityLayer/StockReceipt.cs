using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;

namespace SupermarketApp.Model
{
    internal class StockReceipt : BaseNotify
    {

        #region Properties and members

        private Stock _stock;
        public Stock Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                NotifyPropertyChanged(nameof(Stock));
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

        private float _subtotal;
        public float Subtotal
        {
            get => _subtotal;
            set
            {
                _subtotal = value;
                NotifyPropertyChanged(nameof(Subtotal));
            }
        }

        #endregion

    }
}
