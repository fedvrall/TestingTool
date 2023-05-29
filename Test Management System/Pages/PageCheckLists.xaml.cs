using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Management_System.Classes;
using Test_Management_System.Entities;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCheckLists.xaml
    /// </summary>
    public partial class PageCheckLists : Page
    {
        UserContext userContext {  get; set; }
        Testing_ToolEntity db = new Testing_ToolEntity();
        private int projectID, userID;
        public PageCheckLists(UserContext userContext)
        {
            this.userContext = userContext;
            this.projectID = userContext.projectID;
            this.userID = userContext.userId;
            InitializeComponent();
            Testing_ToolEntity db = new Testing_ToolEntity();
            CheckListGrid.ItemsSource = db.CheckList.Where(x => x.ProjectID == projectID).ToList();
        }

        private void WatchCheckList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCheckList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteCheckList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewCheckList_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new PageNewCheckList(userContext));

            FormContainer.Visibility = Visibility.Visible;
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 300;
            animation.Duration = TimeSpan.FromSeconds(0.3);
            FormContainer.BeginAnimation(Border.WidthProperty, animation);
            //ChoseTCFields.Content = "Просмотреть поля";
        }

        private void CloseAdding_Click(object sender, RoutedEventArgs e)
        {
            FormContainer.Visibility = Visibility.Collapsed;
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 300;
            animation.To = 0;
            animation.Duration = TimeSpan.FromSeconds(0.3);
            FormContainer.BeginAnimation(Border.WidthProperty, animation);
        }

        private void AddCheckList_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TBNameCheckList.Text) || String.IsNullOrEmpty(TBDescrCheckList.Text))
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                CheckList checkList = new CheckList()
                {
                    CLSummary = TBNameCheckList.Text,
                    CLDescription = TBDescrCheckList.Text,
                    ProjectID = projectID,
                    UserID = userID
                };

                try
                {
                    db.CheckList.Add(checkList);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Не получилось добавить чек-лист");
                }
                finally
                {
                    MessageBox.Show("Чек-лист добавлен");
                }
            }
        }
    }
}
