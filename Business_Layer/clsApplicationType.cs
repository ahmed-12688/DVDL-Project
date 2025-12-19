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
        public enum enApplicationTypes
        {
            NewLocalDrivingLicenseService = 1, RenewDrivingLicenseService, ReplacementforaLostDrivingLicense,
            ReplacementforaDamagedDrivingLicense, ReleaseDetainedDrivingLicsense, NewInternationalLicense, RetakeTest
        };


        public enApplicationTypes ApplicationTypeID;
        public string Title;
        public decimal Fees;


        public clsApplicationType(enApplicationTypes ApplicationTypeID, string Title, decimal Fees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.Title = Title;
            this.Fees = Fees;
        }

        public static clsApplicationType FindApplicationType(enApplicationTypes AppTypeID)
        {
            string Title = string.Empty;
            decimal Fees = -1;

            if (clsApplicationTypeDataAccess.FindApplicationType((int)AppTypeID, ref Title, ref Fees))
            {
                return new clsApplicationType(AppTypeID, Title, Fees);
            }

            else
                return null;

        }

        public bool UpdateApplicationType()
        {
            return clsApplicationTypeDataAccess.UpdateApplicationType((int)this.ApplicationTypeID, this.Title, this.Fees);
        }

        
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeDataAccess.GetAllApplicationTypes();
        }
    }
}
