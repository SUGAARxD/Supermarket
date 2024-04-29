
using SupermarketApp.Model.DataAccessLayer;
using SupermarketApp.Model.EntityLayer;
using System.Collections.ObjectModel;

namespace SupermarketApp.Model.BusinessLogicLayer
{
    internal class UsersBLL
    {
        
        public UsersBLL()
        {

        }

        #region Properties and members

        public ObservableCollection<User> UsersList { get; set; }

        UsersDAL usersDAL = new UsersDAL();

        #endregion

        #region Methods

        public bool ExistsUser(User user)
        {
            return usersDAL.ExistsUser(user);
        }

        #endregion

    }
}
