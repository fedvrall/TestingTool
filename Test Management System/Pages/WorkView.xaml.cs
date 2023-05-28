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

namespace Test_Management_System
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WorkView : Window
    {
        public UserContext userContext { get; set; }

        public WorkView(UserContext userContext)
        {
            this.userContext = userContext;
            int userID = userContext.userId;
            string username = userContext.userName;
            int roleID = userContext.roleId;
            int projectID = userContext.projectID;
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
            }
/*            if (userContext.isProjectSelected)
                MainMenu.IsEnabled = true;
            else 
                MainMenu.IsEnabled = false;*/
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            switch (menuItem.Header)
            {
                case "Главная":
                    FrameContent.Navigate(new PageMain(userContext));
                    break;
                case "Проекты":
                    FrameContent.Navigate(new PageProjects());
                    break;
                case "Все баг-репорты":
                    FrameContent.Navigate(new PageBugReports());
                    break;
                case "Новый баг-репорт":
                    FrameContent.Navigate(new PageNewBugReport(userContext));
                    break;
                case "Чек-листы":
                    FrameContent.Navigate(new PageCheckLists());
                    break;
                case "Тест-сьюты":
                    FrameContent.Navigate(new PageTestSuites(userContext));
                    break;
                //case "Тест-кейсы":
                //    FrameContent.Navigate(new PageTestCases(userContext, 0));
                //    break;
                case "Пользователи":
                    FrameContent.Navigate(new PageEditUsers(userContext));
                    break;
                default:
                    break;
            }
        }
    }
}
