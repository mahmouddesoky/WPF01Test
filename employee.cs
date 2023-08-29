using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class employee
    {
        private int employeeID;
        private string employeeEmail;
        private string employeeName;
        BASIC_STRUCTS.EMPLOYEE_POSITION EMPLOYEE_POSITION;
        BASIC_STRUCTS.EMPLOYEE_TEAM EMPLOYEE_TEAM;
        BASIC_STRUCTS.EMPLOYEE_DEPARTMENT EMPLOYEE_DEPARTMENT;
        public employee()
        { }
        public void setemployeeID(int id)
        { employeeID = id; }
        public void setemployeeEmail(string email)
        { employeeEmail = email; }
        public void setemployeeName(string name)
        { employeeName = name; }
        public void setemployeeTeam(string team, int teamid)
        { EMPLOYEE_TEAM.team_name = team;EMPLOYEE_TEAM.team_id = teamid; }
        public void setemployeePosition(string position, int positionid)
        { EMPLOYEE_POSITION.position_name = position; EMPLOYEE_POSITION.position_id = positionid; }
        public void setemployeeDepartment(string department , int departmentid)
        { EMPLOYEE_DEPARTMENT.department_name = department;EMPLOYEE_DEPARTMENT.department_id = departmentid; }
        /////////////////////////////////////////
        ///getFunctions
        ////////////////////////////////////////
        public int getemployeeID()
        {
            return employeeID;
        }
        public string getemployeeName()
        { return employeeName; }
        public BASIC_STRUCTS.EMPLOYEE_TEAM getemployeeTeam()
        { return EMPLOYEE_TEAM; }
        public BASIC_STRUCTS.EMPLOYEE_POSITION getemployeePosition()
        { return EMPLOYEE_POSITION; }
        public BASIC_STRUCTS.EMPLOYEE_DEPARTMENT getemployeeDepartment()
        { return EMPLOYEE_DEPARTMENT; }
        public string getemployeeEmail()
        { return employeeEmail; }
      
        public int CheckIfEmailExist(string Email)
        {
            database database = new database();
            int id=0;
            string query = "select id from employees_business_emails inner join employees_info on employees_business_emails.id = employees_info.employee_id \r\nwhere email='"+Email+"'";
            DataTable table = database.GetColumns(query);
            foreach(DataRow row in table.Rows)
            {
                id = Int32.Parse(row["id"].ToString());
            }
            return id;
        }
        public string CheckIfPasswordCorrect(int id)
        {
            database database=new database();
            string password = "";
            string query = "select password from employees_passwords inner join employees_info on employees_passwords.id=employees_info.employee_id\r\nwhere id="+id;
            DataTable table = database.GetColumns(query);
            foreach(DataRow row in table.Rows)
            {
                password = row["password"].ToString();
            }
            return password;   
        }
        public void FillEmployeeData(int id)
        {
            database database = new database();
            string query = "select name,teams_type.team,teams_type.id,positions_type.position,positions_type.id,departments_type.department,departments_type.id from employees_info inner join teams_type \r\non employees_info.employee_team=teams_type.id inner join positions_type \r\non positions_type.id=employees_info.employee_position inner join departments_type on\r\ndepartments_type.id=employees_info.employee_department where employees_info.employee_id="+id;
            DataTable tabel = database.GetColumns(query);

            foreach(DataRow row in tabel.Rows)
            {
                setemployeeName(row[0].ToString());
                setemployeeTeam(row[1].ToString() , Int32.Parse(row[2].ToString()));
               
                setemployeePosition(row[3].ToString(), Int32.Parse(row[4].ToString()));
                
                setemployeeDepartment(row[5].ToString(), Int32.Parse(row[6].ToString()));
             
            }
        }
    }
}

