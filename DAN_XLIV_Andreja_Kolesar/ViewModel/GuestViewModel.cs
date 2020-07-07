﻿using DAN_XLIV_Andreja_Kolesar.Model;
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
    class GuestViewModel:ViewModelBase
    {
        #region PROPERTY
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

        private List<tblDish> _menuList;
        public List<tblDish> menuList
        {
            get
            {
                return _menuList;
            }
            set
            {
                _menuList = value;
                OnPropertyChanged("menuList");
            }
        }

        private tblDish _pizza;
        public tblDish pizza
        {
            get
            {
                return _pizza;
            }
            set
            {
                _pizza = value;
                OnPropertyChanged("pizza");
            }
        }
        #endregion

        #region CONSTRUCTOR
        public GuestViewModel(Guest open, User user)
        {
            guest = open;
            currentUser = user;
            menuList = Service.Service.GetMenu();
        }

        public GuestViewModel(Guest open)
        {
            guest = open;
        }
        #endregion
        #region VISIBILITY
        private Visibility _btnToOrder = Visibility.Visible;
        public Visibility btnToOrder
        {
            get
            {
                return _btnToOrder;
            }
            set
            {
                _btnToOrder = value;
                OnPropertyChanged("btnToOrder");
            }
        }
        //private Visibility _statusColumn = Visibility.Collapsed;
        //public Visibility statusColumn
        //{
        //    get
        //    {
        //        return _statusColumn;
        //    }
        //    set
        //    {
        //        _statusColumn = value;
        //        OnPropertyChanged("statusColumn");
        //    }
        //}
        #endregion
        #region COMMANDS
        private ICommand _orderPizza;
        public ICommand orderPizza
        {
            get
            {
                if (_orderPizza == null)
                {
                    _orderPizza = new Command.RelayCommand(param => OrderPizzaExecute(), param => CanOrderPizzaExecute());
                }
                return _orderPizza;
            }
        }

        private void OrderPizzaExecute()
        {
            try
            {
                if (pizza != null)
                {
                    pizza.status = "waiting";
                    MakeOrder newOrder = new MakeOrder(pizza,currentUser);
                    newOrder.ShowDialog();
                    if ((newOrder.DataContext as MakeOrderViewModel).isMade == true)
                    {
                        btnToOrder = Visibility.Collapsed;
                        //statusColumn = Visibility.Visible;

                    }
                }   

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanOrderPizzaExecute()
        {
            return true;
        }


        private ICommand _close;
        public ICommand close
        {
            get
            {
                if (_close == null)
                {
                    _close = new Command.RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return _close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                Login login = new Login();
                guest.Close();
                login.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
