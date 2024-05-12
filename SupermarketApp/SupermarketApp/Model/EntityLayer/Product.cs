using SupermarketApp.ViewModel;

namespace SupermarketApp.Model.EntityLayer
{
    public class Product : BaseNotify
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

        private string _barcode;
        public string Barcode
        {
            get => _barcode;
            set
            {
                _barcode = value;
                NotifyPropertyChanged(nameof(Barcode));
            }
        }

        private Category _category;
        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                NotifyPropertyChanged(nameof(Category));
            }
        }

        private Producer _producer;
        public Producer Producer
        {
            get => _producer;
            set
            {
                _producer = value;
                NotifyPropertyChanged(nameof(Producer));
            }
        }

        #endregion

        #region Methods

        public string DisplayValue
        {
            get { return $"{Name}\n{Barcode}"; }
        }

        #endregion

    }
}
