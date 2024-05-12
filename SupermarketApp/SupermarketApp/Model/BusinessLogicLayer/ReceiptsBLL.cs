using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace SupermarketApp.Model.BusinessLogicLayer
{
    internal class ReceiptsBLL
    {
        public ReceiptsBLL()
        {

        }

        #region Properties and members

        ReceiptsDAL receiptsDAL = new ReceiptsDAL();

        #endregion

        #region Methods

        public Receipt CreateNewReceipt(User cashier)
        {
            Receipt receipt = receiptsDAL.CreateNewReceipt(cashier);
            if (receipt == null)
                throw new System.Exception("Create receipt failed!");
            return receipt;
        }

        public void DropReceipt(Receipt receipt)
        {
            receiptsDAL.DropReceipt(receipt);
        }

        public void AddReceiptProduct(StockReceipt stockReceipt)
        {
            receiptsDAL.AddReceiptProduct(stockReceipt);
        }

        public void UpdateReceiptTotal(Receipt receipt)
        {
            receiptsDAL.UpdateReceiptTotal(receipt);
        }

        public void GetReceiptProducts(Receipt receipt, ObservableCollection<StockReceipt> ProductsList)
        {
            receiptsDAL.GetReceiptProducts(receipt, ProductsList);
        }

        public void GetAllActiveReceipts(ObservableCollection<Receipt> Receipts)
        {
            receiptsDAL.GetAllActiveReceipts(Receipts);
            if (Receipts.Count == 0)
                throw new System.Exception("No active receipts found!");
        }

        public void GetAllInactiveReceipts(ObservableCollection<Receipt> Receipts)
        {
            receiptsDAL.GetAllInactiveReceipts(Receipts);
            if (Receipts.Count == 0)
                throw new System.Exception("No inactive receipts found!");
        }

        public void GetBiggestReceipt(string date, ObservableCollection<StockReceipt> ProductsList)
        {
            if (string.IsNullOrEmpty(date))
                throw new System.Exception("Please select a date!");
            receiptsDAL.GetBiggestReceipt(date, ProductsList);
        }
        #endregion

    }
}
