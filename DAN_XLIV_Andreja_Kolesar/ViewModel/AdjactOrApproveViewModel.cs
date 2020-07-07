using DAN_XLIV_Andreja_Kolesar.Service;
using DAN_XLIV_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Andreja_Kolesar.ViewModel
{
    class AdjactOrApproveViewModel:ViewModelBase
    {
        AdjactOrApprove aa;
        private tblOrder _currentOrder;
        public tblOrder currentOrder
        {
            get
            {
                return _currentOrder;
            }
            set
            {
                _currentOrder = value;
                OnPropertyChanged("currentOrder");
            }
        }

        public AdjactOrApproveViewModel(AdjactOrApprove open, tblOrder order)
        {
            aa = open;
            currentOrder = order;
        }

        public AdjactOrApproveViewModel(AdjactOrApprove open)
        {
            aa = open;
        }

    }
}
