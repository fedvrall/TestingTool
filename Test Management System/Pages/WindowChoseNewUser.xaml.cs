using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Test_Management_System.Entities;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowChoseNewUser.xaml
    /// </summary>
    public partial class WindowChoseNewUser : Window
    {
        Testing_ToolEntity db = new Testing_ToolEntity();
        public Userinfo SelectedUser { get; private set; }
        public WindowChoseNewUser()
        {
            InitializeComponent();

            var users = db.Userinfo.Select(x => x.LastName + " " + x.FirstName).ToList();
            userComboBox.ItemsSource = users;

            okButton.Click += (sender, e) =>
            {
                //int selectedIndex = userComboBox.SelectedIndex;

                //if (selectedIndex >= 0 && selectedIndex < userComboBox.Items.Count)
                //{
                //    Userinfo selectedUser = userComboBox.Items[selectedIndex] as Userinfo;

                //    if (selectedUser != null)
                //    {
                //        int userId = selectedUser.UserID;
                //        // Дальнейшая обработка с использованием userId
                //        DialogResult = true;
                //    }
                //}


                //if (userComboBox.SelectedItem is Userinfo selectedUser)
                //{
                //    SelectedUser = selectedUser;
                //    DialogResult = true;
                //}

                string selectedUserString = userComboBox.SelectedItem as string;
                if (selectedUserString != null)
                {
                    SelectedUser = db.Userinfo.FirstOrDefault(x => (x.LastName + " " + x.FirstName) == selectedUserString);
                    DialogResult = true;
                }




                //SelectedUser = (Userinfo)userComboBox.SelectedItem;
                ////SelectedUser = userComboBox.SelectedItem as Userinfo;
                //DialogResult = true;
            };
        }
    }
}
