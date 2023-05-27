using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
    /// Логика взаимодействия для PageNewTestSuite.xaml
    /// </summary>
    
    
    public partial class PageNewTestSuite : Page
    {
        public UserContext UserContext { get; set; }
        Testing_ToolEntities db = new Testing_ToolEntities();

        public PageNewTestSuite(UserContext userContext, string TestSuiteID) // Для редактировани выбранного
        {
            this.UserContext = userContext;
            InitializeComponent();
            var ts = db.TestSuite.Where(x=> x.ProjectID == UserContext.projectID ).ToList();
            ComboTestSuiteParentID.ItemsSource = ts;


        }
        private string generateLabelFromSummary()
        {
            string input = "", result = "", result1 = "";
            if (TBtestSuiteSummary != null)
            {
                input = TBtestSuiteSummary.Text;
                string[] words = input.Split(new[] { ' ', ',', '.', ';', ':', '-', '!' }, StringSplitOptions.RemoveEmptyEntries);

                //result = "";
                foreach (string word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        result += word[0];
                    }
                }
            }
            result1 = result;
            if(result.Length > 3)
            {
                result1 = result.Substring(result.Length - 3);
            }
            //result1.ToUpperInvariant();
            return result1.ToUpper();
        }


        private void BackToTestSuitePageButton_Click(object sender, RoutedEventArgs e)
        {
            if(TBTestSuiteDescription.Text != "" ||  TBTestSuitePreconditions.Text != "" || TBtestSuiteSummary.Text != "" || ComboTestSuiteParentID.SelectedItem != null)
            {
                var result = MessageBox.Show("У вас остались несохранённые данные. Вы действительно хотите выйти?", "Выйти без сохранения?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    NavigationService.Navigate(new PageTestSuites(UserContext));
                else
                    return;
            }
            else
                NavigationService.Navigate(new PageTestSuites(UserContext));
        }

        private void SaveTestSuite_Click(object sender, RoutedEventArgs e)
        {
            string parent = "";
            GenerateID genID = new GenerateID(UserContext);
            //using (Testing_ToolEntities db = new Testing_ToolEntities())
            //{
                if (ComboTestSuiteParentID.SelectedItem == null)
                    parent = null;
                else
                {
                    var parent1 = db.TestSuite.Where(x => x.TestSuiteSummary == ComboTestSuiteParentID.SelectedItem.ToString()).FirstOrDefault();
                    if (parent1 != null)
                        parent = parent1.TestSuiteID.ToString();
                    
                }
            //}
            TestSuite testSuite = new TestSuite
            {
                TestSuiteID = genID.GenerateTestSuiteD(),
                TestSuiteSummary = TBtestSuiteSummary.Text,
                TestSuiteDescription = TBTestSuiteDescription.Text,
                TestSuiteLabel = TBTestSuiteLabel.Text,
                TestSuitePreconditions = TBTestSuitePreconditions.Text,
                ProjectID = UserContext.projectID,
                TestSuiteParentID = parent,
            };

            try
            {
                //using (var dbContext = new Testing_ToolEntities())
                //{
                    db.TestSuite.Add(testSuite);
                    db.SaveChanges();
                //}
                MessageBox.Show("Тест-сьют был добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Тест-сьют не был добавлен");
            }

        }

        private void TBtestSuiteSummary_LostFocus(object sender, RoutedEventArgs e)
        {
            TBTestSuiteLabel.Text = generateLabelFromSummary();
            //using (var dbContext = new Testing_ToolEntities())
           // {
                bool labelExists = db.TestSuite.Any(l => l.TestSuiteLabel == TBTestSuiteLabel.Text);

                if (labelExists)
                {
                    MessageBox.Show("Метка уже существует. Пожалуйста, выберите другую метку.");
                }
            //}
        }
    }
}
