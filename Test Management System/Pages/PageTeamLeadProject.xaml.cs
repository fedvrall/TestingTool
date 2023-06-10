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
        private int companyID, projectID;
        public PageTeamLeadProject(UserContext userContext)
        {
            this.userContext = userContext;
            InitializeComponent();
            companyID = userContext.companyID;

            GridProjects.ItemsSource = db.Project.Where(x => x.CompanyID == companyID).ToList();

            var names = db.Userinfo.Where(x=>x.CompanyID == companyID).Select(u => u.LastName + " " + u.FirstName).ToList();
/*            usersListBox.Items.Clear();
            usersListBox.ItemsSource = names;
            usersListBox.ItemTemplate = CreateCheckBoxItemTemplate();*/

            //DataTemplate CreateCheckBoxItemTemplate()
            //{
            //    string xaml = @"
            //    <DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
            //        <CheckBox Content=""{Binding}"">
            //            <CheckBox.Template>
            //                <ControlTemplate TargetType=""CheckBox"">
            //                    <CheckBox IsChecked=""{Binding Path=IsChecked, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"">
            //                        <CheckBox.Style>
            //                            <Style TargetType=""CheckBox"">
            //                                <EventSetter Event=""Checked"" Handler=""CheckBox_Checked"" />
            //                                <EventSetter Event=""Unchecked"" Handler=""CheckBox_Unchecked"" />
            //                            </Style>
            //                        </CheckBox.Style>
            //                    </CheckBox>
            //                </ControlTemplate>
            //            </CheckBox.Template>
            //        </CheckBox>
            //    </DataTemplate>";

            //    return (DataTemplate)XamlReader.Parse(xaml);
            //}
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GridProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridProjects.SelectedItem != null)
            {
                projectID = ((Project)GridProjects.SelectedItem).ProjectID;
                usersListBox1.IsEnabled = true;
                usersListBox2.IsEnabled = true;
                left.IsEnabled = true;
                Right.IsEnabled = true;

                AddUser.IsEnabled = true;
            }
            else
            {
                usersListBox1.IsEnabled = false;
                usersListBox2.IsEnabled = false;
                left.IsEnabled = false;
                Right.IsEnabled = false;
                AddUser.IsEnabled = false;
            }
        }
    }
}
