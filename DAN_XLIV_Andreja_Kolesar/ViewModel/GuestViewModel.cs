using DAN_XLIV_Andreja_Kolesar.Model;
using DAN_XLIV_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Andreja_Kolesar.ViewModel
{
    class GuestViewModel:ViewModelBase
    {
        Guest guest;
        //current user
        private User _currentUser;
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged("currentUser");
            }
        }

        #region CONSTRUCTOR
        public GuestViewModel(Guest open, User user)
        {
            guest = open;
            currentUser = user;
        }

        public GuestViewModel(Guest open)
        {
            guest = open;
        }
        #endregion
    }
}
