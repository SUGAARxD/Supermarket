using SupermarketApp.Model;
using SupermarketApp.View;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    internal class CashierVM : BaseNotify
    {
        public CashierVM()
        {

        }

        public CashierVM(Theme myTheme)
        {
            MyTheme = myTheme;
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

            Application.Current.Windows.OfType<CashierWindow>().FirstOrDefault().Close();

        }

        #endregion

    }
}
