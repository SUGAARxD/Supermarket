using SupermarketApp.Model.EntityLayer;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

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

        public ObservableCollection<string> GetAllCategoriesName()
        {
            ObservableCollection<string> categoriesName = new ObservableCollection<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllCategoriesName", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    categoriesName.Add(reader[0].ToString());
                }
            }

            return categoriesName;
        }

        #endregion

    }
}
