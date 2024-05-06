using SupermarketApp.ViewModel;

namespace SupermarketApp.Model.EntityLayer
{
    internal class Receipt : BaseNotify
    {

        #region Properties and members

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged(nameof(Id));
            }
        }

        private string _issuanceDate;
        public string IssuanceDate
        {
            get => _issuanceDate;
            set
            {
                _issuanceDate = value;
                NotifyPropertyChanged(nameof(IssuanceDate));
            }
        }

        private double _total = 0;
        public double Total
        {
            get => _total;
            set
            {
                _total = value;
                NotifyPropertyChanged(nameof(Total));
            }
        }

        private User _cashier;
        public User Cashier
        {
            get => _cashier;
            set
            {
                _cashier = value;
                NotifyPropertyChanged(nameof(Cashier));
            }
        }

        #endregion

    }
}
