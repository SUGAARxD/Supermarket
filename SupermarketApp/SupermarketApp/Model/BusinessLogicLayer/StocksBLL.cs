using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System;

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

        public ObservableCollection<Stock> GetAllSearchedStocks(CashierSearchStockModel searchStockParameters)
        {
            return stocksDAL.GetAllSearchedStocks(searchStockParameters);
        }
        
        public Stock GetFirstSearchedStock(CashierSearchStockModel searchStockParameters)
        {
            ObservableCollection<Stock> Stocks = stocksDAL.GetAllSearchedStocks(searchStockParameters);

            if (Stocks.Count == 0)
                throw new System.Exception("Stock doesn't exist!");

            return Stocks[0];
        }

        public void DeleteStock(Stock stock)
        {
            stocksDAL.DeleteStock(stock.Id);
        }

        public void ActivateStock(Stock stock)
        {
            stocksDAL.ActivateStock(stock.Id);
        }

        public void UpdateStockQuantity(Stock stock, int newQuantity)
        {
            stocksDAL.UpdateStockQuantity(stock, newQuantity);
            if (newQuantity == 0)
                DeleteStock(stock);
        }

        public void GetAllActiveStocks(ObservableCollection<Stock> Stocks)
        {
            stocksDAL.GetAllActiveStocks(Stocks);
            if (Stocks.Count == 0)
                throw new System.Exception("No active stocks found!");
        }

        public void GetAllInactiveStocks(ObservableCollection<Stock> Stocks)
        {
            stocksDAL.GetAllInactiveStocks(Stocks);
            if (Stocks.Count == 0)
                throw new System.Exception("No inactive stocks found!");
        }

        public void AddStock(Stock stock)
        {
            try
            {
                VerifyInput(stock);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (stocksDAL.ExistsStock(stock))
                throw new Exception("stock exists!");

            if (stocksDAL.ExistsInactiveStock(stock))
            {
                stocksDAL.ActivateStock(stock.Id);
                return;
            }

            stocksDAL.AddStock(stock);
        }

        private void VerifyInput(Stock stock)
        {

            if (string.IsNullOrEmpty(stock.Unit)
               || string.IsNullOrEmpty(stock.SupplyDate)
               || string.IsNullOrEmpty(stock.ExpirationDate)
               || stock.Product == null)
               throw new Exception("Fields can't be empty!");

            if (stock.Unit.Length > 10)
                throw new Exception("Stock unit should have maximum 10 characters!");
            if (stock.PurchasePrice < 0)
                throw new Exception("Stock purchase price can't be negative!");
            if (stock.VAT < 0)
                throw new Exception("VAT can't be negative!");
            if (stock.Quantity <= 0)
                throw new Exception("Quantity can't be negative or 0!");
            if (stock.PurchasePrice <= 0)
                throw new Exception("Purchase price can't be negative or 0!");
            if (stock.VAT < 0)
                throw new Exception("VAT can't be negative!");
        }

        public void UpdateVAT(Stock stock, double vat)
        {
            if (vat < 0)
                throw new Exception("VAT can't be negative!");

            stocksDAL.UpdateVAT(stock, vat);
        }

        public Stock GetStock(int id)
        {
            return stocksDAL.GetStock(id);
        }

        #endregion

    }
}
