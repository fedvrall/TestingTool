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

            //List<string> attachmentNames = attachmentsList.Select(Path.GetFileName).ToList();

        }

        private void AddNewProject_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewProject(userContext, 0));
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewProject(userContext, projectID));
        }

        private void GridProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridProjects.SelectedItem != null)
            {
                projectID = ((Project)GridProjects.SelectedItem).ProjectID;
                var documentation = db.ProjectDocumentation.FirstOrDefault(x => x.ProjectID == projectID);
                string attString = documentation != null ? documentation.ProjectDocumentationAttachment?.ToString() : string.Empty;

                //string attString = db.ProjectDocumentation.Where(x => x.ProjectID == projectID).FirstOrDefault().ProjectDocumentationAttachment.ToString();
                List<string> attachmentNames = attString.Split(';').Select(System.IO.Path.GetFileName).ToList();
                EditProject.IsEnabled = true;
                AttachmentsListBox.ItemsSource = attachmentNames;
                if (AttachmentsListBox.Items.Count == 0)
                    AttachmentsListBox.Items.Add("Здесь пока ничего нет");                    

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
