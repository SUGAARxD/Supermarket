using SupermarketApp.Model.EntityLayer;
using System.Data.SqlClient;
using System.Data;
using System;
using SupermarketApp.ViewModel;
using SupermarketApp.Model.BusinessLogicLayer;

namespace SupermarketApp.Model.DataAccessLayer
{
    internal class ReceiptsDAL
    {
        public ReceiptsDAL()
        {
        }

        #region Methods

        public Receipt CreateNewReceipt(User cashier)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("CreateNewReceipt", connection);
                command.CommandType = CommandType.StoredProcedure;

                string date = DateTime.Now.ToShortDateString();

                SqlParameter issuanceDateParameter = new SqlParameter("@issuanceDate", date);
                int total = 0;
                SqlParameter totalParameter = new SqlParameter("@total", total);
                SqlParameter cashierIdParameter = new SqlParameter("@cashierId", cashier.Id);
                SqlParameter receiptIdParameter = new SqlParameter("@receiptId", SqlDbType.Int);
                receiptIdParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(issuanceDateParameter);
                command.Parameters.Add(totalParameter);
                command.Parameters.Add(cashierIdParameter);
                command.Parameters.Add(receiptIdParameter);

                connection.Open();

                command.ExecuteNonQuery();

                Receipt receipt = null;

                receipt = new Receipt();

                try
                {
                    receipt.Id = int.Parse(receiptIdParameter.Value.ToString());
                }
                catch (Exception e)
                {
                    return null;
                }

                receipt.IssuanceDate = date;
                receipt.Total = 0;
                receipt.Cashier = cashier;

                return receipt;
            }
        }

        public void DropReceipt(Receipt receipt)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("DropReceipt", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter receiptIdParameter = new SqlParameter("@receiptId", receipt.Id);
                command.Parameters.Add(receiptIdParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void AddReceiptProduct(StockReceipt stockReceipt)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("AddReceiptProduct", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter stockIdParameter = new SqlParameter("@stockId", stockReceipt.Stock.Id);
                SqlParameter receiptIdParameter = new SqlParameter("@receiptId", stockReceipt.Receipt.Id);
                SqlParameter quantityParameter = new SqlParameter("@quantity", stockReceipt.Quantity);
                SqlParameter subtotalParameter = new SqlParameter("@subtotal", stockReceipt.Subtotal);
                command.Parameters.Add(stockIdParameter);
                command.Parameters.Add(receiptIdParameter);
                command.Parameters.Add(quantityParameter);
                command.Parameters.Add(subtotalParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateReceiptTotal(Receipt receipt)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("UpdateReceiptTotal", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter receiptIdParameter = new SqlParameter("@receiptId", receipt.Id);
                SqlParameter totalParameter = new SqlParameter("@total", receipt.Total);
                command.Parameters.Add(receiptIdParameter);
                command.Parameters.Add(totalParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        #endregion

    }
}
