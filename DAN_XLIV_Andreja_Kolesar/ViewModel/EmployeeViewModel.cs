using DAN_XLIV_Andreja_Kolesar.Model;
using DAN_XLIV_Andreja_Kolesar.Service;
using DAN_XLIV_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIV_Andreja_Kolesar.ViewModel
{
    class EmployeeViewModel:ViewModelBase
    {
        #region PROPERTY
        Employee emp;
        //current user
        private List<tblOrder> _orderList;
        public List<tblOrder> orderList
        {
            get
            {
                return _orderList;
            }
            set
            {
                _orderList = value;
                OnPropertyChanged("orderList");
            }
        }

        private tblOrder _singleOrder;
        public tblOrder singleOrder
        {
            get
            {
                return _singleOrder;
            }
            set
            {
                _singleOrder = value;
                OnPropertyChanged("singleOrder");
            }
        }
        #endregion

        #region Constructor
        public EmployeeViewModel(Employee open)
        {
            emp = open;
            orderList = Service.Service.GetAllOrders();
        }
        #endregion

        #region COMMANDS
        private ICommand _action;
        public ICommand action
        {
            get
            {
                if (_action == null)
                {
                    _action = new Command.RelayCommand(param => ActionExecute(), param => CanActionExecute());
                }
                return _action;
            }
        }

        private void ActionExecute()
        {
            try
            {
                if (singleOrder != null)
                {
                    if(singleOrder.status == "approved" || singleOrder.status == "rejected")
                    {
                        Service.Service.DeleteOrder(singleOrder);
                        orderList = Service.Service.GetAllOrders();
                        
                    }
                    else
                    {
                        AdjactOrApprove changeOrder = new AdjactOrApprove(singleOrder);
                        changeOrder.ShowDialog();
                        if ((changeOrder.DataContext as MakeOrderViewModel).isMade == true)
                        {

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanActionExecute()
        {
            return true;
        }
        #endregion
    }
}
