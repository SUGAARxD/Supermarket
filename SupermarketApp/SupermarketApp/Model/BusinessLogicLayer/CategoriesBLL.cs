using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

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

        public ObservableCollection<string> GetAllCategoriesName()
        {
            return categoriesDAL.GetAllCategoriesName();
        }

        public void GetAllActiveCategories(ObservableCollection<Category> Categories)
        {
            categoriesDAL.GetAllActiveCategories(Categories);
            if (Categories.Count == 0)
                throw new System.Exception("No active categories found!");
        }

        public void GetAllInactiveCategories(ObservableCollection<Category> Categories)
        {
            categoriesDAL.GetAllInactiveCategories(Categories);
            if (Categories.Count == 0)
                throw new System.Exception("No inactive categories found!");
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                VerifyInput(category);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            if (ExistsCategory(category) && categoriesDAL.ExistsInactiveCategory(category))
                throw new Exception("Category exists!");

            categoriesDAL.UpdateCategory(category);
        }

        public bool ExistsCategory(Category category)
        {
            return categoriesDAL.ExistsCategory(category);
        }

        public void AddCategory(Category category)
        {
            try
            {
                VerifyInput(category);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ExistsCategory(category))
                throw new Exception("Category exists!");

            if (categoriesDAL.ExistsInactiveCategory(category))
            {
                categoriesDAL.ActivateCategory(category);
                return;
            }

            categoriesDAL.AddCategory(category);
        }

        private void VerifyInput(Category category)
        {
            string categoryNamePattern = @"^[a-zA-Z0-9\s]+(- [a-zA-Z0-9\s]+)?$";

            if (string.IsNullOrEmpty(category.Name))
                throw new Exception("Fields can't be empty!");

            if (category.Name.Length > 100)
                throw new Exception("Category name should have maximum 100 characters!");

            if (!Regex.IsMatch(category.Name, categoryNamePattern))
                throw new Exception("Category name must include only letters or numbers and may have a '-' or empty space in between!");
        }

        public void DeleteCategory(Category category)
        {
            categoriesDAL.DeleteCategory(category);
        }

        public double GetCategoryValue(Category category)
        {
            return categoriesDAL.GetCategoryValue(category);
        }

        #endregion
    }
}
