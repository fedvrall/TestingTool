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
using Test_Management_System.Entities;
using Test_Management_System.Classes;
using Microsoft.Win32;
using System.Diagnostics.Eventing.Reader;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNewTestCase.xaml
    /// </summary>
    public partial class PageNewTestCase : Page
    {
        private List<string> attachmentsList = new List<string>();
        Testing_ToolEntity db = new Testing_ToolEntity();
        public int testSuiteID, testCaseID, userID;
        private bool isEditTC;
        UserContext UserContext { get; set; }
        public PageNewTestCase(UserContext userContext, int testSuiteID, int testCaseID)
        {
            InitializeComponent();
            Testing_ToolEntity db = new Testing_ToolEntity();
            ComboStatusTC.ItemsSource = db.TestCaseStatus.ToList();
            ComboBehaviorTC.ItemsSource = db.TestCaseBehavior.ToList();
            ComboPriorityTC.ItemsSource = db.TestCasePriority.ToList();
            ComboTypeTC.ItemsSource = db.TestCaseType.ToList();
            ComboSeverityTC.ItemsSource = db.TestCaseSeverity.ToList();
            ComboStatusTC.SelectedIndex = 4;
            this.testSuiteID = testSuiteID;
            this.testCaseID = testCaseID;
            this.UserContext = userContext;
            this.userID = userContext.userId;
            if (testCaseID == 0)
                isEditTC = false; 
            else 
                isEditTC = true;
            CreationDate.DisplayDate = DateTime.Now;
        }

        private bool IsAllFieldsHaveContent()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(TBActual.Text))
                TBActual.Text = "-";
            if (string.IsNullOrEmpty(TBSummary.Text))
            {
                TBSummary.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }
            if (string.IsNullOrEmpty(TBExpected.Text))
            {
                TBExpected.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }
            if (string.IsNullOrEmpty(TBSteps.Text))
            {
                TBSteps.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }

            return isValid;
        }

        private void AddNewTestCase()
        {
            var attString = string.Join(";", attachmentsList);
            DateTime selectedDate = CreationDate.SelectedDate ?? DateTime.Now;
            DateTime? ExDate = null;
            int? executor = null;
            if (ComboStatusTC.SelectedIndex == 4)
            {
                ExDate = null;
                executor = null;
            }
            else
            {
                ExDate = DateTime.Now;
                executor = userID;
            }
            int? type = null;
            if (ComboTypeTC.SelectedIndex == -1)
                type = null;
            else
                type = ComboTypeTC.SelectedIndex + 1;

            int? behavior = null;
            if (ComboBehaviorTC.SelectedIndex == -1)
                behavior = null;
            else
                behavior = ComboBehaviorTC.SelectedIndex + 1;

            int? severity = null;
            if (ComboSeverityTC.SelectedIndex == -1)
                severity = null;
            else
                severity = ComboSeverityTC.SelectedIndex + 1;

            int? priority = null;
            if (ComboPriorityTC.SelectedIndex == -1)
                priority = null;
            else
                priority = ComboPriorityTC.SelectedIndex + 1;

            if (!isEditTC)
            {
                if (IsAllFieldsHaveContent())
                {
                    TestCase testCase = new TestCase()
                    {
                        TestCaseSummary = TBSummary.Text,
                        TestCaseDescription = TBDescription.Text,
                        TestCaseSteps = TBSteps.Text,
                        TestCaseExpectedResult = TBExpected.Text,
                        TestCaseActualResult = TBActual.Text,
                        TCStatusID = ComboStatusTC.SelectedIndex + 1,
                        TestCaseTestData = TBTestData.Text,
                        TestSuiteID = testSuiteID,
                        CreatorUserID = userID,
                        TestCaseCreationDate = selectedDate,
                        ExecutorUserID = executor,
                        TestCaseExecutionDate = ExDate,
                        TestCaseEnvironment = TBEnvironment.Text,
                        TCTypeID = type,
                        TCBehaviorID = behavior,
                        TCPriorityID = priority,
                        TCSeverityID = severity,
                        TestCaseAttachment = attString,
                        TestCasePrecondition = TBPreconditions.Text,
                        TestCasePostcondition = TBPostConditions.Text
                    };
                    try
                    {
                        db.TestCase.Add(testCase);
                        db.SaveChanges();

                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить тест-кейс");
                    }
                    finally
                    {
                        MessageBox.Show("Тест-кейс добавлен");

                    }
                }
                else
                    MessageBox.Show("Заполните поля");

            }
            else
            {
                try
                {
                    var findTC = db.TestCase.Find(testCaseID);
                    findTC.TestCaseSummary = TBSummary.Text;
                    findTC.TestCaseDescription = TBDescription.Text;
                    findTC.TestCaseSteps = TBSteps.Text;
                    findTC.TestCaseExpectedResult = TBExpected.Text;
                    findTC.TestCaseActualResult = TBActual.Text;
                    findTC.TCStatusID = ComboStatusTC.SelectedIndex + 1;
                    findTC.TestCaseTestData = TBTestData.Text;
                    findTC.TestSuiteID = testSuiteID;
                    findTC.CreatorUserID = findTC.CreatorUserID;
                    findTC.TestCaseCreationDate = selectedDate;
                    findTC.ExecutorUserID = executor;
                    findTC.TestCaseExecutionDate = ExDate;
                    findTC.TestCaseEnvironment = TBEnvironment.Text;
                    findTC.TCTypeID = ComboTypeTC.SelectedIndex + 1;
                    findTC.TCBehaviorID = ComboBehaviorTC.SelectedIndex + 1;
                    findTC.TCPriorityID = ComboPriorityTC.SelectedIndex + 1;
                    findTC.TCSeverityID = ComboSeverityTC.SelectedIndex + 1;
                    findTC.TestCaseAttachment = attString;
                    findTC.TestCasePrecondition = TBPreconditions.Text;
                    findTC.TestCasePostcondition = TBPostConditions.Text;
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Не удалось отредактировать тест-кейс");
                }
                finally
                {
                    MessageBox.Show("Тест-кейс изменён");
                    NavigationService.Navigate(new PageTestCases(UserContext, testSuiteID));
                }
            }
        }

        private void SaveAndBackToTCPageButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewTestCase();
            //NavigationService.Navigate(new PageTestCases(UserContext, testSuiteID));
        }

        private void SaveAndAddTCButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewTestCase();
            TBSummary.Clear();
            TBDescription.Clear();
            TBSteps.Clear();
            TBExpected.Clear();
            TBActual.Clear();
            ComboStatusTC.SelectedIndex = 4;
            TBTestData.Clear();
            CreationDate.DisplayDate = DateTime.Now;
            TBEnvironment.Clear();
            ComboTypeTC.SelectedIndex = -1;
            ComboBehaviorTC.SelectedIndex = -1;
            ComboPriorityTC.SelectedIndex = -1;
            ComboSeverityTC.SelectedIndex = -1;
            attachmentsList.Clear();
            TBPreconditions.Clear();
            TBPostConditions.Clear();
        }

        private void NoSaveBackToTestCasePageButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = MessageBox.Show("Вы действительно хотите выйти?", "Выйти?", MessageBoxButton.YesNo);
            if (dialog == MessageBoxResult.Yes)
                NavigationService.Navigate(new PageTestCases(UserContext, testSuiteID));
            else
                return;
        }

        private void RemoveAttachment_Click(object sender, RoutedEventArgs e)
        {
            Button removeButton = (Button)sender;
            string fileName = removeButton.DataContext as string;
            string filePath = attachmentsList.FirstOrDefault(path => System.IO.Path.GetFileName(path) == fileName);
            attachmentsList.Remove(filePath);
            AttachmentsListBox.Items.Remove(fileName);
        }

        private void AddAttachment_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                attachmentsList.Add(filePath);
                AttachmentsListBox.Items.Add(fileName);
            }
        }
    }
}
