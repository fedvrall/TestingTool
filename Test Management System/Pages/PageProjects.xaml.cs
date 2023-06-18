using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
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
using System.Diagnostics;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProjects.xaml
    /// </summary>
    public partial class PageProjects : Page
    {
        public int projectID, companyId;
        Testing_ToolEntity db = new Testing_ToolEntity();

        private List<string> attachmentsList = new List<string>();
        List<string> attachmentNames;

        UserContext userContext { get; set; }
        public PageProjects(UserContext userContext)
        {
            this.userContext = userContext;
            this.companyId = userContext.companyID;
            InitializeComponent();
            GridProjects.ItemsSource = db.Project.Where(x=>x.CompanyID == companyId).ToList();
        }

        private void AddNewProject_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewProject(userContext, 0));
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewProject(userContext, projectID));
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
                    if (File.Exists(filePath))
                    {
                        Process.Start(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Файл не найден.", "Открытие файла", MessageBoxButton.OK);
                    }
                }
            }
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GridProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridProjects.SelectedItem != null)
            {
                projectID = ((Project)GridProjects.SelectedItem).ProjectID;

                AttachmentsListBox.ItemsSource = null;
                var documentation = db.ProjectDocumentation.FirstOrDefault(x => x.ProjectID == projectID);
                string attString = string.Empty;

                if (documentation != null && documentation.ProjectDocumentationAttachment != null)
                {
                    attString = documentation.ProjectDocumentationAttachment.ToString();
                    attachmentsList = attString.Split(';').ToList();
                    attachmentNames = attachmentsList.Select(System.IO.Path.GetFileName).ToList();
                    AttachmentsListBox.ItemsSource = attachmentNames;
                }                

                int custID = db.Project.Where(x => x.ProjectID == projectID).FirstOrDefault().CustomerID;
                var custInfo = db.Customer.Where(x => x.CustomerID == custID).FirstOrDefault();
                txtFirstName.Text = custInfo.CustomerFirstName;
                txtLastName.Text = custInfo.CustomerLastName;
                txtEmail.Text = custInfo.CustomerEmail;
                txtPhone.Text = custInfo.CustomerPhone;
                CustomerInfo3.Text = custInfo.CustomerNotes;
            }
            else
            {
                EditProject.IsEnabled = false;
            }
        }
    }
}
