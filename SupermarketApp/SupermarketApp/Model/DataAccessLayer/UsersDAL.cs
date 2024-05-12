using System.Data.SqlClient;
using System.Data;
using SupermarketApp.Model.EntityLayer;
using System.Runtime.Remoting;
using SupermarketApp.Model.BusinessLogicLayer;
using System.Collections.ObjectModel;
using System;

namespace SupermarketApp.Model.DataAccessLayer
{
    internal class UsersDAL
    {

        public UsersDAL()
        {

        }

        #region Methods

        public bool ExistsUser(User user)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ExistsUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter userId = new SqlParameter("@userId", SqlDbType.Int);
                userId.Direction = ParameterDirection.Output;
                SqlParameter usernameParameter = new SqlParameter("@username", user.Username);
                SqlParameter passwordParameter = new SqlParameter("@password", user.Password);
                SqlParameter userTypeParameter = new SqlParameter("@user_type", user.UserType);
                command.Parameters.Add(userId);
                command.Parameters.Add(usernameParameter);
                command.Parameters.Add(passwordParameter);
                command.Parameters.Add(userTypeParameter);
                connection.Open();
                command.ExecuteNonQuery();

                if (string.IsNullOrEmpty(userId.Value.ToString()))
                    return false;
                user.Id = (int)userId.Value;
                return true;
            }
        }

        public void GetAllActiveUsers(ObservableCollection<User> Users)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllActiveUsers", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                Users.Clear();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = (int)(reader[0]);
                    user.Username = reader[1].ToString();
                    user.Password = reader[2].ToString();
                    user.UserType = reader[3].ToString();

                    Users.Add(user);
                }
            }
        }

        public void GetAllInactiveUsers(ObservableCollection<User> Users)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllInactiveUsers", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                Users.Clear();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = (int)(reader[0]);
                    user.Username = reader[1].ToString();
                    user.Password = reader[2].ToString();
                    user.UserType = reader[3].ToString();

                    Users.Add(user);
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("UpdateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@userId", user.Id);
                SqlParameter nameParameter = new SqlParameter("@username", user.Username);
                SqlParameter passwordParameter = new SqlParameter("@password", user.Password);
                SqlParameter userTypeParameter = new SqlParameter("@userType", user.UserType);

                command.Parameters.Add(idParameter);
                command.Parameters.Add(nameParameter);
                command.Parameters.Add(passwordParameter);
                command.Parameters.Add(userTypeParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public bool ExistsInactiveUser(User user)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ExistsInactiveUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParameter = new SqlParameter("@username", user.Username);
                SqlParameter passwordParameter = new SqlParameter("@password", user.Password);
                SqlParameter userTypeParameter = new SqlParameter("@userType", user.UserType);

                command.Parameters.Add(nameParameter);
                command.Parameters.Add(passwordParameter);
                command.Parameters.Add(userTypeParameter);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return (int)(reader[0]) != 0;
                }
                return false;
            }
        }

        public void AddUser(User user)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("AddUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParameter = new SqlParameter("@username", user.Username);
                SqlParameter passwordParameter = new SqlParameter("@password", user.Password);
                SqlParameter userTypeParameter = new SqlParameter("@userType", user.UserType);

                command.Parameters.Add(nameParameter);
                command.Parameters.Add(passwordParameter);
                command.Parameters.Add(userTypeParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(User user)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("DeleteUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@userId", user.Id);

                command.Parameters.Add(idParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void ActivateUser(User user)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ActivateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@userId", user.Id);

                command.Parameters.Add(idParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Tuple<string, double>> GetCashedAmounts(User user, string ReportMonth, string ReportYear)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetCashedAmounts", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@cashierId", user.Id);
                SqlParameter reportMonthParameter = new SqlParameter("@reportMonth", ReportMonth);
                SqlParameter reportYearParameter = new SqlParameter("@reportYear", ReportYear);

                command.Parameters.Add(idParameter);
                command.Parameters.Add(reportMonthParameter);
                command.Parameters.Add(reportYearParameter);

                connection.Open();

                ObservableCollection<Tuple<string, double>> cashedAmounts = new ObservableCollection<Tuple<string, double>>();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cashedAmounts.Add(Tuple.Create(reader[0].ToString(), (double)(reader[1])));
                }

                return cashedAmounts;
            }
        }

        public User GetUser(int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParameter = new SqlParameter("@userId", id);
                command.Parameters.Add(idParameter);

                connection.Open();

                User user = null;
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new User();
                    user.Id = (int)(reader[0]);
                    user.Username = reader[1].ToString();
                    user.Password = reader[2].ToString();
                    user.UserType = reader[3].ToString();
                }
                return user;
            }
        }

        #endregion

    }

}

