using SupermarketApp.Model.EntityLayer;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SupermarketApp.Model.BusinessLogicLayer;

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
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<string> categoriesName = new ObservableCollection<string>();
                SqlCommand command = new SqlCommand("GetAllCategoriesName", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    categoriesName.Add(reader[0].ToString());
                }

                return categoriesName;
            }
        }

        public void GetAllActiveCategories(ObservableCollection<Category> Categories)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllActiveCategories", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                Categories.Clear();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.Id = (int)(reader[0]);
                    category.Name = reader[1].ToString();

                    Categories.Add(category);
                }
            }
        }

        public void GetAllInactiveCategories(ObservableCollection<Category> Categories)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllInactiveCategories", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                Categories.Clear();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.Id = (int)(reader[0]);
                    category.Name = reader[1].ToString();

                    Categories.Add(category);
                }
            }
        }

        public void UpdateCategory(Category category)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("UpdateCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@categoryId", category.Id);
                SqlParameter nameParameter = new SqlParameter("@name", category.Name);

                command.Parameters.Add(idParameter);
                command.Parameters.Add(nameParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public bool ExistsCategory(Category category)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ExistsCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParameter = new SqlParameter("@categoryName", category.Name);

                command.Parameters.Add(nameParameter);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return (int)(reader[0]) != 0;
                }
                return false;
            }
        }

        public bool ExistsInactiveCategory(Category category)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ExistsInactiveCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParameter = new SqlParameter("@categoryName", category.Name);

                command.Parameters.Add(nameParameter);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return (int)(reader[0]) != 0;
                }
                return false;
            }
        }

        public void AddCategory(Category category)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("AddCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParameter = new SqlParameter("@categoryName", category.Name);

                command.Parameters.Add(nameParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(Category category)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("DeleteCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@categoryId", category.Id);

                command.Parameters.Add(idParameter);

                connection.Open();

                command.ExecuteNonQuery();

                ProductsBLL productsBLL = new ProductsBLL();

                foreach (var id in GetProductsIdFromCategory(category))
                {
                    productsBLL.DeleteProduct(new Product { Id = id });
                }
            }
        }

        public void ActivateCategory(Category category)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ActivateCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@categoryId", category.Id);

                command.Parameters.Add(idParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public double GetCategoryValue(Category category)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetCategoryValue", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@categoryId", category.Id);

                command.Parameters.Add(idParameter);

                connection.Open();

                double categoryValue = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    categoryValue = (double)(reader[0]);
                }
                return categoryValue;
            }
        }

        public ObservableCollection<int> GetProductsIdFromCategory(Category category)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetProductsIdFromCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@categoryId", category.Id);

                command.Parameters.Add(idParameter);

                connection.Open();

                ObservableCollection<int> productIds = new ObservableCollection<int>();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productIds.Add((int)(reader[0]));
                }
                return productIds;
            }
        }

        #endregion

    }
}
