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
using static Test_Management_System.Classes.UserContext;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNewBugReport.xaml
    /// </summary>
    public partial class PageNewBugReport : Page
    {
/*        public int userId { get; set; }
        public string userName { get; set; }
        public int roleId { get; set; }*/
        public UserContext userContext { get; set; }
        public PageNewBugReport(UserContext userContext)
        {
            this.userContext = userContext;
            InitializeComponent();
            int userID = userContext.userId;
            string username = userContext.userName;
            int roleID = userContext.roleId;
            //BugUserTextBox.Text = username;
        }

        private void SaveBRAndExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveAndAddOneMoreBR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitWithoutSaveBR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAttachment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveAttachment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
