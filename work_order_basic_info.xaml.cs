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
    /// Interaction logic for work_order_basic_info.xaml
    /// </summary>
    public partial class work_order_basic_info : Page
    {
        common_queries commonQueries = new common_queries();
        List<employee> sales = new List<employee>();
        List<BASIC_STRUCTS.QUOTATIONS>quotations=new List<BASIC_STRUCTS.QUOTATIONS>();
        List<int> quotationSerial = new List<int>();
        public work_order_basic_info()
        {

            InitializeComponent();
            sales = commonQueries.GetAllSales();
            for(int i=0; i < sales.Count; i++)
            {
                salesPersonComboBox.Items.Add(sales[i].getemployeeName());
            }
            quotationIDComboBox.IsEnabled = false;
            quotations = commonQueries.GetAllQuotations();
            
        }

        private void OnCheckQuotationIDCheckBox(object sender, RoutedEventArgs e)
        {
            quotationIDComboBox.Items.Clear();
            if(quotationIDCheckBox.IsChecked == true)
            {
                quotationIDComboBox.IsEnabled = true;
      
                for(int i=0; i<quotations.Count;i++)
                {
                    if (sales[salesPersonComboBox.SelectedIndex].getemployeeID() == quotations[i].sales_id)
                    {
                        quotationIDComboBox.Items.Add(quotations[i].quotation_id);
                        quotationSerial.Add(i);
                    }
                }
            }
            else
            {
                quotationIDComboBox.Items.Clear();
                quotationIDComboBox.IsEnabled = false;
            }
        }

        private void OnSelChangedSalesPersonComboBox(object sender, SelectionChangedEventArgs e)
        {
            if (quotationIDCheckBox.IsChecked == true)
            {
                quotationIDComboBox.Items.Clear();
                for (int i = 0; i < quotations.Count; i++)
                {
                    if (sales[salesPersonComboBox.SelectedIndex].getemployeeID() == quotations[i].sales_id)
                    {
                        quotationIDComboBox.Items.Add(quotations[i].quotation_id);
                        quotationSerial.Add(i);
                    }
                }
            }
        }

        private void OnSelChangedQuotationIDComboBox(object sender, SelectionChangedEventArgs e)
        {
            
            companyNameComboBox.Items.Add(quotations[quotationSerial[quotationIDComboBox.SelectedIndex]].company.company_name);
            companyNameComboBox.SelectedIndex = 0;
            companyAddressComboBox.Items.Add(quotations[quotationSerial[quotationIDComboBox.SelectedIndex]].district.district_name);
            companyAddressComboBox.SelectedIndex = 0;
            contactPersonComboBox.Items.Add(quotations[quotationSerial[quotationIDComboBox.SelectedIndex]].contact_name);
            contactPersonComboBox.SelectedIndex = 0;
            issueDateDatePicker.Text =quotations[quotationSerial[quotationIDComboBox.SelectedIndex]].issue_date.ToString();
        }
    }
}
