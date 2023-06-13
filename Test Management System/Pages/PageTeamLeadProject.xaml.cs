using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Management_System.Classes;
using Test_Management_System.Entities;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTeamLeadProject.xaml
    /// </summary>
    public partial class PageTeamLeadProject : Page
    {
        UserContext userContext {  get; set; }
        Testing_ToolEntity db = new Testing_ToolEntity();
        UserManager userPageManager = new UserManager();


        private int companyID, projectID;
        public PageTeamLeadProject(UserContext userContext)
        {
            this.userContext = userContext;
            InitializeComponent();
            companyID = userContext.companyID;

            GridProjects.ItemsSource = db.Project.Where(x => x.CompanyID == companyID).ToList();

            usersInProject.Items.Clear();
            usersNotInProject.Items.Clear();
        }

        private void DeleteFromProject_Click(object sender, RoutedEventArgs e)
        {
            string selectedUser = usersNotInProject.SelectedItem as string;
            if (selectedUser != null)
            {
                userPageManager.AddUserToProject(selectedUser);
            }
        }

        private void AddToProject_Click(object sender, RoutedEventArgs e)
        {
            string selectedUser = usersInProject.SelectedItem as string;
            if (selectedUser != null)
            {
                userPageManager.RemoveUserFromProject(selectedUser);
            }
        }

        private void GridProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridProjects.SelectedItem != null)
            {
                projectID = ((Project)GridProjects.SelectedItem).ProjectID;
                usersInProject.IsEnabled = true;
                usersNotInProject.IsEnabled = true;
                AddToProject.IsEnabled = true;
                DeleteFromProject.IsEnabled = true;

                userPageManager.LoadUsersInProject(projectID);
                userPageManager.LoadUsersNotInProject(projectID);

                usersInProject.ItemsSource = userPageManager.GetUsersInProject();
                usersNotInProject.ItemsSource = userPageManager.GetUsersNotInProject();
            }
            else
            {
                usersInProject.IsEnabled = false;
                usersNotInProject.IsEnabled = false;
                AddToProject.IsEnabled = false;
                DeleteFromProject.IsEnabled = false;
            }
        }
    }
}
