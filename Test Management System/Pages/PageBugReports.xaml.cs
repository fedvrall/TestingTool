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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Management_System.Classes;
using Test_Management_System.Entities;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBugReports.xaml
    /// </summary>
    public partial class PageBugReports : Page
    {
        List<ColumnSelectionItem> columnSelectionItems = new List<ColumnSelectionItem>();
        Testing_ToolEntity db = new Testing_ToolEntity();
        private int BRID;
        UserContext userContext { get; set; }
        public PageBugReports(UserContext userContext)
        {
            this.userContext = userContext;
            InitializeComponent();

            columnSelectionItems.Add(new ColumnSelectionItem("Критичность"));
            columnSelectionItems.Add(new ColumnSelectionItem("Приоритет"));
            columnSelectionItems.Add(new ColumnSelectionItem("Предусловия"));
            columnSelectionItems.Add(new ColumnSelectionItem("Вложения"));
            columnSelectionItems.Add(new ColumnSelectionItem("Среда"));
            columnSelectionItems.Add(new ColumnSelectionItem("Тестовые данные"));
            columnSelectionItems.Add(new ColumnSelectionItem("Заметки"));
            columnSelectionItems.Add(new ColumnSelectionItem("Компонент"));
            columnSelectionItems.Add(new ColumnSelectionItem("Версия"));
            columnSelectionItems.Add(new ColumnSelectionItem("Связанный тест-кейс"));

            addFieldsList.ItemsSource = columnSelectionItems;
            UpdateDataGridColumns();
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
                { "Критичность", "BugSeverity.BugSeverityNameTranslation"},
                { "Приоритет", "BugPriority.BugPriorityNameTranslation"},
                { "Предусловия", "BugPreconditions"},
                { "Вложения", "BugAttachment"},
                { "Среда", "BugEnvironment"},
                { "Тестовые данные", "BugTestData"},
                { "Заметки", "BugReportRemark"},
                { "Компонент", "BugComponentOfSW"},
                { "Версия", "BugVersionOfSW"},
                { "Связанный тест-кейс", "TestCaseID"}
            };

            foreach (ColumnSelectionItem item in columnSelectionItems)
            {
                if (item.IsSelected)
                {
                    string selectedHeader = item.Header;
                    if (columnDataBindings.ContainsKey(selectedHeader))
                    {
                        string bind = columnDataBindings[selectedHeader];
                        var existingColumn = bugReportGrid.Columns.FirstOrDefault(c => c.Header.ToString() == selectedHeader);
                        if (existingColumn == null)
                        {
                            DataGridTextColumn newColumn = new DataGridTextColumn();
                            newColumn.Header = selectedHeader;
                            newColumn.Binding = new Binding(bind);
                            bugReportGrid.Columns.Add(newColumn);
                        }
                    }
                }
                else if (!item.IsSelected)
                {
                    string colName = item.Header;
                    bugReportGrid.Columns.Remove(bugReportGrid.Columns.FirstOrDefault(c => c.Header.ToString() == colName));
                }
            }
        }


        private void AddBR_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewBugReport(userContext, BRID));
        }

        private void EditBR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBR_Click(object sender, RoutedEventArgs e)
        {

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

        private void bugReportGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bugReportGrid.SelectedItem != null)
            {
                BRID = ((BugReport)bugReportGrid.SelectedItem).BugReportID;
                EditBR.IsEnabled = true;
                DeleteBR.IsEnabled = true;
            }
            else
            {
                EditBR.IsEnabled = false;
                DeleteBR.IsEnabled = false;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateDataGridColumns();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateDataGridColumns();
        }
    }
}
