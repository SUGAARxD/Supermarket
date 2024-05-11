using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

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
            productsDAL.GetAllInactiveProducts(Products);
            if (Products.Count == 0)
                throw new System.Exception("No inactive products found!");
        }

        public void UpdateProduct(Product product)
        {
           try
            {
                VerifyInput(product);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            if (ExistsProduct(product) || productsDAL.ExistsInactiveProduct(product))
                throw new Exception("Product exists!");

            productsDAL.UpdateProduct(product);
        }

        public bool ExistsProduct(Product product)
        {
            return productsDAL.ExistsProduct(product);
        }

        public void AddProduct(Product product)
        {
            try
            {
                VerifyInput(product);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ExistsProduct(product))
                throw new Exception("Product exists!");

            if (productsDAL.ExistsInactiveProduct(product))
            {
                productsDAL.ActivateProduct(product);
                return;
            }

            productsDAL.AddProduct(product);
        }

        private void VerifyInput(Product product)
        {
            string barcodePattern = @"^\d{1,9}$";
            string productNamePattern = @"^[a-zA-Z0-9\s]+(- [a-zA-Z0-9\s]+)?$";

            if (string.IsNullOrEmpty(product.Name)
                || string.IsNullOrEmpty(product.Barcode)
                || product.Category == null
                || product.Producer == null)
                throw new Exception("Fields can't be empty!");

            if (product.Name.Length > 100)
                throw new Exception("Product name should have maximum 100 characters!");

            if (!Regex.IsMatch(product.Name, productNamePattern))
                throw new Exception("Product name must include only letters or numbers and may have a '-' or empty space in between!");

            if (!Regex.IsMatch(product.Barcode, barcodePattern))
                throw new Exception("Barcode must include only numbers from 0-9 and have minimum 1 number and maximum 9 numbers!");
        }

        public void DeleteProduct(Product product)
        {
            productsDAL.DeleteProduct(product);
        }

        #endregion
    }
}
