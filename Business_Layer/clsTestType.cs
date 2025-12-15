using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class clsTestType
    {
        public int TestTypeID;
        public string Title;
        public string Description;
        public decimal Fees;


        public clsTestType(int TestTypeID, string Title, string Description, decimal Fees)
        {
            this.TestTypeID = TestTypeID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

        public static clsTestType FindTestType(int TestTypeID)
        {
            string Title = string.Empty;
            string Description = string.Empty;
            decimal Fees = -1;

            if (clsTestTypeDataAccess.FindTestType(TestTypeID, ref Title, ref Description, ref Fees))
            {
                return new clsTestType(TestTypeID, Title, Description, Fees);
            }

            else
                return null;

        }

        public bool UpdateTestType()
        {
            return clsTestTypeDataAccess.UpdateTestType(this.TestTypeID, this.Title, this.Description, this.Fees);
        }


        public static DataTable GetAllTestTypeDataTable()
        {
            return clsTestTypeDataAccess.GetAllTestTypes();
        }

    }
}
