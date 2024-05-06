using SupermarketApp.Model;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    internal class AdministrationVM : BaseNotify
    {

        public AdministrationVM()
        {

        }

        public AdministrationVM(Theme myTheme, User user)
        {
            MyTheme = myTheme;
            _user = user;
        }

        #region Properties and members

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

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                NotifyPropertyChanged(nameof(User));
            }
        }



        #endregion

        #region Commands

        private ICommand _goBackCommand;
        public ICommand GoBackCommand
        {
            get
            {
                if (_goBackCommand == null)
                    _goBackCommand = new RelayCommand(GoBackToLoginWindow);
                return _goBackCommand;
            }
        }
        private void GoBackToLoginWindow(object parameter)
        {
            LoginWindow loginWindow = new LoginWindow(_myTheme);
            loginWindow.Show();

            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Close();

        }

        #endregion

    }
}
