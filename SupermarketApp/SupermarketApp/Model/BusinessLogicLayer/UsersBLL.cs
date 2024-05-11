
using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace SupermarketApp.Model.BusinessLogicLayer
{
    internal class UsersBLL
    {
        
        public UsersBLL()
        {

        }

        #region Properties and members

        UsersDAL usersDAL = new UsersDAL();

        #endregion

        #region Methods

        public bool ExistsUser(User user)
        {
            return usersDAL.ExistsUser(user);
        }

        public void GetAllActiveUsers(ObservableCollection<User> Users)
        {
            usersDAL.GetAllActiveUsers(Users);
            if (Users.Count == 0)
                throw new System.Exception("No active users found!");
        }

        public void GetAllInactiveUsers(ObservableCollection<User> Users)
        {
            usersDAL.GetAllInactiveUsers(Users);
            if (Users.Count == 0)
                throw new System.Exception("No inactive users found!");
        }

        public void UpdateUser(User user)
        {
            try
            {
                VerifyInput(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            if (ExistsUser(user) || usersDAL.ExistsInactiveUser(user))
                throw new Exception("User exists!");

            usersDAL.UpdateUser(user);
        }
        public void AddUser(User user)
        {
            try
            {
                VerifyInput(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ExistsUser(user))
                throw new Exception("User exists!");

            if (usersDAL.ExistsInactiveUser(user))
            {
                usersDAL.ActivateUser(user);
                return;
            }

            usersDAL.AddUser(user);
        }

        private void VerifyInput(User user)
        {
            string stringPattern = @"^[a-zA-Z0-9\s]+(- [a-zA-Z0-9\s]+)?$";
            string passwordPattern = @"^[a-zA-Z0-9!]+$";

            if (string.IsNullOrEmpty(user.Username) 
                ||string.IsNullOrEmpty(user.Password)
                || string.IsNullOrEmpty(user.UserType))
                throw new Exception("Fields can't be empty!");

            if (user.Username.Length > 30)
                throw new Exception("Username should have maximum 30 characters!");

            if (user.Password.Length > 15)
                throw new Exception("Password should have maximum 15 characters!");

            if (!Regex.IsMatch(user.Username, stringPattern))
                throw new Exception("Username must include only letters or numbers and may have a '-' or empty space in between!");

            if (!Regex.IsMatch(user.Password, passwordPattern))
                throw new Exception("Password must include only letters, numbers or '!' symbol !");
        }

        public void DeleteUser(User user)
        {
            usersDAL.DeleteUser(user);
        }

        public ObservableCollection<Product> GetReceiptReport(User user, string ReportDate)
        {
            if (user == null)
                throw new Exception("Please select a user first!");

            if (string.IsNullOrEmpty(ReportDate))
                throw new Exception("Please select a date first!");


            ObservableCollection<Product> products = new ObservableCollection<Product>();

            return products;
        }

        #endregion

    }
}
