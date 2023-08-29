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
    /// Interaction logic for quotation_basic_info.xaml
    /// </summary>
    public partial class quotation_basic_info : Page
    {
        common_queries commonQueries = new common_queries();
        List<employee> sales;
        List<RFQ> rFQs = new List<RFQ>();
        RFQ rfq = new RFQ();
        List<int> rfqSerial = new List<int>();
        List<int> rfqVersion = new List<int>();
        public static quotation quotation= new quotation();
        public quotation_basic_info()
        {
            InitializeComponent();
            if(LoginPage.team==MACROS.PRE_SALES)
            {
               sales = commonQueries.GetAllSales();
                for(int i=0; i<sales.Count;i++)
                {
                    salesPersonComboBox.Items.Add(sales[i].getemployeeName());
                    
                }
               
            }

            BASIC_STRUCTS.PROJECT[] projects = commonQueries.GetProjects();
            for(int i=0;i< projects.Length;i++)
            {
                projectLocationComboBox.Items.Add(projects[i].project_name);
            }

        }

        private void OnSelChangedSalesPerson(object sender, SelectionChangedEventArgs e)
        {
            rfqSerialComboBox.Items.Clear();
            rFQs = commonQueries.GetAllRFQS();
            for (int i = 0; i < rFQs.Count; i++)
            {
                if (rFQs[i].GetContact().getsalesPersonId() == sales[salesPersonComboBox.SelectedIndex].getemployeeID() && rFQs[i].GetEmployee().getemployeeID() == LoginPage.userId)
                {
                    rfqSerialComboBox.Items.Add(rFQs[i].getRFQId());
                    rfqSerial.Add( rFQs[i].getRFQSerial());
                    rfqVersion.Add(rFQs[i].getRFQVersion());
                }

            }
        }

        private void OnSelChangedRFQId(object sender, SelectionChangedEventArgs e)
        {
            companyNameComboBox.Items.Clear();
            companyAddressComboBox.Items.Clear();
            contactPersonComboBox.Items.Clear();
            if(rfqSerialComboBox.SelectedIndex !=-1)
            {
                rfq = rfq.getRFQ(rfqSerial[rfqSerialComboBox.SelectedIndex], rfqVersion[rfqSerialComboBox.SelectedIndex], sales[salesPersonComboBox.SelectedIndex].getemployeeID());
                companyNameComboBox.Items.Add(rfq.GetCOMPANY().company_name);
                companyNameComboBox.SelectedIndex = 0;
                companyAddressComboBox.Items.Add(rfq.GetCOMPANY().branch_name);
                companyAddressComboBox.SelectedIndex = 0;
                contactPersonComboBox.Items.Add(rfq.GetContact().getcontactName());
                contactPersonComboBox.SelectedIndex = 0;

                quotation.setassignedEmployee(LoginPage.userId, LoginPage.userName);
                quotation.setcontactInfo(rfq.GetContact().getcontactID(), rfq.GetContact().getcontactName(), rfq.GetContact().getcontactPhone(), sales[salesPersonComboBox.SelectedIndex].getemployeeID());
                quotation.setCompany(rfq.GetCOMPANY().company_id, rfq.GetCOMPANY().company_name, rfq.GetCOMPANY().branch_id, rfq.GetCOMPANY().branch_name);
                int maxQuotationSerial = quotation.GetMaxQuotationSerial()+1;
                quotation.setquotationSerial(maxQuotationSerial);
                quotation.setquotationVersion(quotation.GetMaxQuotationVersion());
                string serial = "";
                if (maxQuotationSerial<10)
                {
                    serial="000"+maxQuotationSerial.ToString();
                }
                else if(maxQuotationSerial<100)
                {
                    serial = "00" + maxQuotationSerial.ToString();
                }
                else if(maxQuotationSerial<1000)
                {
                    serial = "0" + maxQuotationSerial.ToString();
                }
                else
                {
                    serial = maxQuotationSerial.ToString();
                }
                string[] date = DateTime.Now.ToString().Split('/');
                string issuedate = date[1] + date[0] + date[2].Substring(0, 4);
                string[] assigneeName = LoginPage.userName.Split(' ');
                quotation.setquotationId("OFFR-" + serial + "-" + assigneeName[0].Substring(0,4).ToUpper()+"."+ assigneeName[0].Substring(0, 4).ToUpper()+"-"+issuedate);
            }
        }

        private void OnBtnClickNext(object sender, RoutedEventArgs e)
        {
            quotation.SetProject(projectLocationComboBox.SelectedIndex, projectLocationComboBox.SelectedItem.ToString());

            NavigationService.Navigate(new quotation_products_info());
        }
    }
}
