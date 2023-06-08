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
        public int TestSuiteID = 0;
        Testing_ToolEntity db = new Testing_ToolEntity();

        public PageTestSuites(UserContext userContext)
        {
            this.UserContext = userContext;
            InitializeComponent();
            dgvTestSuites.ItemsSource = db.TestSuite.ToList();
        }

        private void NewTestSuiteButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewTestSuite(UserContext, 0));
        }

        private void EditTestSuite_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewTestSuite(UserContext, TestSuiteID));
        }

        private void DeleteTestSuite_Click(object sender, RoutedEventArgs e)
        {
            // Удаление со всеми тест-кейсами
        }

        private void WatchTestCases_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageTestCases(UserContext, TestSuiteID));
        }

        private void dgvTestSuites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvTestSuites.SelectedItem != null)
            {
                TestSuiteID = ((TestSuite)dgvTestSuites.SelectedItem).TestSuiteID;
                //EditTestSuite.IsEnabled = true;
                NewTestSuiteButton.IsEnabled = false;
            }
            else
            {
                NewTestSuiteButton.IsEnabled = true;
                //EditTestSuite.IsEnabled = false;
            }
        }


    }
}
