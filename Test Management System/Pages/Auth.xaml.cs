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
using System.Windows.Shapes;
using Test_Management_System.Classes;
using Test_Management_System.Entities;
using Test_Management_System.Pages;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string pass = "";
            if(PasswordBox.Visibility == Visibility.Visible)
                pass = PasswordBox.Password;
            if (TBPass.Visibility == Visibility.Visible)
                pass = TBPass.Text;

            using (Testing_ToolEntity db = new Testing_ToolEntity())
            {
                var user = db.Userinfo.FirstOrDefault(x => x.Login == login && x.Password == pass);
                if (user != null)
                {
                    UserContext userContext = new UserContext
                    {
                        userId = user.UserID,
                        roleId = user.RoleID,
                        userName = user.LastName + " " + user.FirstName,
                        companyID = user.CompanyID                        
                    };
                    MessageBox.Show("Вы вошли как " + userContext.userName);
                    WorkView mainWindow = new WorkView(userContext);
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void ShowPasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TBPass.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Collapsed;
            TBPass.Text = PasswordBox.Password;
        }

        private void ShowPasswordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Visible;
            TBPass.Visibility = Visibility.Collapsed;
            PasswordBox.Password = TBPass.Text;
        }
    }
}
