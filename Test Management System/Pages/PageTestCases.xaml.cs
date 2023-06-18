using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Management_System.Classes;
using Test_Management_System.Entities;
using static Test_Management_System.Pages.PageTestCases;
using CheckBox = System.Windows.Controls.CheckBox;
using DataGridColumn = System.Windows.Controls.DataGridColumn;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTestCases.xaml
    /// </summary>
    public partial class PageTestCases : Page
    {
       // public ICommand ToggleElementCommand { get; }
        List<ColumnSelectionItem> columnSelectionItems = new List<ColumnSelectionItem>();
        Testing_ToolEntity db = new Testing_ToolEntity();
        public int testStuiteID, testCaseID, userID, roleID;
        private bool creator;
        UserContext UserContext { get; set; }

        public PageTestCases(UserContext userContext, int testStuiteID)
        {
            InitializeComponent();

            SortTestCases();
            columnSelectionItems.Add(new ColumnSelectionItem("Описание"));
            columnSelectionItems.Add(new ColumnSelectionItem("Критичность"));
            columnSelectionItems.Add(new ColumnSelectionItem("Приоритет"));
            columnSelectionItems.Add(new ColumnSelectionItem("Тип"));
            columnSelectionItems.Add(new ColumnSelectionItem("Поведение"));
            columnSelectionItems.Add(new ColumnSelectionItem("Дата создания"));
            columnSelectionItems.Add(new ColumnSelectionItem("Дата выполнения"));
            columnSelectionItems.Add(new ColumnSelectionItem("Предусловия"));
            columnSelectionItems.Add(new ColumnSelectionItem("Постусловия"));
            columnSelectionItems.Add(new ColumnSelectionItem("Вложения"));
            columnSelectionItems.Add(new ColumnSelectionItem("Среда"));
            columnSelectionItems.Add(new ColumnSelectionItem("Тестовые данные"));

            addFieldsList.ItemsSource = columnSelectionItems;
            UpdateDataGridColumns();
            this.testStuiteID = testStuiteID;
            this.UserContext = userContext;
            this.userID = userContext.userId;
            this.roleID = userContext.roleId;
            HeaderTestCasesView.Content = db.TestSuite.Where(x => x.TestSuiteID == testStuiteID).FirstOrDefault().TestSuiteSummary;
            testCaseGrid.ItemsSource = db.TestCase.Where(x=>x.TestSuiteID == testStuiteID).ToList();
        }


        public class ColumnSelectionItem
        {
            public string Header { get; set; }
            public bool IsSelected { get; set; } 

            public ColumnSelectionItem(string header, bool isSelected = false)
            {
                Header = header;
                IsSelected = isSelected;
            }

        }
        private void UpdateDataGridColumns()
        {
            Dictionary<string, string> columnDataBindings = new Dictionary<string, string>()
            {
                { "Описание", "TestCaseDescription"},
                { "Критичность", "TestCaseSeverity.TCSeverityDescriptionTranslation"},
                { "Приоритет", "TestCasePriority.TCPriorityDescriptionTranslation"},
                { "Тип", "TestCaseType.TCTypeDescriptionTranlation"},
                { "Поведение", "TestCaseBehavior.TCBehaviorDescriptionTranlation"},
                { "Дата создания", "TestCaseCreationDate"},
                { "Дата выполнения", "TestCaseExecutionDate"},
                { "Предусловия", "TestCasePrecondition"},
                { "Постусловия", "TestCasePostcondition"},
                { "Вложения", "TestCaseAttachment"},
                { "Среда", "TestCaseEnvironment"},
                { "Тестовые данные", "TestCaseTestData"}
            };

            foreach (ColumnSelectionItem item in columnSelectionItems)
            {
                if (item.IsSelected)
                {
                    string selectedHeader = item.Header;
                    if (columnDataBindings.ContainsKey(selectedHeader))
                    {
                        string bind = columnDataBindings[selectedHeader];
                        var existingColumn = testCaseGrid.Columns.FirstOrDefault(c => c.Header.ToString() == selectedHeader);
                        if (existingColumn == null)
                        {
                            DataGridTextColumn newColumn = new DataGridTextColumn();
                            newColumn.Header = selectedHeader;
                            newColumn.Binding = new Binding(bind);
                            testCaseGrid.Columns.Add(newColumn);
                        }
                    }
                }
                else if(!item.IsSelected)
                {
                    string colName = item.Header;
                    testCaseGrid.Columns.Remove(testCaseGrid.Columns.FirstOrDefault(c => c.Header.ToString() == colName));
                }    
            }
        }

        private void ChoseTCFields_Click(object sender, RoutedEventArgs e)
        {
            if (FormContainer.Visibility == Visibility.Visible)
            {
                FormContainer.Visibility = Visibility.Collapsed;
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 200;
                animation.To = 0;
                animation.Duration = TimeSpan.FromSeconds(0.3);
                FormContainer.BeginAnimation(Border.WidthProperty, animation);
                ChoseTCFields.Content = "Просмотреть поля";
            }
            else
            {
                FormContainer.Visibility = Visibility.Visible;
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0;
                animation.To = 200; 
                animation.Duration = TimeSpan.FromSeconds(0.3);
                FormContainer.BeginAnimation(Border.WidthProperty, animation);
                ChoseTCFields.Content = "Скрыть поля";
            }
        }

        private void SortTestCases()
        {
            var tc = db.TestCase.ToList();

            if (ComboSortBy.SelectedIndex == 1)
                tc = db.TestCase.OrderBy(x => x.TestCaseCreationDate).ToList();
            if(ComboSortBy.SelectedIndex == 2)
                tc = db.TestCase.OrderByDescending(x=>x.TestCaseCreationDate).ToList();

            if(ComboSortBy.SelectedIndex == 3)
                tc = db.TestCase.Where(x=>x.TCStatusID == 2).ToList();
            if (ComboSortBy.SelectedIndex == 4)
                tc = db.TestCase.Where(x => x.TCStatusID == 5).ToList();

            if (ComboSortBy.SelectedIndex == 5)
                tc = db.TestCase.OrderByDescending(x => x.TCPriorityID).ToList();
            if (ComboSortBy.SelectedIndex == 6)
                tc = db.TestCase.OrderBy(x => x.TCPriorityID).ToList();
            if (ComboSortBy.SelectedIndex == 7)
                tc = db.TestCase.OrderBy(x => x.TCSeverityID).ToList();
            if (ComboSortBy.SelectedIndex == 8)
                tc = db.TestCase.OrderByDescending(x => x.TCSeverityID).ToList();
            testCaseGrid.ItemsSource = tc;
        }

        private void AddTestCaseItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewTestCase(UserContext, testStuiteID, 0));
        }

        private void EditTestCaseItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewTestCase(UserContext, testStuiteID, testCaseID));
        }

        private void DeleteTestCase_Click(object sender, RoutedEventArgs e)
        {
            var dialog = MessageBox.Show("Вы действительно хотите удалить выбранный тест-кейс?", "Удалить?", MessageBoxButton.YesNo);
            if (dialog == MessageBoxResult.Yes)
            {
                var testCase = db.TestCase.FirstOrDefault(x => x.TestCaseID == testCaseID);
                db.TestCase.Remove(testCase);
                db.SaveChanges();
                MessageBox.Show("Тест-кейс удалён");
                testCaseGrid.ItemsSource = null;
                testCaseGrid.ItemsSource = db.TestCase.Where(x => x.TestSuiteID == testStuiteID).ToList();
            }
            else
                return;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateDataGridColumns();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateDataGridColumns();
        }

        private void testCaseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (testCaseGrid.SelectedItem != null)
            {
                testCaseID = ((TestCase)testCaseGrid.SelectedItem).TestCaseID;

                int userTC = db.TestCase.Where(x => x.TestCaseID == testCaseID).FirstOrDefault().CreatorUserID;
                if (userTC == userID)
                    creator = true;
                if (roleID == 2 || creator)
                {
                    EditTestCaseItem.IsEnabled = true;
                    DeleteTestCase.IsEnabled = true;
                }
                else
                {
                    EditTestCaseItem.IsEnabled = false;
                    DeleteTestCase.IsEnabled = false;
                }
            }
            else
            {
                EditTestCaseItem.IsEnabled = false;
                DeleteTestCase.IsEnabled = false;
            }
        }

        private void ComboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortTestCases();
        }

        private void BackToTS_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageTestSuites(UserContext));
        }
    }
}
