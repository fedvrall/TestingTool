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

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNewTestCase.xaml
    /// </summary>
    public partial class PageNewTestCase : Page
    {
        private List<string> attachmentsList = new List<string>();
        Testing_ToolEntity db = new Testing_ToolEntity();
        public int testSuiteID, testCaseID;
        private bool isEditTC;
        UserContext UserContext { get; set; }
        //PriorityColorConverter cc = new PriorityColorConverter();
        public PageNewTestCase(UserContext userContext, int testSuiteID, int testCaseID)
        {
            InitializeComponent();
            Testing_ToolEntity db = new Testing_ToolEntity();
            ComboStatusTC.ItemsSource = db.TestCaseStatus.ToList();
            ComboBehaviorTC.ItemsSource = db.TestCaseBehavior.ToList();
            ComboPriorityTC.ItemsSource = db.TestCasePriority.ToList();
            ComboTypeTC.ItemsSource = db.TestCaseType.ToList();
            ComboSeverityTC.ItemsSource = db.TestCaseSeverity.ToList();
            this.testSuiteID = testSuiteID;
            this.testCaseID = testCaseID;
            this.UserContext = userContext;
            if (testCaseID == 0)
                isEditTC = false; 
            else 
                isEditTC = true;
            CreationDate.DisplayDate = DateTime.Now;
            CreationDate.SelectedDate = DateTime.Now;
        }

        private bool IsAllFieldsHaveContent()
        {
            // Выполнить проверку на заполнение обязательных полей
            // Добавить поле пользователя, который выполняет тест кейс
            // Или "Если тест-кейс меняет статус, автоматически добавляется пользователь-исполнитель и дата исполнения"
            return true;
        }

        private void AddNewTestCase()
        {
            var attString = string.Join(";", attachmentsList);
            DateTime selectedDate = CreationDate.SelectedDate ?? DateTime.Now;
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
                        CreatorUserID = UserContext.userId,
                        TestCaseCreationDate = selectedDate,
                        ExecutorUserID = null,
                        TestCaseExecutionDate = null,
                        TestCaseEnvironment = TBEnvironment.Text,
                        TCTypeID = ComboTypeTC.SelectedIndex + 1,
                        TCBehaviorID = ComboBehaviorTC.SelectedIndex + 1,
                        TCPriorityID = ComboPriorityTC.SelectedIndex + 1,
                        TCSeverityID = ComboSeverityTC.SelectedIndex + 1,
                        TestCaseAttachment = attString,
                        TestCasePrecondition = TBPreconditions.Text,
                        TestCasePostcondition = TBPostConditions.Text
                    };                
                    try
                    {
                        db.TestCase.Add(testCase);
                        db.SaveChanges();
                        MessageBox.Show("Тест-кейс добавлен");
                    
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Не удалось добавить тест-кейс");
                    }
                }
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
                    findTC.CreatorUserID = UserContext.userId;
                    findTC.TestCaseCreationDate = selectedDate;
                    findTC.ExecutorUserID = null;
                    findTC.TestCaseExecutionDate = null;
                    findTC.TestCaseEnvironment = TBEnvironment.Text;
                    findTC.TCTypeID = ComboTypeTC.SelectedIndex + 1;
                    findTC.TCBehaviorID = ComboBehaviorTC.SelectedIndex + 1;
                    findTC.TCPriorityID = ComboPriorityTC.SelectedIndex + 1;
                    findTC.TCSeverityID = ComboSeverityTC.SelectedIndex + 1;
                    findTC.TestCaseAttachment = attString;
                    findTC.TestCasePrecondition = TBPreconditions.Text;
                    findTC.TestCasePostcondition = TBPostConditions.Text;
                    db.SaveChanges();
                    MessageBox.Show("Тест-кейс изменён");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось отредактировать тест-кейс");
                }
            }
        }

        private void SaveAndBackToTCPageButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewTestCase();
            NavigationService.Navigate(new PageTestCases(UserContext, testSuiteID));
        }

        private void SaveAndAddTCButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewTestCase();
            // очищаем поля, чтобы добавить ещё один
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
