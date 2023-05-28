/*using System;
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
        public string ProjectID;
        public GenerateID(UserContext userContext)
        {
            this.Context = userContext;
            this.ProjectLabel = Context.projectLabel;
            this.ProjectID = Context.projectID;
        }

        public string GenerateTestSuiteD()
        {
            string TSID = "";
            string idPrefix = ProjectID + "TS";
            int lastUsedIdNumber = 0;


            using (Testing_ToolEntities db = new Testing_ToolEntities())
            {
                var getLastTSID = db.TestSuite.Where(x => x.ProjectID == ProjectID).OrderByDescending(x => x.TestSuiteID).FirstOrDefault();
                string lastID = getLastTSID.TestSuiteID;
                if (getLastTSID != null)
                {
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
                }
                else
                {
                    lastUsedIdNumber = 0;
                }
                lastUsedIdNumber++;
                TSID = idPrefix + lastUsedIdNumber.ToString();
                return TSID;
            }
        }
    }
}
*/