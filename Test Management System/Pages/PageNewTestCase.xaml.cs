using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Test_Management_System.Entities;
using Test_Management_System.Classes;
using Microsoft.Win32;

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
        private bool isEditTC, creator, success;
        List<string> attachmentNames;
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
            {
                isEditTC = false;
                Header.Content = "Добавление нового тест-кейса";
                creator = true;
            }
            else
            {
                isEditTC = true;
                Header.Content = "Редактирование тест-кейса";
                SaveAndAddTCButton.IsEnabled = false;
                int userTC = db.TestCase.Where(x => x.TestCaseID == testCaseID).FirstOrDefault().CreatorUserID;
                if (userTC == userID)
                    creator = true;
                else
                    creator = false;
                IsCreator();
            }

            CreationDate.DisplayDate = DateTime.Now;
        }


        private void IsCreator()
        {
            var tc = db.TestCase.Where(x => x.TestCaseID == testCaseID).FirstOrDefault();
            TBSummary.Text = tc.TestCaseSummary;
            TBDescription.Text = tc.TestCaseDescription;
            TBSteps.Text = tc.TestCaseSteps;
            TBExpected.Text = tc.TestCaseExpectedResult;
            if (tc.TestCaseActualResult == "-")
                TBActual.Clear();
            else
                TBActual.Text = tc.TestCaseActualResult;
            TBTestData.Text = tc.TestCaseTestData;
            TBEnvironment.Text = tc.TestCaseEnvironment;
            ComboStatusTC.SelectedIndex = tc.TCStatusID - 1;
            if (tc.TestCasePriority != null)
                ComboPriorityTC.SelectedIndex = (int)(tc.TCPriorityID - 1);
            if (tc.TestCaseSeverity != null)
                ComboSeverityTC.SelectedIndex = (int)(tc.TCSeverityID - 1);
            if (tc.TCBehaviorID != null)
                ComboBehaviorTC.SelectedIndex = (int)(tc.TCBehaviorID - 1);
            if (tc.TCTypeID != null)
                ComboTypeTC.SelectedIndex = (int)(tc.TCTypeID - 1);
            CreationDate.DisplayDate = tc.TestCaseCreationDate;
            TBPreconditions.Text = tc.TestCasePrecondition;
            TBPostConditions.Text = tc.TestCasePostcondition;

            string attString = tc.TestCaseAttachment != null ? tc.TestCaseAttachment?.ToString() : string.Empty;
            attachmentsList = attString.Split(';').ToList();
            attachmentNames = attachmentsList.Select(System.IO.Path.GetFileName).ToList();
            AttachmentsListBox.ItemsSource = attachmentNames;

            if (!creator)
            {
                TBSummary.IsEnabled = false;
                TBDescription.IsEnabled = false;
                TBSteps.IsEnabled = false;
                TBExpected.IsEnabled = false;
                TBPreconditions.IsEnabled = false;
                TBPostConditions.IsEnabled = false;
                TBTestData.IsEnabled = false;
                AddAttachment.IsEnabled = false;
                AttachmentsListBox.IsEnabled = false;
                CreationDate.IsEnabled = false;
                TBEnvironment.IsEnabled = false;
            }
        }

        private bool IsAllFieldsHaveContent()
        {
            bool isValid = true;
            if (ComboStatusTC.SelectedIndex == 4 && string.IsNullOrEmpty(TBActual.Text))
                TBActual.Text = "-";
            if(ComboStatusTC.SelectedIndex != 4 && string.IsNullOrEmpty(TBActual.Text))
            {
                TBActual.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }

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

            GenerateID generateID = new GenerateID(UserContext);
            string testcaseVisibleID = generateID.GenerateTestSuiteD(testSuiteID);

            if (IsAllFieldsHaveContent())
            {
                if (!isEditTC)

                {
                    TestCase testCase = new TestCase()
                    {
                        TestCaseSummary = TBSummary.Text,
                        TestCaseVisibleID = testcaseVisibleID,
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
                        success = false;
                    }
                    finally
                    {
                        MessageBox.Show("Тест-кейс добавлен");
                        success = true;
                    }
                }


            else
                {
                    try
                    {
                        var findTC = db.TestCase.Find(testCaseID);
                        findTC.TestCaseSummary = TBSummary.Text;
                        findTC.TestCaseVisibleID = testcaseVisibleID;
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
                        findTC.TCTypeID = type;
                        findTC.TCBehaviorID = behavior;
                        findTC.TCPriorityID = priority;
                        findTC.TCSeverityID = severity;
                        findTC.TestCaseAttachment = attString;
                        findTC.TestCasePrecondition = TBPreconditions.Text;
                        findTC.TestCasePostcondition = TBPostConditions.Text;
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось отредактировать тест-кейс");
                        success = false;
                    }
                    finally
                    {
                        MessageBox.Show("Тест-кейс изменён");
                        success = true;
                        NavigationService.Navigate(new PageTestCases(UserContext, testSuiteID));
                    }
                }
            }
            else
                MessageBox.Show("Заполните поля");

        }

        private void SaveAndBackToTCPageButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewTestCase();
            if (success)
                NavigationService.Navigate(new PageTestCases(UserContext, testSuiteID));
            else return;
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
            CreationDate.SelectedDate = DateTime.Now;
            TBEnvironment.Clear();
            ComboTypeTC.SelectedIndex = -1;
            ComboBehaviorTC.SelectedIndex = -1;
            ComboPriorityTC.SelectedIndex = -1;
            ComboSeverityTC.SelectedIndex = -1;
            attachmentsList.Clear();
            AttachmentsListBox.ItemsSource = null;
            AttachmentsListBox.ItemsSource = attachmentsList;
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
            attachmentNames.Remove(fileName);
            AttachmentsListBox.ItemsSource = null;
            AttachmentsListBox.ItemsSource = attachmentNames;
        }

        private void AddAttachment_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                attachmentsList.Add(filePath);
                AttachmentsListBox.ItemsSource = null;
                AttachmentsListBox.ItemsSource = attachmentsList.Select(System.IO.Path.GetFileName);
            }
        }
    }
}
