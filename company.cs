using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class company
    {
        private BASIC_STRUCTS.COMPANY companys = new BASIC_STRUCTS.COMPANY();
        private int citySerial;
        private string cityName;
        private int stateSerial;
        private string stateName;
        private int countrySerial;
        private string countryName;

        public company()
        {

        }
        /////////////////////////////////
        ///setfunctions
        /////////////////////
        public void SetCompanys(int companySerial, string companyName, int addressSerail , string addressName)
        {
            companys.company_name=companyName;
            companys.company_id=companySerial;
            companys.branch_id=addressSerail;
            companys.branch_name=addressName;
        }
        public void SetcitySerial(int serial)
        {
            citySerial = serial;
        }
        public void SetcityName(string name)
        {
            cityName = name;
        }
        public void SetstateSerial(int serial)
        {
            stateSerial = serial;
        }
        public void SetstateName(string name)
        {
            stateName = name;
        }
        public void SetcountrySerial(int serial)
        {
            countrySerial = serial;
        }
        public void SetcountryName(string name)
        {
            countryName = name;
        }
        ////////////////////////////////////////////////
        ///getFunctions
        ////////////////////////////////////////////////
        public BASIC_STRUCTS.COMPANY GetCOMPANY()
        { return companys; }
        public int getcitySerial() { return citySerial; }
        public string getcityName() { return cityName; }
        public int getstateSerial() { return stateSerial; }
        public string getstateName() { return stateName; }
        public int getcountrySerial() { return countrySerial; }
        public string getcountryName() { return countryName; }


    }
}

