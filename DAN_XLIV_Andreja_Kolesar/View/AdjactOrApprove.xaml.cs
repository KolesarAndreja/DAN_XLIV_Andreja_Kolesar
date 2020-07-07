using DAN_XLIV_Andreja_Kolesar.Service;
using DAN_XLIV_Andreja_Kolesar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DAN_XLIV_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for AdjactOrApprove.xaml
    /// </summary>
    public partial class AdjactOrApprove : Window
    {
        public AdjactOrApprove()
        {
            InitializeComponent();
            this.DataContext = new AdjactOrApproveViewModel(this);
        }

        public AdjactOrApprove(tblOrder order)
        {
            InitializeComponent();
            this.DataContext = new AdjactOrApproveViewModel(this,order);
        }

    }
}
