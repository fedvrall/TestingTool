using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Test_Management_System.Entities;

namespace Test_Management_System.Classes
{
    public class GenerateID
    {
        public UserContext Context { get; set; }
        public string ProjectLabel;
        public int ProjectID, TSID;
        Testing_ToolEntity db = new Testing_ToolEntity();
        public GenerateID(UserContext userContext)
        {
            this.Context = userContext;
        }

        public string GenerateTestSuiteD(int TSID)
        {
            string TCID = "";
            string TSLabel = db.TestSuite.Where(x => x.TestSuiteID == TSID).FirstOrDefault().TestSuiteLabel;
            string idPrefix = TSLabel + "";
            int lastUsedIdNumber = 0;

            int countRowsInTC = db.TestCase.Where(x => x.TestSuiteID == TSID).Count();
            if(countRowsInTC > 0)
            {
                var getLastTCID = db.TestCase.Where(x => x.TestSuiteID == TSID).OrderByDescending(x => x.TestCaseID).FirstOrDefault();
                string lastID = getLastTCID.TestCaseVisibleID;
                //if (getLastTCID != null)
                //{
                    if (lastID.StartsWith(idPrefix))
                    {
                        string numberString = lastID.Substring(idPrefix.Length);
                        if (int.TryParse(numberString, out int number))
                        {
                            if (number > lastUsedIdNumber)
                            {
                                lastUsedIdNumber = number;
                            }
                        }
                    }
                //}
            }

            else
            {
                lastUsedIdNumber = 0;
            }
            lastUsedIdNumber++;
            TCID = idPrefix + lastUsedIdNumber.ToString();
            return TCID;
        }
    }
}
