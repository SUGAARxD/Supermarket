using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace SupermarketApp.Model.BusinessLogicLayer
{
    internal class ProducersBLL
    {
        public ProducersBLL()
        {

        }

        #region Properties and members

        ProducersDAL producersDAL = new ProducersDAL();

        #endregion

        #region Methods

        public Producer GetProducer(int id)
        {
            return producersDAL.GetProducer(id);
        }

        public ObservableCollection<string> GetAllProducersName()
        {
            return producersDAL.GetAllProducersName();
        }

        public void GetAllActiveProducers(ObservableCollection<Producer> Producers)
        {
            producersDAL.GetAllActiveProducers(Producers);
            if (Producers.Count == 0)
                throw new System.Exception("No active producers found!");
        }

        public void GetAllInactiveProducers(ObservableCollection<Producer> Producers)
        {
            producersDAL.GetAllInactiveProducers(Producers);
            if (Producers.Count == 0)
                throw new System.Exception("No inactive producers found!");
        }

        public void UpdateProducer(Producer producer)
        {
            try
            {
                VerifyInput(producer);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            if (ExistsProducer(producer) && producersDAL.ExistsInactiveProducer(producer))
                throw new Exception("Producer exists!");

            producersDAL.UpdateProducer(producer);
        }

        public bool ExistsProducer(Producer producer)
        {
            return producersDAL.ExistsProducer(producer);
        }

        public void AddProducer(Producer producer)
        {
            try
            {
                VerifyInput(producer);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ExistsProducer(producer))
                throw new Exception("Producer exists!");

            if (producersDAL.ExistsInactiveProducer(producer))
            {
                producersDAL.ActivateProducer(producer);
                return;
            }

            producersDAL.AddProducer(producer);
        }

        private void VerifyInput(Producer producer)
        {
            string stringPattern = @"^[a-zA-Z0-9\s]+(- [a-zA-Z0-9\s]+)?$";

            if (string.IsNullOrEmpty(producer.Name))
                throw new Exception("Fields can't be empty!");

            if (producer.Name.Length > 100)
                throw new Exception("Producer name should have maximum 100 characters!");

            if (producer.Country.Length > 100)
                throw new Exception("Country should have maximum 100 characters!");

            if (!Regex.IsMatch(producer.Name, stringPattern) || !Regex.IsMatch(producer.Country, stringPattern))
                throw new Exception("Producer name must include only letters or numbers and may have a '-' or empty space in between!");
        }

        public void DeleteProducer(Producer producer)
        {
            producersDAL.DeleteProducer(producer);
        }

        public ObservableCollection<Product> GetProductsReport(Producer producer)
        {
            if (producer == null)
                throw new Exception("Please select a producer first!");

            ObservableCollection<Product> products = new ObservableCollection<Product>();

            ProductsDAL productsDAL = new ProductsDAL();
            foreach (var productId in producersDAL.GetProductsIdFromProducer(producer))
            {
                Product product = productsDAL.GetProduct(productId);
                products.Add(product);
            }

            return products;
        }

        #endregion
    }
}
