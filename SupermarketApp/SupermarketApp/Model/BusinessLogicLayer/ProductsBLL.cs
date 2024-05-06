using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System.Collections.ObjectModel;

namespace SupermarketApp.Model.BusinessLogicLayer
{
    internal class ProductsBLL
    {
        public ProductsBLL()
        {
        }

        #region Properties and members

        ProductsDAL productsDAL = new ProductsDAL();

        #endregion

        #region Methods

        public Product GetProduct(int id)
        {
            return productsDAL.GetProduct(id);
        }

        public ObservableCollection<string> GetAllProductsName()
        {
            return productsDAL.GetAllProductsName();
        }

        public ObservableCollection<string> GetAllProductsBarcode()
        {
            return productsDAL.GetAllProductsBarcode();
        }

        public void GetAllActiveProducts(ObservableCollection<Product> Products)
        {
            productsDAL.GetAllActiveProducts(Products);
            if (Products.Count == 0)
                throw new System.Exception("No active products found!");
        }

        public void GetAllInactiveProducts(ObservableCollection<Product> Products)
        {
            productsDAL.GetAllActiveProducts(Products);
            if (Products.Count == 0)
                throw new System.Exception("No inactive products found!");
        }

        #endregion
    }
}
