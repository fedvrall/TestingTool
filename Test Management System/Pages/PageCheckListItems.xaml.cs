using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Management_System.Classes;
using Test_Management_System.Entities;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCheckListItems.xaml
    /// </summary>
    public partial class PageCheckListItems : Page
    {
        UserContext UserContext { get; set; }
        Testing_ToolEntity db = new Testing_ToolEntity();
        private int checklistID;
        private List<string> attachmentsList = new List<string>();
        private CheckListManager checklistManager;

        private ObservableCollection<CheckListItem> checklistItems = new ObservableCollection<CheckListItem>();

        public PageCheckListItems( UserContext userContext, int checklistID)
        {
            this.checklistID = checklistID;
            this.UserContext = userContext;
            InitializeComponent();

            checklistManager = new CheckListManager(checklistID);

            checklistManager.LoadExistingChecklistItems();
            
            CLListView.Items.Clear();
            CLListView.ItemsSource = checklistManager.AllChecklistItems;

            ComboBoxPriority.ItemsSource = db.CheckListPriority.ToList();
            ComboBoxStatus.ItemsSource = db.CheckListStatus.ToList();
        }

        private void AddAttachmentToCheckList_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                attachmentsList.Add(filePath);
                AttachmentsListBox.Items.Add(fileName);
            }
        }

        private void AddItemToCheckListAndExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddItemToCheckListGoToAnother_Click(object sender, RoutedEventArgs e)
        {
            SaveAdding();
        }

        private void ExitFromAddingCheckListItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveAdding()
        {
            CheckListItem listItem = new CheckListItem();
            try
            {
                foreach (CheckListItem item in checklistItems)
                {
                    db.CheckListItem.Add(item);
                }
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Все элементы чек-листа были добавлены");
            }
            finally
            {
                MessageBox.Show("Не удалось добавить пункты");

            }

        }

        private void AddChecklistItem_Click(object sender, RoutedEventArgs e)
        {
            var attString = string.Join(";", attachmentsList);
            DateTime exec;
            //if() тут разобраться с датой
            // возможно, её убрать? Или дату добавить в сам чек-лист
            // Но первоначальная идея - сделать нулль, если статус другой, кроме "Не пройден"
            // Меняется статус - меняется дата
            //


            CheckListItem newItem = new CheckListItem
            {
                CheckListItemDescription = TextBoxDescription.Text,
                CLStatusID = ComboBoxStatus.SelectedIndex + 1,
                CLPriorityID = ComboBoxPriority.SelectedIndex + 1, // Проработать, чтобы
                CLComment = TextBoxComment.Text,
                CheckListID = checklistID,
                UserID = UserContext.userId,
                DataOfExecution = DateTime.Now, // Заменить
                CLAttachment = attString
            };

            checklistManager.AddNewChecklistItem(newItem);

            TextBoxDescription.Text = string.Empty;
            ComboBoxStatus.SelectedItem = null;
            ComboBoxPriority.SelectedItem = null;
            TextBoxComment.Text = string.Empty;
            attachmentsList.Clear();
        }

        private void RemoveAttachment_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button removeButton = (System.Windows.Controls.Button)sender;
            string fileName = removeButton.DataContext as string;
            string filePath = attachmentsList.FirstOrDefault(path => System.IO.Path.GetFileName(path) == fileName);
            attachmentsList.Remove(filePath);
            AttachmentsListBox.Items.Remove(fileName);
        }

        private void DeleteCheckListItem(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button deleteButton = (System.Windows.Controls.Button)sender;
            CheckListItem selItem = (CheckListItem)deleteButton.Tag;

            var result = MessageBox.Show("Вы действительно хотите удалить этот элемент?", "Удалить?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (selItem != null)
                    {
                        checklistManager.DeleteChecklistItem(selItem);
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось удалить пункт");
                }
                finally
                {
                    MessageBox.Show("Пункт успешно удалён");
                }
            }
            else
                return;

        }
    }
}
