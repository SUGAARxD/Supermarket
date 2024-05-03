using SupermarketApp.Model.EntityLayer;
using System.Data.SqlClient;
using System.Data;
using SupermarketApp.Model.BusinessLogicLayer;

namespace SupermarketApp.Model.DataAccessLayer
{
    internal class ProductsDAL
    {
        public ProductsDAL()
        {
        }

        #region Methods

        public Product GetProduct(int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@productId", id);
                command.Parameters.Add(idParameter);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                Product product = null;
                while (reader.Read())
                {
                    product = new Product();
                    product.Id = (int)(reader[0]);
                    product.Name = reader[1].ToString();
                    product.Barcode = reader[2].ToString();

                    CategoriesBLL categoryBLL = new CategoriesBLL();
                    product.Category = categoryBLL.GetCategory((int)(reader[3]));
                    ProducersBLL producersBLL = new ProducersBLL();
                    product.Producer = producersBLL.GetProducer((int)(reader[4]));
                }
                return product;
            }
        }

        #endregion
    }
}
