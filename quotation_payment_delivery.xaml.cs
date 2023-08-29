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
    /// Interaction logic for quotation_payment_delivery.xaml
    /// </summary>
    public partial class quotation_payment_delivery : Page
    {
        common_queries commonQueries = new common_queries();
        List<BASIC_STRUCTS.CONTRACT> contracts = new List<BASIC_STRUCTS.CONTRACT>();
        List<BASIC_STRUCTS.CURRENCY> currency = new List<BASIC_STRUCTS.CURRENCY>();
        List<BASIC_STRUCTS.DELIVERY_POINT> deliveryPoint = new List<BASIC_STRUCTS.DELIVERY_POINT>();
        List<BASIC_STRUCTS.TIME_UNIT> timeUnit = new List<BASIC_STRUCTS.TIME_UNIT>();
        List<BASIC_STRUCTS.CONDITION> timeCondition = new List<BASIC_STRUCTS.CONDITION>();
        public quotation_payment_delivery()
        {
            InitializeComponent();
            deliveryTimeMinTextBox.IsEnabled = false;
            deliveryTimeMaxTextBox.IsEnabled = false;
            deliveryTimeUnitComboBox.Items.Clear();
            deliveryTimeUnitComboBox.IsEnabled = false;
            deliveryTimeConditionComboBox.Items.Clear();
            deliveryTimeConditionComboBox.IsEnabled = false;
            deliveryPointComboBox.IsEnabled = false;


            contracts = commonQueries.GetContract();
            currency = commonQueries.GetCurrencies();
            deliveryPoint = commonQueries.GetDeliveryPoint();
            timeUnit = commonQueries.GetTimeUnit();
            timeCondition = commonQueries.GetTimeCondition();

            for(int i=0;i<contracts.Count;i++)
            {
                contractTypeComboBox.Items.Add(contracts[i].contract_name);
            }
            for (int i = 0; i < currency.Count; i++)
            {
                currencyComboBox.Items.Add(currency[i].currency_name);
            }
          
            vatComboBox.Items.Add("Including Vat");
            vatComboBox.Items.Add("Excluding Vat");
        }

       

        private void OnCheckDeliveryTimeCheckBox(object sender, RoutedEventArgs e)
        {
            if(deliveryTimeCheckBox.IsChecked==false)
            {
                deliveryTimeMinTextBox.IsEnabled = false;
                deliveryTimeMaxTextBox.IsEnabled = false;
                deliveryTimeUnitComboBox.Items.Clear();
                deliveryTimeUnitComboBox.IsEnabled = false;
                deliveryTimeConditionComboBox.Items.Clear();
                deliveryTimeConditionComboBox.IsEnabled = false;
            }
            else
            {
                deliveryTimeMinTextBox.IsEnabled = true;
                deliveryTimeMaxTextBox.IsEnabled = true;
                deliveryTimeUnitComboBox.IsEnabled = true;
                deliveryTimeConditionComboBox.IsEnabled = true;
                for (int i = 0; i < timeUnit.Count; i++)
                {
                    deliveryTimeUnitComboBox.Items.Add(timeUnit[i].time_unit_name);
                }
                for (int i = 0; i < timeCondition.Count; i++)
                {
                    deliveryTimeConditionComboBox.Items.Add(timeCondition[i].condition_name);
                }
            }
        }

        private void OnCheckDeliveryPointCheckBox(object sender, RoutedEventArgs e)
        {
            if (deliveryPointCheckBox.IsChecked == false)
            {
                deliveryPointComboBox.IsEnabled = false;
                deliveryPointComboBox.Items.Clear();
            }
            else
            {
                deliveryPointComboBox.IsEnabled = true;
                for (int i = 0; i < deliveryPoint.Count; i++)
                {
                    deliveryPointComboBox.Items.Add(deliveryPoint[i].delivery_point_name);
                }
            }
        }

        private void OnBtnClickNext(object sender, RoutedEventArgs e)
        {
            quotation_basic_info.quotation.SetContractType(contracts[contractTypeComboBox.SelectedIndex].contract_id, contracts[contractTypeComboBox.SelectedIndex].contract_name);
            quotation_basic_info.quotation.settotalPrice(float.Parse(totalPriceTextBox.Text));
            quotation_basic_info.quotation.setonDelivery(Int32.Parse(onDeliveryTextBox.Text));
            quotation_basic_info.quotation.setonInstallation(Int32.Parse(onInstallationTextBox.Text));
            quotation_basic_info.quotation.setdeliveryMinPeriod(Int32.Parse(deliveryTimeMinTextBox.Text));
            quotation_basic_info.quotation.setdeliveryMaxPeriod(Int32.Parse(deliveryTimeMaxTextBox.Text));
            quotation_basic_info.quotation.SetDeliveryTimeUnit(timeUnit[deliveryTimeUnitComboBox.SelectedIndex].time_unit_id, deliveryTimeUnitComboBox.SelectedItem.ToString());
            quotation_basic_info.quotation.SetDeliveryTimeCondition(timeCondition[ deliveryTimeConditionComboBox.SelectedIndex].condition_id, deliveryTimeConditionComboBox.SelectedItem.ToString());
            quotation_basic_info.quotation.SetCurrency(currency[ currencyComboBox.SelectedIndex].currency_id, currencyComboBox.SelectedItem.ToString());
            quotation_basic_info.quotation.SetDeliveryPoint(deliveryPoint[deliveryPointComboBox.SelectedIndex].delivery_point_id, deliveryPointComboBox.SelectedItem.ToString());
            if(vatComboBox.SelectedIndex==0)
            {
                quotation_basic_info.quotation.setvatCondition(1);
                
            }
            else
                quotation_basic_info.quotation.setvatCondition(0);
            NavigationService.Navigate(new quotation_additional_info());

        }
    }
}
