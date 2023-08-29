using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class BASIC_STRUCTS
    {
        public struct EMPLOYEE_TEAM
        {
            public int team_id;
            public string team_name;
        }
        public struct EMPLOYEE_POSITION
        {
            public int position_id;
            public string position_name;

        }
        public struct EMPLOYEE_DEPARTMENT
        {
            public int department_id;
            public string department_name;
        }
        public struct PRODUCT_INFO
        {
            public int product_id;
            public string product_name;
            public int brand_id;
            public string brand_name;
            public int model_id;
            public string model_name;
            public int quantity;
            public float item_price;
            public CURRENCY currency;
        }
        public struct CONTRACT
        {
            public int contract_id;
            public string contract_name;

        }
        public struct STATUS
        {
            public int status_id;
            public string status_name;
        }
        public struct PROJECT
        {
            public int project_id;
            public int project_location_id;
            public string project_name;
            public string project_location;


        }
        public struct DISTRICT
        {
            public int district_id;
            public string district_name;
        }

        public struct CITY
        {
            public int city_id;
            public string city_name;
        }
        public struct STATE
        {
            public int state_id;
            public string state_name;
        }
        public struct COUNTRY
        {
            public int country_id;
            public string country_name;
        }
        public struct COMPANY
        {
            public int company_id;
            public string company_name;
            public int branch_id;
            public string branch_name;
        }
        public struct DELIVERY_POINT
        {
            public int delivery_point_id;
            public string delivery_point_name;
        }
        public struct TIME_UNIT
        {
            public int time_unit_id;
            public string time_unit_name;
        }
        public struct CONDITION
        {
            public int condition_id;
            public string condition_name;
        }

       
        public struct CURRENCY
        {
            public int currency_id;
            public string currency_name;
        }

        public struct QUOTATIONS
        {
            public string quotation_id;
            public int quotation_version;
            public int quotatin_serial;
            public int pre_sales_id;
            public string pre_sales_name;
            public int sales_id;
            public string sales_name;
            public BASIC_STRUCTS.CONTRACT contract;
            public BASIC_STRUCTS.STATUS status;
            public BASIC_STRUCTS.COMPANY company;
            public BASIC_STRUCTS.DISTRICT district;
            public int contact_id;
            public string contact_name;
            public DateTime issue_date;
            public BASIC_STRUCTS.PRODUCT_INFO product;
        }
    }
}
