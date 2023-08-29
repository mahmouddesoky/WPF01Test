using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class work_order : quotation
    {
       
        private contact contactInfo;
        private employee assignedEmployee;
        private int orderId;
        private float totalPrice;
        private int priceCurrencyId;
        private string priceCurrencyName;
        private int downPayment;
        private int onDelivery;
        private int onInstallation;
        private int deliveryMaxPeriod;
        private int deliveryMinPeriod;
        private int deliveryTimeUnitId;
        private string deliveryTimeUnitName;
        private int deliveryTimeConditionId;
        private string deliveryTimeConditionName;
        private int deliveryPointId;
        private string deliveryPointName;
        private int contractTypeId;
        private string contractTypeName;
        private int warrantyPeriod;
        private int warrantyUnitSerial;
        private string warrantyUnitName;
        private int warrantyTimeConditionId;
        private string warrantyTimeConditionName;
        private Boolean vatCondition;
        private string orderNotes;
        private DateTime issueDate;
        private database database;
        public work_order() 
        {

        }
        ///////////////////////////////////////
        ///setFunctions
        ///////////////////////////////////////
        public void SetcontactInfo(int id, string name, string phone, int salesId)
        {
            contactInfo.setcontactID(id);
            contactInfo.setcontactName(name);
            contactInfo.setcontactPhone(phone);
            contactInfo.setsalesPersonId(salesId);
        }
        public void SetassignedEmployee(int id, string name, string team, string department, string position)
        {
            assignedEmployee.setemployeeID(id);
            assignedEmployee.setemployeeName(name);
          
        }
        public void SetorderId(int id)
        {
            this.orderId = id;
        }
        public void SettotalPrice(float price)
        {
            totalPrice = price;
        }
        public void SetpriceCurrencyId(int id)
        {
            priceCurrencyId = id;
        }
        public void SetpriceCurrencyName(string name)
        {
            priceCurrencyName = name;
        }
        public void SetdownPayment(int downpayment)
        {
            downPayment = downpayment;
        }
        public void SetonDelivery(int ondelivery)
        {
            onDelivery = ondelivery;
        }
        public void SetonInstallation(int installation)
        {
            onInstallation = installation;
        }
        public void SetdeliveryMaxPeriod(int maxperiod)
        {
            deliveryMaxPeriod = maxperiod;
        }
        public void SetdeliveryMinPeriod(int minperiod)
        {
            deliveryMinPeriod = minperiod;
        }
        public void SetdeliveryTimeUnitId(int id)
        { deliveryTimeUnitId = id; }

        public void SetdeliveryTimeUnitName(string name)
        { deliveryTimeUnitName = name; }
        public void SetdeliveryTimeConditionId(int id)
        { deliveryTimeConditionId = id; }
        public void SetdeliveryTimeConditionName(string condition)
        { deliveryTimeConditionName = condition; }

        public void SetdeliveryPointId(int id)
        { deliveryPointId = id; }
        public void SetdeliveryPointName(string name)
        { deliveryPointName = name; }
        public void SetcontractTypeId(int id)
        { contractTypeId = id; }
        public void SetcontractTypeName(string name)
        { contractTypeName = name; }
        public void SetwarrantyPeriod(int period)
        { warrantyPeriod = period; }
        public void SetwarrantyUnitSerial(int serial)
        { warrantyUnitSerial = serial; }
        public void SetwarrantyUnitName(string unit)
        { warrantyUnitName = unit; }
        public void SetwarrantyTimeConditionId(int id)
        { warrantyTimeConditionId = id; }
        public void SetwarrantyTimeConditionName(string name)
        { warrantyTimeConditionName = name; }
        public void SetvatCondition(Boolean condition)
        { vatCondition = condition; }
        public void SetorderNotes(string notes)
        { orderNotes = notes; }

        public void SetissueDate(DateTime datetime)
        { issueDate = datetime; }
        /// <summary>
        /// ////////////////////////////////////////////
        /// getFunctions
        /// ////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        public int getorderId()
        {
            return orderId;
        }
        public float gettotalPrice()
        {
            return totalPrice;
        }
        public int getpriceCurrencyId()
        {
            return priceCurrencyId;
        }
        public string getpriceCurrencyName()
        {
            return priceCurrencyName;
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
        public int getdeliveryTimeUnitId()
        { return deliveryTimeUnitId; }

        public string getdeliveryTimeUnitName()
        { return deliveryTimeUnitName; }
        public int getdeliveryTimeConditionId()
        { return deliveryTimeConditionId; }
        public string getdeliveryTimeConditionName()
        { return deliveryTimeConditionName; }

        public int SetdeliveryPointId()
        { return deliveryPointId; }
        public string getdeliveryPointName()
        { return deliveryPointName; }
        public int getcontractTypeId()
        { return contractTypeId; }
        public string getcontractTypeName()
        { return contractTypeName; }
        public int getwarrantyPeriod()
        { return warrantyPeriod; }
        public int getwarrantyUnitSerial()
        { return warrantyUnitSerial; }
        public string getwarrantyUnitName()
        { return warrantyUnitName; }
        public int getwarrantyTimeConditionId()
        { return warrantyTimeConditionId; }
        public string getwarrantyTimeConditionName()
        { return warrantyTimeConditionName; }
        public Boolean getvatCondition()
        { return vatCondition; }

        public string SetorderNotes()
        { return orderNotes; }

        public DateTime getissueDate()
        { return issueDate; }
    }
}

