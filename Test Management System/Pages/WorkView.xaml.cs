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
using Test_Management_System.Pages;
using MahApps.Metro.Controls;
using System.IO.Packaging;
using Test_Management_System.Entities;
using Test_Management_System.Themes;

namespace Test_Management_System
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WorkView : Window
    {
        public UserContext userContext { get; set; }
        Testing_ToolEntity db = new Testing_ToolEntity();
        public App CurrentApplication { get; set; }
        string username;
        int projectID;

        public WorkView(UserContext userContext)
        {
            this.userContext = userContext;
            int userID = userContext.userId;
            this.username = userContext.userName;
            int roleID = userContext.roleId;
            this.projectID = userContext.projectID;
            InitializeComponent();
            FrameContent.Navigate(new PageMain(userContext));
            /*            CreateDB_MSSql createnewdb = new CreateDB_MSSql();
                        createnewdb.CreateOnlyDB();
                        createnewdb.CreateReferenceTablesInDB();
                        createnewdb.CreateMainTablesInDB();
                        createnewdb.FillReferenceTablesInDB();*/
            if (roleID == 1)
            {
                AdminSetting.Visibility = Visibility.Visible;
                ProjectAdmin.Visibility = Visibility.Visible;
            }
            if(roleID == 2)
            {
                ProjectTeamLead.Visibility = Visibility.Visible;
            }

            FrameContent.Navigated += FrameContent_Navigated;
            User.Content = username;
        }

        private void FrameContent_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is PageMain mainPage)
            {
                mainPage.MainPageClicked += MainPage_MainPageClicked;
            }
        }

        private void MainPage_MainPageClicked(object sender, EventArgs e)
        {
            
            MainMenu.IsEnabled = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            switch (menuItem.Header)
            {
                case "Главная":
                    FrameContent.Navigate(new PageMain(userContext));
                    break;
                case "Баг-репорты":
                    FrameContent.Navigate(new PageBugReports(userContext));
                    break;
                case "Чек-листы":
                    FrameContent.Navigate(new PageCheckLists(userContext));
                    break;
                case "Тест-сьюты":
                    FrameContent.Navigate(new PageTestSuites(userContext));
                    break;
                case "Управление проектами":
                    FrameContent.Navigate(new PageProjects(userContext));
                    break;
                case "Проекты":
                    FrameContent.Navigate(new PageTeamLeadProject(userContext));
                    break;
                case "Пользователи":
                    FrameContent.Navigate(new PageEditUsers(userContext));
                    break;
                    /*                case "Введение в тестовую документацию":
                    FrameContent.Navigate(new PageManual());
                    break;*/

                default:
                    break;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ThemeController.SetTheme(ThemeController.ThemeTypes.Dark);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ThemeController.SetTheme(ThemeController.ThemeTypes.Light);
        }

        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите сменить пользователя?", "Сменить пользователя?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Auth auth = new Auth();
                auth.Show();
                this.Close();
            }
            else
                return;
        }
    }
}
