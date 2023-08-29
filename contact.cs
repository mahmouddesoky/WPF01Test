using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class contact
    {
        private int contactID;
        private string contactEmail;
        private string contactName;
        private string contactPhone;
        private int salesPersonId;
        private string salesPersonName;
        private BASIC_STRUCTS.COMPANY company = new BASIC_STRUCTS.COMPANY();
        private BASIC_STRUCTS.DISTRICT district=new BASIC_STRUCTS.DISTRICT();
        private BASIC_STRUCTS.CITY cities = new BASIC_STRUCTS.CITY();
        private BASIC_STRUCTS.STATE state = new BASIC_STRUCTS.STATE();
        private BASIC_STRUCTS.COUNTRY country = new BASIC_STRUCTS.COUNTRY();

        public contact() { }
        /// <summary>
        /// ///////////////////////////
        /// setFunctions
        /// //////////////////////////
        /// </summary>
        /// <param name="id"></param>

        public void setcontactID(int id)
        {
            contactID = id;
        }
        public void setcontactEmail(string email)
        {
            this.contactEmail = email;
        }
        public void setcontactName(string name)
        {
            this.contactName = name;
        }
        public void setcontactPhone(string phone)
        {
            contactPhone = phone;
        }
        public void setsalesPersonId(int id)
        {
            salesPersonId = id;
        }
        public void setSalesPersonName(string name)
        {
            salesPersonName = name;
        }
        public void SetCompany(string companyName, int CompanySerial,string branchName,int branchSerial)
        {
            company.company_name=companyName;
            company.company_id = CompanySerial;
            company.branch_name=branchName;
            company.branch_id = branchSerial;
        }
      
        public void SetDistrict(int districtId , string districtName)
        {
            district.district_id=districtId;
            district.district_name=districtName;
        }
        public void SetCity(int cityId , string cityName)
        {
            cities.city_id=cityId; 
            cities.city_name=cityName;
        }
        public void SetState (int stateId , string stateName)
        {
            state.state_id=stateId;
            state.state_name=stateName;

        }
        public void SetCountry (int countryId , string CountryName)
        {
            country.country_id=countryId;
            country.country_name=CountryName;

        }


        public int getcontactID()
        {
            return contactID;
        }
        public string getcontactEmail()
        {
            return contactEmail;
        }
        public string getcontactName()
        {
            return contactName;
        }
        public string getcontactPhone()
        {
            return contactPhone;
        }
        public int getsalesPersonId()
        {
            return salesPersonId;
        }
        public string getSalesPersonName()
        {
            return salesPersonName;
        }
        public BASIC_STRUCTS.COMPANY GetCompany()
        {
            return company;
        }
        public BASIC_STRUCTS.DISTRICT GetDistrict()
        {
            return district;
        }
        public BASIC_STRUCTS.CITY GetCity()
        { return cities; }
        public BASIC_STRUCTS.STATE GetState()
        { return state; }
        public BASIC_STRUCTS.COUNTRY GetCountry()
        { return country; }
    }
}
