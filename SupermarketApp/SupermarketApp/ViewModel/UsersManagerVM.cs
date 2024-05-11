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
        }

        #region Properties and members

        readonly UsersBLL _userBLL = new UsersBLL();

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<string> UserTypes { get; set; }

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

        private string _reportDate;
        public string ReportDate
        {
            get => _reportDate;
            set
            {
                _reportDate = value;
                NotifyPropertyChanged(nameof(ReportDate));
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

        private ICommand _showReportCommand;
        public ICommand ShowReportCommand
        {
            get
            {
                if (_showReportCommand == null)
                    _showReportCommand = new RelayCommand(ShowReceiptReport);
                return _showReportCommand;
            }
        }
        private void ShowReceiptReport(object parameter)
        {
            try
            {
                ObservableCollection<Product> products = _userBLL.GetReceiptReport(SelectedUser, ReportDate);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _clearDateCommand;
        public ICommand ClearDateCommand
        {
            get
            {
                if (_clearDateCommand == null)
                    _clearDateCommand = new RelayCommand(ClearDate);
                return _clearDateCommand;
            }
        }
        private void ClearDate(object parameter)
        {
            ReportDate = "";
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
            ReportDate = "";
        }

        #endregion

    }
}
