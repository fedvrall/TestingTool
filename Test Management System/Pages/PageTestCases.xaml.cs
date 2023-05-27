using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public ICommand ToggleElementCommand { get; }
        /*        private ObservableCollection<string> availableFields;
                private List<string> selectedFields;*/
        List<ColumnSelectionItem> columnSelectionItems = new List<ColumnSelectionItem>();

        public PageTestCases()
        {
            InitializeComponent();
            Testing_ToolEntities db = new Testing_ToolEntities();
            testCaseGrid.ItemsSource = db.TestCase.ToList();

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
                { "Предусловия", "TestCaseExecutionDate"},
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
            /*            if(ChoseTCFields.Content.ToString() == "Просмотреть поля")
                        {*/


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


        private void AddTestCaseItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewTestCase());
        }

        private void EditTestCaseItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTestCase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveTestCaseChanges_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateDataGridColumns();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateDataGridColumns();
        }
    }
}
