using DAN_XLIV_Andreja_Kolesar.Model;
using DAN_XLIV_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Andreja_Kolesar.ViewModel
{
    class EmployeeViewModel:ViewModelBase
    {
        Employee emp;


        #region Constructor
        public EmployeeViewModel(Employee open)
        {
            emp = open;
        }
        #endregion
    }
}
