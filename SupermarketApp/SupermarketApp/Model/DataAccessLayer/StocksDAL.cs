using SupermarketApp.Model.EntityLayer;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System;
using SupermarketApp.Model.BusinessLogicLayer;
using System.Data.Common;

namespace SupermarketApp.Model.DataAccessLayer
{
    internal class StocksDAL
    {
        public StocksDAL()
        {

        }

        #region Methods

        public ObservableCollection<Stock> GetAllStocks(CashierSearchStockModel searchStockParameters)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllStocksThatMatchParameters", connection);
                command.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(searchStockParameters.ProductName))
                {
                    SqlParameter productNameParameter = new SqlParameter("@productName", searchStockParameters.ProductName);
                    command.Parameters.Add(productNameParameter);
                }

                if (!string.IsNullOrEmpty(searchStockParameters.ProductBarcode))
                {
                    SqlParameter productBarcodeParameter = new SqlParameter("@productBarcode", searchStockParameters.ProductBarcode);
                    command.Parameters.Add(productBarcodeParameter);
                }

                if (!string.IsNullOrEmpty(searchStockParameters.StockExpirationDate))
                {
                    SqlParameter stockExpirationDateParameter = new SqlParameter("@stockExpirationDate", searchStockParameters.StockExpirationDate);
                    command.Parameters.Add(stockExpirationDateParameter);
                }

                if (!string.IsNullOrEmpty(searchStockParameters.CategoryName))
                {
                    SqlParameter categoryNameParameter = new SqlParameter("@categoryName", searchStockParameters.CategoryName);
                    command.Parameters.Add(categoryNameParameter);
                }

                if (!string.IsNullOrEmpty(searchStockParameters.ProducerName))
                {
                    SqlParameter producerNameParameter = new SqlParameter("@producerName", searchStockParameters.ProducerName);
                    command.Parameters.Add(producerNameParameter);
                }


                connection.Open();

                ObservableCollection<Stock> result = new ObservableCollection<Stock>();

                ProductsBLL productsBLL = new ProductsBLL();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DateTime expirationDate = DateTime.Parse(reader[4].ToString()).Date;

                    if (expirationDate > DateTime.Now.Date)
                    {
                        Stock stock = new Stock();

                        stock.Id = (int)(reader[0]);
                        stock.Quantity = (int)(reader[1]);
                        stock.Unit = reader[2].ToString();
                        stock.SupplyDate = DateTime.Parse(reader[3].ToString()).Date.ToShortDateString();
                        stock.ExpirationDate = expirationDate.ToShortDateString();
                        stock.PurchasePrice = (float)(reader[5]);
                        stock.SalePrice = (float)(reader[6]);
                        stock.VAT = (float)(reader[7]);

                        stock.Product = productsBLL.GetProduct((int)(reader[8]));

                        result.Add(stock);
                    }
                    else
                    {
                        DeleteStock((int)(reader[0]));
                    }
                }
                reader.Close();

                return result;
            }
        }

        public void DeleteStock(int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("DeleteStock", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter stockExpirationDateParameter = new SqlParameter("@stockId", id);
                command.Parameters.Add(stockExpirationDateParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ActivateStock(int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ActivateStock", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter stockExpirationDateParameter = new SqlParameter("@stockId", id);
                command.Parameters.Add(stockExpirationDateParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateStockQuantity(Stock stock, int newQuantity)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("UpdateStockQuantity", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter stockIdParameter = new SqlParameter("@stockId", stock.Id);
                SqlParameter quantityParameter = new SqlParameter("@quantity", newQuantity);
                command.Parameters.Add(stockIdParameter);
                command.Parameters.Add(quantityParameter);

                connection.Open();
                command.ExecuteNonQuery();
                stock.Quantity = newQuantity;
            }
        }

        #endregion
    }
}
