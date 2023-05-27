using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
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
using Test_Management_System.Entities;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCheckLists.xaml
    /// </summary>
    public partial class PageCheckLists : Page
    {
        public PageCheckLists()
        {
            InitializeComponent();
            Testing_ToolEntities db = new Testing_ToolEntities();
            CheckListGrid.ItemsSource = db.CheckList.ToList();

        }
    }
}
