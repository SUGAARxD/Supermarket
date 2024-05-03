using SupermarketApp.Model.EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace SupermarketApp.Model.DataAccessLayer
{
    internal class CategoriesDAL
    {
        public CategoriesDAL()
        {
        }

        #region Methods

        public Category GetCategory(int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@categoryId", id);
                command.Parameters.Add(idParameter);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Category category = null;
                while (reader.Read())
                {
                    category = new Category();
                    category.Id = (int)(reader[0]);
                    category.Name = reader[1].ToString();
                }
                return category;
            }
        }

        #endregion

    }
}
