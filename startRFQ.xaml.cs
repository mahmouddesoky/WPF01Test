using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for startRFQ.xaml
    /// </summary>
    public partial class startRFQ : Page
    {
        List<RFQ> rFQs = new List<RFQ>();
       public static RFQ rFQ = new RFQ();
        common_queries common = new common_queries();
        public static int Revise=0;
        public static int sales_id = 0;
        public startRFQ()
        {
            InitializeComponent();
           
            InitializationFunction();
            
        }

        private void searchCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (searchCheckBox.IsChecked == false)
                searchTextBox.IsEnabled = false;
            else
                searchTextBox.IsEnabled = true;
        }

        private void yearCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(yearCheckBox.IsChecked == false)
                yearComboBox.IsEnabled = false;
            else
                yearComboBox.IsEnabled = true;
        }

        private void quarterCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(quarterCheckBox.IsChecked == false)
                quarterComboBox.IsEnabled = false;
            else 
                quarterComboBox.IsEnabled = true;
        }

        private void salesPersonCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (salesPersonCheckBox.IsChecked == false)
                salesPersonComboBox.IsEnabled = false;
            else
                salesPersonComboBox.IsEnabled = true;
        }

        private void preSalesEngineerCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (preSalesEngineerCheckBox.IsChecked == false)
            {
                preSalesComboBox.IsEnabled = false;
                preSalesComboBox.SelectedItem = null;
            }
            else
            {
                preSalesComboBox.Items.Clear();
                preSalesComboBox.IsEnabled = true;
                for (int i = 0; i < rFQs.Count; i++)
                {
                    employee employee = rFQs[i].GetEmployee();
                    if (preSalesComboBox.Items.Contains(employee.getemployeeName()))
                        continue;
                    else
                    preSalesComboBox.Items.Add(employee.getemployeeName());
                }
            }
        }

        private void productCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (productCheckBox.IsChecked == false)
                productComboBox.IsEnabled = false;
            else
                productComboBox.IsEnabled = true;

        }

        private void brandCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(brandCheckBox.IsChecked == false)
                brandComboBox.IsEnabled = false;
            else
                brandComboBox.IsEnabled = true;

        }

        private void contractTypeCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (contractTypeCheckBox.IsChecked == false)
                contractTypeComboBox.IsEnabled = false;
            else
                contractTypeComboBox.IsEnabled = true;
        }

        private void statusCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (statusCheckBox.IsChecked == false)
            {
                statusComboBox.IsEnabled = false;
                statusComboBox.SelectedItem = null;
            }
            else
            {
                statusComboBox.Items.Clear();
                statusComboBox.IsEnabled = true;
                for (int i = 0; i < rFQs.Count; i++)
                {
                    BASIC_STRUCTS.STATUS statusStruct = rFQs[i].getstatus();
                    if (statusComboBox.Items.Contains(statusStruct.status_name))
                        continue;
                    else
                        statusComboBox.Items.Add(statusStruct.status_name);
                }
            }
        }

        private void yearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterationFunction();
        }

        private void preSalesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            filterationFunction();
        }

       

        private void statusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterationFunction();
        }

        public void filterationFunction()
        {
            loadRfqStackPanel.Children.Clear();
            string year = "";
            string quarter = "";
            string salesPerson = "";
            string preSales = "";
            string product = "";
            string brand = "";
            string contractType = "";
            string status = "";
            if (yearComboBox.SelectedItem != null)
                year = yearComboBox.SelectedItem.ToString();
            if (quarterComboBox.SelectedItem != null)
                quarter = quarterComboBox.SelectedItem.ToString();
            if (salesPersonComboBox.SelectedItem != null)
                salesPerson = salesPersonComboBox.SelectedItem.ToString();
            if (preSalesComboBox.SelectedItem != null)
                preSales = preSalesComboBox.SelectedItem.ToString();
            if (productComboBox.SelectedItem != null)
                product = productComboBox.SelectedItem.ToString();
            if (brandComboBox.SelectedItem != null)
                brand = brandComboBox.SelectedItem.ToString();
            if (contractTypeComboBox.SelectedItem != null)
                contractType = contractTypeComboBox.SelectedItem.ToString();
            if (statusComboBox.SelectedItem != null)
                status = statusComboBox.SelectedItem.ToString();

            for (int i = 0; i < rFQs.Count; i++)
            {
                string[] years = rFQs[i].getRFQId().Split('-');
                string year1 = years[3].Substring(4);
                Grid grid = new Grid();
                grid.Height = 200;
                
                ColumnDefinition col = new ColumnDefinition();
               
                ColumnDefinition col2 = new ColumnDefinition();
                col2.MaxWidth = 120;
                ColumnDefinition col3 = new ColumnDefinition();
                col3.MaxWidth = 55;
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(40);
                RowDefinition row1 = new RowDefinition();
                row1.Height = new GridLength(30);
                RowDefinition row2 = new RowDefinition();
                row2.Height = new GridLength(30);
                RowDefinition row3 = new RowDefinition();
                row3.Height = new GridLength(30);
                RowDefinition row4 = new RowDefinition();
                row4.Height = new GridLength(30);
                RowDefinition row5 = new RowDefinition();
                row5.Height = new GridLength(30);
                grid.ColumnDefinitions.Add(col);
                grid.ColumnDefinitions.Add(col2);
                grid.ColumnDefinitions.Add(col3);
                grid.RowDefinitions.Add(row);
                grid.RowDefinitions.Add(row1);
                grid.RowDefinitions.Add(row2);
                grid.RowDefinitions.Add(row3);
                grid.RowDefinitions.Add(row4);
                grid.RowDefinitions.Add(row5);

                if (year1 == yearComboBox.SelectedItem.ToString())
                {
                    employee employee = rFQs[i].GetEmployee();
                    contact contact = rFQs[i].GetContact();
                    BASIC_STRUCTS.COMPANY company = rFQs[i].GetCOMPANY();
                    BASIC_STRUCTS.STATUS statusStruct = rFQs[i].getstatus();
                    Label rfqID = new Label();
                    Label salesPersonName = new Label();
                    Label assignedPerson = new Label();
                    Label companyLabel = new Label();
                    Label contactPerson = new Label();
                    Label productLabel = new Label();
                    Label statusLabel = new Label();

                    Expander expander = new Expander();
                    StackPanel stackPanel = new StackPanel();
                    Button view = new Button();
                    Button review = new Button();

                    Border statusBorder = new Border();

                    view.Content = "View";
                    review.Content = "Revise";
                    view.Click+=viewButtonClick;
                    review.Click += reviseButtonClick;
                    review.Tag = rFQs[i].getRFQId()+ "," + rFQs[i].getRFQSerial() + "," + rFQs[i].getRFQVersion() +","+ contact.getsalesPersonId() ;
                    view.Style= (Style)FindResource("Button1");
                    review.Style= (Style)FindResource("Button1");
                    stackPanel.Children.Add(view);
                    stackPanel.Children.Add(review);
                    expander.Style = (Style)FindResource("expander");
                    expander.Content =stackPanel;

                    rfqID.Content = rFQs[i].getRFQId();
                    salesPersonName.Content = rFQs[i].GetContact().getSalesPersonName();
                    assignedPerson.Content = employee.getemployeeName();
                    companyLabel.Content = company.company_name;
                    contactPerson.Content = companyLabel.ToString().Substring(31) + "-" + contact.getcontactName();
                    statusLabel.Content = statusStruct.status_name;
                    rfqID.Style = (Style)FindResource("FilterationLabel");
                    salesPersonName.Style = (Style)FindResource("SubTitles");
                    assignedPerson.Style = (Style)FindResource("SubTitles");
                    companyLabel.Style = (Style)FindResource("SubTitles");
                    contactPerson.Style = (Style)FindResource("SubTitles");
                    statusLabel.Style = (Style)FindResource("SubTitles1");
                    statusBorder.Child = statusLabel;
                    statusBorder.Style= (Style)FindResource("status");

                    grid.Children.Add(rfqID);
                    Grid.SetRow(rfqID, 0);
                    grid.Children.Add(salesPersonName);
                    Grid.SetRow(salesPersonName, 1);
                    grid.Children.Add(assignedPerson);
                    Grid.SetRow(assignedPerson, 2);
                    grid.Children.Add(contactPerson);
                    Grid.SetRow(contactPerson, 3);

                    grid.Children.Add(statusBorder);
                    Grid.SetRow(statusBorder,0);
                    Grid.SetColumn(statusBorder, 1);

                    grid.Children.Add(expander);
                    Grid.SetRow(expander, 0);
                    Grid.SetColumn(expander, 2);
                    Grid.SetRowSpan(expander, 2);

                    loadRfqStackPanel.Children.Add(grid);
                   
                }
                else
                    continue;

            }

            for (int i = 0; i < loadRfqStackPanel.Children.Count;)
            {
                Grid grid = (Grid)loadRfqStackPanel.Children[i];
                string[] years = grid.Children[0].ToString().Split('-');
                string currentYear = years[3].Substring(4);
                string sales = grid.Children[1].ToString().Substring(31);
                Border border = new Border();
                UIElement Presaleschild = new UIElement();
                foreach(UIElement  child in grid.Children)
                {
                    if(Grid.GetRow(child) == 2 && Grid.GetColumn(child) == 0)
                        Presaleschild=child;
                    if(Grid.GetRow(child) == 0&&Grid.GetColumn(child) == 1)
                    {
                        border = child as Border;
                        break;
                    }
                }
               
                if (year == currentYear)
                {
                    if (salesPerson == sales || salesPerson == "")
                    {
                        if (preSales == Presaleschild.ToString().Substring(31) || preSales == "")
                        {
                            if (status == border.Child.ToString().Substring(31) || status == "")
                            {
                                i += 1;

                                continue;
                            }
                            else
                            {
                                loadRfqStackPanel.Children.RemoveAt(i);
                                i = 0;
                                continue;
                            }

                        }
                        else
                        {
                            loadRfqStackPanel.Children.RemoveAt(i);
                            i = 0;
                            continue;
                        }
                    }
                    else
                    {
                        loadRfqStackPanel.Children.RemoveAt(i);

                        continue;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new rfq_basic_info());
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new startQuotation());
        }
        private void viewButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void reviseButtonClick(object sender, RoutedEventArgs e)
        {
            Revise = 1;
            Button revise = sender as Button;
            string[] rfqdata = revise.Tag.ToString().Split(',');
            rFQ.setRFQID(rfqdata[0]);
            rFQ.setRFQSerial(Int32.Parse(rfqdata[1]));
            rFQ.setversion(Int32.Parse(rfqdata[2]));
            sales_id=int.Parse(rfqdata[3]);
            NavigationService.Navigate(new rfq_basic_info());
        }
        public void InitializationFunction()
        {
            searchTextBox.IsEnabled = false;
            quarterComboBox.IsEnabled = false;
            salesPersonComboBox.IsEnabled = false;
            preSalesComboBox.IsEnabled = false;
            productComboBox.IsEnabled = false;
            brandComboBox.IsEnabled = false;
            contractTypeComboBox.IsEnabled = false;
            statusComboBox.IsEnabled = false;
            yearCheckBox.IsChecked = true;
            yearCheckBox.IsEnabled = false;

            rFQs = common.GetAllRFQS();
            for (int i = 0; i < rFQs.Count; i++)
            {
                string[] years = rFQs[i].getRFQId().Split('-');
                string year = years[3].Substring(4);

                if (!yearComboBox.Items.Contains(year))
                {
                    yearComboBox.Items.Add(year);
                    continue;
                }

            }
            yearComboBox.SelectedIndex = 0;


            if (LoginPage.team == MACROS.SALES)
            {
                salesPersonCheckBox.IsChecked = true;
                salesPersonCheckBox.IsEnabled = false;
                salesPersonComboBox.Items.Add(LoginPage.userName);
                salesPersonComboBox.SelectedIndex = 0;
                salesPersonComboBox.IsEnabled = false;
            }
        }

        private void OnBtnClickWorkOrder(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new startWorkOrder());
        }
    }
}
