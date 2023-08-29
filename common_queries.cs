using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class common_queries
    {
        public employee[] GetAllPreSales()
        {

            database database = new database();
            DataTable table = new DataTable();
            string query = @"select employees_info.name as employee_name , employees_info.employee_id ,
employees_business_emails.email , teams_type.team , teams_type.id as team_id , positions_type.position,positions_type.id
as position_id , departments_type.department, departments_type.id as department_id  from employees_info 
inner join employees_business_emails
on employees_info.employee_id = employees_business_emails.id
inner join teams_type
on employees_info.employee_team = teams_type.id
inner join departments_type
on employees_info.employee_department=departments_type.id
inner join positions_type
on positions_type.id = employees_info.employee_position
where employee_team=" + MACROS.PRE_SALES;
            table = database.GetColumns(query);
            int size = table.Rows.Count;
            employee[] preSales = new employee[size];
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                preSales[i] = new employee();
                preSales[i].setemployeeName(row[0].ToString());
                preSales[i].setemployeeID(Int32.Parse(row[1].ToString()));
                preSales[i].setemployeeEmail(row["email"].ToString());
                preSales[i].setemployeeTeam(row["team"].ToString(), Int32.Parse(row["team_id"].ToString()));
                preSales[i].setemployeePosition(row["position"].ToString(), Int32.Parse(row["position_id"].ToString()));
                preSales[i].setemployeeDepartment(row["department"].ToString(), Int32.Parse(row["department_id"].ToString()));
                size += 1;
                i++;

            }
            return preSales;
        }

        public contact[] GetCompanies()
        {
            database database = new database();
            DataTable table = new DataTable();
            string query = "select company_name.company_name,company_name.company_serial,company_address.address,districts.district , \r\ncontact_person_info.name , contact_person_info.contact_id , contact_person_mobile.mobile , cities.city , cities.id,states_governorates.state_governorate,states_governorates.id,\r\ncountries.country,countries.id \r\nfrom company_name \r\ninner join company_address on company_name.company_serial=company_address.company_serial\r\ninner join districts on company_address.address=districts.id\r\ninner join contact_person_info on contact_person_info.branch_serial=company_address.address_serial and contact_person_info.sales_person_id=" + LoginPage.userId + "\r\nleft join contact_person_mobile on contact_person_info.contact_id=contact_person_mobile.contact_id and \r\ncontact_person_mobile.branch_serial=company_address.address and contact_person_mobile.sales_person_id=" + LoginPage.userId + "\r\ninner join cities on cities.id=districts.city\r\ninner join states_governorates on states_governorates.id=cities.state_governorate\r\ninner join countries on countries.id=states_governorates.country";
            table = database.GetColumns(query);
            int size = table.Rows.Count;
            contact[] contactsInfo = new contact[size];
            int i = 0;

            foreach (DataRow row in table.Rows)
            {

                contactsInfo[i] = new contact();
                contactsInfo[i].SetCompany(row[0].ToString(), Int32.Parse(row[1].ToString()), row[3].ToString(), Int32.Parse(row[2].ToString()));
                contactsInfo[i].setcontactName(row[4].ToString());
                contactsInfo[i].setcontactID(Int32.Parse(row[5].ToString()));
                contactsInfo[i].setcontactPhone(row[6].ToString());
                contactsInfo[i].SetDistrict(Int32.Parse(row[2].ToString()), row[3].ToString());
                contactsInfo[i].SetCity(Int32.Parse(row[8].ToString()), row[7].ToString());
                contactsInfo[i].SetState(Int32.Parse(row[10].ToString()), row[9].ToString());
                contactsInfo[i].SetCountry(Int32.Parse(row[12].ToString()), row[11].ToString());

                size++;
                i++;
            }

            return contactsInfo;
        }

        public BASIC_STRUCTS.PROJECT[] GetProjects()
        {
            database database = new database();
            DataTable table = new DataTable();
            string query = "select client_projects.project_name,client_projects.project_serial , projects_location.project_location,districts.district from client_projects \r\ninner join projects_location on projects_location.project_serial=client_projects.project_serial\r\ninner join districts on districts.id=projects_location.project_location";
            table = database.GetColumns(query);
            int size = table.Rows.Count;
            BASIC_STRUCTS.PROJECT[] projects = new BASIC_STRUCTS.PROJECT[size];
            int i = 0;

            foreach (DataRow row in table.Rows)
            {
                projects[i] = new BASIC_STRUCTS.PROJECT();
                projects[i].project_name = row[0].ToString();
                projects[i].project_id = Int32.Parse(row[1].ToString());
                projects[i].project_location_id = Int32.Parse(row[2].ToString());
                projects[i].project_location = row[3].ToString();
                size++;
                i++;
            }

            return projects;
        }

        public BASIC_STRUCTS.PRODUCT_INFO[] GetProducts()
        {
            database database = new database();
            DataTable table = new DataTable();
            string query = @"select products.product_name , products.product_id , brand_names.brand_name,brand_names.brand_id, Model.model_name,Model.model_id 
                             from products inner join Model on products.product_id=Model.product_id
                             inner join brand_names on Model.brand_id=brand_names.brand_id";
            table = database.GetColumns(query);
            int size = table.Rows.Count;
            BASIC_STRUCTS.PRODUCT_INFO[] products = new BASIC_STRUCTS.PRODUCT_INFO[size];
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                products[i] = new BASIC_STRUCTS.PRODUCT_INFO();
                products[i].product_name = row[0].ToString();
                products[i].product_id = Int32.Parse(row[1].ToString());
                products[i].brand_name = row[2].ToString();
                products[i].brand_id = Int32.Parse(row[3].ToString());
                products[i].model_name = row[4].ToString();
                products[i].model_id = Int32.Parse(row[5].ToString());
                size++;
                i++;
            }


            return products;
        }

        public List<BASIC_STRUCTS.CONTRACT> GetContract()
        {
            database database = new database();
            DataTable table = new DataTable();
            string query = "select contract_type.id , contract_type.type from contract_type";
            table = database.GetColumns(query);
            BASIC_STRUCTS.CONTRACT contract = new BASIC_STRUCTS.CONTRACT();
            List<BASIC_STRUCTS.CONTRACT> contracts = new List<BASIC_STRUCTS.CONTRACT>();
            foreach (DataRow row in table.Rows)
            {
                contract.contract_id = Int32.Parse(row[0].ToString());
                contract.contract_name = row[1].ToString();
                contracts.Add(contract);

            }

            return contracts;
        }

        public List<BASIC_STRUCTS.QUOTATIONS> GetAllQuotations()
        {
            database database = new database();
           
            string query = @"with get_sales as( select employees_info.name 
                          as sales_name
                        , employees_info.employee_id
						  as sales_id
				   from employees_info
)
select quotations.offer_proposer_id,quotations.Q_serial,quotations.Q_version,quotations.Q_id,
company_name.company_name,company_name.company_serial,districts.district,districts.id as district_id,
contract_type.id as contract_id,contract_type.type as contract_type,qutation_status.id as q_status_id,qutation_status.q_status,
contact_person_info.name as contact_name,contact_person_info.contact_id ,employees_info.name as pre_sales_name , get_sales.sales_name , get_sales.sales_id
,quotations.issue_date
from quotations
inner join company_address 
on company_address.address_serial=quotations.branch_serial
inner join company_name 
on company_address.company_serial=company_name.company_serial
inner join districts
on districts.id = company_address.address
inner join contact_person_info 
on contact_person_info.contact_id=quotations.contact_id
and contact_person_info.sales_person_id=quotations.sales_person and contact_person_info.branch_serial=quotations.branch_serial
inner join contract_type 
on contract_type.id=quotations.contract_type
inner join qutation_status 
on qutation_status.id=quotations.q_status
inner join employees_info 
on quotations.offer_proposer_id=employees_info.employee_id
inner join get_sales
on quotations.sales_person=get_sales.sales_id";
            DataTable table= database.GetColumns(query);
            List<BASIC_STRUCTS.QUOTATIONS> quotationsList = new List<BASIC_STRUCTS.QUOTATIONS>();
            BASIC_STRUCTS.QUOTATIONS quotation = new BASIC_STRUCTS.QUOTATIONS();
            foreach (DataRow row in table.Rows)
            {
                quotation.pre_sales_id = Int32.Parse(row["offer_proposer_id"].ToString());
                quotation.quotatin_serial = Int32.Parse(row["Q_serial"].ToString());
                quotation.quotation_version = Int32.Parse(row["Q_version"].ToString());
                quotation.quotation_id = row["Q_id"].ToString();
                quotation.company.company_name = row["company_name"].ToString();
                quotation.company.company_id = Int32.Parse(row["company_serial"].ToString());
                quotation.district.district_name = row["district"].ToString();
                quotation.district.district_id = Int32.Parse(row["district_id"].ToString());
                quotation.contract.contract_id = Int32.Parse(row["contract_id"].ToString());
                quotation.contract.contract_name = row["contract_type"].ToString();
                quotation.status.status_name = row["q_status"].ToString();
                quotation.status.status_id = Int32.Parse(row["q_status_id"].ToString());
                quotation.contact_name = row["contact_name"].ToString();
                quotation.contact_id = Int32.Parse(row["contact_id"].ToString());
                quotation.pre_sales_name = row["pre_sales_name"].ToString();
                quotation.sales_name = row["sales_name"].ToString();
                quotation.sales_id = Int32.Parse(row["sales_id"].ToString());
                quotation.issue_date = Convert.ToDateTime(row["issue_date"].ToString());
                quotationsList.Add(quotation);

            }
            return quotationsList;
        }



        public List<RFQ> GetAllRFQS()
        {
            RFQ rfQ = new RFQ();
            List<RFQ> listRFQ = new List<RFQ>();
            contact c = new contact();
            database dataBase = new database();
            List<BASIC_STRUCTS.PRODUCT_INFO> products = new List<BASIC_STRUCTS.PRODUCT_INFO>();
            BASIC_STRUCTS.PRODUCT_INFO item = new BASIC_STRUCTS.PRODUCT_INFO();
            DateTime dt;
            string query = @"with get_salesPersonName as (select employees_info.name
                             as sales_name,
							  employees_info.employee_id
							  as sales_id
							 from employees_info
),
 get_preSalesPersonName as (select employees_info.name 
                             as pre_sales 
							 from employees_info
)
select * from RFQ
                        inner join employees_info 
                        on RFQ.assigned_engineer=employees_info.employee_id 
                        inner join employees_business_emails on RFQ.assigned_engineer=employees_business_emails.id
                        inner join departments_type on employees_info.employee_department=departments_type.id
                        inner join positions_type on employees_info.employee_position=positions_type.id 
                        inner join teams_type on employees_info.employee_team = teams_type.id
                        inner join contact_person_info on RFQ.contact_id=contact_person_info.contact_id 
                        and RFQ.sales_person_id=contact_person_info.sales_person_id 
                        and RFQ.branch_serial = contact_person_info.branch_serial 
                        left join contact_person_mobile on RFQ.contact_id=contact_person_mobile.contact_id 
                        and RFQ.sales_person_id=contact_person_mobile.sales_person_id and RFQ.branch_serial = contact_person_mobile.branch_serial
                        inner join RFQ_status on RFQ.status=RFQ_status.id 
                        inner join client_projects on client_projects.project_serial =RFQ.project_serial
                        inner join projects_location on projects_location.project_serial=client_projects.project_serial
                        inner join districts on projects_location.project_location = districts.id 
                        left join RFQ_products on RFQ.sales_person_id=RFQ_products.sales_person_id and 
                        RFQ.RFQ_serial = RFQ_products.RFQ_serial and RFQ.RFQ_version=RFQ_products.RFQ_version
                        left join brand_names on RFQ_products.brand_id=brand_names.brand_id
                        left join Model on Model.model_id = RFQ_products.model_id and Model.brand_id=RFQ_products.model_id and Model.product_id=RFQ_products.product_id
                        inner join contract_type on contract_type.id=RFQ.contract_type
                        left join product_brands on Model.brand_id=product_brands.brand_id
                        left join products on products.product_id=product_brands.product_id 
                        inner join company_address on contact_person_info.branch_serial=company_address.address_serial 
                        inner join company_name on company_address.company_serial=company_name.company_serial
						inner join get_salesPersonName
						on get_salesPersonName.sales_id=RFQ.sales_person_id";
            DataTable table = dataBase.GetColumns(query);

            foreach (DataRow row in table.Rows)
            {

                if (row[6].ToString() == "")
                {
                    row[6] = "0";
                }
                if (row[0].ToString() == "")
                {
                    row[0] = "0";
                }
                if (row[1].ToString() == "")
                {
                    row[1] = "0";
                }
                if (row[31].ToString() == "")
                {
                    row[31] = "0";
                }
                if (row[28].ToString() == "")
                {
                    row[28] = "0";
                }
                if (row[25].ToString() == "")
                {
                    row[25] = "0";
                }
                if (row[2].ToString() == "")
                {
                    row[2] = "0";
                }
                if (row[3].ToString() == "")
                {
                    row[3] = "0";
                }
                if (row[78].ToString() == "")
                {
                    row[78] = "0";
                }
                if (row[49].ToString() == "")
                {
                    row[49] = "0";
                }
                if (row[51].ToString() == "")
                {
                    row[51] = "0";
                }
                if (row[56].ToString() == "")
                {
                    row[56] = "0";
                }
                if (row[65].ToString() == "")
                {
                    row[65] = "0";
                }
                if (row[67].ToString() == "")
                {
                    row[67] = "0";
                }
                if (row[68].ToString() == "")
                {
                    row[68] = "0";
                }
                if (row[85].ToString() == "")
                {
                    row[85] = "0";
                }
                if (row[85].ToString() == "")
                {
                    row[85] = "0";
                }

                rfQ.setcontactInfo(Int32.Parse(row[6].ToString()), row[38].ToString(), row[47].ToString(), Int32.Parse(row[0].ToString()));
                rfQ.setemployeeInfo(Int32.Parse(row[1].ToString()), row[13].ToString(), row[23].ToString(), row[32].ToString(), Int32.Parse(row[31].ToString()), row[29].ToString(), Int32.Parse(row[28].ToString()), row[26].ToString(), Int32.Parse(row[25].ToString()));
                rfQ.setRFQSerial(Int32.Parse(row[2].ToString()));
                rfQ.setversion(Int32.Parse(row[3].ToString()));
                rfQ.setRFQID(row[4].ToString());
                rfQ.setcontract(Int32.Parse(row[78].ToString()), row[79].ToString());
                rfQ.setstatus(Int32.Parse(row[49].ToString()), row[50].ToString());
                rfQ.setcomments(row[9].ToString());
                rfQ.setdeadline(DateTime.Parse(row[10].ToString()));
                rfQ.setproject(Int32.Parse(row[51].ToString()), row[52].ToString(), Int32.Parse(row[56].ToString()), row[60].ToString());
                rfQ.setCompanys(Int32.Parse(row[86].ToString()), row[91].ToString(), Int32.Parse(row[85].ToString()), row[60].ToString());
                rfQ.setSalesName(row["sales_name"].ToString());
                item.product_id = Int32.Parse(row[65].ToString());
                item.product_name = row[82].ToString();
                item.brand_id = Int32.Parse(row[67].ToString());
                item.brand_name = row[70].ToString();
                item.model_id = Int32.Parse(row[68].ToString());
                item.model_name = row[76].ToString();
                products.Add(item);
                listRFQ.Add(rfQ);
                rfQ = new RFQ();
            }
            rfQ.SetProducts(ref products);
            return (listRFQ);
        }

        public List<employee> GetAllSales()
        {
            List<employee> employeeList = new List<employee>();
            employee sales = new employee();
            database database = new database();
            DataTable table = new DataTable();
            string query = @"use erp
select employees_info.name , employees_info.employee_id 
from employees_info 
where  employees_info.employee_team=10202";
            table = database.GetColumns(query);
            foreach (DataRow row in table.Rows)
            {
                sales.setemployeeName(row["name"].ToString());
                sales.setemployeeID(Int32.Parse(row["employee_id"].ToString()));

                employeeList.Add(sales);
                sales = new employee();
            }
            return employeeList;
        }

        public List<BASIC_STRUCTS.CURRENCY> GetCurrencies()
        {
            List<BASIC_STRUCTS.CURRENCY> currencyList = new List<BASIC_STRUCTS.CURRENCY>();
            BASIC_STRUCTS.CURRENCY currency = new BASIC_STRUCTS.CURRENCY();
            database database = new database();
            DataTable table = new DataTable();
            string query = @"select currencies_type.id 
                                    as currency_id,
	                                currencies_type.c_type
	                                as currency_type
                             from currencies_type";
            table = database.GetColumns(query);
            foreach (DataRow row in table.Rows)
            {
                currency.currency_id = Int32.Parse(row["currency_id"].ToString());
                currency.currency_name = row["currency_type"].ToString();
                currencyList.Add(currency);
                currency = new BASIC_STRUCTS.CURRENCY();
            }
            return currencyList;
        }
        public List<BASIC_STRUCTS.DELIVERY_POINT> GetDeliveryPoint()
        {
            List<BASIC_STRUCTS.DELIVERY_POINT> deliveryPointList = new List<BASIC_STRUCTS.DELIVERY_POINT>();
            BASIC_STRUCTS.DELIVERY_POINT deliveryPoint = new BASIC_STRUCTS.DELIVERY_POINT();
            database database = new database();
            DataTable table = new DataTable();
            string query = @"select delivery_points.id
                                    as point_id,
	                                delivery_points.points
	                                as delivery_points
                             from delivery_points";
            table = database.GetColumns(query);
            foreach (DataRow row in table.Rows)
            {
                deliveryPoint.delivery_point_id = Int32.Parse(row["point_id"].ToString());
                deliveryPoint.delivery_point_name = row["delivery_points"].ToString();
                deliveryPointList.Add(deliveryPoint);
                deliveryPoint= new BASIC_STRUCTS.DELIVERY_POINT();
            }
            return deliveryPointList;
        }
        public List<BASIC_STRUCTS.TIME_UNIT> GetTimeUnit()
        {
            List<BASIC_STRUCTS.TIME_UNIT> timeUnitList = new List<BASIC_STRUCTS.TIME_UNIT>();
            BASIC_STRUCTS.TIME_UNIT timeUnit = new BASIC_STRUCTS.TIME_UNIT();
            database database = new database();
            DataTable table = new DataTable();
            string query = @"select time_unit.id
                                    as time_unit_id,
	                                time_unit.t_unit
	                                as time_unit_name
                             from time_unit";
            table = database.GetColumns(query);
            foreach (DataRow row in table.Rows)
            {
                timeUnit.time_unit_id = Int32.Parse(row["time_unit_id"].ToString());
                timeUnit.time_unit_name = row["time_unit_name"].ToString();
                timeUnitList.Add(timeUnit);
                timeUnit = new BASIC_STRUCTS.TIME_UNIT();
            }
            return timeUnitList;
        }
        public List<BASIC_STRUCTS.CONDITION> GetTimeCondition()
        {
            List<BASIC_STRUCTS.CONDITION> conditionList = new List<BASIC_STRUCTS.CONDITION>();
            BASIC_STRUCTS.CONDITION condition = new BASIC_STRUCTS.CONDITION();
            database database = new database();
            DataTable table = new DataTable();
            string query = @"select condition.id 
                                    as condition_id,
	                                condition.condition
	                                as condition
                             from condition";
            table = database.GetColumns(query);
            foreach (DataRow row in table.Rows)
            {
                condition.condition_id = Int32.Parse(row["condition_id"].ToString());
                condition.condition_name = row["condition"].ToString();
                conditionList.Add(condition);
                condition = new BASIC_STRUCTS.CONDITION();
            }
            return conditionList;
        }
    }

    

}
