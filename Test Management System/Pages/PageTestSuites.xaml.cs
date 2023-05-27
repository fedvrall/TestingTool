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
using Test_Management_System.Entities;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTestSuites.xaml
    /// </summary>
    public partial class PageTestSuites : Page
    {
        public UserContext UserContext { get; set; }
        public string TestSuiteID = "";
        Testing_ToolEntities db = new Testing_ToolEntities();

        public PageTestSuites(UserContext userContext)
        {
            this.UserContext = userContext;
            InitializeComponent();
            dgvTestSuites.ItemsSource = db.TestSuite.ToList();
        }

        private void NewTestSuiteButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewTestSuite(UserContext, TestSuiteID));
        }

        private void EditTestSuite_Click(object sender, RoutedEventArgs e)
        {

        }


        private void DeleteTestSuite_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchTestCases_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageTestCases());
        }
    }
}
