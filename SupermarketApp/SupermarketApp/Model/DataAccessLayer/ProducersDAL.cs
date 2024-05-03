using SupermarketApp.Model.EntityLayer;
using System.Data.SqlClient;
using System.Data;

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

        #endregion
    }
}
