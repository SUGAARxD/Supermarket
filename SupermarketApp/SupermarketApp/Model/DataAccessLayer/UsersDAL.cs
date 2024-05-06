using System.Data.SqlClient;
using System.Data;
using SupermarketApp.Model.EntityLayer;
using System.Runtime.Remoting;

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

        #endregion

    }

}

