using ControlzEx.Standard;
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
    /// Логика взаимодействия для PageExecuteCheckList.xaml
    /// </summary>
    public partial class PageExecuteCheckList : Page
    {           
        public ObservableCollection<string> Priorities { get; set; } // Создаем коллекцию приоритетов

        public Testing_ToolEntity db = new Testing_ToolEntity();
        UserContext userContext {  get; set; }
        private int checklistID;
        public PageExecuteCheckList(UserContext userContext, int checklistid)
        {
            this.userContext = userContext;
            this.checklistID = checklistid;
            InitializeComponent();
            CheckListManager clm = new CheckListManager(checklistID);
            clm.LoadExistingChecklistItems(); 
            

            ObservableCollection<CheckListStatus> Statuses = new ObservableCollection<CheckListStatus>();
            Statuses.Clear();
            var getStatuses = db.CheckListStatus;

            foreach (var status in getStatuses)
            {
                Statuses.Add(status);
            }
            LISTBOX.Items.Clear();

            LISTBOX.DataContext = clm.AllChecklistItems;
            LISTBOX.ItemsSource = clm.AllChecklistItems.ToList();


        }

        public class MyViewModel
        {
            public ObservableCollection<CheckListItem> CheckListItems { get; set; }
            public ObservableCollection<CheckListStatus> Statuses { get; set; }
            public ObservableCollection<CheckListPriority> Priorities { get; set; }

            public MyViewModel()
            {
                // Инициализация коллекций и загрузка данных
                CheckListItems = new ObservableCollection<CheckListItem>();
                Statuses = new ObservableCollection<CheckListStatus>();
                Priorities = new ObservableCollection<CheckListPriority>();

                LoadData(); // Метод загрузки данных из базы данных или другого источника
            }

            private void LoadData()
            {
                //Statuses = db.CheckListStatus.ToList();
                // Здесь загрузите данные из базы данных или другого источника и заполните коллекции
                // CheckListItems, Statuses и Priorities
            }
        }

        private void DeleteCheckListItem(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
