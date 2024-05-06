using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SupermarketApp.Model;
using SupermarketApp.Model.BusinessLogicLayer;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.Utilities;
using SupermarketApp.View;

namespace SupermarketApp.ViewModel
{
    internal class LoginVM : BaseNotify
    {
        public LoginVM()
        {
            _myTheme = new Theme();
            FileHelper.InitTheme(ref _myTheme);
            MyTheme = _myTheme;

            Init();
        }

        public LoginVM(Theme theme)
        {
            MyTheme = theme;

            Init();
        }

        #region Properties and members

        private UsersBLL _usersBLL = new UsersBLL();

        private ObservableCollection<User> UsersList
        {
            get => _usersBLL.UsersList;
            set => _usersBLL.UsersList = value;
        }

        private User _user;
        public string Username
        {
            get
            {
                return _user.Username;
            }
            set
            {
                _user.Username = value;
            }
        }
        public string Password
        {
            get
            {
                return _user.Password;
            }
            set
            {
                _user.Password = value;
            }
        }

        public ObservableCollection<string> UserTypes { get; set; }
        public string UserType 
        {
            get => _user.UserType;
            set
            {
                _user.UserType = value;
            }
        }

        private Theme _myTheme;
        public Theme MyTheme
        {
            get => _myTheme;
            set
            {
                _myTheme = value;
                NotifyPropertyChanged(nameof(MyTheme));
            }
        }

        #endregion

        #region Commands

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand(ExecuteLogin, CanLogin);
                return _loginCommand;
            }
        }
        private void ExecuteLogin(object parameter)
        {
            if (_usersBLL.ExistsUser(_user))
            {
                if (UserType == "Administrator")
                {

                    AdministrationWindow administrationWindow = new AdministrationWindow(_myTheme, _user);
                    administrationWindow.Show();

                }
                else if (UserType == "Cashier")
                {

                    CashierWindow cashierWindow = new CashierWindow(_myTheme, _user);
                    cashierWindow.Show();

                }

                Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault().Close();
                return;
            }
            MessageBox.Show("User does not exist!");
        }
        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrEmpty(UserType);
        }

        #endregion

        #region Methods

        private void Init()
        {
            _user = new User();

            UserTypes = new ObservableCollection<string>
            {
                "Administrator",
                "Cashier"
            };
        }

        #endregion

    }
}
