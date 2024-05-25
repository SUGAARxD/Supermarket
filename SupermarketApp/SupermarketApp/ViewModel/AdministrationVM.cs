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
            UserLabel = "Wellcome " + user.Username + "!";
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
        public string UserLabel { get; set; }

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

        private ICommand _openProductsManagerWindowCommand;
        public ICommand OpenProductsManagerWindowCommand
        {
            get
            {
                if (_openProductsManagerWindowCommand == null)
                    _openProductsManagerWindowCommand = new RelayCommand(OpenProductsManagerWindow);
                return _openProductsManagerWindowCommand;
            }
        }
        private void OpenProductsManagerWindow(object parameter)
        {
            ProductsManagerWindow productsManagerWindow = new ProductsManagerWindow(_myTheme);

            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Hide();
            
            productsManagerWindow.ShowDialog();
        }

        private ICommand _openProducersManagerWindowCommand;
        public ICommand OpenProducersManagerWindowCommand
        {
            get
            {
                if (_openProducersManagerWindowCommand == null)
                    _openProducersManagerWindowCommand = new RelayCommand(OpenProducersManagerWindow);
                return _openProducersManagerWindowCommand;
            }
        }
        private void OpenProducersManagerWindow(object parameter)
        {
            ProducersManagerWindow producersManagerWindow = new ProducersManagerWindow(_myTheme);

            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Hide();

            producersManagerWindow.ShowDialog();
        }

        private ICommand _openCategoriesManagerWindowCommand;
        public ICommand OpenCategoriesManagerWindowCommand
        {
            get
            {
                if (_openCategoriesManagerWindowCommand == null)
                    _openCategoriesManagerWindowCommand = new RelayCommand(OpenCategoriesManagerWindow);
                return _openCategoriesManagerWindowCommand;
            }
        }
        private void OpenCategoriesManagerWindow(object parameter)
        {
            CategoriesManagerWindow categoriesManagerWindow = new CategoriesManagerWindow(_myTheme);

            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Hide();

            categoriesManagerWindow.ShowDialog();
        }

        private ICommand _openStocksManagerWindowCommand;
        public ICommand OpenStocksManagerWindowCommand
        {
            get
            {
                if (_openStocksManagerWindowCommand == null)
                    _openStocksManagerWindowCommand = new RelayCommand(OpenStocksManagerWindow);
                return _openStocksManagerWindowCommand;
            }
        }
        private void OpenStocksManagerWindow(object parameter)
        {
            StocksManagerWindow stocksManagerWindow = new StocksManagerWindow(_myTheme);

            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Hide();

            stocksManagerWindow.ShowDialog();
        }

        private ICommand _openReceiptsManagerWindowCommand;
        public ICommand OpenReceiptsManagerWindowCommand
        {
            get
            {
                if (_openReceiptsManagerWindowCommand == null)
                    _openReceiptsManagerWindowCommand = new RelayCommand(OpenReceiptsManagerWindow);
                return _openReceiptsManagerWindowCommand;
            }
        }
        private void OpenReceiptsManagerWindow(object parameter)
        {
            ReceiptsManagerWindow receiptsManagerWindow = new ReceiptsManagerWindow(_myTheme);

            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Hide();

            receiptsManagerWindow.ShowDialog();
        }

        private ICommand _openUsersManagerWindowCommand;
        public ICommand OpenUsersManagerWindowCommand
        {
            get
            {
                if (_openUsersManagerWindowCommand == null)
                    _openUsersManagerWindowCommand = new RelayCommand(OpenUsersManagerWindow);
                return _openUsersManagerWindowCommand;
            }
        }
        private void OpenUsersManagerWindow(object parameter)
        {
            UsersManagerWindow usersManagerWindow = new UsersManagerWindow(_myTheme, _user);

            Application.Current.Windows.OfType<AdministrationWindow>().FirstOrDefault().Hide();

            usersManagerWindow.ShowDialog();
        }

        #endregion

    }
}
