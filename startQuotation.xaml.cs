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
    /// Interaction logic for startQuotation.xaml
    /// </summary>
    /// 
    
    public partial class startQuotation : Page
    {
        common_queries queries;
        List<BASIC_STRUCTS.QUOTATIONS> quotationsList;
        public startQuotation()
        {
            InitializeComponent();
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
            yearComboBox.SelectedIndex = 0;
            queries = new common_queries();
            quotationsList = queries.GetAllQuotations();
            if (LoginPage.team == MACROS.SALES)
            {
                addButton.IsEnabled = false;
            }
            for(int i= 0; i < quotationsList.Count; i++)
            {
                string[] year = quotationsList[i].quotation_id.Split('-');
                yearComboBox.Items.Add(year[3].Substring(4));
            }
            if (LoginPage.team == MACROS.SALES)
            {
                salesPersonCheckBox.IsChecked = true;
                salesPersonCheckBox.IsEnabled = false;
                salesPersonComboBox.Items.Add(LoginPage.userName);
                salesPersonComboBox.SelectedIndex = 0;
                salesPersonComboBox.IsEnabled = false;
            }
            FilterationFunction();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new quotation_basic_info());
           
        }

        public void FilterationFunction ()
        {
            quotationStackPanel.Children.Clear();
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

            for (int i = 0; i < quotationsList.Count; i++)
            {
                string[] years = quotationsList[i].quotation_id.Split('-');
                string year1 = years[3].Substring(4);
                Grid grid = new Grid();
                grid.Height = 165;
               
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
                grid.RowDefinitions.Add(row);
                grid.RowDefinitions.Add(row1);
                grid.RowDefinitions.Add(row2);
                grid.RowDefinitions.Add(row3);
                grid.RowDefinitions.Add(row4);
                grid.RowDefinitions.Add(row5);
                if (year1 == yearComboBox.SelectedItem.ToString())
                {
                    Label quotationId = new Label();
                    Label salesPersonName = new Label();
                    Label assignedPerson = new Label();
                    Label companyLabel = new Label();
                    Label contactPerson = new Label();
                    Label productLabel = new Label();
                    Label statusLabel = new Label();

                    quotationId.Content = quotationsList[i].quotation_id;
                    salesPersonName.Content = quotationsList[i].sales_name;
                    assignedPerson.Content = quotationsList[i].pre_sales_name;
                    companyLabel.Content = quotationsList[i].company.company_name;
                    contactPerson.Content = quotationsList[i].contact_name;
                    productLabel.Content = quotationsList[i].product.product_name;
                    statusLabel.Content = quotationsList[i].status.status_name;

                    quotationId.Style = (Style)FindResource("FilterationLabel");
                    salesPersonName.Style = (Style)FindResource("SubTitles");
                    assignedPerson.Style = (Style)FindResource("SubTitles");
                    companyLabel.Style = (Style)FindResource("SubTitles");
                    contactPerson.Style = (Style)FindResource("SubTitles");
                    statusLabel.Style = (Style)FindResource("SubTitles");

                    grid.Children.Add(quotationId);
                    Grid.SetRow(quotationId, 0);
                    grid.Children.Add(salesPersonName);
                    Grid.SetRow(salesPersonName, 1);
                    grid.Children.Add(assignedPerson);
                    Grid.SetRow(assignedPerson, 2);
                    grid.Children.Add(contactPerson);
                    Grid.SetRow(contactPerson, 3);
                    grid.Children.Add(statusLabel);
                    Grid.SetRow(statusLabel, 4);
                    quotationStackPanel.Children.Add(grid);
                }
                else continue;
            }
                for (int i = 0; i < quotationStackPanel.Children.Count;)
                {
                    Grid grid = (Grid)quotationStackPanel.Children[i];
                    string[] years = grid.Children[0].ToString().Split('-');
                    string currentYear = years[3].Substring(4);
                    string sales = grid.Children[1].ToString().Substring(31);
                    if (year == currentYear)
                    {
                        if (salesPerson == sales || salesPerson == "")
                        {
                            if (preSales == grid.Children[2].ToString().Substring(31) || preSales == "")
                            {
                                if (status == grid.Children[4].ToString().Substring(31) || status == "")
                                {
                                    i += 1;
                                    continue;
                                }
                                else
                                {
                                    quotationStackPanel.Children.RemoveAt(i);
                                    i = 0;
                                    continue;
                                }

                            }
                            else
                            {
                                quotationStackPanel.Children.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                        }
                        else
                        {
                            quotationStackPanel.Children.RemoveAt(i);

                            continue;
                        }
                    }
                }
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
                for (int i = 0; i < quotationsList.Count; i++)
                { 
                    if (preSalesComboBox.Items.Contains(quotationsList[i].pre_sales_name))
                        continue;
                    else
                        preSalesComboBox.Items.Add(quotationsList[i].pre_sales_name);
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
            if (brandCheckBox.IsChecked == false)
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
                for (int i = 0; i < quotationsList.Count; i++)
                {
                   
                    if (statusComboBox.Items.Contains(quotationsList[i].status.status_name))
                        continue;
                    else
                        statusComboBox.Items.Add(quotationsList[i].status.status_name);
                }
            }
        }

        private void quarterCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (quarterCheckBox.IsChecked == false)
                quarterComboBox.IsEnabled = false;
            else
                quarterComboBox.IsEnabled = true;
        }

        private void searchCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (searchCheckBox.IsChecked == false)
                searchTextBox.IsEnabled = false;
            else
                searchTextBox.IsEnabled = true;
        }

        private void OnBtnClickWorkOrder(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new startWorkOrder());
        }

        private void OnBtnClickRFQ(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new startRFQ());
        }
    }
    }


