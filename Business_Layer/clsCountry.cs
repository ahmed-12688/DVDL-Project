using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess_Layer;
namespace Business_Layer
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }

        public clsCountry()
        {
            CountryID = -1;
            CountryName = string.Empty;
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = string.Empty;
            if (clsCountriesDataAccess.GetCountryInfoByID(ID, ref CountryName))
            {
                return new clsCountry(ID, CountryName);
            }
            else
                return null;
        }

        public static clsCountry Find(string CountryName)
        {
            int CountryID = 0;
            if (clsCountriesDataAccess.GetCountryInfoByName(CountryName, ref CountryID))
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }

    }
}
