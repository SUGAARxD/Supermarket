using SupermarketApp.ViewModel;

namespace SupermarketApp.Model.EntityLayer
{
    internal class Producer : BaseNotify
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

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        private string _country;
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                NotifyPropertyChanged(nameof(Country));
            }
        }

        #endregion

    }
}
