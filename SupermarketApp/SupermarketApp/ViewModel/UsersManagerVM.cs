using SupermarketApp.Model;
using SupermarketApp.Model.BusinessLogicLayer;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    internal class UsersManagerVM : BaseNotify
    {
        public UsersManagerVM()
        {
        }
        public UsersManagerVM(Theme myTheme)
        {
            MyTheme = myTheme;
            UserTypes = new ObservableCollection<string>
            {
                "Administrator",
                "Cashier"
            };
            Months = new ObservableCollection<string>
            {
                "",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12"
            };
            Years = new ObservableCollection<string>
            {
                ""
            };
            for (int year = DateTime.Now.Date.Year; year >= DateTime.Now.Date.Year - 100; --year)
            {
                Years.Add(year.ToString());
            }
        }

        #region Properties and members

        readonly UsersBLL _userBLL = new UsersBLL();

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<string> UserTypes { get; set; }
        public ObservableCollection<string> Months { get; set; }

        public ObservableCollection<string> Years { get; set; }

        private string ActiveOrInactive = " ";

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

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;

                if (_selectedUser != null)
                {
                    DummyUser.Id = _selectedUser.Id;
                    DummyUser.Username = _selectedUser.Username;
                    DummyUser.Password = _selectedUser.Password;
                    DummyUser.UserType = _selectedUser.UserType;
                }

                NotifyPropertyChanged(nameof(SelectedUser));
            }
        }

        private User _dummyUser = new User();
        public User DummyUser
        {
            get => _dummyUser;
            set
            {
                _dummyUser = value;
                NotifyPropertyChanged(nameof(DummyUser));
            }
        }

        private string _reportMonth;
        public string ReportMonth
        {
            get => _reportMonth;
            set
            {
                _reportMonth = value;
                NotifyPropertyChanged(nameof(ReportMonth));
            }
        }

        private string _reportYear;
        public string ReportYear
        {
            get => _reportYear;
            set
            {
                _reportYear = value;
                NotifyPropertyChanged(nameof(ReportYear));
            }
        }

        #endregion

        #region Commands

        private ICommand _getActiveUsersCommand;
        public ICommand GetActiveUsersCommand
        {
            get
            {
                if (_getActiveUsersCommand == null)
                    _getActiveUsersCommand = new RelayCommand(GetActiveUsers);
                return _getActiveUsersCommand;
            }
        }
        private void GetActiveUsers(object parameter)
        {
            try
            {
                Clear();
                _userBLL.GetAllActiveUsers(Users);
                ActiveOrInactive = "Active";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _getInctiveUsersCommand;
        public ICommand GetInactiveUsersCommand
        {
            get
            {
                if (_getInctiveUsersCommand == null)
                    _getInctiveUsersCommand = new RelayCommand(GetInactiveUsers);
                return _getInctiveUsersCommand;
            }
        }
        private void GetInactiveUsers(object parameter)
        {
            try
            {
                Clear();
                _userBLL.GetAllInactiveUsers(Users);
                ActiveOrInactive = "Inactive";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _modifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                if (_modifyCommand == null)
                    _modifyCommand = new RelayCommand(Modify, CanModify);
                return _modifyCommand;
            }
        }
        private void Modify(object parameter)
        {
            try
            {
                _userBLL.UpdateUser(DummyUser);
                SelectedUser.Username = DummyUser.Username;
                SelectedUser.Password = DummyUser.Password;
                SelectedUser.UserType = DummyUser.UserType;
                Clear();
                MessageBox.Show("Update successfully!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool CanModify(object parameter)
        {
            return SelectedUser != null
                && !string.IsNullOrEmpty(DummyUser.Username)
                && !string.IsNullOrEmpty(DummyUser.UserType)
                && !string.IsNullOrEmpty(DummyUser.Password);
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                    _clearCommand = new RelayCommand(ClearFields);
                return _clearCommand;
            }
        }
        private void ClearFields(object parameter)
        {
            Clear();
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(AddCategory);
                return _addCommand;
            }
        }
        private void AddCategory(object parameter)
        {
            try
            {
                _userBLL.AddUser(DummyUser);
                MessageBox.Show("User added successfully!");
                if (ActiveOrInactive.Equals("Active"))
                    _userBLL.GetAllActiveUsers(Users);
                else if (ActiveOrInactive.Equals("Inactive"))
                    _userBLL.GetAllInactiveUsers(Users);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(DeleteUser, CanDelete);
                return _deleteCommand;
            }
        }
        private void DeleteUser(object parameter)
        {
            _userBLL.DeleteUser(SelectedUser);
            Users.Remove(SelectedUser);
        }

        private bool CanDelete(object parameter)
        {
            return SelectedUser != null && ActiveOrInactive.Equals("Active");
        }

        private ICommand _showCashedAmountsCommand;
        public ICommand ShowCashedAmountsCommand
        {
            get
            {
                if (_showCashedAmountsCommand == null)
                    _showCashedAmountsCommand = new RelayCommand(ShowCashedAmounts);
                return _showCashedAmountsCommand;
            }
        }
        private void ShowCashedAmounts(object parameter)
        {
            try
            {
                ObservableCollection<Tuple<string, double>> cashedAmounts = _userBLL.GetCashedAmounts(SelectedUser, ReportMonth, ReportYear);
                CashedAmountsWindow cashedAmountsWindow = new CashedAmountsWindow(cashedAmounts);
                cashedAmountsWindow.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _showPasswordCommand;
        public ICommand ShowPasswordCommand
        {
            get
            {
                if (_showPasswordCommand == null)
                    _showPasswordCommand = new RelayCommand(ShowPassword);
                return _showPasswordCommand;
            }
        }
        private void ShowPassword(object parameter)
        {
            if (string.IsNullOrEmpty(DummyUser.Password))
                MessageBox.Show("No password");
            else
                MessageBox.Show("The password is: " + DummyUser.Password);
        }

        private ICommand _addPasswordCommand;
        public ICommand AddPasswordCommand
        {
            get
            {
                if (_addPasswordCommand == null)
                    _addPasswordCommand = new RelayCommand(AddPassword);
                return _addPasswordCommand;
            }
        }
        private void AddPassword(object parameter)
        {
            DialogBox dialogBox = new DialogBox("Enter the password", "Add");
            dialogBox.ShowDialog();
            DummyUser.Password = dialogBox.GetText();
        }

        #endregion

        #region Methods

        private void Clear()
        {
            SelectedUser = null;
            DummyUser.Username = "";
            DummyUser.UserType = null;
            DummyUser.Password = "";
            DummyUser.Id = -1;
            ReportMonth = "";
            ReportYear = "";
        }

        #endregion

    }
}
