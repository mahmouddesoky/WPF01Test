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
    /// Interaction logic for additional_info.xaml
    /// </summary>
    public partial class additional_info : Page
    {
        common_queries commonQueries = new common_queries();
        List<BASIC_STRUCTS.CONTRACT> contracts = new List<BASIC_STRUCTS.CONTRACT>();
        public static int contract_id=0;
        
        int counter = 150;
        public additional_info()
        {
            InitializeComponent();
            contracts = commonQueries.GetContract();
            for(int i=0; i<contracts.Count; i++)
            {
                contractTypeComboBox.Items.Add(contracts[i].contract_name);
            }
            notesTextBox.AcceptsReturn = true;

          
           
            remainingCharactersLabel.Content =counter.ToString();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new rfq_basic_info());
        }

        private void Label_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new rfq_products_info());
        }

        private void Label_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new additional_info());
        }

        private void Label_MouseDoubleClick_3(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new rfq_upload_files());
        }

        private void notesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = notesTextBox.Text;
            
                if (text == "")
                {
                    counter = 150;
                }
                else
                {
                    counter--;
                    if (counter <= 0)
                    {
                        notesTextBox.IsEnabled = false;
                    }
                }
                remainingCharactersLabel.Content = counter.ToString();
            
        }

        private void contractTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           rfq_basic_info.rfq.setcontract( contracts[contractTypeComboBox.SelectedIndex].contract_id, contracts[contractTypeComboBox.SelectedIndex].contract_name);
        }

        private void deadLineTextBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           
            rfq_basic_info.rfq.setdeadline(DateTime.Parse(deadLineTextBox.Text.ToString()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rfq_basic_info.rfq.setcomments(notesTextBox.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rfq_basic_info.rfq.SetProducts(ref rfq_products_info.productsInfo);
            rfq_basic_info.rfq.setcomments(notesTextBox.Text);
            rfq_basic_info.rfq.insertIntoRFQ();
            rfq_basic_info.rfq.insertProducts();
            MessageBox.Show("Successfully Added");
            NavigationService.Navigate(new startRFQ());
        }
    }
}
