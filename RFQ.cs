using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfApp1.BASIC_STRUCTS;

namespace WpfApp1
{
    public class RFQ
    {
        public RFQ() { }
        private contact contactInfo = new contact();
        private employee Assigned = new employee();
        private int RFQSerial;
        private int RFQVersion;
        private string RFQID;
        protected const String RFQ_ID_FORMAT = "RFQ-0001-XXXX.XXXX-DDMMYYYY";
        private BASIC_STRUCTS.CONTRACT contract = new BASIC_STRUCTS.CONTRACT();
        private BASIC_STRUCTS.STATUS status = new BASIC_STRUCTS.STATUS();
        private string comments;
        private DateTime deadline;
        private BASIC_STRUCTS.COMPANY company = new BASIC_STRUCTS.COMPANY();
        private BASIC_STRUCTS.PROJECT project = new BASIC_STRUCTS.PROJECT();
        private List<BASIC_STRUCTS.PRODUCT_INFO> productList = new List<BASIC_STRUCTS.PRODUCT_INFO>();

        /////////////////////////////////////
        ///setFunctions
        //////////////////////////////////
        ///
        public void setcontactInfo(int id, string name, string phone, int salesId )
        {
            contactInfo.setcontactID(id);
            contactInfo.setcontactName(name);
            contactInfo.setcontactPhone(phone);
            contactInfo.setsalesPersonId(salesId);
           
        }
        public void setSalesName(string name)
        {
            contactInfo.setSalesPersonName(name);
        }
        public void setemployeeInfo(int id, string name , string email , string team , int teamId , string position , int positionId, string department,int departmentId)
        {
            Assigned.setemployeeID(id);
            Assigned.setemployeeName(name);
            Assigned.setemployeeEmail(email);
            Assigned.setemployeeTeam(team, teamId);
            Assigned.setemployeePosition(position, positionId);
            Assigned.setemployeeDepartment(department, departmentId);
           
        }
        public void setCompanys(int companySerial, string companyName, int addressSerail, string addressName)
        {
            company.company_name = companyName;
            company.company_id = companySerial;
            company.branch_id = addressSerail;
            company.branch_name = addressName;
        }
        public void setRFQSerial(int id)
        { RFQSerial = id; }
        public void setversion(int version)
        { RFQVersion = version; }
        public void setRFQID(string id)
        { RFQID = id; }
        public void setcontract(int serial , string type)
        {
            contract.contract_id= serial;
            contract.contract_name= type;
        }
        public void setstatus(int id , string status )
        {
            this.status.status_id = id;
            this.status.status_name = status;
        }
       
        public void setcomments(string Comments)
        { comments = Comments; }
        public void setdeadline(DateTime dateTime)
        { deadline = dateTime; }
        public void setproject(int projectId , string projectName,int locationId,string locationName)
        {
            project.project_id = projectId;
            project.project_name = projectName; 
            project.project_location_id= locationId;
            project.project_location=locationName;
        }
        public void SetProducts(ref List<BASIC_STRUCTS.PRODUCT_INFO> temp)
        {

            productList = temp;

        }
        ////////////////////////////////////////////
        ///getFunctons
        ///////////////////////////////////////////
        public int getRFQSerial()
        { return RFQSerial; }
        public int getRFQVersion()
        { return RFQVersion; }
        public string getRFQId()
        { return RFQID; }
        public BASIC_STRUCTS.CONTRACT getcontract()
        { return contract; }
        public BASIC_STRUCTS.STATUS getstatus()
        { return status; }
        public string getcomments()
        { return comments; }
        public DateTime getdeadline()
        { return deadline; }
        public BASIC_STRUCTS.PROJECT getprojectSerial()
        { return project; }
        public List<BASIC_STRUCTS.PRODUCT_INFO> getProducts()
        {
            return productList;
        }
        public BASIC_STRUCTS.COMPANY GetCOMPANY()
        { return company; }
        public employee GetEmployee()
        { return Assigned; }
        public contact GetContact()
        { return contactInfo; }
       
        public RFQ getRFQ(int serial, int version, int sales)
        {
            RFQ rfQ = new RFQ();
            database database = new database();
            DataTable table = new DataTable();
            string query = @"with get_sales_person as(select  employees_info.name as sales_name
							, employees_info.employee_id as sales_id 
						from employees_info
						),
	get_assigned_engineer as(select  employees_info.name as assigned_name
							, employees_info.employee_id as assigned_id 
							, employees_info.employee_team as employee_team_id
							, employees_info.employee_department as employee_department_id
							,employees_info.employee_position as employee_position_id
						from employees_info
						),
	get_contact_info as (select contact_person_info.name as contact_name 
	                          , contact_person_info.contact_id as contact_id 
							  , contact_person_info.sales_person_id as sales_id
							  , contact_person_info.branch_serial as branch_serial
	 from contact_person_info)
select distinct get_sales_person.sales_name, get_assigned_engineer.assigned_name , 
get_sales_person.sales_id , get_assigned_engineer.assigned_id , get_contact_info.contact_name , 
get_contact_info.contact_id , get_contact_info.branch_serial , districts.district , districts.id as district_id,
company_name.company_name , RFQ_status.type as status_type , RFQ_status.id as status_id , 
contract_type.id as contract_id , contract_type.type as contract_type , RFQ.comments , RFQ.deadline , 
client_projects.project_name , client_projects.project_serial , cities.id as city_id, cities.city,
states_governorates.id as state_id , states_governorates.state_governorate , countries.id as country_id , countries.country,
employees_business_emails.email as employee_email , teams_type.team , teams_type.id as team_id , departments_type.department, departments_type.id as department_id
, positions_type.id as position_id,positions_type.position
from RFQ
inner join get_sales_person
on RFQ.sales_person_id=get_sales_person.sales_id
inner join get_assigned_engineer
on RFQ.assigned_engineer=get_assigned_engineer.assigned_id
inner join get_contact_info 
on RFQ.contact_id=get_contact_info.contact_id and get_contact_info.branch_serial=RFQ.branch_serial and get_contact_info.sales_id=RFQ.sales_person_id
inner join company_address 
on company_address.address_serial = get_contact_info.branch_serial
inner join districts
on company_address.address=districts.id
inner join company_name
on company_name.company_serial=RFQ.branch_serial
inner join RFQ_status 
on RFQ_status.id=RFQ.status
inner join contract_type
on RFQ.contract_type = contract_type.id
inner join client_projects 
on client_projects.project_serial=RFQ.project_serial
inner join projects_location
on client_projects.project_serial=projects_location.project_serial
inner join cities
on districts.city=cities.id
inner join states_governorates
on states_governorates.id=cities.state_governorate
inner join countries
on countries.id=states_governorates.country
inner join employees_business_emails
on get_assigned_engineer.assigned_id=employees_business_emails.id
inner join teams_type
on teams_type.id = get_assigned_engineer.employee_team_id
inner join positions_type
on positions_type.id=get_assigned_engineer.employee_position_id
inner join departments_type
on departments_type.id=get_assigned_engineer.employee_department_id
where RFQ.RFQ_serial=" + serial + " and RFQ.RFQ_version=" + version + " and RFQ.sales_person_id=" + sales;
            table = database.GetColumns(query);
            foreach (DataRow row in table.Rows)
            {
                rfQ.setcontactInfo(Int32.Parse(row["contact_id"].ToString()), row["contact_name"].ToString(), "", Int32.Parse(row["sales_id"].ToString()));
                rfQ.setSalesName(row["sales_name"].ToString());
                rfQ.setemployeeInfo(Int32.Parse(row["assigned_id"].ToString()), row["assigned_name"].ToString(), row["employee_email"].ToString(), row["team"].ToString(), Int32.Parse(row["team_id"].ToString()), row["position"].ToString(), Int32.Parse(row["position_id"].ToString()), row["department"].ToString(), Int32.Parse(row["department_id"].ToString()));
                rfQ.setCompanys(Int32.Parse(row["branch_serial"].ToString()), row["company_name"].ToString(), Int32.Parse(row["district_id"].ToString()), row["district"].ToString() + "," + row["city"].ToString() + "," + row["state_governorate"].ToString() + "," + row["country"].ToString());
                rfQ.setstatus(Int32.Parse(row["status_id"].ToString()), row["status_type"].ToString());
                rfQ.setcontract(Int32.Parse(row["contract_id"].ToString()), row["contract_type"].ToString());
                rfQ.setcomments(row["comments"].ToString());
                rfQ.setproject(Int32.Parse(row["project_serial"].ToString()), row["project_name"].ToString(), 0, "");

            }
            return rfQ;
        }

        public int GetMaxRFQSerial(int salesId)
        {
            database database = new database();
            DataTable table = new DataTable();
            int maxRFQSerial = 0;
            string query = "select max(RFQ_serial)  from RFQ where sales_person_id=" + salesId;
            table = database.GetColumns(query);
            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                    maxRFQSerial++;
                else
                maxRFQSerial = Int32.Parse(row[0].ToString())+1;
            }
            return maxRFQSerial;
        }
        public int GetMaxRFQVersion(int salesId)
        {
            database database = new database();
            DataTable table = new DataTable();
            int maxRFQVersion = 0;
            string query = "select max(RFQ_version)  from RFQ where sales_person_id=" + salesId;
            table = database.GetColumns(query);
            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                    maxRFQVersion++;
                else
                    maxRFQVersion = Int32.Parse(row[0].ToString()) + 1;
            }
            return maxRFQVersion;
        }
        public void insertIntoRFQ()
        {
            database database = new database();
            string query = "insert into RFQ Values(" + LoginPage.userId + "," + GetEmployee().getemployeeID() + "," + getRFQSerial() + "," + getRFQVersion() + "," + "'" + getRFQId() + "'" + "," + GetCOMPANY().company_id + "," + GetContact().getcontactID() + "," + getcontract().contract_id + "," + getstatus().status_id + "," + "'" + getcomments() + "'" + "," + "'" + getdeadline() + "'" + "," + getprojectSerial().project_id + ")";
            database.Insert(query);
        }
        public void insertProducts()
        {
            database database = new database();
            List<BASIC_STRUCTS.PRODUCT_INFO> productsInfo = getProducts();
            for (int i = 0; i <productsInfo.Count; i++)
            {
                string query = "insert into RFQ_products Values(" + GetContact().getsalesPersonId() + "," + getRFQSerial() + "," + getRFQVersion() + "," + i + "," + productsInfo[i].product_id + "," + productsInfo[i].brand_id + "," + productsInfo[i].model_id + "," + productsInfo[i].quantity + ")";
                database.Insert(query);
            }
        }
    }
}
