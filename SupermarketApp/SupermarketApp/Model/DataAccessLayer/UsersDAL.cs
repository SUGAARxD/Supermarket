using System.Data.SqlClient;
using System.Data;
using SupermarketApp.Model.EntityLayer;

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
                SqlParameter usernameParameter = new SqlParameter("@username", user.Username);
                SqlParameter passwordParameter = new SqlParameter("@password", user.Password);
                SqlParameter userTypeParameter = new SqlParameter("@user_type", user.UserType);
                SqlParameter usersCountParameter = new SqlParameter("@users_count", SqlDbType.Int);
                usersCountParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(usernameParameter);
                command.Parameters.Add(passwordParameter);
                command.Parameters.Add(userTypeParameter);
                command.Parameters.Add(usersCountParameter);
                connection.Open();
                command.ExecuteNonQuery();
                return (usersCountParameter.Value as int?) != 0;
            }
        }

        #endregion

    }

}

