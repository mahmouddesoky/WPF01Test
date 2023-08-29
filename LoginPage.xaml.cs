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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static int userId=0;
        public static string userName = "";
        public static int team=0;
        public static int position = 0;
        public LoginPage()
        {
            InitializeComponent();
            emailtextbox.Text = "mohamed.amin@01electronics.net";
            passwordtextbox.Password = "1234";
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employee employee = new employee();
            int id = employee.CheckIfEmailExist(emailtextbox.Text);
            if(id != 0)
            {


                string password = employee.CheckIfPasswordCorrect(id);
                if(password == passwordtextbox.Password.ToString())
                {
                    employee.FillEmployeeData(id);
                    employee.setemployeeEmail(emailtextbox.Text);
                    employee.setemployeeID(id);
                    MACROS macros = new MACROS();
                    userId = id;
                    userName = employee.getemployeeName();
                    BASIC_STRUCTS.EMPLOYEE_TEAM employeeTeam= employee.getemployeeTeam();
                    team = employeeTeam.team_id;
                    BASIC_STRUCTS.EMPLOYEE_POSITION employeePosition = employee.getemployeePosition();
                    position = employeePosition.position_id;
                    NavigationService.Navigate(new startRFQ());
                  
                    
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }

               

            }
            else
            {
                MessageBox.Show("Incorrect Email");
            }
            
        }

      
    }
}
