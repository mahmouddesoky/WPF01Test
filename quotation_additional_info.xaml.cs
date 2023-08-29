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
    /// Interaction logic for quotation_additional_info.xaml
    /// </summary>
    public partial class quotation_additional_info : Page
    {
        common_queries commonQueries = new common_queries();
        List<BASIC_STRUCTS.TIME_UNIT> timeUnitList = new List<BASIC_STRUCTS.TIME_UNIT>();
        List<BASIC_STRUCTS.CONDITION> condition = new List<BASIC_STRUCTS.CONDITION>();
        public quotation_additional_info()
        {
            InitializeComponent();
            minDeadlineTextBox.IsEnabled = false;
            maxDeadlineTextBox.IsEnabled = false;
            deadlineTimeUnitComboBox.IsEnabled = false;
            deadlineTimeConditionComboBox.IsEnabled = false;
            warrantyPeriodTextBox.IsEnabled = false;    
            warrantyTimeUnitComboBox.IsEnabled = false;
            warrantyTimeConditionComboBox.IsEnabled=false;

            timeUnitList = commonQueries.GetTimeUnit();
            condition = commonQueries.GetTimeCondition();

            for(int i=0; i < timeUnitList.Count; i++)
            {
                validtyPeriodComboBox.Items.Add(timeUnitList[i].time_unit_name);
            }
            

        }

        private void OnCheckDealineCheckBox(object sender, RoutedEventArgs e)
        {

            if(deadlineCheckBox.IsChecked==false)
            {
                minDeadlineTextBox.IsEnabled = false;
                maxDeadlineTextBox.IsEnabled = false;
                deadlineTimeUnitComboBox.IsEnabled = false;
                deadlineTimeConditionComboBox.IsEnabled = false;
                deadlineTimeConditionComboBox.Items.Clear();
                deadlineTimeUnitComboBox.Items.Clear();
            }
            else
            {
                minDeadlineTextBox.IsEnabled = true;
                maxDeadlineTextBox.IsEnabled = true;
                deadlineTimeUnitComboBox.IsEnabled = true;
                deadlineTimeConditionComboBox.IsEnabled = true;
                for(int i=0; i<timeUnitList.Count; i++)
                {
                    deadlineTimeUnitComboBox.Items.Add(timeUnitList[i].time_unit_name);
                }
                for (int i = 0; i < condition.Count; i++)
                {
                    deadlineTimeConditionComboBox.Items.Add(condition[i].condition_name);
                }
            }
        }

        private void OnCheckWarrantyPeriodCheckBox(object sender, RoutedEventArgs e)
        {
            if(warrantyPeriodCheckBox.IsChecked==false)
            {
                warrantyPeriodTextBox.IsEnabled = false;
                warrantyTimeUnitComboBox.IsEnabled = false;
                warrantyTimeConditionComboBox.IsEnabled = false;
                warrantyTimeConditionComboBox.Items.Clear();
                warrantyTimeUnitComboBox.Items.Clear();
            }
            else
            {
                warrantyPeriodTextBox.IsEnabled = true;
                warrantyTimeUnitComboBox.IsEnabled = true;
                warrantyTimeConditionComboBox.IsEnabled = true;
                for (int i = 0; i < timeUnitList.Count; i++)
                {
                    warrantyTimeUnitComboBox.Items.Add(timeUnitList[i].time_unit_name);
                }
                for (int i = 0; i < condition.Count; i++)
                {
                    warrantyTimeConditionComboBox.Items.Add(condition[i].condition_name);
                }
            }
        }

        private void OnBtnClickFinish(object sender, RoutedEventArgs e)
        {
            quotation_basic_info.quotation.SetWarrantyUnit(timeUnitList[warrantyTimeUnitComboBox.SelectedIndex].time_unit_id, warrantyTimeUnitComboBox.SelectedItem.ToString());
            quotation_basic_info.quotation.SetWarrantyTimeCondition(condition[ warrantyTimeConditionComboBox.SelectedIndex].condition_id, warrantyTimeConditionComboBox.SelectedItem.ToString());
            quotation_basic_info.quotation.SetWarrantyPeriod(Int32.Parse(warrantyPeriodTextBox.Text));
            quotation_basic_info.quotation.setquotationStatusId(3);
            quotation_basic_info.quotation.setquotationNotes(additionalDescriptionTextBox.Text);
            quotation_basic_info.quotation.setissueDate(DateTime.Now);
            quotation_basic_info.quotation.InsertQuotation();

            MessageBox.Show("Added Successfully");
        }
    }
}
