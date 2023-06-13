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
        public int testSuiteID, projectID;
        Testing_ToolEntity db = new Testing_ToolEntity();

        public PageTestSuites(UserContext userContext)
        {
            this.UserContext = userContext;
            this.projectID = userContext.projectID;
            InitializeComponent();
            dgvTestSuites.ItemsSource = db.TestSuite.Where(x=>x.ProjectID == projectID).ToList();
        }

        private void NewTestSuiteButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewTestSuite(UserContext, 0));
        }

        private void EditTestSuite_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewTestSuite(UserContext, testSuiteID));
        }

        private void DeleteTestSuite_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить тест-сьют со всеми тест-кейсами?", "Удаление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var ts = db.TestSuite.FirstOrDefault(x => x.TestSuiteID == testSuiteID);
                var tcToDelete = db.TestCase.Where(x => x.TestSuiteID == testSuiteID);
                try
                {
                    db.TestCase.RemoveRange(tcToDelete);
                    db.TestSuite.Remove(ts);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Не удалось удалить тест-сьют");
                }
                finally
                {
                    MessageBox.Show("Тест-сьют удалён");
                    dgvTestSuites.ItemsSource = null;
                    dgvTestSuites.ItemsSource = db.TestSuite.Where(x => x.ProjectID == projectID).ToList();
                }
            }
            else return;
        }

        private void WatchTestCases_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageTestCases(UserContext, testSuiteID));
        }

        private void dgvTestSuites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvTestSuites.SelectedItem != null)
            {
                testSuiteID = ((TestSuite)dgvTestSuites.SelectedItem).TestSuiteID;
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
