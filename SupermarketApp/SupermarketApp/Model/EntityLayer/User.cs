using SupermarketApp.ViewModel;

namespace SupermarketApp.Model.EntityLayer
{
    public class User : BaseNotify
    {

        public User()
        {

        }

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

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                NotifyPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        private string _userType;
        public string UserType
        {
            get => _userType;
            set
            {
                _userType = value;
                NotifyPropertyChanged(nameof(UserType));
            }
        }

        #endregion

    }
}
