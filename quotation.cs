using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class quotation : RFQ
    {
        private contact contactInfo;
        private employee assignedEmployee = new employee();
        private int quotationSerial;
        private int quotationVersion;
        private string quotationId;
        private float totalPrice;
        private BASIC_STRUCTS.CURRENCY quotationCurrency=new BASIC_STRUCTS.CURRENCY();
        private int downPayment;
        private int onDelivery;
        private int onInstallation;
        private int deliveryMaxPeriod;
        private int deliveryMinPeriod;
        private BASIC_STRUCTS.TIME_UNIT deliveryTimeUnit = new BASIC_STRUCTS.TIME_UNIT();
        private BASIC_STRUCTS.CONDITION deliveryTimeCondition = new BASIC_STRUCTS.CONDITION();
        private BASIC_STRUCTS.DELIVERY_POINT deliveryPoint = new BASIC_STRUCTS.DELIVERY_POINT();
        private BASIC_STRUCTS.CONTRACT contractType = new BASIC_STRUCTS.CONTRACT();
        private int warrantyPeriod;
        private BASIC_STRUCTS.TIME_UNIT warrantyUnit = new BASIC_STRUCTS.TIME_UNIT();
        private BASIC_STRUCTS.CONDITION warrantyTimeCondition = new BASIC_STRUCTS.CONDITION();
        private int vatCondition;
        private int quotationStatusId;
        private string quotationStatusName;
        private string quotationNotes;
        private DateTime issueDate;
        private BASIC_STRUCTS.COMPANY company = new BASIC_STRUCTS.COMPANY();
        private BASIC_STRUCTS.PROJECT project = new BASIC_STRUCTS.PROJECT();
        private List<BASIC_STRUCTS.PRODUCT_INFO> products = new List<BASIC_STRUCTS.PRODUCT_INFO>();

        public quotation()
        {
            contactInfo = new contact();
        }
        ///////////////////////////////
        ///setFunctions
        //////////////////////////////
        ///
        public void setcontactInfo(int id, string name, string phone, int salesId)
        {
            contactInfo.setcontactID(id);
            contactInfo.setcontactName(name);
            contactInfo.setcontactPhone(phone);
            contactInfo.setsalesPersonId(salesId);
        }
        public void setassignedEmployee(int id, string name)
        {
            assignedEmployee.setemployeeID(id);
            assignedEmployee.setemployeeName(name);

           
        }
        public void SetWarrantyUnit(int id, string name)
        {
            warrantyUnit.time_unit_id = id;
            warrantyUnit.time_unit_name = name;
        }
        public void SetCurrency(int id , string name)
        {
            quotationCurrency.currency_id = id;
            quotationCurrency.currency_name = name;
        }
        public void SetDeliveryTimeUnit(int id,string name)
        {
            deliveryTimeUnit.time_unit_id = id;
            deliveryTimeUnit.time_unit_name = name;
        }
        public void SetDeliveryPoint(int id, string name)
        {
            deliveryPoint.delivery_point_id = id;
            deliveryPoint.delivery_point_name= name;
        }
        public void SetDeliveryTimeCondition(int id,string name)
        {
            deliveryTimeCondition.condition_id = id;
            deliveryTimeCondition.condition_name = name;
        }
        public void SetContractType(int id , string name)
        {
            contractType.contract_id = id;
            contractType.contract_name = name;
        }
        public void SetWarrantyTimeCondition(int id , string name)
        {
            warrantyTimeCondition.condition_id = id;
            warrantyTimeCondition.condition_name = name;
        }
        public void SetProject (int id,string name)
        {
            project.project_id = id;
            project.project_name = name;
        }
        public void setquotationSerial(int serial)
        {
            quotationSerial = serial;
        }
        public void setquotationVersion(int version)
        {
            quotationVersion = version;
        }
        public void setquotationId(string id)
        {
            this.quotationId = id;
        }
        public void settotalPrice(float price)
        {
            totalPrice = price;
        }
      
        public void setdownPayment(int downpayment)
        {
            downPayment = downpayment;
        }
        public void setonDelivery(int ondelivery)
        {
            onDelivery = ondelivery;
        }
        public void setonInstallation(int installation)
        {
            onInstallation = installation;
        }
        public void setdeliveryMaxPeriod(int maxperiod)
        {
            deliveryMaxPeriod = maxperiod;
        }
        public void setdeliveryMinPeriod(int minperiod)
        {
            deliveryMinPeriod = minperiod;
        }
      
        public void setvatCondition(int condition)
        { vatCondition = condition; }
        public void setquotationStatusId(int id)
        { quotationStatusId = id; }
        public void setquotationStatusName(string name)
        { quotationStatusName = name; }
        public void setquotationNotes(string notes)
        { quotationNotes = notes; }

        public void setissueDate(DateTime datetime)
        { issueDate = datetime; }

        public void SetWarrantyPeriod(int period )
        {
            warrantyPeriod = period;
        }

        public void setCompany (int companySerial , string companyName , int branchSerial , string branchName)
        {
            company.company_name=companyName;
            company.company_id=companySerial;
            company.branch_id=branchSerial;
            company.branch_name=branchName;
        }
        public void SetProducts(ref List<BASIC_STRUCTS.PRODUCT_INFO> temp)
        {
            products = temp;
        }
        ////////////////////////////////////
        ///getFunctions
        ////////////////////////////////////

        public int getquotationSerial()
        {
            return quotationSerial;
        }
        public int getquotationVersion()
        {
            return quotationVersion;
        }
        public string getquotationId()
        {
            return quotationId;
        }
        public float gettotalPrice()
        {
            return totalPrice;
        }
       
      
        public int getdownPayment()
        {
            return downPayment;
        }
        public int getonDelivery()
        {
            return onDelivery;
        }
        public int getonInstallation()
        {
            return onInstallation;
        }
        public int getdeliveryMaxPeriod()
        {
            return deliveryMaxPeriod;
        }
        public int getdeliveryMinPeriod()
        {
            return deliveryMinPeriod;
        }
       
        public int getvatCondition()
        { return vatCondition; }
        public int getquotationStatusId()
        { return quotationStatusId; }
        public string getquotationStatusName()
        { return quotationStatusName; }
        public string setquotationNotes()
        { return quotationNotes; }

        public DateTime getissueDate()
        { return issueDate; }
     
        public BASIC_STRUCTS.CURRENCY GetCurrency()
        {
            return quotationCurrency;
        }
        public BASIC_STRUCTS.TIME_UNIT GetDeliveryTimeUnit()
        {
            return deliveryTimeUnit;
        }
        public BASIC_STRUCTS.CONDITION GetDeliveryTimeCondition()
        {
            return deliveryTimeCondition;
        }
        public BASIC_STRUCTS.DELIVERY_POINT GetDeliveryPoint()
        {
            return deliveryPoint;
        }
        public BASIC_STRUCTS.CONTRACT GetContract()
        {
            return contractType;
        }
        public BASIC_STRUCTS.TIME_UNIT GetWarrantyUnit()
        {
            return warrantyUnit;
        }
        public BASIC_STRUCTS.CONDITION GetWarrantyTimeCondition()
        {
            return warrantyTimeCondition;
        }
        public BASIC_STRUCTS.PROJECT GetProject()
        {
            return project;
        }
         public BASIC_STRUCTS.COMPANY GetCompany()
        { return company; }
        public employee GetAssignedEmployee()
        { return assignedEmployee; }
        public List<BASIC_STRUCTS.PRODUCT_INFO> GetProducts()
        { return products; }
        public contact GetContactInfo()
        { return contactInfo; }
        public int GetWarrantyPeriod()
        { return warrantyPeriod; }
        public string GetQuotationNotes()
        { return quotationNotes; }
        public int GetMaxQuotationSerial()
        {
            database database = new database();
            DataTable table = new DataTable();
            string qery = @"select max(Q_serial) 
                           from quotations 
                           where offer_proposer_id=" + GetAssignedEmployee().getemployeeID();
           
            int maxQuotationSerial = 0;
            table = database.GetColumns(qery);
            foreach(DataRow row in table.Rows)
            {
                maxQuotationSerial = Int32.Parse(row[0].ToString());
            }
            return maxQuotationSerial;
        }
        public int GetMaxQuotationVersion()
        {
            database database = new database();
            DataTable table = new DataTable();
            string qery = @"select max(Q_version) 
                           from quotations 
                           where offer_proposer_id=" + GetAssignedEmployee().getemployeeID();

            int maxQuotationSerial = 0;
            table = database.GetColumns(qery);
            foreach (DataRow row in table.Rows)
            {
                maxQuotationSerial = Int32.Parse(row[0].ToString());
            }
            return maxQuotationSerial;
        }
        public void InsertQuotation()
        {
            database database=new database();
            string query = @"insert into quotations values ("+GetAssignedEmployee().getemployeeID()+","+getquotationSerial()+","+getquotationVersion()+","+
               "'"+getquotationId()+"'"+","+GetContactInfo().getsalesPersonId()+","+GetCompany().company_id+","
              + GetContactInfo().getcontactID()+","+gettotalPrice()+","+GetCurrency().currency_id+","+
               getdownPayment()+","+getonDelivery()+","+getdeliveryMaxPeriod()+","+getdeliveryMinPeriod()+","
               +GetDeliveryTimeUnit().time_unit_id+","+ GetDeliveryPoint().delivery_point_id+","+
               GetDeliveryTimeCondition().condition_id+","+ GetContract().contract_id+","+ GetWarrantyPeriod()+","+
               GetWarrantyUnit().time_unit_id+","+getvatCondition()+","+getquotationStatusId()+","+"'"+GetQuotationNotes()+"'"+","
               +"'"+getissueDate()+"'"+","+GetProject().project_id+","+GetWarrantyTimeCondition().condition_id+","+getonInstallation()+")";
            database.Insert(query);
        }
    }
}
