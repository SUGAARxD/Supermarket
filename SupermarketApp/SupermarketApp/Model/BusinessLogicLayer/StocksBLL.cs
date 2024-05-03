using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System.Collections.ObjectModel;

namespace SupermarketApp.Model.BusinessLogicLayer
{
    internal class StocksBLL
    {
        public StocksBLL()
        {

        }

        #region Properties and members

        StocksDAL stocksDAL = new StocksDAL();

        #endregion

        #region Methods

        public ObservableCollection<Stock> GetAllStocks(CashierSearchStockModel searchStockParameters)
        {
            return stocksDAL.GetAllStocks(searchStockParameters);
        }
        
        public Stock GetStock(CashierSearchStockModel searchStockParameters)
        {
            ObservableCollection<Stock> Stocks = stocksDAL.GetAllStocks(searchStockParameters);

            if (Stocks.Count == 0)
                throw new System.Exception("Stock doesn't exist!");

            return Stocks[0];
        }

        #endregion
    }
}
