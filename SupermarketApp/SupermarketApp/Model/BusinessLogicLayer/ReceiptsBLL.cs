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

        #endregion

    }
}
