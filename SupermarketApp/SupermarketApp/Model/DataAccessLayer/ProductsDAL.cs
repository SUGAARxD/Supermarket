using SupermarketApp.Model.EntityLayer;
using System.Data.SqlClient;
using System.Data;
using SupermarketApp.Model.BusinessLogicLayer;
using System.Collections.ObjectModel;

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
        public ObservableCollection<string> GetAllProductsName()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<string> productsName = new ObservableCollection<string>();

                SqlCommand command = new SqlCommand("GetAllProductsName", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productsName.Add(reader[0].ToString());
                }

                return productsName;
            }
        }

        public ObservableCollection<string> GetAllProductsBarcode()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<string> productsBarcode = new ObservableCollection<string>();

                SqlCommand command = new SqlCommand("GetAllProductsBarcode", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productsBarcode.Add(reader[0].ToString());
                }

                return productsBarcode;
            }
        }

        public void GetAllActiveProducts(ObservableCollection<Product> Products)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllActiveProducts", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                
                CategoriesBLL categoryBLL = new CategoriesBLL();
                ProducersBLL producersBLL = new ProducersBLL();
                
                Products.Clear();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)(reader[0]);
                    product.Name = reader[1].ToString();
                    product.Barcode = reader[2].ToString();

                    product.Category = categoryBLL.GetCategory((int)(reader[3]));
                    product.Producer = producersBLL.GetProducer((int)(reader[4]));

                    Products.Add(product);
                }
            }
        }

        public void GetAllInactiveProducts(ObservableCollection<Product> Products)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllInactiveProducts", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                CategoriesBLL categoryBLL = new CategoriesBLL();
                ProducersBLL producersBLL = new ProducersBLL();

                Products.Clear();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)(reader[0]);
                    product.Name = reader[1].ToString();
                    product.Barcode = reader[2].ToString();

                    product.Category = categoryBLL.GetCategory((int)(reader[3]));
                    product.Producer = producersBLL.GetProducer((int)(reader[4]));

                    Products.Add(product);
                }
            }
        }

        #endregion
    }
}
