using ControlzEx.Standard;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using static Test_Management_System.Classes.UserContext;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNewBugReport.xaml
    /// </summary>
    public partial class PageNewBugReport : Page
    {
        private List<string> attachmentsList = new List<string>();
        public UserContext userContext { get; set; }
        private int BRID, projectID, userID, roleID;
        private bool isEditBR, creator, success;
        Testing_ToolEntity db = new Testing_ToolEntity();
        List<string> attachmentNames;

        public PageNewBugReport(UserContext userContext, int brID)
        {
            InitializeComponent();
            this.userContext = userContext;
            this.userID = userContext.userId;
            this.roleID = userContext.roleId;
            this.projectID = userContext.projectID;
            BRID = brID;
            if (BRID == 0)
            {
                isEditBR = false;
                Header.Content = "Добавление нового баг-репорта";
                creator = true;
            }
            else
            {
                Header.Content = "Редактирование баг-репорта";
                isEditBR = true;
                int userBR = db.BugReport.Where(x => x.BugReportID == BRID).FirstOrDefault().UserID;
                if (userBR == userID)
                    creator = true;
                else
                    creator = false;
                IsCreator();
                SaveAndAddOneMoreBR.IsEnabled = false;
            }
            ComboPriority.ItemsSource = db.BugPriority.ToList();
            ComboSeverity.ItemsSource = db.BugSeverity.ToList();
            ComboStatus.ItemsSource = db.BugReportStatus.ToList();
            var ts = db.TestSuite.Where(x => x.ProjectID == projectID).ToList();
            var tstc = ts.SelectMany(t => t.TestCase).ToList();
            ComboTC.ItemsSource = tstc;
        }

        private void IsCreator()
        {
            var br = db.BugReport.Where(x => x.BugReportID == BRID).FirstOrDefault();
            TBSummary.Text = br.BugReportSummary;
            TBEnvir.Text = br.BugEnvironment;
            TBSteps.Text = br.BugSteps;
            TBexpected.Text = br.BugExpectedResult;
            TBactual.Text = br.BugActualResult;
            TBprecond.Text = br.BugPreconditions;
            TBtestdata.Text = br.BugTestData;
            if(br.BugPriorityID != null)
                ComboPriority.SelectedIndex = (int)(br.BugPriorityID - 1);
            if (br.BugSeverityID != null)
                ComboSeverity.SelectedIndex = (int)(br.BugSeverityID - 1);
            if (br.BRStatusID != null)
                ComboStatus.SelectedIndex = (int)(br.BRStatusID - 1);
            DPCreation.DisplayDate = br.DateOfCreation;
            TBNotes.Text = br.BugReportRemark;
            TBComponent.Text = br.BugComponentOfSW;
            TBVersion.Text = br.BugVersionOfSW;
            if (br.TestCaseID != null)
                ComboTC.SelectedIndex = (int)(br.TestCaseID - 1);

            AttachmentsListBox.ItemsSource = null;
            var documentation = db.BugReport.FirstOrDefault(x => x.ProjectID == projectID);
            string attString = string.Empty;

            if (documentation != null && documentation.BugAttachment != null && documentation.BugAttachment != "")
            {
                attString = documentation.BugAttachment.ToString();
                attachmentsList = attString.Split(';').ToList();
                attachmentNames = attachmentsList.Select(System.IO.Path.GetFileName).ToList();
                AttachmentsListBox.ItemsSource = attachmentNames;
            }


            if (!creator)
            {
                TBSummary.IsEnabled = false;
                TBEnvir.IsEnabled = false;
                TBSteps.IsEnabled = false;
                TBexpected.IsEnabled = false;
                TBactual.IsEnabled = false;
                TBprecond.IsEnabled = false;
                TBtestdata.IsEnabled = false;
                AddAttachment.IsEnabled = false;
                AttachmentsListBox.IsEnabled = false;
                DPCreation.IsEnabled = false;
                TBComponent.IsEnabled = false;
                TBVersion.IsEnabled = false;
            }
        }

        private bool IsFieldsAreFilled()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(TBSummary.Text))
            {
                TBSummary.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }
            if (string.IsNullOrEmpty(TBEnvir.Text))
            {
                TBEnvir.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }
            if (string.IsNullOrEmpty(TBSteps.Text))
            {
                TBSteps.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }
            if (string.IsNullOrEmpty(TBexpected.Text))
            {
                TBexpected.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }
            if (string.IsNullOrEmpty(TBactual.Text))
            {
                TBactual.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }
            return isValid;
        }

        private void AddOrEditBR()
        {
            var attString = string.Join(";", attachmentsList);
            int? severity = null;
            if (ComboSeverity.SelectedIndex != -1)
                severity = ComboSeverity.SelectedIndex + 1;
            else severity = null;

            int? priority = null;
            if (ComboPriority.SelectedIndex != -1)
                priority = ComboPriority.SelectedIndex + 1;
            else priority = null;

            int? status = null;
            if (ComboStatus.SelectedIndex != -1)
                status = ComboStatus.SelectedIndex + 1;
            else status = null;

            int? TC = null;
            if (ComboTC.SelectedIndex != -1) 
                TC = ComboTC.SelectedIndex + 1;
            else TC = null;

            DateTime selectedDate = DPCreation.SelectedDate ?? DateTime.Now;


            if (IsFieldsAreFilled())
            {
                if(!isEditBR)
                {
                    BugReport bugReport = new BugReport()
                    {
                        BugReportSummary = TBSummary.Text,
                        BugEnvironment = TBEnvir.Text,
                        BugSteps = TBSteps.Text,
                        BugExpectedResult = TBexpected.Text,
                        BugActualResult = TBactual.Text,
                        BugPreconditions = TBprecond.Text,
                        BugTestData = TBtestdata.Text,
                        BugAttachment = attString,
                        BugSeverityID = severity,
                        BugPriorityID = priority,
                        BRStatusID = status,
                        ProjectID = projectID,
                        UserID = userID,
                        DateOfCreation = selectedDate,
                        BugReportRemark = TBNotes.Text,
                        BugComponentOfSW = TBComponent.Text,
                        BugVersionOfSW = TBVersion.Text,
                        TestCaseID = TC
                    };

                    try
                    {
                        db.BugReport.Add(bugReport);
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить баг-репорт");
                        success = false;
                    }
                    finally
                    {
                        MessageBox.Show("Баг-репорт добавлен");
                        success = true;
                    }
                }
                else // Редактирование
                {
                    SaveAndAddOneMoreBR.IsEnabled = false;
                    var findBR = db.BugReport.Find(BRID);
                    if(TBSummary.IsEnabled)
                        findBR.BugReportSummary = TBSummary.Text;

                    if (TBEnvir.IsEnabled)
                        findBR.BugEnvironment = TBEnvir.Text;
                    if (TBSteps.IsEnabled)
                        findBR.BugSteps = TBSteps.Text;

                    if(TBexpected.IsEnabled)
                        findBR.BugExpectedResult = TBexpected.Text;
                    if(TBactual.IsEnabled)
                        findBR.BugActualResult = TBactual.Text;
                    if(TBprecond.IsEnabled)
                        findBR.BugPreconditions = TBprecond.Text;
                    if(TBtestdata.IsEnabled)
                        findBR.BugTestData = TBtestdata.Text;
                    findBR.BugAttachment = attString;
                    findBR.BugSeverityID = severity;
                    findBR.BugPriorityID = priority;
                    findBR.BRStatusID = status;
                    findBR.ProjectID = findBR.ProjectID;
                    findBR.UserID = findBR.UserID;
                    findBR.DateOfCreation = findBR.DateOfCreation;
                    findBR.BugReportRemark = TBNotes.Text;
                    if(TBComponent.IsEnabled)
                        findBR.BugComponentOfSW = TBComponent.Text;
                    if(TBVersion.IsEnabled)
                        findBR.BugVersionOfSW = TBVersion.Text;
                    findBR.TestCaseID = TC;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось отредактировать баг-репорт");
                        success = false;
                    }
                    finally
                    {
                        MessageBox.Show("Баг-репорт отредактирован");
                        success = true;
                    }
                }
            }
            else
                MessageBox.Show("Заполните поля");
        }

        private void SaveBRAndExit_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditBR();
            if (success)
                NavigationService.Navigate(new PageBugReports(userContext));
            else return;
        }

        private void SaveAndAddOneMoreBR_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditBR();
            if (success)
                ClearFields();
            else return;
        }

        private void ClearFields()
        {
            TBSummary.Clear();
            TBEnvir.Clear();
            TBSteps.Clear();
            TBexpected.Clear();
            TBactual.Clear();
            TBprecond.Clear();
            TBtestdata.Clear();
            attachmentsList.Clear();
            AttachmentsListBox.Items.Clear();
            AttachmentsListBox.ItemsSource = attachmentsList;
            DPCreation.SelectedDate = null;
            ComboPriority.SelectedIndex = 0;
            ComboSeverity.SelectedIndex = 0;
            ComboStatus.SelectedIndex = 0;
            TBNotes.Clear();
            TBComponent.Clear();
            TBVersion.Clear();
            ComboTC.SelectedIndex = -1;
        }

        private void ExitWithoutSaveBR_Click(object sender, RoutedEventArgs e)
        {
            var dialog = MessageBox.Show("Вы действительно хотите выйти?", "Выйти?", MessageBoxButton.YesNo);
            if (dialog == MessageBoxResult.Yes)
                NavigationService.Navigate(new PageBugReports(userContext));
            else
                return;
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

        private void RemoveAttachment_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button removeButton = (System.Windows.Controls.Button)sender;
            string fileName = removeButton.DataContext as string;
            string filePath = attachmentsList.FirstOrDefault(path => System.IO.Path.GetFileName(path) == fileName);
            attachmentsList.Remove(filePath);
            attachmentNames.Remove(fileName);
            AttachmentsListBox.ItemsSource = null;
            AttachmentsListBox.ItemsSource = attachmentNames;
        }
    }
}
