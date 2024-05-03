using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System.Collections.ObjectModel;

namespace SupermarketApp.Model.BusinessLogicLayer
{
    internal class CategoriesBLL
    {

        public CategoriesBLL()
        {

        }

        #region Properties and members

        CategoriesDAL categoriesDAL = new CategoriesDAL();

        #endregion

        #region Methods

        public Category GetCategory(int id)
        {
            return categoriesDAL.GetCategory(id);
        }

        #endregion
    }
}
