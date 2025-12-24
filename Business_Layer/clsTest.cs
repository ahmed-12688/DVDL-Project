using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class clsTest
    {
        public enum enMode { Addnew, Update }
        public enMode Mode;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = true;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
            this.Mode = enMode.Addnew;
        }

        public clsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            this.TestID = testID;
            this.TestAppointmentID = testAppointmentID;
            this.TestResult = testResult;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;
        }
        public static clsTest FindTest(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = true;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if (clsTestDataAccess.FindTest(TestID, ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))
            {
                return new clsTest(TestID, TestAppointmentID, TestResult,
                       Notes, CreatedByUserID);
            }

            else
                return null;

        }

        public static bool DeleteTest(int TestID)
        {
            return clsTestDataAccess.DeleteTest(TestID);
        }

        public static DataTable GetAllTests()
        {
            return clsTestDataAccess.GetAllTests();
        }

        public static bool IsUTestExist(int TestID)
        {
            return clsTestDataAccess.IsTestExist(TestID);
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestDataAccess.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            return (clsTestDataAccess.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes,
                this.CreatedByUserID));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    if (_UpdateTest())
                        return true;
                    else
                        return false;


            }
            return false;
        }

    }
}
