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
        private int projectID, userID, checklistID;
        private bool isEdit;

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

            NavigationService.Navigate(new PageCheckListItems(userContext, checklistID));
        }

        private void EditCheckList_Click(object sender, RoutedEventArgs e)
        {
            getBorder();
            isEdit = true;
            var cl = db.CheckList.FirstOrDefault(x => x.CheckListID == checklistID);
            TBNameCheckList.Text = cl.CLSummary;
            TBDescrCheckList.Text = cl.CLDescription;
            SaveChanges.Visibility = Visibility.Visible;
            AddCheckList.Visibility = Visibility.Collapsed;
        }

        private void DeleteCheckList_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить чек-лист и все пункты в нём?", "Удаление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var cl = db.CheckList.FirstOrDefault(x => x.CheckListID == checklistID);
                var delCKItem = db.CheckListItem.Where(x => x.CheckListID == checklistID);
                try
                {
                    db.CheckListItem.RemoveRange(delCKItem);
                    db.CheckList.Remove(cl);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Не удалось удалить чек-лист");
                }
                finally
                {
                    MessageBox.Show("Чек-лист удалён");
                }
            }
            else return;
        }

        private void getBorder()
        {
            FormContainer.Visibility = Visibility.Visible;
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 300;
            animation.Duration = TimeSpan.FromSeconds(0.3);
            FormContainer.BeginAnimation(Border.WidthProperty, animation);
        }

        private void AddNewCheckList_Click(object sender, RoutedEventArgs e)
        {
            getBorder();
        }

        private void CheckListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checklistID = ((CheckList)CheckListGrid.SelectedItem).CheckListID;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var findCL = db.CheckList.Find(checklistID);

                findCL.CheckListID = checklistID;
                findCL.CLSummary = TBNameCheckList.Text;
                findCL.CLDescription = TBDescrCheckList.Text;
                findCL.ProjectID = projectID;
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Не удалось отредактировать чек-лист");
            }
            finally
            {
                MessageBox.Show("Чек-лист отредактирован");
                CloseBorder();
            }
        }

        private void CloseBorder()
        {
            FormContainer.Visibility = Visibility.Collapsed;
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 300;
            animation.To = 0;
            animation.Duration = TimeSpan.FromSeconds(0.3);
            FormContainer.BeginAnimation(Border.WidthProperty, animation);
        }

        private void CloseAdding_Click(object sender, RoutedEventArgs e)
        {
            CloseBorder();
        }

        private void AddCheckList_Click(object sender, RoutedEventArgs e)
        {
            isEdit = false;
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
                    CheckListGrid.ItemsSource = db.CheckList.Where(x => x.ProjectID == projectID).ToList();
                    CloseBorder();
                }
                TBNameCheckList.Clear();
                TBDescrCheckList.Clear();
            }
        }
    }
}
