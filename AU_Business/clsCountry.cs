using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsCountry
    {
        public int CountryID {  get; set; }
        public string CountryName { get; set; }
        

        private clsCountry(int id,string name)
        {
            this.CountryID = id;
            this.CountryName = name;
        }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";
        }

        public static DataTable ListCountries()
        {
            return clsCountryData.GetCountriesList();
        }

        public static clsCountry Find(int id)
        {
            string name = "";

            if (clsCountryData.FindCountryByID(id, ref name))
            {
                return new clsCountry(id, name);
            }
            
                return new clsCountry();
        }

        public static clsCountry Find(string name)
        {
            int id= -1;

            if (clsCountryData.FindCountryByName(ref id,name))
            {
                return new clsCountry(id, name);
            }
           
                return new clsCountry();
        }

    }
}
