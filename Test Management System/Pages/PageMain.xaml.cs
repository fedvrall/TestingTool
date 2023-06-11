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
using Test_Management_System.Classes;
using Test_Management_System.Entities;
using Test_Management_System.Pages;

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


        private void AdmitChosenProject_Click(object sender, RoutedEventArgs e)
        {
            if (ChooseProjectCombo.Text != "")
            {
                MessageBox.Show("Вы выбрали проект " + ChooseProjectCombo.Text);
                Project project = db.Project.FirstOrDefault(x => x.ProjectName == ChooseProjectCombo.Text);
                DateOfProjectCreation.Content = project.ProjectDateOfCreation.ToString();
                DateOfProjectEnd.Content = project.ProjectDateOfDeadLine.ToString();
                userContext.projectID = project.ProjectID;

                //string attString = db.Project.Where(x => x.ProjectID == projectID).FirstOrDefault().ProjectDocumentation.FirstOrDefault().ProjectDocumentationAttachment.ToString();
                //List<string> attachmentNames = attString.Split(';').Select(Path.GetFileName).ToList();

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
