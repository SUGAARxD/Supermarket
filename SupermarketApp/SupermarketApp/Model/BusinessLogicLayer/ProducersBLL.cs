using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;

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

        #endregion
    }
}
