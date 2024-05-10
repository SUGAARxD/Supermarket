using SupermarketApp.Model.EntityLayer;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SupermarketApp.Model.BusinessLogicLayer;
using System.Collections.Generic;
using System;

namespace SupermarketApp.Model.DataAccessLayer
{
    internal class ProducersDAL
    {
        public ProducersDAL()
        {
        }

        #region Methods

        public Producer GetProducer(int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetProducer", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@producerId", id);
                command.Parameters.Add(idParameter);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Producer producer = null;
                while (reader.Read())
                {
                    producer = new Producer();
                    producer.Id = (int)(reader[0]);
                    producer.Name = reader[1].ToString();
                    producer.Country = reader[2].ToString();
                }
                return producer;
            }
        }

        public ObservableCollection<string> GetAllProducersName()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<string> producersName = new ObservableCollection<string>();

                SqlCommand command = new SqlCommand("GetAllProducersName", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    producersName.Add(reader[0].ToString());
                }

                return producersName;
            }
        }

        public void GetAllActiveProducers(ObservableCollection<Producer> Producers)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllActiveProducers", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                Producers.Clear();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producer producer = new Producer();
                    producer.Id = (int)(reader[0]);
                    producer.Name = reader[1].ToString();
                    producer.Country = reader[2].ToString();

                    Producers.Add(producer);
                }
            }
        }

        public void GetAllInactiveProducers(ObservableCollection<Producer> Producers)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllInactiveProducers", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                Producers.Clear();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producer category = new Producer();
                    category.Id = (int)(reader[0]);
                    category.Name = reader[1].ToString();
                    category.Country = reader[2].ToString();

                    Producers.Add(category);
                }
            }
        }

        public void UpdateProducer(Producer producer)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("UpdateProducer", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@producerId", producer.Id);
                SqlParameter nameParameter = new SqlParameter("@producerName", producer.Name);
                SqlParameter countryParameter = new SqlParameter("@country", producer.Country);

                command.Parameters.Add(idParameter);
                command.Parameters.Add(nameParameter);
                command.Parameters.Add(countryParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public bool ExistsProducer(Producer producer)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ExistsProducer", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParameter = new SqlParameter("@producerName", producer.Name);
                SqlParameter countryParameter = new SqlParameter("@country", producer.Country);

                command.Parameters.Add(nameParameter);
                command.Parameters.Add(countryParameter);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return (int)(reader[0]) != 0;
                }
                return false;
            }
        }

        public bool ExistsInactiveProducer(Producer producer)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ExistsInactiveProducer", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParameter = new SqlParameter("@producerName", producer.Name);
                SqlParameter countryParameter = new SqlParameter("@country", producer.Country);

                command.Parameters.Add(nameParameter);
                command.Parameters.Add(countryParameter);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return (int)(reader[0]) != 0;
                }
                return false;
            }
        }

        public void AddProducer(Producer producer)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("AddProducer", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParameter = new SqlParameter("@producerName", producer.Name);
                SqlParameter countryParameter = new SqlParameter("@country", producer.Country);

                command.Parameters.Add(nameParameter);
                command.Parameters.Add(countryParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void DeleteProducer(Producer Producer)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("DeleteProducer", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@producerId", Producer.Id);

                command.Parameters.Add(idParameter);

                connection.Open();

                command.ExecuteNonQuery();

                ProductsBLL productsBLL = new ProductsBLL();

                foreach (var id in GetProductsIdFromProducer(Producer))
                {
                    productsBLL.DeleteProduct(new Product { Id = id });
                }
            }
        }

        public void ActivateProducer(Producer producer)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("ActivateProducer", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@producerId", producer.Id);

                command.Parameters.Add(idParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<int> GetProductsIdFromProducer(Producer producer)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetProductsIdFromProducer", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@producerId", producer.Id);

                command.Parameters.Add(idParameter);

                connection.Open();

                ObservableCollection<int> productIds = new ObservableCollection<int>();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productIds.Add((int)(reader[0]));
                }
                return productIds;
            }
        }

        #endregion

    }
}
