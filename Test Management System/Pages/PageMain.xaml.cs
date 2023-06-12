using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Test_Management_System.Classes;
using Test_Management_System.Entities;
using Word = Microsoft.Office.Interop.Word;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public UserContext userContext { get; set; }
        public bool IsMenuEnabled { get; set; }

        public event EventHandler MainPageClicked;
        private int companyID, projectID;

        Testing_ToolEntity db = new Testing_ToolEntity();
        
        public PageMain(UserContext userContext)
        {
            this.userContext = userContext;
            this.companyID = userContext.companyID;
            this.projectID = userContext.projectID;
            InitializeComponent();
            ChooseProjectCombo.Items.Clear();
            ChooseProjectCombo.ItemsSource = db.Project.Where(x => x.CompanyID == companyID).ToList();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var fileName = button.CommandParameter.ToString();

                var documentation = db.ProjectDocumentation.FirstOrDefault(x => x.ProjectID == userContext.projectID);
                string attString = documentation != null ? documentation.ProjectDocumentationAttachment?.ToString() : string.Empty;

                var filePath = attString.Split(';').FirstOrDefault(x => System.IO.Path.GetFileName(x) == fileName);

                if (!string.IsNullOrEmpty(filePath))
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        Process.Start(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            attachments.Visibility = Visibility.Visible;
            //ReportPanel.Visibility = Visibility.Visible;
            //LabelForDocs.Visibility = Visibility.Visible;
        }

        private void CreateReport()
        {
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Add();
            if (startPeriod.SelectedDate != null && EndPeriod.SelectedDate != null)
            {
                try
                {
                    DateTime startDate = (DateTime)startPeriod.SelectedDate;
                    DateTime endDate = (DateTime)EndPeriod.SelectedDate;

                    int bugReportsCount = db.BugReport.Where(x => x.DateOfCreation >= startDate && x.DateOfCreation <= endDate).Count(); // БР
                    int testCaseCount = db.TestCase.Where(x => x.TestCaseCreationDate >= startDate && x.TestCaseCreationDate <= endDate).Count(); // все созданные 
                    int testCaseExecutedCount = db.TestCase.Where(x => x.TestCaseExecutionDate >= startDate && x.TestCaseExecutionDate <= endDate).Count();
                    //int testSuiteCount = db.TestSuite.Where(x => x.TestCaseCreationDate >= startDate && x.TestCaseCreationDate <= endDate).Count();
                    int checkListCount = db.CheckListItem.Where(x => x.DataOfExecution >= startDate && x.DataOfExecution <= endDate).Count();



                    // Формирование текста с использованием переменных
                    string content = $"За период с {startDate.ToShortDateString()} по {endDate.ToShortDateString()} было создано {bugReportsCount} баг-репортов";

                    // Добавление содержимого в документ
                    doc.Content.Text = content;

                    // Сохранение документа
                    string outputPath = "путь_к_сохранению_документа.docx";
                    doc.SaveAs2(outputPath);

                    // Открытие документа в Word
                    wordApp.Visible = true;
                    wordApp.Activate();
                    doc.Activate();
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                finally
                {
                    // Закрытие документа и высвобождение ресурсов
                    doc.Close();
                    wordApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    doc = null;
                    wordApp = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            else
                MessageBox.Show("Выберите дату начала и дату окончания");

            
        }

        private void GetReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdmitChosenProject_Click(object sender, RoutedEventArgs e)
        {
            if (ChooseProjectCombo.Text != "")
            {
                MessageBox.Show("Вы выбрали проект " + ChooseProjectCombo.Text);
                Project project = db.Project.FirstOrDefault(x => x.ProjectName == ChooseProjectCombo.Text);
                DateOfProjectCreation.Content = project.ProjectDateOfCreation.ToString();
                DateOfProjectEnd.Content = project.ProjectDateOfDeadLine.ToString();
                userContext.projectID = project.ProjectID;

                var documentation = db.ProjectDocumentation.FirstOrDefault(x => x.ProjectID == project.ProjectID);
                string attString = documentation != null ? documentation.ProjectDocumentationAttachment?.ToString() : string.Empty;

                List<string> attachmentNames = attString.Split(';').Select(System.IO.Path.GetFileName).ToList();
                AttachmentsListBox.ItemsSource = attachmentNames;
                if (AttachmentsListBox.Items.Count == 0)
                    AttachmentsListBox.Items.Add("Здесь пока ничего нет");

                IsMenuEnabled = true;
                MainPageClicked?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали, для начала выберите проект");
                IsMenuEnabled = false;
            }
        }
    }
}
