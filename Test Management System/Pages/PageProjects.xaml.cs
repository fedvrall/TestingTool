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

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProjects.xaml
    /// </summary>
    public partial class PageProjects : Page
    {
        public int projectID;
        public PageProjects()
        {
            InitializeComponent();
            Testing_ToolEntity db = new Testing_ToolEntity();
            GridProjects.ItemsSource = db.Project.ToList();
        }

        private void AddNewProject_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewProject(0));
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNewProject(projectID));
        }

        private void GridProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridProjects.SelectedItem != null)
            {
                projectID = ((Project)GridProjects.SelectedItem).ProjectID;
                EditProject.IsEnabled = true;
            }
            else
            {
                EditProject.IsEnabled = false;
            }
        }
    }
}
