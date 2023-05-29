using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Management_System.Classes;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNewCheckList.xaml
    /// </summary>
    public partial class PageNewCheckList : Page
    {
        UserContext UserContext { get; set; }
        private int projectID;
        public PageNewCheckList(UserContext userContext)
        {
            this.projectID = userContext.projectID;
            this.UserContext = userContext;
            InitializeComponent();
        }
    }
}
