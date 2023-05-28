using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Test_Management_System.Classes
{
    public class UserContext
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public int roleId { get; set; }
        public string companyLabel { get; set; }
        public int companyID { get; set; }
        public int projectID { get; set; }
        public string projectLabel { get; set; }
        public bool isProjectSelected {get; set; }

    }
}
