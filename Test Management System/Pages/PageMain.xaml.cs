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

        Testing_ToolEntities db = new Testing_ToolEntities();
        
        public PageMain(UserContext userContext)
        {
            this.userContext = userContext;
            InitializeComponent();
            ChooseProjectCombo.Items.Clear();
            List<Project> projects = db.Project.ToList();
            ChooseProjectCombo.ItemsSource = projects;
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
                WorkView main = new WorkView(userContext);
                userContext.isProjectSelected = true;
                GenerateID generateID = new GenerateID(userContext);
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали, для начала выберите проект");
                userContext.projectID = null;
                userContext.isProjectSelected = false;

            }


        }
    }
}
