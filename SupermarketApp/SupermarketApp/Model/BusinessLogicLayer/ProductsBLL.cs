using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;

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

        #endregion
    }
}
