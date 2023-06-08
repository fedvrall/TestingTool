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
        Testing_ToolEntity db = new Testing_ToolEntity();
        public bool isEditing = false;
        public int testSuiteID;

        public PageNewTestSuite(UserContext userContext, int TestSuiteID) // Для редактировани выбранного
        {
            this.testSuiteID = TestSuiteID;
            this.UserContext = userContext;
            InitializeComponent();
            var ts = db.TestSuite.Where(x=> x.ProjectID == UserContext.projectID ).ToList();
            ComboTestSuiteParentID.ItemsSource = ts;

            if (testSuiteID == 0)
            {
                isEditing = false;
                HeaderTS.Content = "Добавление нового тест-сьюта";
            }
            else
            {
                isEditing = true;
                var currTS = db.TestSuite.Where(x => x.TestSuiteID == testSuiteID).ToList().FirstOrDefault();
                TBtestSuiteSummary.Text = currTS.TestSuiteSummary;
                TBTestSuiteLabel.Text = currTS.TestSuiteLabel;
                TBTestSuitePreconditions.Text = currTS.TestSuitePreconditions;
                TBTestSuiteDescription.Text = currTS.TestSuiteDescription;
                if (currTS.TestSuiteParentID != null)
                    ComboTestSuiteParentID.SelectedIndex = Convert.ToInt32(currTS.TestSuiteParentID) - 1;
                else
                    ComboTestSuiteParentID.SelectedIndex = -1;

                TBTestSuiteLabel.IsReadOnly = true;
                TBtestSuiteSummary.IsReadOnly = true;
                HeaderTS.Content = "Редактирование тест-сьюта";
            }
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
            if(!isEditing) // добавление нового
            {
                int? parent = null;
                if (ComboTestSuiteParentID.SelectedItem == null)
                    parent = null;
                else
                {
                    var parent1 = db.TestSuite.Where(x => x.TestSuiteSummary == ComboTestSuiteParentID.SelectedItem.ToString()).FirstOrDefault();
                    if (parent1 != null)
                        parent = parent1.TestSuiteID;
                    
                }
                TestSuite testSuite = new TestSuite
                {
                    TestSuiteSummary = TBtestSuiteSummary.Text,
                    TestSuiteDescription = TBTestSuiteDescription.Text,
                    TestSuiteLabel = TBTestSuiteLabel.Text,
                    TestSuitePreconditions = TBTestSuitePreconditions.Text,
                    TestSuiteParentID = parent,
                    ProjectID = UserContext.projectID
                };

                try
                {

                    db.TestSuite.Add(testSuite);
                    db.SaveChanges();
                }
                catch 
                {
                    MessageBox.Show("Тест-сьют не был добавлен");
                }
                finally
                {
                    MessageBox.Show("Тест-сьют был добавлен");
                    NavigationService.Navigate(new PageTestSuites(UserContext));
                }
            }
            else // редактирование существующего
            {

                try
                {
                    var findTS = db.TestSuite.Find(testSuiteID);
                    findTS.TestSuiteSummary = TBtestSuiteSummary.Text.ToString();
                    findTS.TestSuiteDescription = TBTestSuiteDescription.Text.ToString();
                    findTS.TestSuiteLabel = findTS.TestSuiteLabel;
                    findTS.TestSuitePreconditions = TBTestSuiteLabel.Text.ToString();
                    findTS.ProjectID = UserContext.projectID;
                    findTS.TestSuiteParentID = ComboTestSuiteParentID.SelectedIndex + 1;
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Не удалось отредактировать тест-сьют");
                }
                finally
                {
                    MessageBox.Show("Изменения в тест-сьюте сохранены");
                }
            }
        }

        private void TBtestSuiteSummary_LostFocus(object sender, RoutedEventArgs e)
        {
            TBTestSuiteLabel.Text = generateLabelFromSummary();
            bool labelExists = db.TestSuite.Any(l => l.TestSuiteLabel == TBTestSuiteLabel.Text);

            if (labelExists)
            {
                MessageBox.Show("Метка уже существует. Пожалуйста, выберите другую метку.");
            }
        }
    }
}
