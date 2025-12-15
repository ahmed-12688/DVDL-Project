using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;

namespace Business_Layer
{
    public class clsApplicationType
    {
        public int ApplicationTypeID;
        public string Title;
        public decimal Fees;


        public clsApplicationType(int ApplicationTypeID, string Title, decimal Fees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.Title = Title;
            this.Fees = Fees;
        }

        public static clsApplicationType FindApplicationType(int AppTypeID)
        {
            string Title = string.Empty;
            decimal Fees = -1;

            if (clsApplicationTypeDataAccess.FindApplicationType(AppTypeID, ref Title, ref Fees))
            {
                return new clsApplicationType(AppTypeID, Title, Fees);
            }

            else
                return null;

        }

        public bool UpdateApplicationType()
        {
            return clsApplicationTypeDataAccess.UpdateApplicationType(this.ApplicationTypeID, this.Title, this.Fees);
        }

        
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeDataAccess.GetAllApplicationTypes();
        }
    }
}
