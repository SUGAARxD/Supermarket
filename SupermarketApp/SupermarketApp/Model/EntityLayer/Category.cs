using SupermarketApp.ViewModel;

namespace SupermarketApp.Model.EntityLayer
{
    public class Category : BaseNotify
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

        #endregion

    }
}
