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
    /// Interaction logic for rfq_basic_info.xaml
    /// </summary>
    public partial class rfq_basic_info : Page
    {
        common_queries commonQueries = new common_queries();
        employee[] assignee=null;
        contact[] contacts = null;
        public static RFQ rfq = new RFQ();
        List<BASIC_STRUCTS.COMPANY> company= new List<BASIC_STRUCTS.COMPANY>();
        List<BASIC_STRUCTS.CITY> city=new List<BASIC_STRUCTS.CITY>();
        List<BASIC_STRUCTS.STATE> state = new List<BASIC_STRUCTS.STATE>();
        List<BASIC_STRUCTS.COUNTRY> country = new List<BASIC_STRUCTS.COUNTRY>();
        BASIC_STRUCTS.PROJECT[] projects = new BASIC_STRUCTS.PROJECT[100];
        public static int sales_id=0;
        public rfq_basic_info()
        {
            InitializeComponent();
            sales_id = LoginPage.userId;
           
            if (startRFQ.Revise == 1)
            {
                companyAddressComboBox.IsEnabled = false;
                contactPersonComboBox.IsEnabled = false;
                contactPhoneComboBox.IsEnabled = false;
                ProjectComboBox.IsEnabled = false;
                rfq = rfq.getRFQ(startRFQ.rFQ.getRFQSerial(), startRFQ.rFQ.getRFQVersion(), startRFQ.sales_id);
                salesPersonComboBox.Items.Add(rfq.GetContact().getSalesPersonName());
                salesPersonComboBox.IsEnabled = false;
                salesPersonComboBox.SelectedIndex = 0;
                assignee = commonQueries.GetAllPreSales();
                for (int i = 0; i < assignee.Length; i++)
                {

                    preSalesComboBox.Tag = assignee[i].getemployeeID();
                    preSalesComboBox.Items.Add(assignee[i].getemployeeName());

                }
                preSalesComboBox.SelectedItem = rfq.GetEmployee().getemployeeName();
                companyNameComboBox.Items.Add(rfq.GetCOMPANY().company_name.ToString());
                companyNameComboBox.SelectedIndex = 0;
                companyNameComboBox.IsEnabled = false;

                companyAddressComboBox.Items.Add(rfq.GetCOMPANY().branch_name);
                companyAddressComboBox.SelectedIndex = 0;

                contactPersonComboBox.Items.Add(rfq.GetContact().getcontactName());
                contactPersonComboBox.SelectedIndex = 0;

                ProjectComboBox.Items.Add(rfq.getprojectSerial().project_name);
                ProjectComboBox.SelectedIndex = 0;

                rfq.setversion( rfq.GetMaxRFQVersion(LoginPage.userId));
                rfq.setRFQSerial(rfq.GetMaxRFQSerial(sales_id)-1);

            }
            else
            {
                InitializatonFunction();
                rfq.setstatus(1, "Pending");
                rfq.setversion(rfq.GetMaxRFQVersion(LoginPage.userId)-1);
                rfq.setRFQSerial(rfq.GetMaxRFQSerial(sales_id));
                
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            NavigationService.Navigate(new rfq_products_info());
        }

        private void companyNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startRFQ.Revise != 1)
            {
                companyAddressComboBox.IsEnabled = true;
                contactPersonComboBox.IsEnabled = true;
                contactPhoneComboBox.IsEnabled = true;
                ProjectComboBox.IsEnabled = true;

                companyAddressComboBox.Items.Clear();
                contactPersonComboBox.Items.Clear();
                contactPhoneComboBox.Items.Clear();
                ProjectComboBox.Items.Clear();

                companyAddressComboBox.Items.Add(company[companyNameComboBox.SelectedIndex].branch_name + " , " + city[companyNameComboBox.SelectedIndex].city_name + " , " + state[companyNameComboBox.SelectedIndex].state_name + " , " + country[companyNameComboBox.SelectedIndex].country_name);
                companyAddressComboBox.SelectedIndex = 0;

                contactPersonComboBox.Items.Add(contacts[companyNameComboBox.SelectedIndex].getcontactName());
                contactPersonComboBox.SelectedIndex = 0;

                contactPhoneComboBox.Items.Add(contacts[companyNameComboBox.SelectedIndex].getcontactPhone());
                contactPhoneComboBox.SelectedIndex = 0;

                projects= commonQueries.GetProjects();
                for (int i = 0; i < projects.Length; i++)
                {
                    ProjectComboBox.Items.Add(projects[i].project_name);
                }
               
                rfq.setcontactInfo(contacts[companyNameComboBox.SelectedIndex].getcontactID(), contacts[companyNameComboBox.SelectedIndex].getcontactName(), "", LoginPage.userId);
                rfq.setCompanys(company[companyNameComboBox.SelectedIndex].company_id, company[companyNameComboBox.SelectedIndex].company_name, company[companyNameComboBox.SelectedIndex].branch_id, company[companyNameComboBox.SelectedIndex].branch_name);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void InitializatonFunction()
        {
            companyAddressComboBox.IsEnabled = false;
            contactPersonComboBox.IsEnabled = false;
            contactPhoneComboBox.IsEnabled = false;
            ProjectComboBox.IsEnabled = false;

            if (LoginPage.team == MACROS.SALES)
            {
                salesPersonComboBox.Items.Add(LoginPage.userName);
                salesPersonComboBox.SelectedIndex = 0;
                salesPersonComboBox.IsEnabled = false;
            }


            assignee = commonQueries.GetAllPreSales();
            for (int i = 0; i < assignee.Length; i++)
            {

                preSalesComboBox.Tag = assignee[i].getemployeeID();
                preSalesComboBox.Items.Add(assignee[i].getemployeeName());

            }

            contacts = commonQueries.GetCompanies();

            for (int i = 0; i < contacts.Length; i++)
            {

                company.Add(contacts[i].GetCompany());
                city.Add(contacts[i].GetCity());
                state.Add(contacts[i].GetState());
                country.Add(contacts[i].GetCountry());
                companyNameComboBox.Items.Add(company[i].company_name);

            }
        }

       
        private void preSalesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            rfq.setemployeeInfo(assignee[preSalesComboBox.SelectedIndex].getemployeeID(), assignee[preSalesComboBox.SelectedIndex].getemployeeName(), assignee[preSalesComboBox.SelectedIndex].getemployeeEmail(), assignee[preSalesComboBox.SelectedIndex].getemployeeTeam().team_name, assignee[preSalesComboBox.SelectedIndex].getemployeeTeam().team_id, assignee[preSalesComboBox.SelectedIndex].getemployeePosition().position_name, assignee[preSalesComboBox.SelectedIndex].getemployeePosition().position_id, assignee[preSalesComboBox.SelectedIndex].getemployeeDepartment().department_name, assignee[preSalesComboBox.SelectedIndex].getemployeeDepartment().department_id);
            string[] salesName = LoginPage.userName.Split(' ');
            string[] date = DateTime.Now.ToString().Split('/');
            string issuedate = date[1] + date[0] + date[2].Substring(0, 4);
            if(salesName[1].Substring(0, 2)=="Al")
                rfq.setRFQID( "RFQ-" + "000" + startRFQ.rFQ.GetMaxRFQSerial(LoginPage.userId) + "-" + salesName[0].Substring(0, 4).ToUpper() + "." + salesName[2].Substring(0, 4).ToUpper() + "-" + issuedate);
            else
             rfq.setRFQID("RFQ-" + "000" + startRFQ.rFQ.GetMaxRFQSerial(LoginPage.userId) + "-" + salesName[0].Substring(0, 4).ToUpper() + "." + salesName[1].Substring(0, 4).ToUpper() + "-"+issuedate);
        }

        private void companyAddressComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void contactPersonComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void contactPhoneComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProjectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ProjectComboBox.SelectedIndex!=-1)
            rfq.setproject(projects[ProjectComboBox.SelectedIndex].project_id,ProjectComboBox.SelectedItem.ToString(),0,"");
        }
    }
}
