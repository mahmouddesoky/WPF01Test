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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for startWorkOrder.xaml
    /// </summary>
    public partial class startWorkOrder : Page
    {
        public startWorkOrder()
        {
            InitializeComponent();
        }

        private void OnBtnClickAdd(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new work_order_basic_info());
        }
    }
}
